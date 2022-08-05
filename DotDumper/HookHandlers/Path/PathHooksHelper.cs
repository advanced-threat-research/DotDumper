using System.Collections.Generic;
using DotDumper.Helpers;

namespace DotDumper.HookHandlers
{
    class PathHooksHelper
    {
        private static readonly int stackTraceOffset = 2;
        public static void ChangeExtension(string functionName, string path, string extension)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The extension of the file at \"" + path + "\" has been changed to \"" + extension + "\"\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }
        private static void Combine(string functionName, string[] paths, string output, int stackTraceOffset)
        {
            stackTraceOffset++;

            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The following path-parts were combined:\n";
                foreach (string path in paths)
                {
                    message += "\t" + path + "\n";
                }
                message += "The combined path equals \"" + output + "\"\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void Combine(string functionName, string[] paths, string output)
        {
            Combine(functionName, paths, output, stackTraceOffset);
        }

        public static void Combine(string functionName, string path1, string path2, string output)
        {
            string[] paths = { path1, path2 };
            Combine(functionName, paths, output, stackTraceOffset);
        }

        public static void Combine(string functionName, string path1, string path2, string path3, string output)
        {
            string[] paths = { path1, path2, path3 };
            Combine(functionName, paths, output, stackTraceOffset);
        }

        public static void Combine(string functionName, string path1, string path2, string path3, string path4, string output)
        {
            string[] paths = { path1, path2, path3, path4 };
            Combine(functionName, paths, output, stackTraceOffset);
        }

        public static void GetDirectoryName(string functionName, string path)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The directory name of \"" + path + "\" was requested\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void GetExtension(string functionName, string path)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The extension of the file at \"" + path + "\" was requested\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void GetFileName(string functionName, string path)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The name of the file at \"" + path + "\" was requested\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void GetFileNameWithoutExtension(string functionName, string path)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The name of the file at \"" + path + "\" was requested without its extension\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void GetFullPath(string functionName, string fullPath)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The full path for \"" + fullPath + "\" was requested\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void GetPathRoot(string functionName, string fullPath, string pathRoot)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The path root (being \"" + pathRoot + "\") for \"" + fullPath + "\" was requested\n\n";

                //Write the aggregated data to the log and the console
                //GenericHookHelper._Logger.Log(functionName, message);
            }
            else
            {
                //GenericHookHelper._Logger.LogRaw(null, null, false, true);
            }
        }

        public static void ProcessOutput(string functionName, string output)
        {
            List<string> stackTraceLines = GenericHookHelper.GetStackTraceRaw(stackTraceOffset);
            bool isFromSample = AssemblyMapper.IsComingFromSample(stackTraceLines);

            if (isFromSample)
            {
                string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);
                message += "The returned value equals \"" + output + "\"\n\n";

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