using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ResourceManagerHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetObjectHookString(ResourceManager resourceManager, string name)
        {
            //Declare the local variable to store the result in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();
                result = null;
                try
                {
                    result = resourceManager.GetObject(name);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteObjectGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetObjectString(), new object[] { name }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetObjectHookStringCultureInfo(ResourceManager resourceManager, string name, CultureInfo cultureInfo)
        {
            //Declare the local variable to store the result in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetObject(name, cultureInfo);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteObjectGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetObjectStringCultureInfo(), new object[] { name, cultureInfo }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetStringHookString(ResourceManager resourceManager, string name)
        {
            //Declare the local variable to store the result in
            string result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();
                result = null;
                try
                {
                    result = resourceManager.GetString(name);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteStringGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStringString(), new object[] { name }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetStringHookStringCultureInfo(ResourceManager resourceManager, string name, CultureInfo cultureInfo)
        {
            //Declare the local variable to store the result in
            string result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetString(name, cultureInfo);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteStringGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStringStringCultureInfo(), new object[] { name, cultureInfo }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static UnmanagedMemoryStream GetStreamHookString(ResourceManager resourceManager, string name)
        {
            //Declare the local variable to store the result in
            UnmanagedMemoryStream result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetStream(name);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteStreamGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStreamString(), new object[] { name }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static UnmanagedMemoryStream GetStreamHookStringCultureInfo(ResourceManager resourceManager, string name, CultureInfo cultureInfo)
        {
            //Declare the local variable to store the result in
            UnmanagedMemoryStream result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetStream(name, cultureInfo);
                }
                catch (Exception)
                {

                }

                if (result == null)
                {
                    result = BruteStreamGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStreamStringCultureInfo(), new object[] { name, cultureInfo }, result);

                HookManager.HookAll();
            }

            //Return the process object to the caller
            return result;
        }

        private static string BruteStringGet(string resourceName)
        {
            string result = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                string[] resourceNames = assembly.GetManifestResourceNames();

                foreach (string resource in resourceNames)
                {
                    try
                    {
                        ResourceManager resourceManager = new ResourceManager(resourceName, assembly);
                        result = resourceManager.GetString(resourceName);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                    catch (Exception)
                    {
                        //Ignore exceptions, as this function returns null if the resource cannot be found
                    }
                }
            }

            return result;
        }

        private static object BruteObjectGet(string resourceName)
        {
            object result = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                string[] resourceNames = assembly.GetManifestResourceNames();

                foreach (string resource in resourceNames)
                {
                    try
                    {
                        ResourceManager resourceManager = new ResourceManager(resourceName, assembly);
                        result = resourceManager.GetObject(resourceName);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                    catch (Exception)
                    {
                        //Ignore exceptions, as this function returns null if the resource cannot be found
                    }
                }
            }

            return result;
        }

        private static UnmanagedMemoryStream BruteStreamGet(string resourceName)
        {
            UnmanagedMemoryStream result = null;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                string[] resourceNames = assembly.GetManifestResourceNames();

                foreach (string resource in resourceNames)
                {
                    try
                    {
                        ResourceManager resourceManager = new ResourceManager(resourceName, assembly);
                        result = resourceManager.GetStream(resourceName, null);
                        if (result != null)
                        {
                            return result;
                        }
                    }
                    catch (Exception)
                    {
                        //Ignore exceptions, as this function returns null if the resource cannot be found
                    }
                }
            }

            return result;
        }
    }
}
