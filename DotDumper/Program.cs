using System;
using System.Reflection;
using DotDumper.Hooks;
using DotDumper.HookHandlers;
using System.Collections.Generic;
using DotDumper.Helpers;
using DotDumper.Models;
using System.Threading;
using DotDumper.Pipes;

namespace DotDumper
{
    class Program
    {
        /// <summary>
        /// The version information of DotDumper
        /// </summary>
        public static readonly string VERSION = "DotDumper 1.1-stable by Max 'Libra' Kersten (@Libranalysis)\n";

        /// <summary>
        /// A boolean which is to be changed within the source code. The sole purpose is to load the CLI arguments differently (or rather, load them from hardcoded values when debugging), to easily change them without breaking the argument parsing method
        /// </summary>
        public static readonly bool DEBUG = false;

        static void Main(string[] args)
        {
            if (DEBUG)
            {
                //Provide arguments to parse when debugging in Visual Studio
            }
            else
            {
                //Parses the given arguments
                ArgumentHandler.ParseArguments(args);
            }

            //Creates the logger object
            GenericHookHelper._Logger = new Logger();

            //Initialises the named pipe manager which handles the named pipe communication
            PipeManager.Initialise();

            //Creates and starts the delayed timer to handle stagnations during the execution
            Timer Timer = new Timer(StagnationHandler.TimerCallback, null, 0, (20 * 1000));

            //Initialises all hooks
            HookManager.Initialise();

            //LoadFile also sets the location of the entry assembly to the malware sample's location, unlike the Load(byte[] rawAssembly) function
            Assembly assembly = Assembly.LoadFile(Config.SamplePath);

            //Sets the original assembly, which is used by some hooks
            GenericHookHelper.OriginalAssembly = assembly;

            //Set all hooks, before moving on to the execution of the sample
            HookManager.HookAll();

            try
            {
                //Check if the entry point should be overridden
                if (Config.OverrideEntryPoint == false)
                {
                    //If this is not the case, a verification is in place to ensure that the given binary has a defined entry point
                    if (assembly.EntryPoint == null)
                    {
                        throw new Exception("No default entry point found in the given binary!");
                    }

                    //If no arguments are provided, the entry point is called without arguments
                    if (Config.DllArguments == null)
                    {
                        //Check if arguments are required (for string[] args in main, for example)
                        int argLength = assembly.EntryPoint.GetParameters().Length;
                        if (argLength != 0)
                        {
                            //If this is the case, empty strings arrays are provided as filler
                            object[] arguments = new object[argLength];
                            for (int i = 0; i < argLength; i++)
                            {
                                arguments[i] = new string[0];
                            }
                            assembly.EntryPoint.Invoke(null, arguments);
                        }
                        else //If this is not the case, no argument is given at all
                        {
                            assembly.EntryPoint.Invoke(null, null);
                        }
                    }
                    else //Since user-provided arguments are present, they will be passed on
                    {
                        assembly.EntryPoint.Invoke(null, Config.DllArguments);
                    }
                }
                else //Entry point is overridden
                {
                    //Get the type object from the given assembly
                    Type type = assembly.GetType(Config.DllFullyQualifiedClassName);
                    //If the object cannot be found, null is returned
                    if (type == null)
                    {
                        throw new Exception("No class found in the given sample for \"" + Config.DllFullyQualifiedClassName + "\"!");
                    }

                    //Create a list of types (in order) that should match the public function's argument types (and order)
                    List<string> parameterTypes = new List<string>();
                    if (Config.DllArguments != null)
                    {
                        foreach (object o in Config.DllArguments)
                        {
                            parameterTypes.Add(o.GetType().Name);
                        }
                    }

                    //Get the method info object
                    MethodInfo methodInfo = HookManager.GetMethodInfo(type, Config.DllFunctionName, parameterTypes);
                    //If no such method can be found, null is returned
                    if (methodInfo == null)
                    {
                        throw new Exception("No method found in the given class with the name \"" + Config.DllFunctionName + "\"!");
                    }

                    //Null when invoking a static method
                    object target = null;
                    //If it is not static, an instance needs to be created
                    if (methodInfo.IsStatic == false)
                    {
                        //Create an instance if the method is not static
                        target = Activator.CreateInstance(type);
                    }
                    //Call the function
                    type.InvokeMember(Config.DllFunctionName, BindingFlags.InvokeMethod, null, target, Config.DllArguments);
                }
            }
            catch (Exception ex) //Catch any exception that is thrown
            {
                HookManager.UnHookAll();
                //Log the message via the logger, dumping missing binaries as well
                LogEntry entry = LogEntryHelper.Create(0, ex);
                GenericHookHelper._Logger.Log(entry, false, true);
            }
            //Remove all hooks, as the sample's execution has finished (or migrated to a different process)
            HookManager.UnHookAll();
            //Sets the time to a future time to force the sandbo to time out
            StagnationHandler.SetTime();
        }
    }
}
