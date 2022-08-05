using System;
using System.Collections.Generic;
using DotDumper.Hooks;

namespace DotDumper.Models
{
    /// <summary>
    /// A log entry object, which is used by the logger to easily write logs into different formats (i.e. JSON, XML, and human readable plaintext)
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// The name of the assembly object the call originated from
        /// </summary>
        public string OriginatingAssemblyName { get; set; }

        /// <summary>
        /// The hash object which contains the MD-5, SHA-1, and SHA-256 hashes of the assembly object where the call originated from
        /// </summary>
        public Hash OriginatingAssemblyHash { get; set; }

        /// <summary>
        /// The version of the assembly object the call originated from
        /// </summary>
        public string OriginatingAssemblyVersion { get; set; }

        /// <summary>
        /// The names of the resources of the assembly object the call originated from
        /// </summary>
        public List<string> OriginatingAssemblyResourceNames { get; set; }

        /// <summary>
        /// The hash of the assembly object that called/loaded this assembly object. If absent, this should be null!
        /// </summary>
        public string ParentAssemblyHash { get; set; }

        /// <summary>
        /// A list of hash objects of files related to this call, all of which can be found in the logging folder (named after their SHA-256 hash)
        /// </summary>
        public List<Hash> RelatedFileHashes { get; set; }

        /// <summary>
        /// The date time at the creation of this object, formatted as dd-MM-yyyy HH:mm:ss
        /// </summary>
        public string DateTimeStamp { get; set; }

        /// <summary>
        /// The name of the hooked function
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// The arguments of the function
        /// </summary>
        public List<Argument> FunctionArguments { get; set; }

        /// <summary>
        /// The returned value of the original function
        /// </summary>
        public Argument ReturnValue { get; set; }

        /// <summary>
        /// The stack trace to the hooked function
        /// </summary>
        public List<string> StackTrace { get; set; }

        /// <summary>
        /// The order in which the assembly objects are called prior to this call
        /// </summary>
        public List<AssemblyObject> AssemblyCallOrder { get; set; }

        /// <summary>
        /// Creates a LogEntry object, which the logger uses to log the details within the object in several formats
        /// </summary>
        /// <param name="originatingAssemblyName">The name of the assembly object the call originated from</param>
        /// <param name="originatingAssemblyHash">The hash object which contains the MD-5, SHA-1, and SHA-256 hashes of the assembly object where the call originated from</param>
        /// <param name="originatingAssemblyVersion">The version of the assembly object the call originated from</param>
        /// <param name="originatingAssemblyResourceNames">The names of the resources of the assembly object the call originated from</param>
        /// <param name="parentAssemblyHash">The hash of the assembly object that called/loaded this assembly object. If absent, this should be null!</param>
        /// <param name="relatedFileHashes">A list of hash objects of files related to this call, all of which can be found in the logging folder (named after their SHA-256 hash)</param>
        /// <param name="functionName">The name of the hooked function</param>
        /// <param name="functionArguments">The arguments of the function</param>
        /// <param name="returnValue">The returned value of the original function</param>
        /// <param name="stackTrace">The stack trace to the hooked function</param>
        /// <param name="assemblyCallOrder">The order in which the assembly objects are called prior to this call</param>
        public LogEntry(string originatingAssemblyName, Hash originatingAssemblyHash, string originatingAssemblyVersion, List<string> originatingAssemblyResourceNames, string parentAssemblyHash, List<Hash> relatedFileHashes, string functionName, List<Argument> functionArguments, Argument returnValue, List<string> stackTrace, List<AssemblyObject> assemblyCallOrder)
        {
            OriginatingAssemblyName = originatingAssemblyName;
            OriginatingAssemblyHash = originatingAssemblyHash;
            OriginatingAssemblyVersion = originatingAssemblyVersion;
            OriginatingAssemblyResourceNames = originatingAssemblyResourceNames;
            ParentAssemblyHash = parentAssemblyHash;
            RelatedFileHashes = relatedFileHashes;
            DateTimeStamp = GetDateTime();
            FunctionName = functionName;
            FunctionArguments = functionArguments;
            ReturnValue = returnValue;
            StackTrace = stackTrace;
            AssemblyCallOrder = assemblyCallOrder;
        }

        /// <summary>
        /// DO NOTE USE THIS CONSTRUCTOR! This is an empty constructor to be able to serialise the object, which is its sole purpose!
        /// </summary>
        public LogEntry()
        {
            DateTimeStamp = GetDateTime();
        }

        /// <summary>
        /// A private method to get the current date time as a string, in the following format: dd-MM-yyyy HH:mm:ss
        /// </summary>
        /// <returns>The date time format of the current system at the moment of this call</returns>
        private static string GetDateTime()
        {
            HookManager.UnHookAll();
            string dateTime = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            HookManager.HookAll();
            return dateTime;
        }
    }
}
