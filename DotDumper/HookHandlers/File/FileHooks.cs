using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class FileHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AppendAllLinesHookStringIenumerableString(string path, IEnumerable<string> contents)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FileAppendAllLinesHookStringIenumerableString");
                //Call the original function
                File.AppendAllLines(path, contents);
                //Restore the hook
                HookManager.HookByHookName("FileAppendAllLinesHookStringIenumerableString");

                //Sets the title for the log
                string functionName = "File.AppendAllLines(string path, IEnumerable<string> contents)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileAppendAllLinesStringIenumerableString(), new object[] { path, contents }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AppendAllLinesHookStringIenumerableStringEncoding(string path, IEnumerable<string> contents, Encoding encoding)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FileAppendAllLinesHookStringIenumerableStringEncoding");
                //Call the original function
                File.AppendAllLines(path, contents, encoding);
                //Restore the hook
                HookManager.HookByHookName("FileAppendAllLinesHookStringIenumerableStringEncoding");

                //Sets the title for the log
                string functionName = "File.AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileAppendAllLinesStringIenumerableString(), new object[] { path, contents, encoding }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AppendAllTextHookStringStringEncoding(string path, string contents, Encoding encoding)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FileAppendAllTextHookStringStringEncoding");
                //Call the original function
                File.AppendAllText(path, contents, encoding);
                //Restore the hook
                HookManager.HookByHookName("FileAppendAllTextHookStringStringEncoding");

                //Sets the title for the log
                string functionName = "File.AppendAllText(string path, string contents, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileAppendAllTextStringStringEncoding(), new object[] { path, contents, encoding }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void AppendAllTextHookStringString(string path, string contents)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FileAppendAllTextHookStringString");
                //Call the original function
                File.AppendAllText(path, contents);
                //Restore the hook
                HookManager.HookByHookName("FileAppendAllTextHookStringString");

                //Sets the title for the log
                string functionName = "File.AppendAllText(string path, string contents)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileAppendAllTextStringString(), new object[] { path, contents }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static StreamWriter AppendTextHookString(string path)
        {
            //Declare the local variable to store the object in
            StreamWriter stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FileAppendTextHookString");
                //Call the original function
                stream = File.AppendText(path);
                //Restore the hook
                HookManager.HookByHookName("FileAppendTextHookString");

                //Sets the title for the log
                string functionName = "File.AppendText(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileAppendTextString(), new object[] { path }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CopyHookStringString(string sourceFileName, string destFileName)
        {
            //Declare the local variable to store the object in
            //StreamWriter stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CopyHookStringString");
                //Call the original function
                File.Copy(sourceFileName, destFileName);
                //Restore the hook
                HookManager.HookByHookName("CopyHookStringString");

                //Sets the title for the log
                string functionName = "File.Copy(string sourceFileName, string destFileName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCopyStringString(), new object[] { sourceFileName, destFileName }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CopyHookStringStringBoolean(string sourceFileName, string destFileName, bool overwrite)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CopyHookStringStringBoolean");
                //Call the original function
                File.Copy(sourceFileName, destFileName, overwrite);
                //Restore the hook
                HookManager.HookByHookName("CopyHookStringStringBoolean");

                //Sets the title for the log
                string functionName = "File.Copy(string sourceFileName, string destFileName, bool overwrite)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCopyStringStringBoolean(), new object[] { sourceFileName, destFileName, overwrite }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream CreateHookString(string path)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CreateHookString");
                //Call the original function
                stream = File.Create(path);
                //Restore the hook
                HookManager.HookByHookName("CreateHookString");

                //Sets the title for the log
                string functionName = "File.Create(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCreateString(), new object[] { path }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream CreateHookStringInt(string path, int bufferSize)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CreateHookStringInt");
                //Call the original function
                stream = File.Create(path, bufferSize);
                //Restore the hook
                HookManager.HookByHookName("CreateHookStringInt");

                //Sets the title for the log
                string functionName = "File.Create(string path, int bufferSize)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCreateStringInt(), new object[] { path, bufferSize }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream CreateHookStringIntFileOptions(string path, int bufferSize, FileOptions fileOptions)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CreateHookStringIntFileOptions");
                //Call the original function
                stream = File.Create(path, bufferSize, fileOptions);
                //Restore the hook
                HookManager.HookByHookName("CreateHookStringIntFileOptions");

                //Sets the title for the log
                string functionName = "File.Create(string path, int bufferSize, FileOptions fileOptions)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCreateStringIntFileOptions(), new object[] { path, bufferSize, fileOptions }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream CreateHookStringIntFileOptionsFileSecurity(string path, int bufferSize, FileOptions fileOptions, FileSecurity fileSecurity)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CreateHookStringIntFileOptionsFileSecurity");
                //Call the original function
                stream = File.Create(path, bufferSize, fileOptions, fileSecurity);
                //Restore the hook
                HookManager.HookByHookName("CreateHookStringIntFileOptionsFileSecurity");

                //Sets the title for the log
                string functionName = "File.Create(string path, int bufferSize, FileOptions fileOptions, FileSecurity fileSecurity)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCreateStringIntFileOptionsFileSecurity(), new object[] { path, bufferSize, fileOptions, fileSecurity }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static StreamWriter CreateTextHookString(string path)
        {
            //Declare the local variable to store the object in
            StreamWriter stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("CreateTextHookString");
                //Call the original function
                stream = File.CreateText(path);
                //Restore the hook
                HookManager.HookByHookName("CreateTextHookString");

                //Sets the title for the log
                string functionName = "File.CreateText(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileCreateTextString(), new object[] { path }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DecryptHookString(string path)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("DecryptHookString");
                //Call the original function
                File.Decrypt(path);
                //Restore the hook
                HookManager.HookByHookName("DecryptHookString");

                //Sets the title for the log
                string functionName = "File.Decrypt(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileDecryptString(), new object[] { path }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DeleteHookString(string path)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("DeleteHookString");
                //Call the original function
                File.Delete(path);
                //Restore the hook
                HookManager.HookByHookName("DeleteHookString");

                //Sets the title for the log
                string functionName = "File.Delete(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileDeleteString(), new object[] { path }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void EncryptHookString(string path)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("EncryptHookString");
                //Call the original function
                File.Encrypt(path);
                //Restore the hook
                HookManager.HookByHookName("EncryptHookString");

                //Sets the title for the log
                string functionName = "File.Encrypt(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileEncryptString(), new object[] { path }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ExiststHookString(string path)
        {
            //Declare the local variable to store the object in
            bool result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ExiststHookString");
                //Call the original function
                result = File.Exists(path);
                //Restore the hook
                HookManager.HookByHookName("ExiststHookString");

                //Sets the title for the log
                string functionName = "File.Exists(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileExiststString(), new object[] { path }, result);
            }

            //Return the result to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MoveHookStringString(string sourceFileName, string destFileName)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("MoveHookStringString");
                //Call the original function
                File.Move(sourceFileName, destFileName);
                //Restore the hook
                HookManager.HookByHookName("MoveHookStringString");

                //Sets the title for the log
                string functionName = "File.Move(string sourceFileName, string destFileName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileMoveStringString(), new object[] { sourceFileName, destFileName }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream OpenHookStringFileModeFileAccessFileShare(string path, FileMode mode, FileAccess access, FileShare share)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("OpenHookStringFileModeFileAccessFileShare");
                //Call the original function
                stream = File.Open(path, mode, access, share);
                //Restore the hook
                HookManager.HookByHookName("OpenHookStringFileModeFileAccessFileShare");

                //Sets the title for the log
                string functionName = "File.Open(string path, FileMode mode, FileAccess access, FileShare share)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileOpenStringFileModeFileAccessFileShare(), new object[] { path, mode, access, share }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream OpenHookStringFileModeFileAccess(string path, FileMode mode, FileAccess access)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("OpenHookStringFileModeFileAccess");
                //Call the original function
                stream = File.Open(path, mode, access);
                //Restore the hook
                HookManager.HookByHookName("OpenHookStringFileModeFileAccess");

                //Sets the title for the log
                string functionName = "File.Open(string path, FileMode mode, FileAccess access)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileOpenStringFileModeFileAccess(), new object[] { path, mode, access }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream OpenHookStringFileMode(string path, FileMode mode)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("OpenHookStringFileMode");
                //Call the original function
                stream = File.Open(path, mode);
                //Restore the hook
                HookManager.HookByHookName("OpenHookStringFileMode");

                //Sets the title for the log
                string functionName = "File.Open(string path, FileMode mode)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileOpenStringFileMode(), new object[] { path, mode }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static StreamReader OpenTextHookString(string path)
        {
            //Declare the local variable to store the object in
            StreamReader stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("OpenTextHookString");
                //Call the original function
                stream = File.OpenText(path);
                //Restore the hook
                HookManager.HookByHookName("OpenTextHookString");

                //Sets the title for the log
                string functionName = "File.OpenText(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileOpenTextString(), new object[] { path }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static FileStream OpenWriteHookString(string path)
        {
            //Declare the local variable to store the object in
            FileStream stream;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("OpenWriteHookString");
                //Call the original function
                stream = File.OpenWrite(path);
                //Restore the hook
                HookManager.HookByHookName("OpenWriteHookString");

                //Sets the title for the log
                string functionName = "File.OpenWrite(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileOpenWriteString(), new object[] { path }, stream);
            }

            //Return the object to the caller
            return stream;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] ReadAllLinesHookString(string path)
        {
            //Declare the local variable to store the object in
            string[] lines;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadAllLinesHookString");
                //Call the original function
                lines = File.ReadAllLines(path);
                //Restore the hook
                HookManager.HookByHookName("ReadAllLinesHookString");

                //Sets the title for the log
                string functionName = "File.ReadAllLines(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadAllLinesString(), new object[] { path }, lines);
            }

            //Return the object to the caller
            return lines;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string[] ReadAllLinesHookStringEncoding(string path, Encoding encoding)
        {
            //Declare the local variable to store the object in
            string[] lines;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadAllLinesHookStringEncoding");
                //Call the original function
                lines = File.ReadAllLines(path, encoding);
                //Restore the hook
                HookManager.HookByHookName("ReadAllLinesHookStringEncoding");

                //Sets the title for the log
                string functionName = "File.ReadAllLines(string path, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadAllLinesStringEncoding(), new object[] { path, encoding }, lines);
            }

            //Return the object to the caller
            return lines;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReadAllTextHookStringEncoding(string path, Encoding encoding)
        {
            //Declare the local variable to store the object in
            string text;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadAllTextHookStringEncoding");
                //Call the original function
                text = File.ReadAllText(path, encoding);
                //Restore the hook
                HookManager.HookByHookName("ReadAllTextHookStringEncoding");

                //Sets the title for the log
                string functionName = "File.ReadAllText(string path, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadAllTextStringEncoding(), new object[] { path, encoding }, text);
            }

            //Return the object to the caller
            return text;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReadAllTextHookString(string path)
        {
            //Declare the local variable to store the object in
            string text;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadAllTextHookString");
                //Call the original function
                text = File.ReadAllText(path);
                //Restore the hook
                HookManager.HookByHookName("ReadAllTextHookString");

                //Sets the title for the log
                string functionName = "File.ReadAllText(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadAllTextString(), new object[] { path }, text);
            }

            //Return the object to the caller
            return text;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IEnumerable<string> ReadLinesHookString(string path)
        {
            //Declare the local variable to store the object in
            IEnumerable<string> lines;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadLinesHookString");
                //Call the original function
                lines = File.ReadLines(path);
                //Restore the hook
                HookManager.HookByHookName("ReadLinesHookString");

                //Sets the title for the log
                string functionName = "File.ReadLines(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadLinesString(), new object[] { path }, lines);
            }

            //Return the object to the caller
            return lines;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static IEnumerable<string> ReadLinesHookStringEncoding(string path, Encoding encoding)
        {
            //Declare the local variable to store the object in
            IEnumerable<string> lines;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReadLinesHookStringEncoding");
                //Call the original function
                lines = File.ReadLines(path, encoding);
                //Restore the hook
                HookManager.HookByHookName("ReadLinesHookStringEncoding");

                //Sets the title for the log
                string functionName = "File.ReadLines(string path, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadLinesStringEncoding(), new object[] { path, encoding }, lines);
            }

            //Return the object to the caller
            return lines;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ReplaceHookStringStringString(string sourceFileName, string destinationFileName, string destinationBackupFileName)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReplaceHookStringStringString");
                //Call the original function
                File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
                //Restore the hook
                HookManager.HookByHookName("ReplaceHookStringStringString");

                //Sets the title for the log
                string functionName = "File.Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReplaceStringStringString(), new object[] { sourceFileName, destinationFileName, destinationBackupFileName }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ReplaceHookStringStringStringBoolean(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("ReplaceHookStringStringStringBoolean");
                //Call the original function
                File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
                //Restore the hook
                HookManager.HookByHookName("ReplaceHookStringStringStringBoolean");

                //Sets the title for the log
                string functionName = "File.Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReplaceStringStringStringBoolean(), new object[] { sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetAccessControlHookStringFileSecurity(string path, FileSecurity fileSecurity)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("SetAccessControlHookStringFileSecurity");
                //Call the original function
                File.SetAccessControl(path, fileSecurity);
                //Restore the hook
                HookManager.HookByHookName("SetAccessControlHookStringFileSecurity");

                //Sets the title for the log
                string functionName = "File.SetAccessControl(string path, FileSecurity fileSecurity)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileSetAccessControlStringFileSecurity(), new object[] { path, fileSecurity }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetAttributesHookStringFileAttributes(string path, FileAttributes fileAttributes)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("SetAttributesHookStringFileAttributes");
                //Call the original function
                File.SetAttributes(path, fileAttributes);
                //Restore the hook
                HookManager.HookByHookName("SetAttributesHookStringFileAttributes");

                //Sets the title for the log
                string functionName = "File.SetAttributes(string path, FileAttributes fileAttributes)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileSetAttributesStringFileAttributes(), new object[] { path, fileAttributes }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllBytesHookStringByteArray(string path, byte[] bytes)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllBytesHookStringByteArray");
                //Call the original function
                File.WriteAllBytes(path, bytes);
                //Restore the hook
                HookManager.HookByHookName("WriteAllBytesHookStringByteArray");

                //Sets the title for the log
                string functionName = "File.WriteAllBytes(string path, byte[] bytes)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllBytesStringByteArray(), new object[] { path, bytes }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllLinesHookStringStringArray(string path, string[] lines)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllLinesHookStringStringArray");
                //Call the original function
                File.WriteAllLines(path, lines);
                //Restore the hook
                HookManager.HookByHookName("WriteAllLinesHookStringStringArray");

                //Sets the title for the log
                string functionName = "File.WriteAllLines(string path, string[] lines)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllLinesStringStringArray(), new object[] { path, lines }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllLinesHookStringStringArrayEncoding(string path, string[] lines, Encoding encoding)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllLinesHookStringStringArrayEncoding");
                //Call the original function
                File.WriteAllLines(path, lines, encoding);
                //Restore the hook
                HookManager.HookByHookName("WriteAllLinesHookStringStringArrayEncoding");

                //Sets the title for the log
                string functionName = "File.WriteAllLines(string path, string[] lines, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllLinesStringStringArrayEncoding(), new object[] { path, lines, encoding }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllLinesHookStringIenumerableString(string path, IEnumerable<string> contents)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllLinesHookStringIenumerableString");
                //Call the original function
                File.WriteAllLines(path, contents);
                //Restore the hook
                HookManager.HookByHookName("WriteAllLinesHookStringIenumerableString");

                //Sets the title for the log
                string functionName = "File.WriteAllLines(string path, IEnumerable<string> contents)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllLinesStringIenumerableString(), new object[] { path, contents }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllLinesHookStringIenumerableStringEncoding(string path, IEnumerable<string> contents, Encoding encoding)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllLinesHookStringIenumerableStringEncoding");
                //Call the original function
                File.WriteAllLines(path, contents, encoding);
                //Restore the hook
                HookManager.HookByHookName("WriteAllLinesHookStringIenumerableStringEncoding");

                //Sets the title for the log
                string functionName = "File.WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllLinesStringIenumerableStringEncoding(), new object[] { path, contents, encoding }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllTextHookStringString(string path, string contents)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllTextHookStringString");
                //Call the original function
                File.WriteAllText(path, contents);
                //Restore the hook
                HookManager.HookByHookName("WriteAllTextHookStringString");

                //Sets the title for the log
                string functionName = "File.WriteAllText(string path, string contents)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllTextStringString(), new object[] { path, contents }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteAllTextHookStringStringEncoding(string path, string contents, Encoding encoding)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllTextHookStringStringEncoding");
                //Call the original function
                File.WriteAllText(path, contents, encoding);
                //Restore the hook
                HookManager.HookByHookName("WriteAllTextHookStringStringEncoding");

                //Sets the title for the log
                string functionName = "File.WriteAllText(string path, string contents, Encoding encoding)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileWriteAllTextStringStringEncoding(), new object[] { path, contents, encoding }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ReadAllBytesHookString(string path)
        {
            //Declare the local variable to store the object in
            byte[] bytes;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("WriteAllTextHookStringStringEncoding");
                //Call the original function
                bytes = File.ReadAllBytes(path);
                //Restore the hook
                HookManager.HookByHookName("WriteAllTextHookStringStringEncoding");

                //Sets the title for the log
                string functionName = "File.ReadAllBytes(string path)";
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.FileReadAllBytesString(), new object[] { path }, bytes);
            }

            //Return the object to the caller
            return bytes;
        }
    }
}
