using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using DotDumper.Helpers;

namespace DotDumper.HookHandlers
{
    class FileHooksHelper
    {

        private static string ReadFileSecurity(FileSecurity fileSecurity)
        {
            string output = "";
            foreach (AuthorizationRuleCollection ruleCollection in fileSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
                foreach (FileSystemAccessRule rule in ruleCollection)
                {
                    output += "\t\t-----------------------------------------------------------------\n";
                    output += "\t\tIdentityReference: " + rule.IdentityReference + "\n";
                    output += "\t\tAccessControlType: " + rule.AccessControlType + "\n";
                    output += "\t\tFileSystemRights: " + rule.FileSystemRights + "\n";
                    output += "\t\t-----------------------------------------------------------------\n";
                }
            }
            return output;
        }

        private static string ArrayToString(string[] lines)
        {
            string text = "";
            foreach (string s in lines)
            {
                text += s + "\n";
            }
            return text;
        }

        private static void Append(string functionName, string path, string content, Encoding encoding, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The following content is to be added to \"" + path + "\":\n"
                    + content;

                //Save the data to the disk, whilst returning the full path to the file
               // string filePath = GenericHookHelper.SaveFile(content);

                //Add the module dump to the log, including the full path
                //message += "Wrote " + content.Length + " characters to \"" + filePath + "\"\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(OriginalFunctions.FileAppendAllTextStringStringEncoding(), new object[] {path, content, encoding}, 
            }
            else
            {
                ////GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Append(string functionName, string path, IEnumerable<string> contents)
        {

            Append(functionName, path, ArrayToString(contents.ToArray()), null, 2);
        }

        public static void Append(string functionName, string path, IEnumerable<string> contents, Encoding encoding)
        {
            Append(functionName, path, ArrayToString(contents.ToArray()), encoding, 2);
        }

        public static void Append(string functionName, string path, string content)
        {
            Append(functionName, path, content, null, 2);
        }

        public static void Append(string functionName, string path, string contents, Encoding encoding)
        {
            Append(functionName, path, contents, encoding, 2);
        }

        public static void Append(string functionName, string path)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "A stream to write data to \"" + path + "\" has been opened\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Copy(string functionName, string sourceFileName, string destFileName, bool overwrite)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "A file was copied from \"" + sourceFileName + "\" to \"" + destFileName + "\"\n" +
                    "\tOverwriting of the destination file allowed:" + overwrite + "\n" +
                    "\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        private static void Create(string functionName, string path, int bufferSize, FileOptions fileOptions, FileSecurity fileSecurity, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "A file was created at \"" + path + "\"\n";
                if (bufferSize > 0)
                {
                    message += "\tUsing a buffer size of " + bufferSize + "\n";
                }
                message += "\tUsing file option " + fileOptions + "\n";
                if (fileSecurity != null)
                {
                    message += "\tUsing the following file security settings:\n";
                    message += ReadFileSecurity(fileSecurity);
                }
                message += "\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Create(string functionName, string path, int bufferSize, FileOptions fileOptions, FileSecurity fileSecurity)
        {
            Create(functionName, path, bufferSize, fileOptions, fileSecurity, 2);
        }

        public static void Create(string functionName, string path, int bufferSize, FileOptions fileOptions)
        {
            Create(functionName, path, bufferSize, fileOptions, null, 2);
        }

        public static void Create(string functionName, string path, int bufferSize)
        {
            Create(functionName, path, bufferSize, FileOptions.None, null, 2);
        }

        public static void Create(string functionName, string path)
        {
            Create(functionName, path, -1, FileOptions.None, null, 2);
        }

        public static void CreateText(string functionName, string path)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "Opened a stream to write data to \"" + path + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void ProcessString(string functionName, string path)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The affected file is located at \"" + path + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Move(string functionName, string sourceFileName, string destFileName)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file located at \"" + sourceFileName + "\" has been moved to \"" + destFileName + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        private static void Open(string functionName, string path, FileMode mode, FileAccess access, FileShare share, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file at \"" + path + "\" has been opened\n";
                message += "\tFile mode: " + mode + "\n";
                message += "\tFile access mode: " + access + "\n";
                message += "\tFile share: " + share + "\n";
                message += "\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Open(string functionName, string path, FileMode mode, FileAccess access, FileShare share)
        {
            Open(functionName, path, mode, access, share, 2);
        }

        public static void Open(string functionName, string path, FileMode mode, FileAccess access)
        {
            Open(functionName, path, mode, access, FileShare.None, 2);
        }

        public static void Open(string functionName, string path, FileMode mode)
        {
            Open(functionName, path, mode, FileAccess.ReadWrite, FileShare.None, 2);
        }

        private static void ReadAll(string functionName, string path, string text, Encoding encoding, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file at \"" + path + "\" has been read. The content is shown below between the two lines of dashes.\n";
                message += "-------------------------------------------------------------------------------------------\n";
                message += text + "\n";
                message += "-------------------------------------------------------------------------------------------\n";

                //string savedPath = GenericHookHelper.SaveFile(text);
                //message += "The file has been saved to \"" + savedPath + "\"\n\n";
                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }

        }

        public static void ReadAll(string functionName, string path, string[] lines, Encoding encoding)
        {
            ReadAll(functionName, path, ArrayToString(lines), encoding, 2);
        }

        public static void ReadAll(string functionName, string path, string[] lines)
        {
            ReadAll(functionName, path, ArrayToString(lines), null, 2);
        }

        public static void ReadAll(string functionName, string path, string text, Encoding encoding)
        {
            ReadAll(functionName, path, text, encoding, 2);
        }

        public static void ReadAll(string functionName, string path, string text)
        {
            ReadAll(functionName, path, text, null, 2);
        }

        public static void Replace(string functionName, string sourceFileName, string destinationFileName)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file located at \"" + destinationFileName + "\" has been replaced with \"" + sourceFileName + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void SetAccessControl(string functionName, string path, FileSecurity fileSecurity)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file at \"" + path + "\" has the following attribute(s) set:\n"
                    + ReadFileSecurity(fileSecurity) + "\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void SetAttributes(string functionName, string path, FileAttributes fileAttributes)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file at \"" + path + "\" has the following attribute set: " + fileAttributes + "\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void WriteAllBytes(string functionName, string path, byte[] bytes)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                //string copyPath = GenericHookHelper.SaveFile(bytes);
                //string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                //message += "The file at \"" + path + "\" has been written to. A copy of the written data has been saved to \"" + copyPath + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void WriteAllLines(string functionName, string path, string[] lines)
        {
            WriteAllText(functionName, path, ArrayToString(lines), null, 2);
        }

        public static void WriteAllLines(string functionName, string path, string[] lines, Encoding encoding)
        {
            WriteAllText(functionName, path, ArrayToString(lines), encoding, 2);
        }

        public static void WriteAllText(string functionName, string path, string text, Encoding encoding)
        {
            WriteAllText(functionName, path, text, encoding, 2);
        }

        public static void WriteAllText(string functionName, string path, string text)
        {
            WriteAllText(functionName, path, text, null, 2);
        }

        public static void WriteAllText(string functionName, string path, string text, Encoding encoding, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                //string copyPath = GenericHookHelper.SaveFile(text);
                //string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                //message += "The file at \"" + path + "\" has been written to. A copy of the written data has been saved to \"" + copyPath + "\"\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void ReadAllBytes(string functionName, string path)
        {
            int stackTraceOffset = 2;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The file at \"" + path + "\" has been read\n\n";

                //Write the aggregated data to the log and the console
               //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }
    }
}
