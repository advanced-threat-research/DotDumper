using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using DotDumper.Helpers;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper
{
    /// <summary>
    /// This class is used to log data to both the standard output, as well as the designated logging file. This allows the analyst to view DotDumper's output in real time, if so desired.
    /// </summary>
    class Logger
    {
        /// <summary>
        /// The list of log entries that were logged during the current run of DotDumper
        /// </summary>
        private List<LogEntry> _logEntries;

        /// <summary>
        /// The folder where the log file, as well as other files, are stored. This folder is based in the current directory of DotDumper.exe, where the name is user defined. This string does not end with a backslash.
        /// </summary>
        public readonly string Folder;

        /// <summary>
        /// The full path to the log file, called log.txt
        /// </summary>
        private readonly string LogFileText;

        /// <summary>
        /// The full path to the log file, called log.json
        /// </summary>
        private readonly string LogFileJson;

        /// <summary>
        /// The full path to the log file, called log.xml
        /// </summary>
        private readonly string LogFileXml;

        /// <summary>
        /// The amount of logs that were written using this instance of the logger
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Creates a logger object, which can then be used to log data to the standard output, and the log file. The log file, as well as dropped artifacts, are stored in a subfolder of DotDumper's folder. The subfolder's name is provided as a parameter in this constructor. This subfolder does not need to exist yet, as it will be created if need be.
        /// </summary>
        public Logger()
        {
            //Initialises the log entry list
            _logEntries = new List<LogEntry>();
            Count = 0;

            //Sets the variables
            Folder = Directory.GetCurrentDirectory() + @"\" + Config.LoggerFolder;
            LogFileText = Folder + @"\log.txt";
            LogFileJson = Folder + @"\log.json";
            LogFileXml = Folder + @"\log.xml";

            /*
             * The logger is initialised prior to the hooks being set, 
             * meaning these calls do not need to be unhooked and hooked.
             * In fact, doing so would create errors later on
             */

            //Creates the directory if it doesn't already. If the directory already exists, this call is redundant
            Directory.CreateDirectory(Folder);

            //Create the opening message with DotDumper's version
            string message = Program.VERSION + "\n";
            //Add the text to the log file. If the file does not exist, it is created, after which the data is then appended
            File.AppendAllText(LogFileText, message);
            //Write the text to the standard output, if the configuration allows
            if (Config.PrintLogsToConsole)
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Log a call, but only if it is coming from a sample, based on the stack trace, it should not originate from DotDumper or any GAC module.
        /// Logging means that the human readable log is written to the log.txt file, as well as printed in the console window. Additionally, JSON
        /// and XML versions of the logs are written to log.json and log.xml respectively. All files reside in the logging folder, which is either 
        /// provided by the user upon the start-up of DotDumper. If it is not provided, the name of the sample (without an extension, if there is one)
        /// is used as the base for a folder name, which is then appended with "_DotDumper" until there is no such folder already.
        /// 
        /// Note that this function will set all hooks upon returning
        /// </summary>
        /// <param name="stackTraceOffset">The amount of layers the caller of this function is away from the original flow of the program</param>
        /// <param name="method">The method of importance, which corresponds with the other arguments in this function call</param>
        /// <param name="parameterValues">The values (in order of calling them as-if they were code) of the arguments of the given method</param>
        /// <param name="returnValue">The return value of the method (use null if the return type is void)</param>
        public void LogSampleCall(int stackTraceOffset, MethodBase method, object[] parameterValues, object returnValue)
        {
            //Increment by one since this function has been entered
            stackTraceOffset++;
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);
            if (isFromSample)
            {
                Log(stackTraceOffset, method, parameterValues, returnValue);
            }
            else
            {
                MissedAssemblyDumper.Dump();
            }
        }

        /// <summary>
        /// Log a call. Logging means that the human readable log is written to the log.txt file, as well as printed in the console window. 
        /// Additionally, JSON and XML versions of the logs are written to log.json and log.xml respectively. All files reside in the 
        /// logging folder, which is either provided by the user upon the start-up of DotDumper. If it is not provided, the name of the 
        /// sample (without an extension, if there is one) is used as the base for a folder name, which is then appended with "_DotDumper"
        /// until there is no such folder already.
        /// 
        /// Note that this function will set all hooks upon returning
        /// </summary>
        /// <param name="stackTraceOffset">The amount of layers the caller of this function is away from the original flow of the program</param>
        /// <param name="method">The method of importance, which corresponds with the other arguments in this function call</param>
        /// <param name="parameterValues">The values (in order of calling them as-if they were code) of the arguments of the given method</param>
        /// <param name="returnValue">The return value of the method (use null if the return type is void)</param>
        public void Log(int stackTraceOffset, MethodBase method, object[] parameterValues, object returnValue)
        {
            //Increment by one since this function has been entered
            stackTraceOffset++;
            //Create the log entry
            LogEntry entry = LogEntryHelper.Create(stackTraceOffset, method, parameterValues, returnValue);
            //Call the logging function
            Log(entry, false, true);
        }

        /// <summary>
        /// Log a call. Logging means that the human readable log is written to the log.txt file, as well as printed in the console window. 
        /// Additionally, JSON and XML versions of the logs are written to log.json and log.xml respectively. All files reside in the 
        /// logging folder, which is either provided by the user upon the start-up of DotDumper. If it is not provided, the name of the 
        /// sample (without an extension, if there is one) is used as the base for a folder name, which is then appended with "_DotDumper"
        /// until there is no such folder already.
        /// </summary>
        /// <param name="entry">The entry to log</param>
        /// <param name="ignoreHooks">Defines if the hooks should be ignored (meaning it operates via normal calls), or if the hooks should be disabled prior to logging, and enabled afterwards</param>
        /// <param name="periodicDump">Defines if the periodic dump check should be performed, which dumps missed Assembly objects when they are found</param>
        public void Log(LogEntry entry, bool ignoreHooks, bool periodicDump)
        {
            //If the entry is null, no logs are written
            if (entry != null)
            {
                Count++;
                //Add the entry to the list of entries, seeing as it's not null
                _logEntries.Add(entry);
                //Get the entries in JSON format
                string json = Serialise.ToJson(_logEntries);
                //Get the entries in XML format
                string xml = Serialise.ToXml(_logEntries);
                //Get the entries in human readable format
                string plaintext = LogEntry2HumanReadablePlaintext(entry);

                /*
                 * Write data to the respective files by appending the human readable log, 
                 * and by overwriting the JSON and XML lists, as those cannot be appended to 
                 * in the same manner
                 * 
                 * If the hooks are to  be ignored, the nromal functions should be called
                 */
                if (ignoreHooks)
                {
                    HookManager.UnHookAll();
                    //Creates the folder where the log files are stored if it doesn't exist
                    Directory.CreateDirectory(Folder);
                    File.AppendAllText(LogFileText, plaintext);
                    File.WriteAllText(LogFileJson, json);
                    File.WriteAllText(LogFileXml, xml);
                    if (Config.PrintLogsToConsole)
                    {
                        Console.WriteLine(plaintext);
                    }
                    HookManager.HookAll();
                }
                else //If not, the functions need to be unhooked, called, and hooked again
                { //Unhooks all hooks, calls the original function, and sets all hooks again, for each call
                    GenericHookHelper.DirectoryCreateDirectory(Folder);
                    GenericHookHelper.FileAppendAllText(LogFileText, plaintext);
                    GenericHookHelper.FileWriteAllBytes(LogFileJson, Encoding.Default.GetBytes(json));
                    GenericHookHelper.FileWriteAllBytes(LogFileXml, Encoding.Default.GetBytes(xml));
                    if (Config.PrintLogsToConsole)
                    {
                        GenericHookHelper.ConsoleWriteLine(plaintext);
                    }
                }
            }

            /*
             * Dump the missing assemblies, depending on the specified boolean. The dumping is 
             * not used in several cases when logging data before the hooks are set. Calling this function
             * restores all hooks, which leads to errors in those cases, hence this split set-up
             */
            if (periodicDump)
            {
                MissedAssemblyDumper.Dump();
            }
        }

        /// <summary>
        /// Creates a human readable plaintext version of the given LogEntry object
        /// </summary>
        /// <param name="entry">The entry to convert</param>
        /// <returns>The converted entry, human readable in a string</returns>
        private string LogEntry2HumanReadablePlaintext(LogEntry entry)
        {
            //Assume the complete LogEntry instance is not null, the caller should check this
            //The date time stamp is made in the entry's constructor, meaning it's never null
            string functionName = "[no_function_name_found]";
            if (entry != null && entry.FunctionName != null)
            {
                functionName = entry.FunctionName;
            }
            string title = "[" + entry.DateTimeStamp + "] Hook for " + functionName + " hit!\n";

            /*
             * The message lay-out for human readable logs is as follows:
             * 
             * 1. Stack Trace
             * 2. Assembly call order
             * 3. Originating assembly information (name, version, resource names, hash)
             * 4. Parent assembly hash, if present
             * 5. Function argument names, types, and their respective values
             * 6. The return value and type
             * 7. Related files (by their SHA-256 hashes), if any
             * 
             * Entries that are empty or null are omitted, as are the headers for the section
             * if the complete section is missing or null. This ensures the log is easy
             * to read and contains as little clutter as possible.
             */

            //Initialise the string
            string message = "";

            //Add the stack trace
            if (entry.StackTrace != null && entry.StackTrace.Count > 0)
            {
                message += "--------StackTrace information--------\n";
                foreach (string line in entry.StackTrace)
                {
                    message += line + "\n";
                }
                message += "--------------------------------------\n\n";
            }


            //Add the assembly call order
            if (entry.AssemblyCallOrder != null && entry.AssemblyCallOrder.Count > 0)
            {
                message += "---------Assembly call order----------\n";
                foreach (AssemblyObject assembly in entry.AssemblyCallOrder)
                {
                    message += assembly.Name;
                    if (assembly.Hash.Equals("[none]", StringComparison.InvariantCultureIgnoreCase) == false)
                    {
                        message += " (SHA-256: " + assembly.Hash + ")";
                    }
                    message += "\n";

                }
                message += "--------------------------------------\n\n";
            }

            //Add originating information
            if (entry.OriginatingAssemblyName != null &&
                entry.OriginatingAssemblyVersion != null &&
                entry.OriginatingAssemblyHash != null &&
                entry.OriginatingAssemblyResourceNames != null &&
                entry.OriginatingAssemblyName.Equals("DotDumper", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                message += "---Originating assembly information---\n";
                message += "Name: " + entry.OriginatingAssemblyName + "\n";
                message += "Version: " + entry.OriginatingAssemblyVersion + "\n";
                message += "MD-5: " + entry.OriginatingAssemblyHash.Md5 + "\n";
                message += "SHA-1: " + entry.OriginatingAssemblyHash.Sha1 + "\n";
                message += "SHA-256: " + entry.OriginatingAssemblyHash.Sha256 + "\n";
                message += "SHA-384: " + entry.OriginatingAssemblyHash.Sha384 + "\n";
                message += "SHA-512: " + entry.OriginatingAssemblyHash.Sha512 + "\n";
                if (entry.OriginatingAssemblyHash.TypeRef != null && entry.OriginatingAssemblyHash.TypeRef.Length > 0)
                {
                    message += "TypeRef: " + entry.OriginatingAssemblyHash.TypeRef + "\n";
                }
                if (entry.OriginatingAssemblyHash.ImportHash != null && entry.OriginatingAssemblyHash.ImportHash.Length > 0)
                {
                    message += "ImportHash: " + entry.OriginatingAssemblyHash.ImportHash + "\n";
                }
                if (entry.OriginatingAssemblyHash.AuthenticodeSha256 != null && entry.OriginatingAssemblyHash.AuthenticodeSha256.Length > 0)
                {
                    message += "Authenticode (SHA-256 based): " + entry.OriginatingAssemblyHash.AuthenticodeSha256 + "\n";
                }

                if (entry.OriginatingAssemblyResourceNames != null && entry.OriginatingAssemblyResourceNames.Count > 0)
                {
                    message += "Resource names:\n";
                    foreach (string resourceName in entry.OriginatingAssemblyResourceNames)
                    {
                        message += "\t" + resourceName + "\n";
                    }
                }

                message += "--------------------------------------\n\n";
            }

            //Add parent assembly hash

            if (entry.ParentAssemblyHash != null && entry.ParentAssemblyHash.Equals("[none]", StringComparison.InvariantCultureIgnoreCase) == false)
            {
                message += "---------Parent assembly hash---------\n";
                message += entry.ParentAssemblyHash;
                message += "\n--------------------------------------\n\n";
            }


            //Add argument names, types, and values
            if (entry.FunctionArguments != null && entry.FunctionArguments.Count > 0)
            {
                message += "----Function argument information-----\n";
                for (int i = 0; i < entry.FunctionArguments.Count; i++)
                {
                    //Get the current object
                    Argument argument = entry.FunctionArguments[i];

                    //Add details for the current argument to the message
                    message += "Type:  \"" + argument.Type + "\"\n";
                    message += "Name:  \"" + argument.Name + "\"\n";
                    message += "Value: \"" + argument.Value + "\"\n";

                    //If there are more arguments after this, add a new line for readability
                    if ((entry.FunctionArguments.Count - 1) > i)
                    {
                        message += "\n";
                    }
                }
                message += "--------------------------------------\n\n";
            }

            //Add the return value
            if (entry.ReturnValue != null)
            {
                message += "-------------Return value-------------\n";
                message += "Type:  \"" + entry.ReturnValue.Type + "\"\n";
                message += "Name:  \"" + entry.ReturnValue.Name + "\"\n";
                message += "Value: \"" + entry.ReturnValue.Value + "\"\n";
                message += "--------------------------------------\n\n";
            }

            //Add related files
            if (entry.RelatedFileHashes != null && entry.RelatedFileHashes.Count > 0)
            {
                message += "------------Related files-------------\n";
                for (int i = 0; i < entry.RelatedFileHashes.Count; i++)
                {
                    //Get the current object
                    Hash hash = entry.RelatedFileHashes[i];

                    //Add details for the current argument to the message
                    message += "MD-5:  \"" + hash.Md5 + "\"\n";
                    message += "SHA-1:  \"" + hash.Sha1 + "\"\n";
                    message += "SHA-256: \"" + hash.Sha256 + "\"\n";
                    message += "SHA-384: \"" + hash.Sha384 + "\"\n";
                    message += "SHA-512: \"" + hash.Sha512 + "\"\n";
                    if (hash.TypeRef != null && hash.TypeRef.Length > 0)
                    {
                        message += "TypeRef: \"" + hash.TypeRef + "\"\n";
                    }
                    if (hash.ImportHash != null && hash.ImportHash.Length > 0)
                    {
                        message += "ImportHash: \"" + hash.ImportHash + "\"\n";
                    }
                    if (hash.AuthenticodeSha256 != null && hash.AuthenticodeSha256.Length > 0)
                    {
                        message += "Authenticode (SHA-256 based): \"" + hash.AuthenticodeSha256 + "\"\n";
                    }

                    //If there are more arguments after this, add a new line for readability
                    if ((entry.RelatedFileHashes.Count - 1) > i)
                    {
                        message += "\n";
                    }
                }
                message += "--------------------------------------\n\n";
            }

            return title + message;
        }
    }
}
