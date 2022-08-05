using System;
using System.Runtime.CompilerServices;
using System.Collections;
using static System.Environment;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class EnvironmentHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ExitHookInt(int exitCode)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Environment.Exit(int exitCode)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentExitInt(), new object[] { exitCode }, null);

                //Disable the placed hook
                HookManager.UnHookByHookName("ExitHookInt");
                //Call the original function
                Environment.Exit(exitCode);
                //Restore the hook
                HookManager.HookByHookName("ExitHookInt");
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ExpandEnvironmentVariablesHookString(string name)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ExpandEnvironmentVariablesHookString");
                //Call the original function
                output = Environment.ExpandEnvironmentVariables(name);
                //Restore the hook
                HookManager.HookByHookName("ExpandEnvironmentVariablesHookString");

                //Sets the title for the log
                string functionName = "Environment.ExpandEnvironmentVariables(string name)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentExpandEnvironmentVariablesString(), new object[] { name }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void FailFastHookStringException(string message, Exception exception)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Environment.FailFast(string message, Exception exception)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentFailFastStringException(), new object[] { message, exception }, null);

                //Disable the placed hook
                HookManager.UnHookByHookName("FailFastHookStringException");
                //Call the original function
                Environment.FailFast(message, exception);
                //Restore the hook
                HookManager.HookByHookName("FailFastHookStringException");
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void FailFastHookString(string message)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Environment.FailFast(string message)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentFailFastString(), new object[] { message }, null);

                //Disable the placed hook
                HookManager.UnHookByHookName("FailFastHookString");
                //Call the original function
                Environment.FailFast(message);
                //Restore the hook
                HookManager.HookByHookName("FailFastHookString");
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetCommandLineArgsHook()
        {
            //Declare the local variable to store the object in
            string[] output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetCommandLineArgsHook");
                //Call the original function
                //TODO obtain provided CLI arguments, if any, otherwise return an empty array, as this would return the CLI arguments of DotDumper itself
                //output = Environment.GetCommandLineArgs();
                output = new string[0];

                //Restore the hook
                HookManager.HookByHookName("GetCommandLineArgsHook");

                //Sets the title for the log
                string functionName = "Environment.GetCommandLineArgs()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetCommandLineArgs(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetEnvironmentVariableHookStringEnvironmentVariableTarget(string variable, EnvironmentVariableTarget target)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetEnvironmentVariableHookStringEnvironmentVariableTarget");
                //Call the original function
                output = Environment.GetEnvironmentVariable(variable, target);
                //Restore the hook
                HookManager.HookByHookName("GetEnvironmentVariableHookStringEnvironmentVariableTarget");

                //Sets the title for the log
                string functionName = "Environment.GetEnvironmentVariable(string variable, EnvironmentVariableTarget target)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetEnvironmentVariableStringEnvironmentVariableTarget(), new object[] { variable, target }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetEnvironmentVariablesHookString(string variable)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetEnvironmentVariablesHookString");
                //Call the original function
                output = Environment.GetEnvironmentVariable(variable);
                //Restore the hook
                HookManager.HookByHookName("GetEnvironmentVariablesHookString");

                //Sets the title for the log
                string functionName = "Environment.GetEnvironmentVariable(string variable)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetEnvironmentVariableString(), new object[] { variable }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IDictionary GetEnvironmentVariablesHookEnvironmentVariableTarget(EnvironmentVariableTarget target)
        {
            //Declare the local variable to store the object in
            IDictionary output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetEnvironmentVariablesHookEnvironmentVariableTarget");
                //Call the original function
                output = Environment.GetEnvironmentVariables(target);
                //Restore the hook
                HookManager.HookByHookName("GetEnvironmentVariablesHookEnvironmentVariableTarget");

                //Sets the title for the log
                string functionName = "Environment.GetEnvironmentVariables(EnvironmentVariableTarget target)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetEnvironmentVariablesEnvironmentVariableTarget(), new object[] { target }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IDictionary GetEnvironmentVariablesHook()
        {
            //Declare the local variable to store the object in
            IDictionary output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetEnvironmentVariablesHook");
                //Call the original function
                output = Environment.GetEnvironmentVariables();
                //Restore the hook
                HookManager.HookByHookName("GetEnvironmentVariablesHook");

                //Sets the title for the log
                string functionName = "Environment.GetEnvironmentVariables()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetEnvironmentVariables(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFolderPathHookSpecialFolderSpecialFolderOption(SpecialFolder folder, SpecialFolderOption option)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetFolderPathHookSpecialFolderSpecialFolderOption");
                //Call the original function
                output = Environment.GetFolderPath(folder, option);
                //Restore the hook
                HookManager.HookByHookName("GetFolderPathHookSpecialFolderSpecialFolderOption");

                //Sets the title for the log
                string functionName = "Environment.GetFolderPath(SpecialFolder folder, SpecialFolderOption option)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetFolderPathSpecialFolderSpecialFolderOption(), new object[] { folder, option }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFolderPathHookSpecialFolder(SpecialFolder folder)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetFolderPathHookSpecialFolder");
                //Call the original function
                output = Environment.GetFolderPath(folder);
                //Restore the hook
                HookManager.HookByHookName("GetFolderPathHookSpecialFolder");

                //Sets the title for the log
                string functionName = "Environment.GetFolderPath(SpecialFolder folder)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetFolderPathSpecialFolder(), new object[] { folder }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] GetLogicalDrivesHook()
        {
            //Declare the local variable to store the object in
            string[] output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetLogicalDrivesHook");
                //Call the original function
                output = Environment.GetLogicalDrives();
                //Restore the hook
                HookManager.HookByHookName("GetLogicalDrivesHook");

                //Sets the title for the log
                string functionName = "Environment.GetLogicalDrives()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentGetLogicalDrives(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetEnvironmentVariableHookStringStringEnvironmentVariableTarget(string variable, string value, EnvironmentVariableTarget target)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("SetEnvironmentVariableHookStringStringEnvironmentVariableTarget");
                //Call the original function
                Environment.SetEnvironmentVariable(variable, value, target);
                //Restore the hook
                HookManager.HookByHookName("SetEnvironmentVariableHookStringStringEnvironmentVariableTarget");

                //Sets the title for the log
                string functionName = "SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentSetEnvironmentVariableStringStringEnvironmentVariableTarget(), new object[] { variable, value, target }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetEnvironmentVariableHookStringString(string variable, string value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("SetEnvironmentVariableHookStringStringEnvironmentVariableTarget");
                //Call the original function
                Environment.SetEnvironmentVariable(variable, value);
                //Restore the hook
                HookManager.HookByHookName("SetEnvironmentVariableHookStringStringEnvironmentVariableTarget");

                //Sets the title for the log
                string functionName = "SetEnvironmentVariable(string variable, string value)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.EnvironmentSetEnvironmentVariableStringString(), new object[] { variable, value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetResourceFromDefaultHookString(string key)
        {
            object result = null;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookAll();
                //Call the original function
                result = OriginalManagedFunctions.EnvironmentGetResourceFromDefaultString().Invoke(null, new object[] { key });


                //Sets the title for the log
                string functionName = "SetEnvironmentVariable(string variable, string value)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.EnvironmentGetResourceFromDefaultString(), new object[] { key }, result);
                //Restore the hook
                HookManager.HookAll();
            }
            return (string)result;
        }
    }
}
