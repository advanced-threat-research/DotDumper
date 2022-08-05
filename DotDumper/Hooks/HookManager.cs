using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DotDumper.Helpers;
using DotDumper.HookHandlers;
using DotDumper.Models;

namespace DotDumper.Hooks
{
    /// <summary>
    /// The HookManager is used to create all hook objects, which are stored in a private static list. Additionally, this class contains methods to set and remove hooks for a given hook, or for all hooks
    /// </summary>
    class HookManager
    {
        /// <summary>
        /// The list where all initialised hooks are stored. Hooks should be added via the AddHook function, rather than directly via the Add function of this list
        /// </summary>
        private static List<Hook> Hooks = new List<Hook>();

        /// <summary>
        /// Adds a hook to the list of hooks, unless the string representation (disregarding the casing) of the original method or the hook is already present in the list. If this is the case, a warning will be printed via the logger.
        /// </summary>
        /// <param name="originalMethod">The method to hook</param>
        /// <param name="hookMethod">The hook to execute when the original method is called</param>
        private static void AddHook(MethodInfo originalMethod, MethodInfo hookMethod)
        {
            bool toAdd = true;
            foreach (Hook hook in Hooks)
            {
                if (hook.CompareOriginal(originalMethod))
                {
                    string message = "A hook for \"" + hook.OriginalMethod + "\" is already present in the set hooks!\n" +
                        "\tThe hook that is already placed is named \"" + hook.HookMethod + "\"\n" +
                        "\tThe hook that was attempted to be added is named \"" + hookMethod.Name + "\"\n" +
                        "\n";
                    Console.WriteLine(message);
                    toAdd = false;
                }
                if (hook.CompareHook(hookMethod))
                {
                    string message = "The hook function \"" + hook.HookMethod + "\" is already used in a different hook!\n" +
                        "\tThe original function that is hooked is named \"" + hook.OriginalMethod + "\"\n" +
                        "\tThe original function that was attempted to be added is named \"" + originalMethod.Name + "\"\n" +
                        "\n";
                    Console.WriteLine(message);
                    toAdd = false;
                }
            }
            if (toAdd)
            {
                Hooks.Add(new Hook(originalMethod, hookMethod));
            }
        }

        /// <summary>
        /// Initialises all hook objects without setting the hooks. One can select the inclusion of deprecated functions with the first argument, whereas the second argument defines if the set hooks should be logged.
        /// </summary>
        public static void Initialise()
        {
            if (Config.IncludeDeprecatedFunctions)
            {
                #region Deprecated Assembly hooks
                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadStringEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookStringEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadAssemblyNameEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookAssemblyNameEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadByteArrayByteArrayEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookByteArrayByteArrayEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadFileStringEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadFileHookStringEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadFromStringEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadFromHookStringEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadFromStringEvidenceByteArrayAssemblyHashAlgorithm(), GetMethodInfo(typeof(AssemblyHooks), "LoadFromHookStringEvidenceByteArrayAssemblyHashAlgorithm", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadWithPartialNameString(), GetMethodInfo(typeof(AssemblyHooks), "LoadWithPartialNameHookString", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.AssemblyLoadWithPartialNameStringEvidence(), GetMethodInfo(typeof(AssemblyHooks), "LoadWithPartialNameHookStringEvidence", null));
                #endregion

                #region Deprecated Activator hooks
                //Deprecated!
                AddHook(OriginalManagedFunctions.ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence", null));

                //Deprecated!
                AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence", null));
                #endregion
            }

            #region Assembly hooks
            AddHook(OriginalManagedFunctions.AssemblyGetEntryAssembly(), GetMethodInfo(typeof(AssemblyHooks), "GetEntryAssemblyHook", null));

            AddHook(OriginalManagedFunctions.AssemblyGetExecutingAssembly(), GetMethodInfo(typeof(AssemblyHooks), "GetExecutingAssemblyHook", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadByteArray(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookByteArray", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadAssemblyName(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookAssemblyName", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadString(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookString", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadByteArrayByteArraySecurityContextSource(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookByteArrayByteArraySecurityContextSource", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadByteArrayByteArray(), GetMethodInfo(typeof(AssemblyHooks), "LoadHookByteArrayByteArray", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadFileString(), GetMethodInfo(typeof(AssemblyHooks), "LoadFileHookString", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadFromString(), GetMethodInfo(typeof(AssemblyHooks), "LoadFromHookString", null));

            AddHook(OriginalManagedFunctions.AssemblyLoadFromStringByteArrayAssemblyHashAlgorithm(), GetMethodInfo(typeof(AssemblyHooks), "LoadFromHookStringByteArrayAssemblyHashAlgorithm", null));

            AddHook(OriginalManagedFunctions.AssemblyReflectionOnlyLoadString(), GetMethodInfo(typeof(AssemblyHooks), "ReflectionOnlyLoadHookString", null));

            AddHook(OriginalManagedFunctions.AssemblyReflectionOnlyLoadByteArray(), GetMethodInfo(typeof(AssemblyHooks), "ReflectionOnlyLoadHookByteArray", null));

            AddHook(OriginalManagedFunctions.AssemblyReflectionOnlyLoadFromString(), GetMethodInfo(typeof(AssemblyHooks), "ReflectionOnlyLoadFromHookString", null));

            AddHook(OriginalManagedFunctions.AssemblyUnsafeLoadFromString(), GetMethodInfo(typeof(AssemblyHooks), "UnsafeLoadFromHookString", null));
            #endregion

            #region Convert hooks
            AddHook(OriginalManagedFunctions.ConvertFromBase64StringString(), GetMethodInfo(typeof(ConvertHooks), "FromBase64StringString", null));

            AddHook(OriginalManagedFunctions.ConvertFromBase64CharArrayCharArrayIntInt(), GetMethodInfo(typeof(ConvertHooks), "FromBase64CharArrayCharyArrayIntInt", null));
            #endregion

            #region WebClient hooks
            //AddHook(OriginalFunctions.WebClientDownloadDataString(), GetMethodInfo(typeof(WebClientHooks), "DownloadDataHookString", null));

            //AddHook(OriginalFunctions.WebClientDownloadDataUri(), GetMethodInfo(typeof(WebClientHooks), "DownloadDataHookUri", null));

            //AddHook(OriginalFunctions.WebClientDownloadStringString(), GetMethodInfo(typeof(WebClientHooks), "DownloadStringHookString", null));

            //AddHook(OriginalFunctions.WebClientDownloadStringUri(), GetMethodInfo(typeof(WebClientHooks), "DownloadStringHookUri", null));

            //AddHook(OriginalFunctions.WebClientDownloadFileStringString(), GetMethodInfo(typeof(WebClientHooks), "DownloadFileHookStringString", null));

            //AddHook(OriginalFunctions.WebClientDownloadFileUriString(), GetMethodInfo(typeof(WebClientHooks), "DownloadFileHookUriString", null));

            //AddHook(OriginalFunctions.WebClientOpenReadString(), GetMethodInfo(typeof(WebClientHooks), "OpenReadHookString", null));

            //AddHook(OriginalFunctions.WebClientOpenReadUri(), GetMethodInfo(typeof(WebClientHooks), "OpenReadHookUri", null));

            //AddHook(OriginalFunctions.WebClientOpenWriteString(), GetMethodInfo(typeof(WebClientHooks), "OpenWriteHookString", null));

            //AddHook(OriginalFunctions.WebClientOpenWriteStringString(), GetMethodInfo(typeof(WebClientHooks), "OpenWriteHookStringString", null));

            //AddHook(OriginalFunctions.WebClientOpenWriteUri(), GetMethodInfo(typeof(WebClientHooks), "OpenWriteHookUri", null));

            //AddHook(OriginalFunctions.WebClientOpenWriteUriString(), GetMethodInfo(typeof(WebClientHooks), "OpenWriteHookUriString", null));

            //AddHook(OriginalFunctions.WebClientUploadDataUriStringByteArray(), GetMethodInfo(typeof(WebClientHooks), "UploadDataHookUriStringByteArray", null));

            //AddHook(OriginalFunctions.WebClientUploadDataStringStringByteArray(), GetMethodInfo(typeof(WebClientHooks), "UploadDataHookStringStringByteArray", null));

            //AddHook(OriginalFunctions.WebClientUploadDataStringByteArray(), GetMethodInfo(typeof(WebClientHooks), "UploadDataHookStringByteArray", null));

            //AddHook(OriginalFunctions.WebClientUploadDataUriByteArray(), GetMethodInfo(typeof(WebClientHooks), "UploadDataHookUriByteArray", null));

            //AddHook(OriginalFunctions.WebClientUploadFileUriStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadFileHookUriStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadFileStringStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadFileHookStringStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadFileUriString(), GetMethodInfo(typeof(WebClientHooks), "UploadFileHookUriString", null));

            //AddHook(OriginalFunctions.WebClientUploadFileStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadFileHookStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadStringStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadStringHookStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadStringUriString(), GetMethodInfo(typeof(WebClientHooks), "UploadStringHookUriString", null));

            //AddHook(OriginalFunctions.WebClientUploadStringStringStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadStringHookStringStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadStringUriStringString(), GetMethodInfo(typeof(WebClientHooks), "UploadStringHookUriStringString", null));

            //AddHook(OriginalFunctions.WebClientUploadValuesUriStringNameValueCollection(), GetMethodInfo(typeof(WebClientHooks), "UploadValuesHookUriStringNameValueCollection", null));

            //AddHook(OriginalFunctions.WebClientUploadValuesStringStringNameValueCollection(), GetMethodInfo(typeof(WebClientHooks), "UploadValuesHookStringStringNameValueCollection", null));

            //AddHook(OriginalFunctions.WebClientUploadValuesUriNameValueCollection(), GetMethodInfo(typeof(WebClientHooks), "UploadValuesHookUriNameValueCollection", null));

            //AddHook(OriginalFunctions.WebClientUploadValuesStringNameValueCollection(), GetMethodInfo(typeof(WebClientHooks), "UploadValuesHookStringNameValueCollection", null));
            #endregion

            #region Process hooks
            AddHook(OriginalManagedFunctions.ProcessGetCurrentProcess(), GetMethodInfo(typeof(ProcessHooks), "GetCurrentProcessHook", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcessByIdIntString(), GetMethodInfo(typeof(ProcessHooks), "GetProcessByIdHookIntString", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcessByIdInt(), GetMethodInfo(typeof(ProcessHooks), "GetProcessByIdHookInt", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcesses(), GetMethodInfo(typeof(ProcessHooks), "GetProcessesHook", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcessesString(), GetMethodInfo(typeof(ProcessHooks), "GetProcessesHookString", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcessesByNameString(), GetMethodInfo(typeof(ProcessHooks), "GetProcessesByNameHookString", null));

            AddHook(OriginalManagedFunctions.ProcessGetProcessesByNameStringString(), GetMethodInfo(typeof(ProcessHooks), "GetProcessesByNameHookStringString", null));

            AddHook(OriginalManagedFunctions.ProcessStartStringString(), GetMethodInfo(typeof(ProcessHooks), "ProcessStartHookStringString", null));

            AddHook(OriginalManagedFunctions.ProcessStartProcessStartInfo(), GetMethodInfo(typeof(ProcessHooks), "ProcessStartHookProcessStartInfo", null));

            AddHook(OriginalManagedFunctions.ProcessStartString(), GetMethodInfo(typeof(ProcessHooks), "ProcessStartHookString", null));

            AddHook(OriginalManagedFunctions.ProcessStartStringStringStringSecureStringString(), GetMethodInfo(typeof(ProcessHooks), "ProcessStartHookStringStringStringSecureStringString", null));

            AddHook(OriginalManagedFunctions.ProcessStartStringStringSecureStringString(), GetMethodInfo(typeof(ProcessHooks), "ProcessStartHookStringStringSecureStringString", null));
            #endregion

            #region File hooks
            AddHook(OriginalManagedFunctions.FileAppendAllLinesStringIenumerableString(), GetMethodInfo(typeof(FileHooks), "AppendAllLinesHookStringIenumerableString", null));

            AddHook(OriginalManagedFunctions.FileAppendAllLinesStringIenumerableStringEncoding(), GetMethodInfo(typeof(FileHooks), "AppendAllLinesHookStringIenumerableStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileAppendAllTextStringStringEncoding(), GetMethodInfo(typeof(FileHooks), "AppendAllTextHookStringStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileAppendAllTextStringString(), GetMethodInfo(typeof(FileHooks), "AppendAllTextHookStringString", null));

            AddHook(OriginalManagedFunctions.FileAppendTextString(), GetMethodInfo(typeof(FileHooks), "AppendTextHookString", null));

            AddHook(OriginalManagedFunctions.FileCopyStringString(), GetMethodInfo(typeof(FileHooks), "CopyHookStringString", null));

            AddHook(OriginalManagedFunctions.FileCopyStringStringBoolean(), GetMethodInfo(typeof(FileHooks), "CopyHookStringStringBoolean", null));

            AddHook(OriginalManagedFunctions.FileCreateString(), GetMethodInfo(typeof(FileHooks), "CreateHookString", null));

            AddHook(OriginalManagedFunctions.FileCreateStringInt(), GetMethodInfo(typeof(FileHooks), "CreateHookStringInt", null));

            AddHook(OriginalManagedFunctions.FileCreateStringIntFileOptions(), GetMethodInfo(typeof(FileHooks), "CreateHookStringIntFileOptions", null));

            AddHook(OriginalManagedFunctions.FileCreateStringIntFileOptionsFileSecurity(), GetMethodInfo(typeof(FileHooks), "CreateHookStringIntFileOptionsFileSecurity", null));

            AddHook(OriginalManagedFunctions.FileCreateTextString(), GetMethodInfo(typeof(FileHooks), "CreateTextHookString", null));

            AddHook(OriginalManagedFunctions.FileDecryptString(), GetMethodInfo(typeof(FileHooks), "DecryptHookString", null));

            AddHook(OriginalManagedFunctions.FileDeleteString(), GetMethodInfo(typeof(FileHooks), "DeleteHookString", null));

            AddHook(OriginalManagedFunctions.FileEncryptString(), GetMethodInfo(typeof(FileHooks), "EncryptHookString", null));

            AddHook(OriginalManagedFunctions.FileExiststString(), GetMethodInfo(typeof(FileHooks), "ExiststHookString", null));

            AddHook(OriginalManagedFunctions.FileMoveStringString(), GetMethodInfo(typeof(FileHooks), "MoveHookStringString", null));

            AddHook(OriginalManagedFunctions.FileOpenStringFileModeFileAccessFileShare(), GetMethodInfo(typeof(FileHooks), "OpenHookStringFileModeFileAccessFileShare", null));

            AddHook(OriginalManagedFunctions.FileOpenStringFileModeFileAccess(), GetMethodInfo(typeof(FileHooks), "OpenHookStringFileModeFileAccess", null));

            AddHook(OriginalManagedFunctions.FileOpenStringFileMode(), GetMethodInfo(typeof(FileHooks), "OpenHookStringFileMode", null));

            AddHook(OriginalManagedFunctions.FileOpenTextString(), GetMethodInfo(typeof(FileHooks), "OpenTextHookString", null));

            AddHook(OriginalManagedFunctions.FileOpenWriteString(), GetMethodInfo(typeof(FileHooks), "OpenWriteHookString", null));

            AddHook(OriginalManagedFunctions.FileReadAllLinesString(), GetMethodInfo(typeof(FileHooks), "ReadAllLinesHookString", null));

            AddHook(OriginalManagedFunctions.FileReadAllLinesStringEncoding(), GetMethodInfo(typeof(FileHooks), "ReadAllLinesHookStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileReadAllTextStringEncoding(), GetMethodInfo(typeof(FileHooks), "ReadAllTextHookStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileReadAllTextString(), GetMethodInfo(typeof(FileHooks), "ReadAllTextHookString", null));

            AddHook(OriginalManagedFunctions.FileReadLinesString(), GetMethodInfo(typeof(FileHooks), "ReadLinesHookString", null));

            AddHook(OriginalManagedFunctions.FileReadLinesStringEncoding(), GetMethodInfo(typeof(FileHooks), "ReadLinesHookStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileReplaceStringStringString(), GetMethodInfo(typeof(FileHooks), "ReplaceHookStringStringString", null));

            AddHook(OriginalManagedFunctions.FileReplaceStringStringStringBoolean(), GetMethodInfo(typeof(FileHooks), "ReplaceHookStringStringStringBoolean", null));

            AddHook(OriginalManagedFunctions.FileSetAccessControlStringFileSecurity(), GetMethodInfo(typeof(FileHooks), "SetAccessControlHookStringFileSecurity", null));

            AddHook(OriginalManagedFunctions.FileSetAttributesStringFileAttributes(), GetMethodInfo(typeof(FileHooks), "SetAttributesHookStringFileAttributes", null));

            AddHook(OriginalManagedFunctions.FileWriteAllBytesStringByteArray(), GetMethodInfo(typeof(FileHooks), "WriteAllBytesHookStringByteArray", null));

            AddHook(OriginalManagedFunctions.FileWriteAllLinesStringStringArray(), GetMethodInfo(typeof(FileHooks), "WriteAllLinesHookStringStringArray", null));

            AddHook(OriginalManagedFunctions.FileWriteAllLinesStringStringArrayEncoding(), GetMethodInfo(typeof(FileHooks), "WriteAllLinesHookStringStringArrayEncoding", null));

            AddHook(OriginalManagedFunctions.FileWriteAllLinesStringIenumerableString(), GetMethodInfo(typeof(FileHooks), "WriteAllLinesHookStringIenumerableString", null));

            AddHook(OriginalManagedFunctions.FileWriteAllLinesStringIenumerableStringEncoding(), GetMethodInfo(typeof(FileHooks), "WriteAllLinesHookStringIenumerableStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileWriteAllTextStringString(), GetMethodInfo(typeof(FileHooks), "WriteAllTextHookStringString", null));

            AddHook(OriginalManagedFunctions.FileWriteAllTextStringStringEncoding(), GetMethodInfo(typeof(FileHooks), "WriteAllTextHookStringStringEncoding", null));

            AddHook(OriginalManagedFunctions.FileReadAllBytesString(), GetMethodInfo(typeof(FileHooks), "ReadAllBytesHookString", null));
            #endregion

            #region Path hooks
            AddHook(OriginalManagedFunctions.PathChangeExtensionStringString(), GetMethodInfo(typeof(PathHooks), "ChangeExtensionHookStringString", null));

            AddHook(OriginalManagedFunctions.PathCombineStringString(), GetMethodInfo(typeof(PathHooks), "CombineHookStringString", null));

            AddHook(OriginalManagedFunctions.PathCombineStringStringString(), GetMethodInfo(typeof(PathHooks), "CombineHookStringStringString", null));

            AddHook(OriginalManagedFunctions.PathCombineStringStringStringString(), GetMethodInfo(typeof(PathHooks), "CombineHookStringStringStringString", null));

            AddHook(OriginalManagedFunctions.PathCombineStringArray(), GetMethodInfo(typeof(PathHooks), "CombineHookStringArray", null));

            AddHook(OriginalManagedFunctions.PathGetDirectoryNameString(), GetMethodInfo(typeof(PathHooks), "GetDirectoryNameHookString", null));

            AddHook(OriginalManagedFunctions.PathGetExtensionString(), GetMethodInfo(typeof(PathHooks), "GetExtensionHookString", null));

            AddHook(OriginalManagedFunctions.PathGetFileNameString(), GetMethodInfo(typeof(PathHooks), "GetFileNameHookString", null));

            AddHook(OriginalManagedFunctions.PathGetFileNameWithoutExtensionString(), GetMethodInfo(typeof(PathHooks), "GetFileNameWithoutExtensionHookString", null));

            AddHook(OriginalManagedFunctions.PathGetFullPathString(), GetMethodInfo(typeof(PathHooks), "GetFullPathHookString", null));

            AddHook(OriginalManagedFunctions.PathGetPathRootString(), GetMethodInfo(typeof(PathHooks), "GetPathRootHookString", null));

            AddHook(OriginalManagedFunctions.PathGetRandomFileName(), GetMethodInfo(typeof(PathHooks), "GetRandomFileNameHook", null));

            AddHook(OriginalManagedFunctions.PathGetTempFileName(), GetMethodInfo(typeof(PathHooks), "GetTempFileNameHook", null));

            AddHook(OriginalManagedFunctions.PathGetTempPath(), GetMethodInfo(typeof(PathHooks), "GetTempPathHook", null));
            #endregion

            #region Thread hooks
            AddHook(OriginalManagedFunctions.ThreadSleepInt(), GetMethodInfo(typeof(ThreadHooks), "SleepHookInt", null));

            AddHook(OriginalManagedFunctions.ThreadSleepTimeSpan(), GetMethodInfo(typeof(ThreadHooks), "SleepHookTimeSpan", null));
            #endregion

            #region Environment hooks
            AddHook(OriginalManagedFunctions.EnvironmentExitInt(), GetMethodInfo(typeof(EnvironmentHooks), "ExitHookInt", null));

            AddHook(OriginalManagedFunctions.EnvironmentExpandEnvironmentVariablesString(), GetMethodInfo(typeof(EnvironmentHooks), "ExpandEnvironmentVariablesHookString", null));

            AddHook(OriginalManagedFunctions.EnvironmentFailFastStringException(), GetMethodInfo(typeof(EnvironmentHooks), "FailFastHookStringException", null));

            AddHook(OriginalManagedFunctions.EnvironmentFailFastString(), GetMethodInfo(typeof(EnvironmentHooks), "FailFastHookString", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetCommandLineArgs(), GetMethodInfo(typeof(EnvironmentHooks), "GetCommandLineArgsHook", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetEnvironmentVariableStringEnvironmentVariableTarget(), GetMethodInfo(typeof(EnvironmentHooks), "GetEnvironmentVariableHookStringEnvironmentVariableTarget", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetEnvironmentVariableString(), GetMethodInfo(typeof(EnvironmentHooks), "GetEnvironmentVariablesHookString", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetEnvironmentVariablesEnvironmentVariableTarget(), GetMethodInfo(typeof(EnvironmentHooks), "GetEnvironmentVariablesHookEnvironmentVariableTarget", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetEnvironmentVariables(), GetMethodInfo(typeof(EnvironmentHooks), "GetEnvironmentVariablesHook", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetFolderPathSpecialFolderSpecialFolderOption(), GetMethodInfo(typeof(EnvironmentHooks), "GetFolderPathHookSpecialFolderSpecialFolderOption", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetFolderPathSpecialFolder(), GetMethodInfo(typeof(EnvironmentHooks), "GetFolderPathHookSpecialFolder", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetLogicalDrives(), GetMethodInfo(typeof(EnvironmentHooks), "GetLogicalDrivesHook", null));

            AddHook(OriginalManagedFunctions.EnvironmentSetEnvironmentVariableStringStringEnvironmentVariableTarget(), GetMethodInfo(typeof(EnvironmentHooks), "SetEnvironmentVariableHookStringStringEnvironmentVariableTarget", null));

            AddHook(OriginalManagedFunctions.EnvironmentSetEnvironmentVariableStringString(), GetMethodInfo(typeof(EnvironmentHooks), "SetEnvironmentVariableHookStringString", null));

            AddHook(OriginalManagedFunctions.EnvironmentGetResourceFromDefaultString(), GetMethodInfo(typeof(EnvironmentHooks), "GetResourceFromDefaultHookString", null));
            #endregion

            #region ResourceManager hooks
            AddHook(OriginalManagedFunctions.ResourceManagerGetObjectString(), GetMethodInfo(typeof(ResourceManagerHooks), "GetObjectHookString", null));

            AddHook(OriginalManagedFunctions.ResourceManagerGetObjectStringCultureInfo(), GetMethodInfo(typeof(ResourceManagerHooks), "GetObjectHookStringCultureInfo", null));

            AddHook(OriginalManagedFunctions.ResourceManagerGetStringString(), GetMethodInfo(typeof(ResourceManagerHooks), "GetStringHookString", null));

            AddHook(OriginalManagedFunctions.ResourceManagerGetStringStringCultureInfo(), GetMethodInfo(typeof(ResourceManagerHooks), "GetStringHookStringCultureInfo", null));

            AddHook(OriginalManagedFunctions.ResourceManagerGetStreamString(), GetMethodInfo(typeof(ResourceManagerHooks), "GetStreamHookString", null));

            AddHook(OriginalManagedFunctions.ResourceManagerGetStreamStringCultureInfo(), GetMethodInfo(typeof(ResourceManagerHooks), "GetStreamHookStringCultureInfo", null));
            #endregion

            #region Console hooks
            AddHook(OriginalManagedFunctions.ConsoleWriteString(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookString", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteUlong(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookUlong", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLong(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookLong", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteStringObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookStringObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteInt(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookInt", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteStringObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookStringObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteUint(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookUint", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteStringObjectObjectObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookStringObjectObjectObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteStringObjectArray(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookStringObjectArray", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteBool(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookBool", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteChar(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookChar", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteCharArray(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookCharArray", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteCharArrayIntInt(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookCharArrayIntInt", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteStringObjectObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookStringObjectObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteDecimal(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookDecimal", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteFloat(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookFloat", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteDouble(), GetMethodInfo(typeof(ConsoleHooks), "WriteHookDouble", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineString(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookString", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineUlong(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookUlong", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineLong(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookLong", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineStringObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookStringObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineInt(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookInt", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineStringObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookStringObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineUint(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookUint", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineStringObjectObjectObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookStringObjectObjectObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineStringObjectArray(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookStringObjectArray", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineBool(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookBool", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineChar(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookChar", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineCharArray(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookCharArray", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineCharArrayIntInt(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookCharArrayIntInt", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineStringObjectObjectObject(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookStringObjectObjectObject", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineDecimal(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookDecimal", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineFloat(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookFloat", null));

            AddHook(OriginalManagedFunctions.ConsoleWriteLineDouble(), GetMethodInfo(typeof(ConsoleHooks), "WriteLineHookDouble", null));
            #endregion

            #region MethodBase hooks
            AddHook(OriginalManagedFunctions.MethodBaseInvokeObjectObjectArray(), GetMethodInfo(typeof(MethodBaseHooks), "InvokeHookObjectObjectArray", null));

            //Cannot hook abstract method
            //AddHook(OriginalFunctions.MethodBaseInvokeObjectBindingFlagsBinderObjectArrayCultureInfo(), GetMethodInfo(typeof(MethodBaseHooks), "InvokeHookObjectBindingFlagsBinderObjectArrayCultureInfo", null));
            #endregion

            #region Type hooks
            AddHook(OriginalManagedFunctions.TypeInvokeMemberStringBindingFlagsBinderObjectObjectArray(), GetMethodInfo(typeof(TypeHooks), "InvokeMemberHookStringBindingFlagsBinderObjectObjectArray", null));

            AddHook(OriginalManagedFunctions.TypeInvokeMemberStringBindingFlagsBinderObjectObjectArrayCultureInfo(), GetMethodInfo(typeof(TypeHooks), "InvokeMemberHookStringBindingFlagsBinderObjectObjectArrayCultureInfo", null));
            #endregion

            #region Activator hooks
            AddHook(OriginalManagedFunctions.ActivatorCreateComInstanceFromStringStringByteArrayAssemblyHashAlgorithm(), GetMethodInfo(typeof(ActivatorHooks), "CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateComInstanceFromStringString(), GetMethodInfo(typeof(ActivatorHooks), "CreateComInstanceFromHookStringString", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceType(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookType", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceTypeBool(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookTypeBool", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceActivationContext(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookActivationContext", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceTypeObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookTypeObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceStringString(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookStringString", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceTypeBindingFlagsBinderObjectArrayCultureInfo(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfo", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceActivationContextStringArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookActivationContextStringArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceStringStringObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookStringStringObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringString(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookAppDomainStringString", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringString(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookAppDomainStringString", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromStringString(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookStringString", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromStringStringObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookStringStringObjectArray", null));

            AddHook(OriginalManagedFunctions.ActivatorCreateInstanceFromStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray(), GetMethodInfo(typeof(ActivatorHooks), "CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray", null));
            #endregion

            //TODO the following classes are intresting:
            //Activator 04794ec7e7eb5c6611aada660fb1716a91e01503fb4703c7d2f2099c089c9017
            //Marshal

            if (Config.LogHooks)
            {
                LogHooks();
            }
        }

        /// <summary>
        /// Gets the MethodInfo object from the given type, using the given name (disregarding the casing), and matching the given parameter types (disregarding the casing) and count. Note that only public methods from the given type are iterated!
        /// </summary>
        /// <param name="type">The type to find the method in</param>
        /// <param name="name">The function name, case insensitive </param>
        /// <param name="parameterTypes">The parameter type(s), insensitive</param>
        /// <returns>If a match is found, the corresponding MethodInfo object is returned. If no match is found, null is returned</returns>
        public static MethodInfo GetMethodInfo(Type type, string name, List<string> parameterTypes)
        {
            //Get all public methods from the given type
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            //Iterate over all methods
            foreach (MethodInfo methodInfo in methodInfos)
            {
                //If the name (disregarding casing) is the same, more checks follow, as the correct overloaded method needs to be selected (if present)
                if (methodInfo.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    //If the given list is not null, include a check for the parameter types (and count)
                    if (parameterTypes != null)
                    {
                        //Get the information regarding the parameters of the method
                        ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                        //If the amount of parameters is the same, it is a potential match (though not a certain one, as overloads with different types can have the same amount of arguments)
                        if (parameterInfos.Length == parameterTypes.Count)
                        {
                            //A local variable that states if the two functions match
                            bool isMatching = true;

                            //Iterate over all the user-provided parameters
                            for (int i = 0; i < parameterTypes.Count; i++)
                            {
                                //Get the type from the parameter at the given index
                                string parameterInfoType = parameterInfos[i].ParameterType.Name;
                                //Compare the name (disregarding the casing) of the two parameters
                                if (parameterInfoType.Equals(parameterTypes[i], StringComparison.InvariantCultureIgnoreCase) == false)
                                {
                                    //If the parameter types do not match at any point in time, the functions do not match
                                    isMatching = false;
                                    break;
                                }
                            }
                            //If all types matched, the boolean's value remains true
                            if (isMatching)
                            {
                                //Since everything matches, this function matches with the provided information
                                return methodInfo;
                            }
                        }
                    }
                    else //If no parameters are provided, the first hit is returned
                    {
                        return methodInfo;
                    }
                }
            }
            //If no match is found, null is returned
            return null;
        }

        /// <summary>
        /// Logs all loaded hooks via the logger object
        /// </summary>
        private static void LogHooks()
        {
            string title = "Logging all " + Hooks.Count + " loaded hooks";
            string message = title + "\n";
            foreach (Hook hook in Hooks)
            {
                message += hook.OriginalMethod + "\n";
            }
            message += "\n";

            Console.WriteLine(message);
        }

        /// <summary>
        /// Sets all hooks
        /// </summary>
        public static void HookAll()
        {
            foreach (Hook hook in Hooks)
            {
                hook.Enable();
            }
        }

        /// <summary>
        /// Removes all the hooks
        /// </summary>
        public static void UnHookAll()
        {
            foreach (Hook hook in Hooks)
            {
                hook.Disable();
            }
        }

        /// <summary>
        /// Sets the hook, based on the given hook name, ignoring the casing
        /// </summary>
        /// <param name="hookName">The name of the hook function (ignoring the return type or parameters)</param>
        /// <returns>True if the hook is set, false if there is no hook with such a name</returns>
        public static bool HookByHookName(string hookName)
        {
            foreach (Hook hook in Hooks)
            {
                if (hook.CompactHookMethod.Equals(hookName, StringComparison.InvariantCultureIgnoreCase))
                {
                    hook.Enable();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the hook for the given original method, based on the given hook name, ignoring the casing
        /// </summary>
        /// <param name="hookName">The name of the hook function (ignoring the return type or parameters)</param>
        /// <returns>True if the hook is removed, false if there is no hook with such a name</returns>
        public static bool UnHookByHookName(string hookName)
        {
            foreach (Hook hook in Hooks)
            {
                if (hook.CompactHookMethod.Equals(hookName, StringComparison.InvariantCultureIgnoreCase))
                {
                    hook.Disable();
                    return true;
                }
            }
            return false;
        }
    }
}
