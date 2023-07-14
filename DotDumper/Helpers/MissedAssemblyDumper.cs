using System;
using System.Collections.Generic;
using System.Reflection;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class is used to dump missed assembly objects from memory to the disk
    /// </summary>
    class MissedAssemblyDumper
    {
        /// <summary>
        /// A list which contains the (partial) names of the assemblies to exclude during periodic dumping
        /// </summary>
        public static List<string> ExcludedAssemblies { get; set; }

        /// <summary>
        /// SHA-256 hashes of raw Assembly objects (their byte[] representation) that have been written to the disk during the execution of this run of DotDumper
        /// </summary>
        public static List<string> AssemblyHashes { get; set; }

        /// <summary>
        /// The static constructor of the class ensures the class scoped list is always initialised prior to its usage
        /// </summary>
        static MissedAssemblyDumper()
        {
            //Initialise the lists
            AssemblyHashes = new List<string>();
            ExcludedAssemblies = new List<string>();

            //Populate the list
            ExcludedAssemblies.Add("dotdumper");
            ExcludedAssemblies.Add("penet");
            ExcludedAssemblies.Add("system.memory");
            ExcludedAssemblies.Add("system.runtime.compilerservices.unsafe");
            ExcludedAssemblies.Add("system.numerics.vectors");
            ExcludedAssemblies.Add("microsoft.generatedcode");
        }

        /// <summary>
        /// Dumps all loaded assemblies that haven't been dumped before and are not part of the Global Assembly Cache (GAC). This function removes all hooks, dumps the missing data, after which all hooks are set again.
        /// </summary>
        public static void Dump()
        {
            //Temporarily remove all hooks
            HookManager.UnHookAll();

            //If the original assembly is not null, it can be added to the list of hashes, this avoids the sample to show up as a "missed" assembly object
            if (GenericHookHelper.OriginalAssembly != null)
            {
                //Get the raw bytes
                byte[] sample = GenericHookHelper.GetAsByteArray(GenericHookHelper.OriginalAssembly);
                //Unhook all hooks, as these are set after the previous call
                HookManager.UnHookAll();
                //Get the SHA-256 hash
                string sampleSha256 = Hashes.Sha256(sample);
                //Check if the list does not contain this item
                if (AssemblyHashes.Contains(sampleSha256) == false)
                {
                    //Add the hash to the list
                    AssemblyHashes.Add(sampleSha256);
                }
            }

            //Declare and initialise the list for the saved assemblies
            List<Hash> savedAssemblies = new List<Hash>();

            //Get all the assemblies in the current domain
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //Iterate over all assemblies within the current domain
            foreach (Assembly assembly in assemblies)
            {
                //Omit DotDumper itself, as well as used (DotNet Framework related) libraries 
                if (ExcludeAssembly(assembly))
                {
                    continue;
                }
                try
                {
                    //Get the raw bytes of the assembly
                    byte[] rawAssembly = GenericHookHelper.GetAsByteArray(assembly);
                    //Unhook all hooks, as these are set via the previous call
                    HookManager.UnHookAll();
                    //Get the SHA-256 hash of the given assembly object's bytes
                    string sha256 = Hashes.Sha256(rawAssembly);

                    //Only save assemblies that haven't been saved before during this run
                    if (AssemblyHashes.Contains(sha256) == false)
                    {
                        //Save the file, and store the SHA-256 hash in the list of processed assembly objects, and store the Hash object in the saved assemblies list
                        Tuple<string, Hash> result = GenericHookHelper.SaveFile(rawAssembly);
                        HookManager.UnHookAll();
                        savedAssemblies.Add(result.Item2);
                        AssemblyHashes.Add(result.Item2.Sha256);
                    }
                }
                catch (Exception)
                {
                    //Ignore errors when trying to save an assembly object in its raw form. In some cases, DotNet Framework related assembly objects cause errors when attempting to save them, i.e. when they are dynamically generated
                }
            }

            //If at least 1 assembly has been saved (and was thus missed), this should be logged
            if (savedAssemblies.Count > 0)
            {
                //Create a nearly empty log entry object with the relevant information
                LogEntry entry = new LogEntry(null, null, null, null, null, savedAssemblies, "periodic assembly dumping", null, null, null, null);
                //Log the entry to all relevant logs
                GenericHookHelper._Logger.Log(entry, false, false);
            }
            //Set all hooks prior to returning to the caller
            HookManager.HookAll();
        }

        /// <summary>
        /// Checks if the given assembly is to be excluded or not. It will be if either of the following is true: the given assembly object is null, the given assembly is part of the global assembly cache, or if the fullname matches (in full or partially) the name of any of the names in the exclusion list.
        /// </summary>
        /// <param name="assembly">The assembly to check for</param>
        /// <returns>True if the assembly is to be excluded, false if not</returns>
        private static bool ExcludeAssembly(Assembly assembly)
        {
            //If the given assembly object is null, it is to be excluded
            if (assembly == null)
            {
                return true;
            }

            //Excludes the assembly if it's part of the global assembly cache
            if (assembly.GlobalAssemblyCache)
            {
                return true;
            }

            //Get the assembly name in lower case
            string assemblyName = assembly.GetName().FullName.ToLowerInvariant();

            //Iterate over all excluded assembly names
            foreach (string excludedName in ExcludedAssemblies)
            {
                //If the current assembly name (in lower case) contains the excluded name (also in lower case), it is to be skipped
                if (assemblyName.Contains(excludedName.ToLowerInvariant()))
                {
                    return true;
                }
            }

            //The assembly is not to be skipped if its not meeting any of the skip criteria
            return false;
        }
    }
}
