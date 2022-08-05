using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DotDumper.HookHandlers;
using DotDumper.Models;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class is used to save and handle arguments from functions
    /// </summary>
    class ArgumentHelper
    {
        /// <summary>
        /// Verifies if a given hash object occurs in the given list of hashes. Existance of the same hash is based on the included SHA-256 hash in the hash object, regardless of the casing. As such, two different objects based on the same file will be seen as duplicates in the same way as the same object will be seen as a duplicate when it is provided as an argument whilst also being in the list.
        /// </summary>
        /// <param name="hashes">The list of hashes, which will be used to check if the given hash is present in this list</param>
        /// <param name="hash">The hash to check if it is present in the given list</param>
        /// <returns>True if the list contains the hash, false if not</returns>
        public static bool ContainsHash(List<Hash> hashes, Hash hash)
        {
            //Iterate over all given hashes
            foreach (Hash currentHash in hashes)
            {
                //If the currently iterated hash equals the given hash, regardless of the casing
                if (currentHash.Sha256.Equals(hash.Sha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    //Return true
                    return true;
                }
            }
            //If no matches were found while the iteration completed, return false
            return false;
        }

        /// <summary>
        /// This function saves the value of the given object. The way it is saved depends on the type and the size of the given object. Anything larger than 100 bytes is written to disk. Values are represented in textual form when possible, but some types (i.e. an Assembly object) is always saved to disk, regardless of its size.
        /// </summary>
        /// <param name="input">The object to save</param>
        /// <returns>A tuple with a string (the textual representation of the given input, which can be a reference to a file), and a list of hashes (which can be empty) for all files that were saved to the disk. This list can be empty, but will never be null</returns>
        public static Tuple<string, List<Hash>> SaveValue(object input)
        {
            List<Hash> relatedFileHashes = new List<Hash>();
            string value = "";
            if (input is bool
                    || input is byte
                    || input is sbyte
                    || input is char
                    || input is decimal
                    || input is double
                    || input is float
                    || input is int
                    || input is uint
                    || input is long
                    || input is ulong
                    || input is short
                    || input is ushort
                    || input is string)
            {
                if (input.ToString().Length > 100)
                {
                    //Save the file
                    Tuple<string, Hash> result = GenericHookHelper.SaveFile(input.ToString());
                    if (ContainsHash(relatedFileHashes, result.Item2) == false)
                    {
                        relatedFileHashes.Add(result.Item2);
                    }
                    value += "";
                }
                else
                {
                    value += input;
                }
            }
            else if (input is Assembly)
            {
                Assembly assembly = (Assembly)input;
                byte[] rawAssembly = GenericHookHelper.GetAsByteArray(assembly);
                //Save the file, which returns the path to the file, where the file name is the SHA-256 hash of the given content
                Tuple<string, Hash> result = GenericHookHelper.SaveFile(rawAssembly);
                if (ContainsHash(relatedFileHashes, result.Item2) == false)
                {
                    relatedFileHashes.Add(result.Item2);
                }
                if (MissedAssemblyDumper.AssemblyHashes.Contains(result.Item2.Sha256) == false)
                {
                    MissedAssemblyDumper.AssemblyHashes.Add(result.Item2.Sha256);
                }
                value = "";
            }
            else if (input is IList)
            {
                Tuple<string, List<Hash>> result = HandleCollection(input);
                value = result.Item1;
                foreach (Hash hash in result.Item2)
                {
                    if (ContainsHash(relatedFileHashes, hash) == false)
                    {
                        relatedFileHashes.Add(hash);
                    }
                }
            }
            else if (input == null)
            {
                value = "null";
            }
            else
            {
                value = input.ToString();
            }
            return Tuple.Create(value, relatedFileHashes);
        }

        /// <summary>
        /// Creats an argument object, based on the given input and the name of the argument
        /// </summary>
        /// <param name="input">The value of the argument, of which the type is derrived</param>
        /// <param name="argumentName">The name of the argument</param>
        /// <returns>An argument object that corresponds with the given arguments</returns>
        public static Argument Create(object input, string argumentName)
        {
            Tuple<string, List<Hash>> result = SaveValue(input);
            string argType = "null";
            string argValue = "null";
            if (input != null)
            {
                argType = input.GetType().FullName;
            }
            if (result.Item1 != null)
            {
                argValue = result.Item1;
            }
            return new Argument(argType, argumentName, argValue, result.Item2);
        }

        /// <summary>
        /// Creates a list of argument objects based on the given method, along with their values
        /// </summary>
        /// <param name="method">The method to fetch the arguments from</param>
        /// <param name="parameterValues">The values of the parameters (in order of the method's parameters)</param>
        /// <returns>A list of argument objects based on the two given arguments</returns>
        public static List<Argument> Create(MethodBase method, object[] parameterValues)
        {
            List<Argument> arguments = new List<Argument>();

            if (method != null && parameterValues != null)
            {
                ParameterInfo[] parameterInfos = method.GetParameters();
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    object parameter;
                    if (parameterValues.Length <= i)
                    {
                        parameter = null;
                    }
                    else
                    {
                        parameter = parameterValues[i];
                    }

                    string type = "null";
                    string name = "null";
                    if (parameterInfos[i] != null)
                    {
                        type = parameterInfos[i].ParameterType.FullName;
                        name = parameterInfos[i].Name;
                    }

                    Tuple<string, List<Hash>> result = SaveValue(parameter);
                    string value = "null";
                    if (result.Item1 != null)
                    {
                        value = result.Item1;
                    }
                    Argument argument = new Argument(type, name, value, result.Item2);
                    arguments.Add(argument);
                }
            }
            return arguments;
        }

        /// <summary>
        /// Handles a collection, either by converting it into a string, or by saving it to the disk and returning the location as if it were the value, together with a brief explanation).
        /// </summary>
        /// <param name="collection">The collection to handle</param>
        /// <returns>The handled collection in the form of a string (as Item1 in the tuple), as well as a list of file hashes of related files (if any, as Item2 in the tuple)</returns>
        private static Tuple<string, List<Hash>> HandleCollection(object collection)
        {
            //Initialise the list of related files
            List<Hash> files = new List<Hash>();
            //Initialise the data variable
            string data = "{ ";

            //Any type of collection with a length of more than 100 indices is saved to disk, as converting and printing large arrays can consume a lot of time
            if (((IList)collection).Count > 100)
            {
                List<byte> bytes = new List<byte>();

                for (int i = 0; i < ((IList)collection).Count; i++)
                {
                    if (((IList)collection) is char[])
                    {
                        char c = (char)((IList)collection)[i];
                        byte[] temp = Encoding.UTF8.GetBytes("" + c);
                        bytes.AddRange(temp);
                    }
                    else if (((IList)collection) is string[])
                    {
                        string s = (string)((IList)collection)[i];
                        byte[] temp = Encoding.UTF8.GetBytes(s);
                        bytes.AddRange(temp);
                    }
                    else if (((IList)collection) is bool[])
                    {
                        bool b = (bool)((IList)collection)[i];
                        if (b)
                        {
                            bytes.Add(1);
                        }
                        else
                        {
                            bytes.Add(0);
                        }
                    }
                    else if (((IList)collection) is byte[])
                    {
                        bytes.Add((byte)((IList)collection)[i]);
                    }
                    else if (((IList)collection) is sbyte[])
                    {
                        byte myByte = (byte)((IList)collection)[i];
                        bytes.Add(myByte);
                    }
                    else if (((IList)collection) is decimal[])
                    {
                        //TODO store numbers properly, if done as dotnet memory streams no loss occurs, and no significant latency is added
                    }
                    else if (((IList)collection) is double[])
                    {

                    }
                    else if (((IList)collection) is float[])
                    {

                    }
                    else if (((IList)collection) is int[])
                    {

                    }
                    else if (((IList)collection) is uint[])
                    {

                    }
                    else if (((IList)collection) is long[])
                    {

                    }
                    else if (((IList)collection) is ulong[])
                    {

                    }
                    else if (((IList)collection) is short[])
                    {

                    }
                    else if (((IList)collection) is ushort[])
                    {

                    }
                    else if (((IList)collection) is object[])
                    {
                        bytes.AddRange(Encoding.UTF8.GetBytes(((IList)collection)[i].ToString()));
                    }
                }

                //Save the file, which returns a tuple with the path to the file, and a hash object with the MD-5, SHA-1, and SHA-256 hash of the file, where the file name is the SHA-256 hash of the given content
                Tuple<string, Hash> result = GenericHookHelper.SaveFile(bytes.ToArray());
                //Tuple<string, Hash> result = GenericHookHelper.SaveFile(Encoding.UTF8.GetBytes(output));
                //Add it to the list of files
                if (ContainsHash(files, result.Item2) == false)
                {
                    files.Add(result.Item2);
                }
                //Inform the user that the data is stored in a file
                data += "DotDumper::" + result.Item2.Sha256 + "  "; //Note: the last two characters are removed once the function returns
            }
            else //Handle collections that are less than 100 indices in size
            {
                //If the type is an object collection, it needs to be handled in a specific way
                if (collection is object[] || collection is IList<object>)
                {
                    if (collection is IList<object>)
                    {
                        collection = ((IList<object>)collection).ToArray();
                    }

                    if (((object[])collection).Length == 0)
                    {
                        data += "DotDumper::empty  "; //Note: the last two characters are removed once the function returns
                    }
                    else
                    {
                        foreach (object subParameter in (object[])collection)
                        {
                            if (subParameter is object[] || subParameter is IList<object>)
                            {
                                //Recursive call if the array contains an array
                                Tuple<string, List<Hash>> result = HandleCollection(subParameter);
                                //Get the data from the tuple, and append it to this one
                                data += result.Item1;
                                //Add all file hashes to the current file list
                                foreach (Hash hash in result.Item2)
                                {
                                    if (ContainsHash(files, hash) == false)
                                    {
                                        files.Add(hash);
                                    }
                                }
                            }
                            else if (subParameter == null)
                            {
                                data += "null";
                            }
                            else
                            {
                                string subParameterType = subParameter.GetType().FullName;
                                data += subParameterType + " " + subParameter;
                            }
                            data += ", ";
                        }
                    }
                }
                else
                {
                    foreach (var subParameter in (IList)collection)
                    {
                        if (subParameter == null)
                        {
                            data += "null";
                        }
                        else
                        {
                            data += subParameter;
                        }
                        data += ", ";
                    }
                }
            }
            //Remove the last comma and space, after which a curly bracket is appended
            data = data.Substring(0, data.Length - 2) + " }";
            //Return the value as a tuple
            return Tuple.Create(data, files);
        }
    }
}
