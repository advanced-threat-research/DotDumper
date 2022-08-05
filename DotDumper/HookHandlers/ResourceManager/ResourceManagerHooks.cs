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
                //Sets the title for the log
                string functionName = "ResourceManager.GetObject(string name)";
                HookManager.UnHookByHookName("GetObjectHookString");
                HookManager.UnHookAll();
                result = null;
                try
                {
                    result = resourceManager.GetObject(name);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteObjectGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetObjectString(), new object[] { name }, result);
                
                HookManager.HookAll();
                HookManager.HookByHookName("GetObjectHookString");
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
                //Sets the title for the log
                string functionName = "ResourceManager.GetObject(string name, CultureInfo cultureInfo)";

                HookManager.UnHookByHookName("GetObjectHookStringCultureInfo");
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetObject(name, cultureInfo);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteObjectGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetObjectStringCultureInfo(), new object[] { name, cultureInfo }, result);
                
                HookManager.HookByHookName("GetObjectHookStringCultureInfo");
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
                //Sets the title for the log
                string functionName = "ResourceManager.GetString(string name, CultureInfo cultureInfo)";

                /**
                 * The GetString(string name) function wraps around GetString(string name, CultureInfo cultureInfo) function
                 * meaning that one hook would call the next, causing clutter, hence the double unhook and double rehook
                 */
                HookManager.UnHookByHookName("GetStringHookString");
                HookManager.UnHookByHookName("GetStringHookStringCultureInfo");
                HookManager.UnHookAll();
                result = null;
                try
                {
                    result = resourceManager.GetString(name);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteStringGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStringString(), new object[] { name }, result);

                HookManager.HookByHookName("GetStringHookString");
                HookManager.HookByHookName("GetStringHookStringCultureInfo");
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
                //Sets the title for the log
                string functionName = "ResourceManager.GetString(string name, CultureInfo cultureInfo)";

                HookManager.UnHookByHookName("GetStringHookStringCultureInfo");
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetString(name, cultureInfo);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteStringGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStringStringCultureInfo(), new object[] { name, cultureInfo }, result);

                HookManager.HookByHookName("GetStringHookStringCultureInfo");
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
                //Sets the title for the log
                string functionName = "ResourceManager.GetStream(string name)";
                HookManager.UnHookByHookName("GetStreamHookString");
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetStream(name);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteStreamGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStreamString(), new object[] { name }, result);

                HookManager.HookByHookName("GetStreamHookString");
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
                //Sets the title for the log
                string functionName = "ResourceManager.GetStream(string name, CultureInfo cultureInfo)";
                //Process the given data via the helper class
                ResourceManagerHooksHelper.Handle(functionName, name);
                HookManager.UnHookByHookName("GetStreamHookStringCultureInfo");
                HookManager.UnHookAll();

                result = null;
                try
                {
                    result = resourceManager.GetStream(name, cultureInfo);
                }
                catch (Exception ex)
                {

                }

                if (result == null)
                {
                    result = BruteStreamGet(name);
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ResourceManagerGetStreamStringCultureInfo(), new object[] { name, cultureInfo }, result);

                HookManager.HookByHookName("GetStreamHookStringCultureInfo");
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
                    catch (Exception ex)
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
                    catch (Exception ex)
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
                    catch (Exception ex)
                    {
                        //Ignore exceptions, as this function returns null if the resource cannot be found
                    }
                }
            }

            return result;
        }
    }
}
