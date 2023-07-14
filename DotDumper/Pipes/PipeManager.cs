using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using DotDumper.Helpers;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.Pipes
{
    class PipeManager
    {
        /// <summary>
        /// The named pipe's name
        /// </summary>
        public static string PIPE_NAME = "dotdumper";

        /// <summary>
        /// The named pipe to communicate with the unmanaged DLL to handle unmanaged hooks
        /// </summary>
        public static NamedPipeServerStream Pipe = new NamedPipeServerStream(PIPE_NAME, PipeDirection.InOut, 100, PipeTransmissionMode.Byte);

        /// <summary>
        /// Creates the thread which handles the incoming data
        /// </summary>
        public static void Initialise()
        {
            //Creates a new thread to handle incoming calls
            Thread newThread = new Thread(new ThreadStart(HandlePipeCalls));
            /*
             * Sets the priority to the highest, which is required. Otherwise, the original sample will continue its execution
             * before the interaction with the pipe and the logging thereof is not finished before another thread (usually DotDumper's 
             * main thread, via which the malware executes) is given priority.
             */
            newThread.Priority = ThreadPriority.Highest;
            //Start the new thread
            newThread.Start();
        }

        /// <summary>
        /// Handles named pipe interactions
        /// </summary>
        public static void HandlePipeCalls()
        {
            //If the pipe isn't initialised (or has been closed for any reason), an error is thrown and logged
            if (Pipe == null)
            {
                LogEntry error = LogEntryHelper.Create(0, new Exception("Pipe not found for name: " + PIPE_NAME));
                GenericHookHelper._Logger.Log(error, false, true);
                return;
            }

            //If there is no connection yet, wait for it to come in
            if (Pipe.IsConnected == false)
            {
                Pipe.WaitForConnection();
            }

            //The writer is used to write data to the pipe
            StreamWriter writer = new StreamWriter(Pipe);
            //Automatically write data after a write call is made
            writer.AutoFlush = true;
            //The variable to fetch raw bytes from the named pipe
            byte[] buffer;


            //Loop endlessly once this segment is reached, waiting for communication from the unmanaged DLL
            while (true)
            {
                //Gets the buffer from the pipe
                buffer = GetBufferFromPipe();
                //Converts the given bytes to a UTF-8 string
                string input = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

                //If the input starts with unhook, the specified function is unhooked
                if (input != null && input.StartsWith("unhook-", StringComparison.InvariantCultureIgnoreCase))
                {
                    string hookName = input.Substring("unhook-".Length);
                    bool unhookResult = HookManager.UnHookByHookName(hookName);
                    //HookManager.UnHookAll();
                }

                //If the input starts with hook, the specified function is hooked
                if (input != null && input.StartsWith("hook-", StringComparison.InvariantCultureIgnoreCase))
                {
                    string hookName = input.Substring("hook-".Length);
                    bool hookResult = HookManager.HookByHookName(hookName);
                    //HookManager.HookAll();
                }

                //If the input starts with log, the specified function is logged
                if (input != null && input.StartsWith("log-", StringComparison.InvariantCultureIgnoreCase))
                {
                    string functionName = input.Substring("log-".Length);
                    LogEntry logEntry = null;
                    switch (functionName)
                    {
                        case "MessageBoxW":
                            logEntry = HandleMessageBoxW();
                            break;
                        case "WriteProcessMemory":
                            logEntry = HandleWriteProcessMemory();
                            break;
                        case "CreateProcessA":
                            logEntry = HandleCreateProcessA();
                            break;
                        case "CreateProcessW":
                            logEntry = HandleCreateProcessW();
                            break;
                        default:
                            logEntry = LogEntryHelper.Create(0, new Exception("Unknown function to log (\"" + functionName + "\"), as such all received data from the pipe is printed below:\n\n" + input));
                            break;
                    }

                    //If a log entry has been created, it is logged
                    if (logEntry != null)
                    {
                        GenericHookHelper._Logger.Log(logEntry, false, true);
                    }
                }
            }
        }

        private static LogEntry HandleMessageBoxW()
        {
            byte[] result = GetBufferFromPipe();
            string s = Encoding.Unicode.GetString(result, 0, result.Length);
            return LogEntryHelper.Create(OriginalUnmanagedFunctions.User32MessageBoxW(), new object[] { 0, s }, null);
        }

        private static LogEntry HandleWriteProcessMemory()
        {
            byte[] hProcessBytes = GetBufferFromPipe();

            //Is actually the process ID, not the raw handle
            string hProcess = Encoding.ASCII.GetString(hProcessBytes);

            byte[] lpBaseAddressBytes = GetBufferFromPipe();

            long lpBaseAddressLong;
            if (IntPtr.Size == 8)
            {
                lpBaseAddressLong = BitConverter.ToInt64(lpBaseAddressBytes, 0);
            }
            else
            {
                lpBaseAddressLong = BitConverter.ToInt32(lpBaseAddressBytes, 0);
            }
            string lpBaseAddress = "0x" + lpBaseAddressLong.ToString("x");

            byte[] lpBuffer = GetBufferFromPipe();

            string lpBufferLength = "0x" + int.Parse(("" + lpBuffer.Length)).ToString("x");

            //WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, IntPtr lpBuffer, int nSize, ref int lpNumberOfBytesWritten)
            return LogEntryHelper.Create(OriginalUnmanagedFunctions.Kernel32WriteProcessMemory(), new object[] { hProcess, lpBaseAddress, lpBuffer, lpBufferLength, null }, null);
        }

        private static LogEntry HandleCreateProcessA()
        {
            byte[] lpApplicationNameBytes = GetBufferFromPipe();
            string applicationName = Encoding.ASCII.GetString(lpApplicationNameBytes);

            byte[] lpCommandLineBytes = GetBufferFromPipe();
            string commandLine = Encoding.ASCII.GetString(lpCommandLineBytes);

            byte[] creationFlagsBytes = GetBufferFromPipe();
            string asciiFlags = Encoding.ASCII.GetString(creationFlagsBytes);

            string creationFlags = "0x" + int.Parse(asciiFlags).ToString("x");

            //string applicationName, IntPtr commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, int creationFlags, IntPtr environment, IntPtr currentDirectory, ref IntPtr startupInfo, ref IntPtr processInformation
            return LogEntryHelper.Create(OriginalUnmanagedFunctions.Kernel32CreateProcessA(), new object[] { applicationName, commandLine, null, null, null, creationFlags, null, null, null, null }, null);
        }

        private static LogEntry HandleCreateProcessW()
        {
            byte[] lpApplicationNameBytes = GetBufferFromPipe();
            string applicationName = Encoding.Unicode.GetString(lpApplicationNameBytes);

            byte[] lpCommandLineBytes = GetBufferFromPipe();
            string commandLine = Encoding.Unicode.GetString(lpCommandLineBytes);

            byte[] creationFlagsBytes = GetBufferFromPipe();
            string asciiFlags = Encoding.ASCII.GetString(creationFlagsBytes);

            string creationFlags = "0x" + int.Parse(asciiFlags).ToString("x");

            //string applicationName, IntPtr commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, int creationFlags, IntPtr environment, IntPtr currentDirectory, ref IntPtr startupInfo, ref IntPtr processInformation
            return LogEntryHelper.Create(OriginalUnmanagedFunctions.Kernel32CreateProcessW(), new object[] { applicationName, commandLine, null, null, null, creationFlags, null, null, null, null }, null);
        }

        /// <summary>
        /// Gets the buffer from the pipe, no larger than 10 000 bytes at a time
        /// </summary>
        /// <returns>The pipe's data</returns>
        private static byte[] GetBufferFromPipe()
        {
            //Create a buffer where the pipe's data is to be stored in
            byte[] buffer = new byte[10000];
            //Read the data
            int size = Pipe.Read(buffer, 0, 10000);
            //Create the subset (and return it) for the number of read bytes from the buffer
            return GetSubArray(buffer, 0, size);
        }

        /// <summary>
        /// Gets a subset of the byte array, starting at the given index, equal to count's value in size
        /// </summary>
        /// <param name="buffer">The buffer to take the subset from</param>
        /// <param name="index">The index to start at</param>
        /// <param name="count">The number of bytes to take from the buffer</param>
        /// <returns>The byte array subset, or an empty byte array if the values would overflow</returns>
        private static byte[] GetSubArray(byte[] buffer, int index, int count)
        {
            //Gets the length of the buffer
            int length = buffer.Length;

            /*
             * If the index is larger or equal to the length, it'd result in an index out of bounds error.
             * 
             * If the count is more than the length, the subset would be larger than the buffer, which (eventually) results in an index out of bounds error.
             * 
             * If the index plus the count (which is equal to the length of the subset) is larger than the buffer's length, it will result in an index out of bounds error.
             */
            if (index >= length || count > length || (index + count) > length)
            {
                return new byte[0];
            }

            //Create the new buffer
            byte[] subset = new byte[count];
            for (int i = 0; i < count; i++)
            {
                //Copy each byte, starting at the given offset
                subset[i] = buffer[index + i];
            }

            //Return the newly created subset
            return subset;
        }
    }
}
