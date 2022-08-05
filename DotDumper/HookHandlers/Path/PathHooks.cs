using System.IO;
using System.Runtime.CompilerServices;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class PathHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ChangeExtensionHookStringString(string path, string extension)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ChangeExtensionHookStringString");
                //Call the original function
                output = Path.ChangeExtension(path, extension);
                //Restore the hook
                HookManager.HookByHookName("ChangeExtensionHookStringString");

                //Sets the title for the log
                string functionName = "Path.ChangeExtension(string path, string extension)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathChangeExtensionStringString(), new object[] { path, extension }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CombineHookStringString(string path1, string path2)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CombineHookStringString");
                //Call the original function
                output = Path.Combine(path1, path2);
                //Restore the hook
                HookManager.HookByHookName("CombineHookStringString");

                //Sets the title for the log
                string functionName = "Path.Combine(string path1, string path2)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathCombineStringString(), new object[] { path1, path2 }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CombineHookStringStringString(string path1, string path2, string path3)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CombineHookStringStringString");
                //Call the original function
                output = Path.Combine(path1, path2, path3);
                //Restore the hook
                HookManager.HookByHookName("CombineHookStringStringString");

                //Sets the title for the log
                string functionName = "Path.Combine(string path1, string path2, string path3)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathCombineStringStringString(), new object[] { path1, path2, path3 }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CombineHookStringStringStringString(string path1, string path2, string path3, string path4)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CombineHookStringStringStringString");
                //Call the original function
                output = Path.Combine(path1, path2, path3, path4);
                //Restore the hook
                HookManager.HookByHookName("CombineHookStringStringStringString");

                //Sets the title for the log
                string functionName = "Path.Combine(string path1, string path2, string path3, string path4)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathCombineStringStringStringString(), new object[] { path1, path2, path3, path4 }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string CombineHookStringArray(string[] paths)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CombineHookStringArray");
                //Call the original function
                output = Path.Combine(paths);
                //Restore the hook
                HookManager.HookByHookName("CombineHookStringArray");

                //Sets the title for the log
                string functionName = "Path.Combine(string[] paths)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathCombineStringArray(), new object[] { paths }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDirectoryNameHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetDirectoryNameHookString");
                //Call the original function
                output = Path.GetDirectoryName(path);
                //Restore the hook
                HookManager.HookByHookName("GetDirectoryNameHookString");

                //Sets the title for the log
                string functionName = "Path.GetDirectoryName(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetDirectoryNameString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetExtensionHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetExtensionHookString");
                //Call the original function
                output = Path.GetExtension(path);
                //Restore the hook
                HookManager.HookByHookName("GetExtensionHookString");

                //Sets the title for the log
                string functionName = "Path.GetExtension(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetExtensionString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFileNameHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetFileNameHookString");
                //Call the original function
                output = Path.GetFileName(path);
                //Restore the hook
                HookManager.HookByHookName("GetFileNameHookString");

                //Sets the title for the log
                string functionName = "Path.GetFileName(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetFileNameString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFileNameWithoutExtensionHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetFileNameWithoutExtensionHookString");
                //Call the original function
                output = Path.GetFileNameWithoutExtension(path);
                //Restore the hook
                HookManager.HookByHookName("GetFileNameWithoutExtensionHookString");

                //Sets the title for the log
                string functionName = "Path.GetFileNameWithoutExtension(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetFileNameWithoutExtensionString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetFullPathHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetFullPathHookString");
                //Call the original function
                output = Path.GetFullPath(path);
                //Restore the hook
                HookManager.HookByHookName("GetFullPathHookString");

                //Sets the title for the log
                string functionName = "Path.GetFullPath(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetFullPathString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetPathRootHookString(string path)
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetPathRootHookString");
                //Call the original function
                output = Path.GetPathRoot(path);
                //Restore the hook
                HookManager.HookByHookName("GetPathRootHookString");

                //Sets the title for the log
                string functionName = "Path.GetPathRoot(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetPathRootString(), new object[] { path }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetRandomFileNameHook()
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetRandomFileNameHook");
                //Call the original function
                output = Path.GetRandomFileName();
                //Restore the hook
                HookManager.HookByHookName("GetRandomFileNameHook");

                //Sets the title for the log
                string functionName = "Path.GetRandomFileName()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetRandomFileName(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTempFileNameHook()
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetTempFileNameHook");
                //Call the original function
                output = Path.GetTempFileName();
                //Restore the hook
                HookManager.HookByHookName("GetTempFileNameHook");

                //Sets the title for the log
                string functionName = "Path.GetTempFileName()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetTempFileName(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetTempPathHook()
        {
            //Declare the local variable to store the object in
            string output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetTempPathHook");
                //Call the original function
                output = Path.GetTempPath();
                //Restore the hook
                HookManager.HookByHookName("GetTempPathHook");

                //Sets the title for the log
                string functionName = "Path.GetTempPath()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.PathGetTempPath(), new object[] { }, output);
            }

            //Return the object to the caller
            return output;
        }
    }
}
