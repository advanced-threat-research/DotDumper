using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.IO;
using DotDumper.Helpers;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    /// <summary>
    /// This class provides helper functions that are used by multiple hook classes, thereby avoiding duplicate code blocks.
    /// </summary>
    class GenericHookHelper
    {
        /// <summary>
        /// The synchornisation object to ensure that multi-threaded malware does not cause two hooks to call the logger at the same time
        /// </summary>
        public static readonly object SyncLock = new object();

        /// <summary>
        /// The original sample that was loaded by DotDumper
        /// </summary>
        public static Assembly OriginalAssembly;

        /// <summary>
        /// The logger object to log data
        /// </summary>
        public static Logger _Logger;

        /// <summary>
        /// Gets the stack trace that leads to this function call, the amount of offset lines from the start. The removal is done to exclude hook related functions to end up in the trace, as that would clutter the overview.
        /// </summary>
        /// <param name="offset">The amount of lines to skip, equal to the amount of functions that are entered from the hook prior to this function (including the hook itself)</param>
        /// <returns>The stack trace to the call in the original code</returns>
        public static string GetStackTraceAndAssemblyMapping(int offset)
        {
            //Increment the offset, as the trace is requested in this function, which is another line/layer deep
            offset++;
            //Initialise the variable where the result will be stored
            string result = "---StackTrace information---\n";
            //Get the trace, split by lines
            List<string> stackTraceLines = GetStackTraceRaw(offset);

            //Add all lines from the given offset to the result variable, including a newline for each added line
            for (int i = 0; i < stackTraceLines.Count; i++)
            {
                result += stackTraceLines[i] + "\n";
            }
            result += "----------------------------\n\n";

            //Get the assembly call order from the mapper
            result += "-----Assembly call order-----\n";
            result += AssemblyMapper.ProcessStackTrace(stackTraceLines);
            result += "-----------------------------\n\n";

            //Return the result
            return result;
        }

        public static List<string> GetStackTraceRaw(int offset)
        {
            HookManager.UnHookAll();
            List<string> stackTraceLines = new List<string>();
            //Increment the offset, as the trace is requested in this function, which is another line/layer deep
            offset++;
            //Increment the offset by two as the stacktrace itself is two additional layers deep when requesting it
            offset += 2;
            //Initialise and simplify newlines in the stacktrace
            string rawStackTrace = Environment.StackTrace.Replace("\r\n", "\n");
            //Get the trace for each 
            string[] lines = rawStackTrace.Split(new char[] { '\n' });

            //If the given offset is too big or less than zero, ignore the value and simply return the complete stacktrace
            if (offset >= lines.Length || offset < 0)
            {
                offset = 0;
            }
            //Add all lines from the given offset to the result variable, including a newline for each added line
            for (int i = offset; i < lines.Length; i++)
            {
                stackTraceLines.Add(lines[i]);
            }
            HookManager.HookAll();
            //Return the result
            return stackTraceLines;
        }

        /// <summary>
        /// Saves the given data in the logger folder as a file, with the given file name (not starting with a backslash). If such a file already exists, it is overwritten without warning! This function is only to be used after the hooks are set, as all hooks are set prior to returning.
        /// </summary>
        /// <param name="fileName">The name of the file to save</param>
        /// <param name="data">The data to save</param>
        /// <returns>The complete path to the newly saved file</returns>
        public static string SaveFile(string fileName, byte[] data)
        {
            //Call Directory.CreateDirectory by unhooking the hooks, and hooking them afterwards
            DirectoryCreateDirectory(_Logger.Folder);
            //Create the full path, using the logging folder as the base
            string path = _Logger.Folder + @"\" + fileName;
            //Write all bytes using File.WriteAllBytes to the given path
            FileWriteAllBytes(path, data);
            //Return the full path of the newly saved file
            return path;
        }

        /// <summary>
        /// Saves the given data in the logger folder as a file, using the SHA-256 hash of the data as the file name (not starting with a backslash). If the file already exists, it is overwritten without warning! This function is only to be used after the hooks are set, as all hooks are set prior to returning.
        /// </summary>
        /// <param name="data">The data to save</param>
        /// <returns>A tuple, with the complete path to the newly saved file, and a hash object with the MD-5, SHA-1, and SHA-256 hash of the newly saved file</returns>
        public static Tuple<string, Models.Hash> SaveFile(byte[] data)
        {
            string md5 = Hashes.Md5(data);
            string sha1 = Hashes.Sha1(data);
            string sha256 = Hashes.Sha256(data);
            string path = SaveFile(sha256, data);
            return Tuple.Create(path, new Models.Hash(md5, sha1, sha256));
        }

        /// <summary>
        /// Saves the given string in the logger folder as a file, using the SHA-256 hash of the data as the file name (not starting with a backslash). If the file already exists, it is overwritten without warning! This function is only to be used after the hooks are set, as all hooks are set prior to returning.
        /// </summary>
        /// <param name="data">The data to save</param>
        /// <returns>The complete path to the newly saved file</returns>
        public static Tuple<string, Models.Hash> SaveFile(string data)
        {
            byte[] rawData = Encoding.Default.GetBytes(data);
            return SaveFile(rawData);
        }

        /// <summary>
        /// Removes all hooks, calls File.ReadAllBytes(string path) with the given path, and sets all hooks. The result of the function call is returned.
        /// </summary>
        /// <param name="path">The path to read the data from</param>
        /// <returns>The data that has been read from the given path</returns>
        public static byte[] FileReadAllBytes(string path)
        {
            HookManager.UnHookAll();
            byte[] data = File.ReadAllBytes(path);
            HookManager.HookAll();
            return data;
        }

        /// <summary>
        /// Removes all hooks, calls File.AppendAllText(string path, string contents) with the given path and contents, and sets all hooks.
        /// </summary>
        /// <param name="path">The path to append the contents to</param>
        /// <param name="contents">The text to append</param>
        public static void FileAppendAllText(string path, string contents)
        {
            HookManager.UnHookAll();
            File.AppendAllText(path, contents);
            HookManager.HookAll();
        }

        /// <summary>
        /// Removes all hooks, calls File.WriteAllBytes(string path, byte[] bytes) with the given path and bytes, and sets all hooks.
        /// </summary>
        /// <param name="path">The path to write all bytes to</param>
        /// <param name="bytes">The bytes to write</param>
        public static void FileWriteAllBytes(string path, byte[] bytes)
        {
            HookManager.UnHookAll();
            File.WriteAllBytes(path, bytes);
            HookManager.HookAll();
        }

        /// <summary>
        /// Removes all hooks, calls Path.GetFileName(string path) with the given path, sets all hooks, and returns the file name
        /// </summary>
        /// <param name="path">The path to get the file name from</param>
        /// <returns>The file name of the file at the given path</returns>
        public static string PathGetFileName(string path)
        {
            HookManager.UnHookAll();
            string fileName = Path.GetFileName(path);
            HookManager.HookAll();
            return fileName;
        }

        /// <summary>
        /// Removes the hook named "SleepHookInt", calls Thread.Sleep(int milliseconds) with the given milliseconds, and sets the hook named "SleepHookInt".
        /// </summary>
        /// <param name="milliseconds">The amount of milliseconds to sleep</param>
        public static void ThreadSleep(int milliseconds)
        {
            HookManager.UnHookByHookName("SleepHookInt");
            Thread.Sleep(milliseconds);
            HookManager.HookByHookName("SleepHookInt");
        }

        /// <summary>
        /// Removes all hooks, calls Directory.CreateDirectory(string folder) with the given folder, and sets all hooks.
        /// </summary>
        /// <param name="folder">The folder to create</param>
        /// <returns>The relevant DirectoryInfo object</returns>
        public static DirectoryInfo DirectoryCreateDirectory(string folder)
        {
            HookManager.UnHookAll();
            DirectoryInfo directoryInfo = Directory.CreateDirectory(folder);
            HookManager.HookAll();
            return directoryInfo;
        }

        /// <summary>
        /// Removes all hooks, calls Console.WriteLine(string value) with the given value, and sets all hooks
        /// </summary>
        /// <param name="value">The value to write to the standard output</param>
        public static void ConsoleWriteLine(string value)
        {
            HookManager.UnHookAll();
            Console.WriteLine(value);
            HookManager.HookAll();
        }

        /// <summary>
        /// Gets the raw data of the given Assembly object. This function removes all hooks, after which the raw data is obtained reflectively. All hooks are then set.
        /// </summary>
        /// <param name="assembly">The Assembly object to get the raw data from</param>
        /// <returns>The raw bytes of the given Assembly object</returns>
        public static byte[] GetAsByteArray(Assembly assembly)
        {
            HookManager.UnHookAll();
            //Taken from https://stackoverflow.com/a/46209735
            Hash hash = new Hash(assembly);
            byte[] rawAssembly = (byte[])hash.GetType().GetMethod("GetRawData", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(hash, new object[0]);
            HookManager.HookAll();
            return rawAssembly;
        }
    }
}
