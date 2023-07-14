using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace DotDumper.Hooks
{
    /// <summary>
    /// All methods within this class refer to managed functions. This class contains static functions which obtain the MethodInfo object. This object, for the corresponding function, is used in the hooks of DotDumper, and when logging certain calls.
    /// </summary>
    class OriginalManagedFunctions
    {
        #region Original ResourceManager methods
        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetObject(string name)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetObjectString()
        {
            Type type = typeof(ResourceManager);
            string name = "GetObject";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetObject(string name, CultureInfo cultureInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetObjectStringCultureInfo()
        {
            Type type = typeof(ResourceManager);
            string name = "GetObject";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("cultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetString(string name)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetStringString()
        {
            Type type = typeof(ResourceManager);
            string name = "GetString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetString(string name, CultureInfo cultureInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetStringStringCultureInfo()
        {
            Type type = typeof(ResourceManager);
            string name = "GetString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("cultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetString(string name)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetStreamString()
        {
            Type type = typeof(ResourceManager);
            string name = "GetStream";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for ResourceManager.GetString(string name, CultureInfo cultureInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ResourceManagerGetStreamStringCultureInfo()
        {
            Type type = typeof(ResourceManager);
            string name = "GetStream";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("cultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Environment methods
        /// <summary>
        /// Gets the MethodInfo object for Environment.Exit(int exitCode)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentExitInt()
        {
            Type type = typeof(Environment);
            string name = "Exit";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.ExpandEnvironmentVariables(string name)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentExpandEnvironmentVariablesString()
        {
            Type type = typeof(Environment);
            string name = "ExpandEnvironmentVariables";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.FailFast(string message, Exception exception)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentFailFastStringException()
        {
            Type type = typeof(Environment);
            string name = "FailFast";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("exception");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.FailFast(string message)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentFailFastString()
        {
            Type type = typeof(Environment);
            string name = "FailFast";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetCommandLineArgs()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetCommandLineArgs()
        {
            Type type = typeof(Environment);
            string name = "GetCommandLineArgs";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetEnvironmentVariable(string variable, EnvironmentVariableTarget target)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetEnvironmentVariableStringEnvironmentVariableTarget()
        {
            Type type = typeof(Environment);
            string name = "GetEnvironmentVariable";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("EnvironmentVariableTarget");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetEnvironmentVariable(string variable)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetEnvironmentVariableString()
        {
            Type type = typeof(Environment);
            string name = "GetEnvironmentVariable";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetEnvironmentVariables(EnvironmentVariableTarget target)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetEnvironmentVariablesEnvironmentVariableTarget()
        {
            Type type = typeof(Environment);
            string name = "GetEnvironmentVariables";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("EnvironmentVariableTarget");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetEnvironmentVariables()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetEnvironmentVariables()
        {
            Type type = typeof(Environment);
            string name = "GetEnvironmentVariables";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetFolderPath(SpecialFolder folder, SpecialFolderOption option)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetFolderPathSpecialFolderSpecialFolderOption()
        {
            Type type = typeof(Environment);
            string name = "GetFolderPath";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("SpecialFolder");
            parameterTypes.Add("SpecialFolderOption");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetFolderPath(SpecialFolder folder)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetFolderPathSpecialFolder()
        {
            Type type = typeof(Environment);
            string name = "GetFolderPath";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("SpecialFolder");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetLogicalDrives()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetLogicalDrives()
        {
            Type type = typeof(Environment);
            string name = "GetLogicalDrives";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentSetEnvironmentVariableStringStringEnvironmentVariableTarget()
        {
            Type type = typeof(Environment);
            string name = "SetEnvironmentVariable";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("EnvironmentVariableTarget");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.SetEnvironmentVariable(string variable, string value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentSetEnvironmentVariableStringString()
        {
            Type type = typeof(Environment);
            string name = "SetEnvironmentVariable";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Environment.GetResourceFromDefault(string key)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo EnvironmentGetResourceFromDefaultString()
        {
            Type type = typeof(Environment);
            string name = "GetResourceFromDefault";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Thread methods
        /// <summary>
        /// Gets the MethodInfo object for Thread.Sleep(int millisecondsTimeout)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ThreadSleepInt()
        {
            Type type = typeof(Thread);
            string name = "Sleep";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Thread.Sleep(TimeSpan timeout)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ThreadSleepTimeSpan()
        {
            Type type = typeof(Thread);
            string name = "Sleep";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("timespan");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Path methods
        /// <summary>
        /// Gets the MethodInfo object for Path.ChangeExtension(string path, string extension)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathChangeExtensionStringString()
        {
            Type type = typeof(Path);
            string name = "ChangeExtension";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.Combine(string path1, string path2)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathCombineStringString()
        {
            Type type = typeof(Path);
            string name = "Combine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.Combine(string path1, string path2, string path3)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathCombineStringStringString()
        {
            Type type = typeof(Path);
            string name = "Combine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.Combine(string path1, string path2, string path3, string path4)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathCombineStringStringStringString()
        {
            Type type = typeof(Path);
            string name = "Combine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.Combine(params string[] paths)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathCombineStringArray()
        {
            Type type = typeof(Path);
            string name = "Combine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetDirectoryName(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetDirectoryNameString()
        {
            Type type = typeof(Path);
            string name = "GetDirectoryName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetExtension(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetExtensionString()
        {
            Type type = typeof(Path);
            string name = "GetExtension";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetFileName(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetFileNameString()
        {
            Type type = typeof(Path);
            string name = "GetFileName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetFileNameWithoutExtension(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetFileNameWithoutExtensionString()
        {
            Type type = typeof(Path);
            string name = "GetFileNameWithoutExtension";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetFullPath(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetFullPathString()
        {
            Type type = typeof(Path);
            string name = "GetFullPath";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetPathRoot(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetPathRootString()
        {
            Type type = typeof(Path);
            string name = "GetPathRoot";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetRandomFileName()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetRandomFileName()
        {
            Type type = typeof(Path);
            string name = "GetRandomFileName";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetTempFileName()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetTempFileName()
        {
            Type type = typeof(Path);
            string name = "GetTempFileName";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Path.GetTempPath()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo PathGetTempPath()
        {
            Type type = typeof(Path);
            string name = "GetTempPath";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original File methods
        /// <summary>
        /// Gets the MethodInfo object for File.AppendAllLines(string path, IEnumerable<string> contents)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileAppendAllLinesStringIenumerableString()
        {
            Type type = typeof(File);
            string name = "AppendAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("IEnumerable`1");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileAppendAllLinesStringIenumerableStringEncoding()
        {
            Type type = typeof(File);
            string name = "AppendAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("IEnumerable`1");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.AppendAllText(string path, string contents, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileAppendAllTextStringStringEncoding()
        {
            Type type = typeof(File);
            string name = "AppendAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.AppendAllText(string path, string contents)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileAppendAllTextStringString()
        {
            Type type = typeof(File);
            string name = "AppendAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.AppendText(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileAppendTextString()
        {
            Type type = typeof(File);
            string name = "AppendText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Copy(string sourceFileName, string destFileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCopyStringString()
        {
            Type type = typeof(File);
            string name = "Copy";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Copy(string sourceFileName, string destFileName, bool overwrite)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCopyStringStringBoolean()
        {
            Type type = typeof(File);
            string name = "Copy";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Create(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCreateString()
        {
            Type type = typeof(File);
            string name = "Create";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Create(string path, int bufferSize)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCreateStringInt()
        {
            Type type = typeof(File);
            string name = "Create";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Create(string path, int bufferSize, FileOptions options)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCreateStringIntFileOptions()
        {
            Type type = typeof(File);
            string name = "Create";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("int32");
            parameterTypes.Add("FileOptions");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Create(string path, int bufferSize, FileOptions options, FileSecurity fileSecurity)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCreateStringIntFileOptionsFileSecurity()
        {
            Type type = typeof(File);
            string name = "Create";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("int32");
            parameterTypes.Add("FileOptions");
            parameterTypes.Add("FileSecurity");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.CreateText(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileCreateTextString()
        {
            Type type = typeof(File);
            string name = "CreateText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Decrypt(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileDecryptString()
        {
            Type type = typeof(File);
            string name = "Decrypt";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Delete(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileDeleteString()
        {
            Type type = typeof(File);
            string name = "Delete";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Encrypt(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileEncryptString()
        {
            Type type = typeof(File);
            string name = "Encrypt";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Exists(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileExiststString()
        {
            Type type = typeof(File);
            string name = "Exists";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Move(string sourceFileName, string destFileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileMoveStringString()
        {
            Type type = typeof(File);
            string name = "Move";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Open(string path, FileMode mode, FileAccess access, FileShare share)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenStringFileModeFileAccessFileShare()
        {
            Type type = typeof(File);
            string name = "Open";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("FileMode");
            parameterTypes.Add("FileAccess");
            parameterTypes.Add("FileShare");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Open(string path, FileMode mode)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenStringFileMode()
        {
            Type type = typeof(File);
            string name = "Open";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("FileMode");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Open(string path, FileMode mode, FileAccess access)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenStringFileModeFileAccess()
        {
            Type type = typeof(File);
            string name = "Open";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("FileMode");
            parameterTypes.Add("FileAccess");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.OpenRead(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenReadString()
        {
            Type type = typeof(File);
            string name = "OpenRead";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.OpenText(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenTextString()
        {
            Type type = typeof(File);
            string name = "OpenText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.OpenWrite(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileOpenWriteString()
        {
            Type type = typeof(File);
            string name = "OpenWrite";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadAllLines(string path, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadAllLinesStringEncoding()
        {
            Type type = typeof(File);
            string name = "ReadAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadAllLines(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadAllLinesString()
        {
            Type type = typeof(File);
            string name = "ReadAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadAllText(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadAllTextString()
        {
            Type type = typeof(File);
            string name = "ReadAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadAllText(string path, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadAllTextStringEncoding()
        {
            Type type = typeof(File);
            string name = "ReadAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadLines(string path, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadLinesStringEncoding()
        {
            Type type = typeof(File);
            string name = "ReadLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadLines(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadLinesString()
        {
            Type type = typeof(File);
            string name = "ReadLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReplaceStringStringString()
        {
            Type type = typeof(File);
            string name = "Replace";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReplaceStringStringStringBoolean()
        {
            Type type = typeof(File);
            string name = "Replace";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.SetAccessControl(string path, FileSecurity fileSecurity)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileSetAccessControlStringFileSecurity()
        {
            Type type = typeof(File);
            string name = "SetAccessControl";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("FileSecurity");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.SetAttributes(string path, FileAttributes fileAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileSetAttributesStringFileAttributes()
        {
            Type type = typeof(File);
            string name = "SetAttributes";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("FileAttributes");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllBytes(string path, byte[] bytes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllBytesStringByteArray()
        {
            Type type = typeof(File);
            string name = "WriteAllBytes";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllLines(string path, string[] contents)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllLinesStringStringArray()
        {
            Type type = typeof(File);
            string name = "WriteAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllLines(string path, string[] contents, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllLinesStringStringArrayEncoding()
        {
            Type type = typeof(File);
            string name = "WriteAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string[]");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllLines(string path, IEnumerable<string> contents)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllLinesStringIenumerableString()
        {
            Type type = typeof(File);
            string name = "WriteAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("ienumerable`1");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllLinesStringIenumerableStringEncoding()
        {
            Type type = typeof(File);
            string name = "WriteAllLines";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("ienumerable`1");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllText(string path, string contents)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllTextStringString()
        {
            Type type = typeof(File);
            string name = "WriteAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.WriteAllText(string path, string contents, Encoding encoding)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileWriteAllTextStringStringEncoding()
        {
            Type type = typeof(File);
            string name = "WriteAllText";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("encoding");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for File.ReadAllBytes(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo FileReadAllBytesString()
        {
            Type type = typeof(File);
            string name = "ReadAllBytes";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Convert methods
        /// <summary>
        /// Gets the MethodInfo object for Convert.FromBase64String(string s)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConvertFromBase64StringString()
        {
            Type type = typeof(Convert);
            string name = "FromBase64String";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Convert.FromBase64CharArray(char[] inArray, int offset, int length)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConvertFromBase64CharArrayCharArrayIntInt()
        {
            Type type = typeof(Convert);
            string name = "FromBase64CharArray";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char[]");
            parameterTypes.Add("int32");
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Process methods
        /// <summary>
        /// Gets the MethodInfo object for Process.GetCurrentProcess()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetCurrentProcess()
        {
            Type type = typeof(Process);
            string name = "GetCurrentProcess";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcessById(int processId, string machineName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcessByIdIntString()
        {
            Type type = typeof(Process);
            string name = "GetProcessById";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcessById(int processId)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcessByIdInt()
        {
            Type type = typeof(Process);
            string name = "GetProcessById";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcesses()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcesses()
        {
            Type type = typeof(Process);
            string name = "GetProcesses";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcesses(string machineName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcessesString()
        {
            Type type = typeof(Process);
            string name = "GetProcesses";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcessesByName(string processName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcessesByNameString()
        {
            Type type = typeof(Process);
            string name = "GetProcessesByName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.GetProcessesByName(string processName, string machineName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessGetProcessesByNameStringString()
        {
            Type type = typeof(Process);
            string name = "GetProcessesByName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start(string fileName, string arguments)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStartStringString()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start(ProcessStartInfo startInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStartProcessStartInfo()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("ProcessStartInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start(string fileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStartString()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start(string fileName, string arguments, string userName, SecureString password, string domain)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStartStringStringStringSecureStringString()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("securestring");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start(string fileName, string userName, SecureString password, string domain)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStartStringStringSecureStringString()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("securestring");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Process.Start()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ProcessStart()
        {
            Type type = typeof(Process);
            string name = "Start";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original WebClient methods
        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadData(string address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadDataString()
        {
            Type type = typeof(WebClient);
            string name = "DownloadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadData(Uri address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadDataUri()
        {
            Type type = typeof(WebClient);
            string name = "DownloadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadString(string address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadStringString()
        {
            Type type = typeof(WebClient);
            string name = "DownloadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadString(Uri address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadStringUri()
        {
            Type type = typeof(WebClient);
            string name = "DownloadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadFile(string address, string filename)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadFileStringString()
        {
            Type type = typeof(WebClient);
            string name = "DownloadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().DownloadFile(Uri address, string filename)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientDownloadFileUriString()
        {
            Type type = typeof(WebClient);
            string name = "DownloadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenRead(string address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenReadString()
        {
            Type type = typeof(WebClient);
            string name = "OpenRead";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenRead(Uri address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenReadUri()
        {
            Type type = typeof(WebClient);
            string name = "OpenRead";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenWrite(string address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenWriteString()
        {
            Type type = typeof(WebClient);
            string name = "OpenWrite";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenWrite(string address, string method)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenWriteStringString()
        {
            Type type = typeof(WebClient);
            string name = "OpenWrite";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenWrite(Uri address)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenWriteUri()
        {
            Type type = typeof(WebClient);
            string name = "OpenWrite";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().OpenWrite(Uri address, string method)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientOpenWriteUriString()
        {
            Type type = typeof(WebClient);
            string name = "OpenWrite";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadData(Uri address, string method, byte[] data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadDataUriStringByteArray()
        {
            Type type = typeof(WebClient);
            string name = "UploadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadData(string address, string method, byte[] data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadDataStringStringByteArray()
        {
            Type type = typeof(WebClient);
            string name = "UploadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadData(string address, byte[] data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadDataStringByteArray()
        {
            Type type = typeof(WebClient);
            string name = "UploadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadData(Uri address, byte[] data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadDataUriByteArray()
        {
            Type type = typeof(WebClient);
            string name = "UploadData";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadFile(Uri address, string method, string fileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadFileUriStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadFile(string address, string method, string fileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadFileStringStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadFile(Uri address, string fileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadFileUriString()
        {
            Type type = typeof(WebClient);
            string name = "UploadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadFile(String address, string fileName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadFileStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadString(string address, string data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadStringStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadString(Uri address, string data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadStringUriString()
        {
            Type type = typeof(WebClient);
            string name = "UploadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadString(string address, string method, string data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadStringStringStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadString(Uri address, string method, string data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadStringUriStringString()
        {
            Type type = typeof(WebClient);
            string name = "UploadString";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadValues(Uri address, string method, NameValueCollection data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadValuesUriStringNameValueCollection()
        {
            Type type = typeof(WebClient);
            string name = "UploadValues";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("string");
            parameterTypes.Add("NameValueCollection");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadValues(string address, string method, NameValueCollection data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadValuesStringStringNameValueCollection()
        {
            Type type = typeof(WebClient);
            string name = "UploadValues";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("NameValueCollection");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadValues(Uri address, NameValueCollection data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadValuesUriNameValueCollection()
        {
            Type type = typeof(WebClient);
            string name = "UploadValues";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uri");
            parameterTypes.Add("NameValueCollection");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for new WebClient().UploadValues(string address, NameValueCollection data)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo WebClientUploadValuesStringNameValueCollection()
        {
            Type type = typeof(WebClient);
            string name = "UploadValues";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("NameValueCollection");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Type methods
        /// <summary>
        /// Gets the MethodInfo object for Type.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo TypeInvokeMemberStringBindingFlagsBinderObjectObjectArrayCultureInfo()
        {
            Type type = typeof(Type);
            string name = "InvokeMember";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("BindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object");
            parameterTypes.Add("object[]");
            parameterTypes.Add("CultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Type.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo TypeInvokeMemberStringBindingFlagsBinderObjectObjectArray()
        {
            Type type = typeof(Type);
            string name = "InvokeMember";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("BindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original MethodBase methods
        /// <summary>
        /// Gets the MethodInfo object for MethodBase.Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo MethodBaseInvokeObjectBindingFlagsBinderObjectArrayCultureInfo()
        {
            Type type = typeof(MethodBase);
            string name = "Invoke";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("object");
            parameterTypes.Add("BindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("CultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for MethodBase.Invoke(object obj, object[] parameters)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo MethodBaseInvokeObjectObjectArray()
        {
            Type type = typeof(MethodBase);
            string name = "Invoke";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("object");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Assembly methods
        /// <summary>
        /// Gets the MethodInfo object for Assembly.GetEntryAssembly()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyGetEntryAssembly()
        {
            Type type = typeof(Assembly);
            string name = "GetEntryAssembly";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.GetExecutingAssembly()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyGetExecutingAssembly()
        {
            Type type = typeof(Assembly);
            string name = "GetExecutingAssembly";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.ReflectionOnlyLoadFrom(string assemblyFile)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyReflectionOnlyLoadFromString()
        {
            Type type = typeof(Assembly);
            string name = "ReflectionOnlyLoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.UnsafeLoadFrom(string assemblyFile)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyUnsafeLoadFromString()
        {
            Type type = typeof(Assembly);
            string name = "UnsafeLoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.ReflectionOnlyLoad(byte[] rawAssembly)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyReflectionOnlyLoadByteArray()
        {
            Type type = typeof(Assembly);
            string name = "ReflectionOnlyLoad";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.ReflectionOnlyLoad(string assemblyString)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyReflectionOnlyLoadString()
        {
            Type type = typeof(Assembly);
            string name = "ReflectionOnlyLoad";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadWithPartialName(string partialName)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadWithPartialNameString()
        {
            Type type = typeof(Assembly);
            string name = "LoadWithPartialName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadWithPartialName(string partialName, Evidence securityEvidence)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=14202 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadWithPartialNameStringEvidence()
        {
            Type type = typeof(Assembly);
            string name = "LoadWithPartialName";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFrom(string assemblyFile, Evidence securityEvidence, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=14202 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFromStringEvidenceByteArrayAssemblyHashAlgorithm()
        {
            Type type = typeof(Assembly);
            string name = "LoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("evidence");
            parameterTypes.Add("byte[]");
            parameterTypes.Add("AssemblyHashAlgorithm");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFrom(string assemblyFile, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFromStringByteArrayAssemblyHashAlgorithm()
        {
            Type type = typeof(Assembly);
            string name = "LoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            parameterTypes.Add("AssemblyHashAlgorithm");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFrom(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFromString()
        {
            Type type = typeof(Assembly);
            string name = "LoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFrom(string path, Evidence securityEvidence)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFromStringEvidence()
        {
            Type type = typeof(Assembly);
            string name = "LoadFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFile(string path, Evidence securityEvidence)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFileStringEvidence()
        {
            Type type = typeof(Assembly);
            string name = "LoadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.LoadFile(string path)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadFileString()
        {
            Type type = typeof(Assembly);
            string name = "LoadFile";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadByteArrayByteArray()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("byte[]");
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore, SecurityContextSource securityContextSource)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadByteArrayByteArraySecurityContextSource()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("byte[]");
            parameterTypes.Add("byte[]");
            parameterTypes.Add("SecurityContextSource");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(AssemblyName assemblyRef, Evidence securityEvidence)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadAssemblyNameEvidence()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AssemblyName");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(AssemblyName assemblyRef)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadAssemblyName()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AssemblyName");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(byte[] rawAssembly, byte[] rawSymbolStore, Evidence securityEvidence)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadByteArrayByteArrayEvidence()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("byte[]");
            parameterTypes.Add("byte[]");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(string assemblyString, Evidence assemblySecurity)
        /// 
        /// Note that this function is deprecated, see http://go.microsoft.com/fwlink/?LinkID=155570 for more information
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadStringEvidence()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(String assemblyString)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadString()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Assembly.Load(Byte[] rawAssembly)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo AssemblyLoadByteArray()
        {
            Type type = typeof(Assembly);
            string name = "Load";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("byte[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Console methods
        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteString()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(object value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteObject()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(ulong value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteUlong()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uint64");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(long value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLong()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int64");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(int value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteInt()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(uint value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteUint()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uint32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(bool value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteBool()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("boolean");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(char value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteChar()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(decimal value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteDecimal()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("decimal");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(float value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteFloat()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("single");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(double value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteDouble()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("double");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string format, object arg0)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteStringObject()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string format, object arg0, object arg1)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteStringObjectObject()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string format, object arg0, object arg1, object arg2)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteStringObjectObjectObject()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string format, object arg0, object arg1, object arg2, object arg3)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteStringObjectObjectObjectObject()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(string format, object[] arg)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteStringObjectArray()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(char[] buffer)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteCharArray()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.Write(char[] buffer, int index, int count)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteCharArrayIntInt()
        {
            Type type = typeof(Console);
            string name = "Write";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char[]");
            parameterTypes.Add("int32");
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine()
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLine()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(float value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineFloat()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("single");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(int value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineInt()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(uint value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineUint()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uint32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(long value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineLong()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("int64");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(ulong value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineUlong()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("uint64");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(object value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineObject()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineString()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(decimal value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineDecimal()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("decimal");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(char[] value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineCharArray()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(char value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineChar()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(bool value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineBool()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("boolean");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(double value)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineDouble()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("double");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string format, object arg0)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineStringObject()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string format, object arg0, object arg1)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineStringObjectObject()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string format, object arg0, object arg1, object arg2)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineStringObjectObjectObject()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineStringObjectObjectObjectObject()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            parameterTypes.Add("object");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(string format, object[] arg)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineStringObjectArray()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Console.WriteLine(char[] buffer, int index, int count)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ConsoleWriteLineCharArrayIntInt()
        {
            Type type = typeof(Console);
            string name = "WriteLine";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("char[]");
            parameterTypes.Add("int32");
            parameterTypes.Add("int32");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion

        #region Original Activator methods
        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateComInstanceFrom(string assemblyName, string typeName, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateComInstanceFromStringStringByteArrayAssemblyHashAlgorithm()
        {
            Type type = typeof(Activator);
            string name = "CreateComInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("byte[]");
            parameterTypes.Add("AssemblyHashAlgorithm");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateComInstanceFrom(string assemblyName, string typeName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateComInstanceFromStringString()
        {
            Type type = typeof(Activator);
            string name = "CreateComInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(Type type, bool nonPublic)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceTypeBool()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("type");
            parameterTypes.Add("boolean");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(Type type)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceType()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("type");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(ActivationContext activationContext)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceActivationContext()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("ActivationContext");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(string assemblyName, string typeName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceStringString()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(Type type, object[] args)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceTypeObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("type");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceTypeBindingFlagsBinderObjectArrayCultureInfo()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("type");
            parameterTypes.Add("bindingflags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("type");
            parameterTypes.Add("bindingflags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(ActivationContext activationContext, string[] activationCustomData)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceActivationContextStringArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("activationContext");
            parameterTypes.Add("string[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(string assemblyName, string typeName, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceStringStringObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(string assemblyName, string typeName, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceAppDomainStringString()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("appDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AppDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstance(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence()
        {
            Type type = typeof(Activator);
            string name = "CreateInstance";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AppDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(AppDomain domain, string assemblyName, string typeName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromAppDomainStringString()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AppDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AppDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("AppDomain");
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("bindingFlags");
            parameterTypes.Add("binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("cultureInfo");
            parameterTypes.Add("object[]");
            parameterTypes.Add("evidence");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(string assemblyFile, string typeName)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromStringString()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(string assemblyFile, string typeName, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromStringStringObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }

        /// <summary>
        /// Gets the MethodInfo object for Activator.CreateInstanceFrom(string assemblyFile, string typeName, object[] activationAttributes)
        /// </summary>
        /// <returns></returns>
        public static MethodInfo ActivatorCreateInstanceFromStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray()
        {
            Type type = typeof(Activator);
            string name = "CreateInstanceFrom";
            List<string> parameterTypes = new List<string>();
            parameterTypes.Add("string");
            parameterTypes.Add("string");
            parameterTypes.Add("boolean");
            parameterTypes.Add("BindingFlags");
            parameterTypes.Add("Binder");
            parameterTypes.Add("object[]");
            parameterTypes.Add("CultureInfo");
            parameterTypes.Add("object[]");
            return HookManager.GetMethodInfo(type, name, parameterTypes);
        }
        #endregion
    }
}
