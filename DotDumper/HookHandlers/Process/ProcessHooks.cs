using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ProcessHooks
    {

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process GetCurrentProcessHook()
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetCurrentProcessHook");
                //Call the original function
                process = Process.GetCurrentProcess();
                //Restore the hook
                HookManager.HookByHookName("GetCurrentProcessHook");

                //Sets the title for the log
                string functionName = "Process.GetCurrentProcess()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetCurrentProcess(), new object[] { }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process GetProcessByIdHookIntString(int processId, string machineName)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessByIdHookIntString");
                //Call the original function
                process = Process.GetProcessById(processId, machineName);
                //Restore the hook
                HookManager.HookByHookName("GetProcessByIdHookIntString");

                //Sets the title for the log
                string functionName = "Process.GetProcessById(int processId, string machineName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcessByIdIntString(), new object[] { processId, machineName }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process GetProcessByIdHookInt(int processId)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessByIdHookIntString");
                //Call the original function
                process = Process.GetProcessById(processId);
                //Restore the hook
                HookManager.HookByHookName("GetProcessByIdHookIntString");

                //Sets the title for the log
                string functionName = "Process.GetProcessById(int processId)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcessByIdInt(), new object[] { processId }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process[] GetProcessesHook()
        {
            //Declare the local variable to store the process objects in
            Process[] processes;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessesHook");
                //Call the original function
                processes = Process.GetProcesses();
                //Restore the hook
                HookManager.HookByHookName("GetProcessesHook");

                //Sets the title for the log
                string functionName = "Process.GetProcesses()";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcesses(), new object[] { }, processes);
            }

            //Return the process object to the caller
            return processes;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process[] GetProcessesHookString(string machineName)
        {
            //Declare the local variable to store the process objects in
            Process[] processes;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessesHookString");
                //Call the original function
                processes = Process.GetProcesses(machineName);
                //Restore the hook
                HookManager.HookByHookName("GetProcessesHookString");

                //Sets the title for the log
                string functionName = "Process.GetProcesses(string machineName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcessesString(), new object[] { machineName }, processes);
            }

            //Return the process object to the caller
            return processes;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process[] GetProcessesByNameHookString(string processName)
        {
            //Declare the local variable to store the process objects in
            Process[] processes;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessesByNameHookString");
                //Call the original function
                processes = Process.GetProcessesByName(processName);
                //Restore the hook
                HookManager.HookByHookName("GetProcessesByNameHookString");

                //Sets the title for the log
                string functionName = "Process.GetProcessesByName(string processName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcessesByNameString(), new object[] { processName }, processes);
            }

            //Return the process object to the caller
            return processes;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process[] GetProcessesByNameHookStringString(string processName, string machineName)
        {
            //Declare the local variable to store the process objects in
            Process[] processes;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("GetProcessesByNameHookStringString");
                //Call the original function
                processes = Process.GetProcessesByName(processName, machineName);
                //Restore the hook
                HookManager.HookByHookName("GetProcessesByNameHookStringString");

                //Sets the title for the log
                string functionName = "Process.GetProcessesByName(string processName, string machineName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessGetProcessesByNameStringString(), new object[] { processName, machineName }, processes);
            }

            //Return the process object to the caller
            return processes;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process ProcessStartHookStringString(string fileName, string arguments)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ProcessStartHookStringString");
                //Call the original function
                process = Process.Start(fileName, arguments);
                //Restore the hook
                HookManager.HookByHookName("ProcessStartHookStringString");

                //Sets the title for the log
                string functionName = "Process.Start(string fileName, string arguments)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartStringString(), new object[] { fileName, arguments }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process ProcessStartHookProcessStartInfo(ProcessStartInfo startInfo)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ProcessStartHookProcessStartInfo");
                //Call the original function
                process = Process.Start(startInfo);
                //Restore the hook
                HookManager.HookByHookName("ProcessStartHookProcessStartInfo");

                //Sets the title for the log
                string functionName = "Process.Start(ProcessStartInfo startInfo)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartProcessStartInfo(), new object[] { startInfo }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process ProcessStartHookString(string fileName)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ProcessStartHookString");
                //Call the original function
                process = Process.Start(fileName);
                //Restore the hook
                HookManager.HookByHookName("ProcessStartHookString");

                //Sets the title for the log
                string functionName = "Process.Start(string fileName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartString(), new object[] { fileName }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process ProcessStartHookStringStringStringSecureStringString(string fileName, string arguments, string userName, SecureString password, string domain)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ProcessStartHookStringStringStringSecureStringString");
                //Call the original function
                process = Process.Start(fileName, arguments, userName, password, domain);
                //Restore the hook
                HookManager.HookByHookName("ProcessStartHookStringStringStringSecureStringString");

                //Sets the title for the log
                string functionName = "Process.Start(string fileName, string arguments, string userName, SecureString password, string domain)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartStringStringStringSecureStringString(), new object[] { fileName, arguments, userName, password, domain }, process);
            }

            //Return the process object to the caller
            return process;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Process ProcessStartHookStringStringSecureStringString(string fileName, string userName, SecureString password, string domain)
        {
            //Declare the local variable to store the process object in
            Process process;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ProcessStartHookStringStringSecureStringString");
                //Call the original function
                process = Process.Start(fileName, userName, password, domain);
                //Restore the hook
                HookManager.HookByHookName("ProcessStartHookStringStringSecureStringString");

                //Sets the title for the log
                string functionName = "Process.Start(string fileName, string userName, SecureString password, string domain)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartStringStringSecureStringString(), new object[] { fileName, userName, password, domain }, process);
            }
            //Return the process object to the caller
            return process;
        }

        //void Kill();
        //void Close();
    }
}
