using System.Configuration.Assemblies;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Policy;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class AssemblyHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly GetEntryAssemblyHook()
        {
            return GenericHookHelper.OriginalAssembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly GetExecutingAssemblyHook()
        {
            return GenericHookHelper.OriginalAssembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookByteArray(byte[] rawAssembly)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookByteArray");
                //Call the original function
                assembly = Assembly.Load(rawAssembly);
                //Restore the hook
                HookManager.HookByHookName("LoadHookByteArray");


                //Sets the title for the log
                string functionName = "Assembly.Load(byte[] rawAssembly)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadByteArray(), new object[] { rawAssembly }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookString(string assemblyString)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookString");
                //Call the original function
                assembly = Assembly.Load(assemblyString);
                //Restore the hook
                HookManager.HookByHookName("LoadHookString");

                //Sets the title for the log
                string functionName = "Assembly.Load(string assemblyString)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadString(), new object[] { assemblyString }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookStringEvidence(string assemblyString, Evidence assemblySecurity)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookStringEvidence");
                //Call the original function
                assembly = Assembly.Load(assemblyString, assemblySecurity);
                //Restore the hook
                HookManager.HookByHookName("LoadHookStringEvidence");

                //Sets the title for the log
                string functionName = "Assembly.Load(String assemblyString, Evidence assemblySecurity)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadStringEvidence(), new object[] { assemblyString, assemblySecurity }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookByteArrayByteArrayEvidence(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookByteArrayByteArrayEvidence");
                //Call the original function
                assembly = Assembly.Load(rawAssembly, rawSymbolStore, securityEvidence);
                //Restore the hook
                HookManager.HookByHookName("LoadHookByteArrayByteArrayEvidence");

                //Sets the title for the log
                string functionName = "Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadByteArrayByteArrayEvidence(), new object[] { rawAssembly, rawSymbolStore, securityEvidence }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookAssemblyName(AssemblyName assemblyRef)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookAssemblyName");
                //Call the original function
                assembly = Assembly.Load(assemblyRef);
                //Restore the hook
                HookManager.HookByHookName("LoadHookAssemblyName");

                //Sets the title for the log
                string functionName = "Assembly.Load(AssemblyName assemblyRef)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadAssemblyName(), new object[] { assemblyRef }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookAssemblyNameEvidence(AssemblyName assemblyRef, Evidence assemblySecurity)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookAssemblyNameEvidence");
                //Call the original function
                assembly = Assembly.Load(assemblyRef, assemblySecurity);
                //Restore the hook
                HookManager.HookByHookName("LoadHookAssemblyNameEvidence");

                //Sets the title for the log
                string functionName = "Assembly.Load(AssemblyName assemblyRef, Evidence assemblySecurity)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadAssemblyNameEvidence(), new object[] { assemblyRef, assemblySecurity }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookByteArrayByteArraySecurityContextSource(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookByteArrayByteArraySecurityContextSource");
                //Call the original function
                assembly = Assembly.Load(rawAssembly, rawSymbolStore, securityContextSource);
                //Restore the hook
                HookManager.HookByHookName("LoadHookByteArrayByteArraySecurityContextSource");

                //Sets the title for the log
                string functionName = "Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadByteArrayByteArraySecurityContextSource(), new object[] { rawAssembly, rawSymbolStore, securityContextSource }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadHookByteArrayByteArray(byte[] rawAssembly, byte[] rawSymbolStore)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadHookByteArrayByteArray");
                //Call the original function
                assembly = Assembly.Load(rawAssembly, rawSymbolStore);
                //Restore the hook
                HookManager.HookByHookName("LoadHookByteArrayByteArray");

                //Sets the title for the log
                string functionName = "Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadByteArrayByteArray(), new object[] { rawAssembly, rawSymbolStore }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFileHookString(string path)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFileHookString");
                //Call the original function
                assembly = Assembly.LoadFile(path);
                //Restore the hook
                HookManager.HookByHookName("LoadFileHookString");

                //Sets the title for the log
                string functionName = "Assembly.LoadFile(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFileString(), new object[] { path }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFileHookStringEvidence(string path, Evidence securityEvidence)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFileHookStringEvidence");
                //Call the original function
                assembly = Assembly.LoadFile(path, securityEvidence);
                //Restore the hook
                HookManager.HookByHookName("LoadFileHookStringEvidence");

                //Sets the title for the log
                string functionName = "Assembly.LoadFile(string path, Evidence securityEvidence)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFileStringEvidence(), new object[] { path, securityEvidence }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFromHookString(string assemblyFile)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFromHookString");
                //Call the original function
                assembly = Assembly.LoadFrom(assemblyFile);
                //Restore the hook
                HookManager.HookByHookName("LoadFromHookString");

                //Sets the title for the log
                string functionName = "Assembly.LoadFrom(string assemblyFile)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFromString(), new object[] { assemblyFile }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFromHookStringEvidence(string assemblyFile, Evidence securityEvidence)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFromHookStringEvidence");
                //Call the original function
                assembly = Assembly.LoadFrom(assemblyFile, securityEvidence);
                //Restore the hook
                HookManager.HookByHookName("LoadFromHookStringEvidence");

                //Sets the title for the log
                string functionName = "Assembly.LoadFrom(string assemblyFile, Evidence securityEvidence)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFromStringEvidence(), new object[] { assemblyFile, securityEvidence }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFromHookStringEvidenceByteArrayAssemblyHashAlgorithm(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFromHookStringEvidenceByteArrayAssemblyHashAlgorithm");
                //Call the original function
                assembly = Assembly.LoadFrom(assemblyFile, securityEvidence, hashValue, hashAlgorithm);
                //Restore the hook
                HookManager.HookByHookName("LoadFromHookStringEvidenceByteArrayAssemblyHashAlgorithm");

                //Sets the title for the log
                string functionName = "Assembly.LoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFromStringEvidenceByteArrayAssemblyHashAlgorithm(), new object[] { assemblyFile, securityEvidence, hashValue, hashAlgorithm }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadFromHookStringByteArrayAssemblyHashAlgorithm(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadFromHookStringByteArrayAssemblyHashAlgorithm");
                //Call the original function
                assembly = Assembly.LoadFrom(assemblyFile, hashValue, hashAlgorithm);
                //Restore the hook
                HookManager.HookByHookName("LoadFromHookStringByteArrayAssemblyHashAlgorithm");

                //Sets the title for the log
                string functionName = "Assembly.LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadFromStringByteArrayAssemblyHashAlgorithm(), new object[] { assemblyFile, hashValue, hashAlgorithm }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadWithPartialNameHookStringEvidence(string partialName, Evidence securityEvidence)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadWithPartialNameHookStringEvidence");
                //Call the original function
                assembly = Assembly.LoadWithPartialName(partialName, securityEvidence);
                //Restore the hook
                HookManager.HookByHookName("LoadWithPartialNameHookStringEvidence");

                //Sets the title for the log
                string functionName = "Assembly.LoadWithPartialName(string partialName, Evidence securityEvidence)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadWithPartialNameStringEvidence(), new object[] { partialName, securityEvidence }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly LoadWithPartialNameHookString(string partialName)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("LoadWithPartialNameHookString");
                //Call the original function
                assembly = Assembly.LoadWithPartialName(partialName);
                //Restore the hook
                HookManager.HookByHookName("LoadWithPartialNameHookString");

                //Sets the title for the log
                string functionName = "Assembly.LoadWithPartialName(string partialName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyLoadWithPartialNameString(), new object[] { partialName }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly ReflectionOnlyLoadHookString(string assemblyString)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReflectionOnlyLoadHookString");
                //Call the original function
                assembly = Assembly.ReflectionOnlyLoad(assemblyString);
                //Restore the hook
                HookManager.HookByHookName("ReflectionOnlyLoadHookString");

                //Sets the title for the log
                string functionName = "Assembly.ReflectionOnlyLoad(string assemblyString)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyReflectionOnlyLoadString(), new object[] { assemblyString }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly ReflectionOnlyLoadHookByteArray(byte[] rawAssembly)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReflectionOnlyLoadHookByteArray");
                //Call the original function
                assembly = Assembly.ReflectionOnlyLoad(rawAssembly);
                //Restore the hook
                HookManager.HookByHookName("ReflectionOnlyLoadHookByteArray");

                //Sets the title for the log
                string functionName = "Assembly.ReflectionOnlyLoad(byte[] rawAssembly)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyReflectionOnlyLoadByteArray(), new object[] { rawAssembly }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly ReflectionOnlyLoadFromHookString(string assemblyFile)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReflectionOnlyLoadFromHookString");
                //Call the original function
                assembly = Assembly.ReflectionOnlyLoadFrom(assemblyFile);
                //Restore the hook
                HookManager.HookByHookName("ReflectionOnlyLoadFromHookString");

                //Sets the title for the log
                string functionName = "Assembly.ReflectionOnlyLoadFrom(string assemblyFile)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyReflectionOnlyLoadFromString(), new object[] { assemblyFile }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Assembly UnsafeLoadFromHookString(string assemblyFile)
        {
            //Declare the local variable to store the assembly in
            Assembly assembly;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("UnsafeLoadFromHookString");
                //Call the original function
                assembly = Assembly.UnsafeLoadFrom(assemblyFile);
                //Restore the hook
                HookManager.HookByHookName("UnsafeLoadFromHookString");

                //Sets the title for the log
                string functionName = "Assembly.UnsafeLoadFrom(string assemblyFile)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.AssemblyUnsafeLoadFromString(), new object[] { assemblyFile }, assembly);
            }

            //Return the assembly to the caller
            return assembly;
        }
    }
}
