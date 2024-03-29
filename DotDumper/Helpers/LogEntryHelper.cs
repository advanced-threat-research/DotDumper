﻿using System;
using System.Collections.Generic;
using System.Reflection;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class is used to create DotDumper.Model.LogEntry objects based on as few parameters as possible
    /// </summary>
    class LogEntryHelper
    {
        /// <summary>
        /// Creates a log entry object based on the given exception, with the given stack trace offset from the caller's position
        /// </summary>
        /// <param name="stackTraceOffset">The amount of layers away from the original call flow, based on the caller's position</param>
        /// <param name="ex">The exception to base the log entry object on</param>
        /// <returns>A log entry based on the given values</returns>
        public static LogEntry Create(int stackTraceOffset, Exception ex)
        {
            stackTraceOffset++;
            LogEntry entry = Create(stackTraceOffset, ex.TargetSite, null, ex);
            return entry;
        }

        /// <summary>
        /// Creates a log entry for an unmanaged function, along with its argument and return values
        /// </summary>
        /// <param name="unmanagedMethodInfo">The unmanaged methodinfo object, corresponding to the original function that was hooked</param>
        /// <param name="parameterValues">An array of objects with the values of the function's arguments</param>
        /// <param name="returnValue">The value of the function's return value</param>
        /// <returns>A log entry based on the given values</returns>
        public static LogEntry Create(UnmanagedMethodInfo unmanagedMethodInfo, object[] parameterValues, object returnValue)
        {
            MethodInfo methodInfo = HookManager.GetMethodInfo(typeof(InteropFunctions), unmanagedMethodInfo.MethodName, unmanagedMethodInfo.ParameterTypes);
            //A negative value for the stack trace, as the wrong value is obtained since this call is invoked based on async information that is shared via the unmanaged function hooks that share via a named pipe 
            return Create(-1, methodInfo, parameterValues, returnValue);
        }

        /// <summary>
        /// Creates a log entry based on the given stack trace offset (from the caller's position), method, the method values, and the return value of said method
        /// </summary>
        /// <param name="stackTraceOffset">The amount of layers away from the original call flow, based on the caller's position. A value less than 0 is used to indicate that the stack trace is to be ignored (done for unmanaged function hooks, as the function is obtained from a different location than the actual call comes from)</param>
        /// <param name="method">The method that is of importance to log</param>
        /// <param name="parameterValues">The values of said method's parameters</param>
        /// <param name="returnValue">The return value of the function (use null if it's a void)</param>
        /// <returns>A log entry based on the given values</returns>
        public static LogEntry Create(int stackTraceOffset, MethodBase method, object[] parameterValues, object returnValue)
        {
            //Gets a list of arguments based on the given function
            List<Argument> functionArguments = ArgumentHelper.Create(method, parameterValues);
            //Initialises a list of related files
            List<Hash> relatedFileHashes = new List<Hash>();

            //Iterate over all extracted arguments
            foreach (Argument argument in functionArguments)
            {
                //Iterate over all hashes
                foreach (Hash hash in argument.RelatedFileHashes)
                {
                    //If there is no such hash in the list, add it. Otherwise, ignore it
                    if (ArgumentHelper.ContainsHash(relatedFileHashes, hash) == false)
                    {
                        relatedFileHashes.Add(hash);
                    }
                }
            }

            //Declare and initialise the stack trace variable
            List<string> stackTrace = new List<string>();

            /*
             * If the value is negative, its a hook for an unmanaged function and the only obtainable stack trace is useless. If it is zero or higher, its a managed hook
             */
            if (stackTraceOffset >= 0)
            {
                //Increment the stack trace offset, since this is another function deep into the trace
                stackTraceOffset++;
                //Get the stack trace
                stackTrace = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            }

            //Get the assembly and assembly object information based on the stack trace
            Tuple<Assembly, List<AssemblyObject>> result = AssemblyMapper.ProcessStackTrace(stackTrace);

            //Declare the originating assembly variable
            Assembly originatingAssembly = null;

            /*
             * If the first tuple item (being the Assembly object) is null, the call is coming from either the DotNet Framework, or from DotDumper's code base.
             * If the value is not-null, it is assigned.
             */
            if (result.Item1 == null)
            {
                HookManager.UnHookAll();
                originatingAssembly = Assembly.GetAssembly(typeof(Program));
                HookManager.HookAll();
            }
            else
            {
                originatingAssembly = result.Item1;
            }


            //Get the name from the originating assembly
            string originatingAssemblyName = originatingAssembly.GetName().Name;

            //Get the raw assembly as an unboxed byte array
            byte[] rawAssembly = GenericHookHelper.GetAsByteArray(originatingAssembly);

            //Get the hashes based on the given raw assembly byte array
            string md5 = Hashes.Md5(rawAssembly);
            string sha1 = Hashes.Sha1(rawAssembly);
            string sha256 = Hashes.Sha256(rawAssembly);
            string sha384 = Hashes.Sha384(rawAssembly);
            string sha512 = Hashes.Sha512(rawAssembly);
            string typeRef = Hashes.TypeRef(rawAssembly);
            string importHash = Hashes.ImportHash(rawAssembly);
            string authenticodeSha256 = Hashes.AuthenticodeSha256(rawAssembly);
            //Create a hash object to store the values in
            Hash originatingAssemblyHash = new Hash(md5, sha1, sha256, sha384, sha512, typeRef, importHash, authenticodeSha256);

            //Get the originating assembly version
            string originatingAssemblyVersion = originatingAssembly.GetName().Version.ToString();

            //Get the originating assembly resource names
            List<string> originatingAssemblyResourceNames = new List<string>(originatingAssembly.GetManifestResourceNames());

            //Get the call order, which is the second item from the tuple
            List<AssemblyObject> assemblyCallOrder = result.Item2;

            //Declare and assign a value to the parent assembly hash string
            string parentAssemblyHash = "[none]";

            //Iterate over all assembly objects in the call order
            foreach (AssemblyObject assemblyObject in assemblyCallOrder)
            {
                //If the hash is not equal to none nor to the current originating hash, it is set as the parent
                if (assemblyObject.Hash.Equals("[none]", StringComparison.InvariantCultureIgnoreCase) == false
                    && assemblyObject.Hash.Equals(originatingAssemblyHash.Sha256, StringComparison.InvariantCultureIgnoreCase) == false)
                {
                    parentAssemblyHash = assemblyObject.Hash;
                    //There is no need to continue the iteration, since only the first parent is stored (and the rest is visible in the call order)
                    break;
                }
            }

            //Get the function name
            string functionName = Serialise.Method(method);

            //The return value is stored in an argument object, with a hardcoded name
            Argument returnValueArg = ArgumentHelper.Create(returnValue, "ReturnValue");

            //The return value can also be related to a file
            foreach (Hash hash in returnValueArg.RelatedFileHashes)
            {
                //Iterate over all the hashes, and add the ones that aren't in the list yet
                if (ArgumentHelper.ContainsHash(relatedFileHashes, hash) == false)
                {
                    relatedFileHashes.Add(hash);
                }
            }

            //Return a new LogEntry object based on all the gathered information
            return new LogEntry(originatingAssemblyName, originatingAssemblyHash, originatingAssemblyVersion, originatingAssemblyResourceNames, parentAssemblyHash, relatedFileHashes, functionName, functionArguments, returnValueArg, stackTrace, assemblyCallOrder);
        }
    }
}
