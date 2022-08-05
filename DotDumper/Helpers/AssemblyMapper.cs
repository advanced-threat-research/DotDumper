using System;
using System.Collections.Generic;
using System.Reflection;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class is used to map a (line of a) stack trace to an assembly object
    /// </summary>
    class AssemblyMapper
    {
        /// <summary>
        /// Gets the function's signature as a string, formatted as "Full.Class.Path.With.Function(ArgumentType argumentName)". An example is "System.Reflection.Assembly.Load(Byte[] rawAssembly)".
        /// </summary>
        /// <returns>The hook's full name as a string, i.e. "System.Reflection.Assembly.Load(Byte[] rawAssembly)"</returns>
        private static string GetMethod(MethodInfo method)
        {
            string output = method.DeclaringType + "." + method.Name + "(";
            foreach (ParameterInfo parameterInfo in method.GetParameters())
            {
                output += parameterInfo.ParameterType.Name + " " + parameterInfo.Name + ", ";
            }
            if (method.GetParameters().Length > 0)
            {
                output = output.Substring(0, output.Length - 2);
            }
            output += ")";

            return output;
        }

        /// <summary>
        /// Creates the mapping as a dictionary where the keys equal a function signature as a string, and an assembly object as the value
        /// </summary>
        /// <returns>The mapping to use when matching a (line of a) stack trace</returns>
        public static Dictionary<string, Assembly> CreateMapping()
        {
            HookManager.UnHookAll();
            Dictionary<string, Assembly> mapping = new Dictionary<string, Assembly>();
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                //Omit framework related objects, as well as DotDumper itself
                if (assembly.GlobalAssemblyCache ||
                    assembly.GetName().FullName.ToLowerInvariant().Contains("dotdumper"))
                {
                    continue;
                }
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    //Gets all declared (omitting inherited functions to avoid duplicates) public, non-public, normal, and static functions
                    MethodInfo[] methodInfos = type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
                    foreach (MethodInfo methodInfo in methodInfos)
                    {
                        if (methodInfo.DeclaringType.Assembly == assembly)
                        {
                            string functionSignature = GetMethod(methodInfo);
                            if (mapping.ContainsKey(functionSignature) == false)
                            {
                                mapping.Add(functionSignature, assembly);
                            }

                        }
                    }
                }
            }
            HookManager.HookAll();
            return mapping;
        }

        /// <summary>
        /// Get the assembly object where the referenced function of the stack trace line resides. If it is not found, null is returned!
        /// </summary>
        /// <param name="stackTraceLine">The raw stack trace line to match</param>
        /// <returns>The assembly object if it can be found, null if it cannot be found</returns>
        public static Assembly ProcessStackTraceLine(string stackTraceLine)
        {
            //Create the mapping, ensuring it is as up to date as possible
            Dictionary<string, Assembly> mapping = CreateMapping();
            //Remove leading and trailing whitespace
            stackTraceLine = stackTraceLine.Trim();
            //Skip "at " from the line in the beginning
            stackTraceLine = stackTraceLine.Substring(3);
            //Declare the corresponding Assembly object
            Assembly assembly = null;
            //Get the Assembly object from the mapping, which returns null if it is not present
            mapping.TryGetValue(stackTraceLine, out assembly);
            //Return the Assembly object (or null, if it couldn't be found)
            return assembly;
        }

        /// <summary>
        /// Process a list of stack traces to get a list of assembly objects (concatenated as a string in their simple form) that are used, in the same order, excluding duplicates. A duplicate is when two stack trace lines originate from the same assembly object.
        /// </summary>
        /// <param name="stackTraceLines">The stack trace lines to use</param>
        /// <returns>A string representation of the linked assembly objects, excluding duplicates, in the same order as the given list</returns>
        public static string ProcessStackTraceOld(List<string> stackTraceLines)
        {
            string output = "";

            string currentItem = "";
            string lastItem = "";

            foreach (string stackTraceLine in stackTraceLines)
            {
                Assembly assembly = ProcessStackTraceLine(stackTraceLine);
                if (assembly != null)
                {
                    currentItem = assembly.FullName;
                }
                else
                {
                    currentItem = "[DotDumper or DotNet Framework related assembly]";
                }


                if (currentItem.Equals(lastItem, StringComparison.InvariantCultureIgnoreCase) == false)
                {
                    output += currentItem + "\n";
                    lastItem = currentItem;
                }
            }
            return output;
        }

        /// <summary>
        /// Process a list of stack traces to get a list of assembly objects (concatenated as a string in their simple form) that are used, in the same order, excluding duplicates. A duplicate is when two stack trace lines originate from the same assembly object.
        /// </summary>
        /// <param name="stackTraceLines">The stack trace lines to use</param>
        /// <returns>A string representation of the linked assembly objects, excluding duplicates, in the same order as the given list</returns>
        public static Tuple<Assembly, List<AssemblyObject>> ProcessStackTrace(List<string> stackTraceLines)
        {
            List<AssemblyObject> assemblyObjects = new List<AssemblyObject>();
            Assembly originatingAssembly = null;
            foreach (string stackTraceLine in stackTraceLines)
            {
                Assembly assembly = ProcessStackTraceLine(stackTraceLine);
                //Default values, if the assembly is part of the GAC or if it refers to DotDumper
                string name = "[DotDumper or DotNet Framework related assembly]";
                string hash = "[none]";

                //If the response from the function is not null, an object matches
                if (assembly != null)
                {
                    //Set the hash and the name for the given assembly object
                    hash = Hashes.Sha256(GenericHookHelper.GetAsByteArray(assembly));
                    name = assembly.GetName().Name;
                    //Set the originating assembly as the first non-GAC non-DotDumper assembly
                    if (originatingAssembly == null)
                    {
                        originatingAssembly = assembly;
                    }
                }

                //Check if this object is not the same as the last in the list
                if (assemblyObjects.Count == 0)
                {
                    AssemblyObject assemblyObject = new AssemblyObject(hash, name);
                    assemblyObjects.Add(assemblyObject);
                }
                else
                {
                    if (assemblyObjects[assemblyObjects.Count - 1].Hash.Equals(hash, StringComparison.InvariantCultureIgnoreCase) == false)
                    {
                        AssemblyObject assemblyObject = new AssemblyObject(hash, name);
                        assemblyObjects.Add(assemblyObject);
                    }
                }


            }
            return Tuple.Create(originatingAssembly, assemblyObjects);
        }

        /// <summary>
        /// Checks if a the most recent call of a given list of strack trace lines is coming from a stage of a sample, or from DotDumper, or a GAC module
        /// </summary>
        /// <param name="stackTraceLines">The stack trace to use</param>
        /// <returns>True if the most recent call is coming from a sample stage, false if it is coming from DotDumper, or a GAC module</returns>
        public static bool IsComingFromSample(List<string> stackTraceLines)
        {
            //Get the last call from the trace, as this is the origin of the hook location
            //Use the last call from the trace to check if it matches any key in the mapping
            Assembly assembly = ProcessStackTraceLine(stackTraceLines[0]);
            if (assembly == null)
            {
                //Null means it didn't match a binary, since it is part of the framework's core, or DotDumper internally
                return false;
            }
            {
                //Not null means it matched with one of the binaries
                return true;
            }
        }
    }
}
