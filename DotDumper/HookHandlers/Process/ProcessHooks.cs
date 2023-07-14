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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.GetCurrentProcess();
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.GetProcessById(processId, machineName);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.GetProcessById(processId);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                processes = Process.GetProcesses();
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                processes = Process.GetProcesses(machineName);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                processes = Process.GetProcessesByName(processName);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                processes = Process.GetProcessesByName(processName, machineName);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.Start(fileName, arguments);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.Start(startInfo);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.Start(fileName);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.Start(fileName, arguments, userName, password, domain);
                //Restore the hooks
                HookManager.HookAll();

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
                //Disable the placed hooks
                HookManager.UnHookAll();
                //Call the original function
                process = Process.Start(fileName, userName, password, domain);
                //Restore the hooks
                HookManager.HookAll();

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ProcessStartStringStringSecureStringString(), new object[] { fileName, userName, password, domain }, process);
            }
            //Return the process object to the caller
            return process;
        }
    }
}
