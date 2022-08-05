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
        /// SHA-256 hashes of raw Assembly objects (their byte[] representation) that have been written to the disk during the execution of this run of DotDumper
        /// </summary>
        public static List<string> AssemblyHashes { get; set; }

        /// <summary>
        /// The static constructor of the class ensures the class scoped list is always initialised prior to its usage
        /// </summary>
        static MissedAssemblyDumper()
        {
            //Initialise the list
            AssemblyHashes = new List<string>();
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
                //Omit framework related objects, as well as DotDumper itself
                if (assembly.GlobalAssemblyCache ||
                    assembly.GetName().FullName.ToLowerInvariant().Contains("dotdumper"))
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
                catch (Exception ex)
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
    }
}
