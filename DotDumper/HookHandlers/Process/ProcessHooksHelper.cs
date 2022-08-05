
using System.Diagnostics;

namespace DotDumper.HookHandlers
{
    class ProcessHooksHelper
    {
        private static readonly int offset = 2;
        private static string GetProcessInfo(Process process)
        {
            string output = "---Process information---\n";
            output += "File name: " + process.StartInfo.FileName + "\n";
            output += "Process name: " + process.ProcessName + "\n";
            output += "Process ID: " + process.Id + "\n";
            output += "Arguments: " + process.StartInfo.Arguments + "\n";
            output += "User name to launch with: " + process.StartInfo.UserName + "\n";
            output += "Password to launch with: " + process.StartInfo.PasswordInClearText + "\n";
            output += "Process working directory: " + process.StartInfo.WorkingDirectory + "\n";
            output += "Domain: " + process.StartInfo.Domain + "\n";
            output += "Machine name: " + process.MachineName + "\n";
            output += "Window style: " + process.StartInfo.WindowStyle + "\n";
            output += "Uses system shell to start the process: " + process.StartInfo.UseShellExecute + "\n";
            output += "\n";
            return output;
        }

        public static void Process(string functionName)
        {
            string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(offset);

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(functionName, message);
        }

        public static void Process(string functionName, string machineName)
        {
            string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(offset);
            message += "Requested machine name: " + machineName + "\n\n"; ;

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(functionName, message);
        }

        public static void Process(string functionName, Process process)
        {
            string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(offset);
            message += GetProcessInfo(process);

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(functionName, message);
        }

        public static void Process(string functionName, string processName, Process[] processes)
        {
            Process(functionName, processName, null, processes, offset);
        }

        public static void Process(string functionName, string processName, string machineName, Process[] processes)
        {
            Process(functionName, processName, machineName, processes, offset);
        }

        private static void Process(string functionName, string processName, string machineName, Process[] processes, int stackTraceOffset)
        {
            stackTraceOffset++;
            string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
            message += "Listing all processes that match \"" + processName + "\":\n";
            if (machineName != null)
            {
                message += "Results limited to processes that run on \"" + machineName + "\"\n";
            }

            foreach (Process process in processes)
            {
                message += GetProcessInfo(process);
            }

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(functionName, message);
        }
    }
}
