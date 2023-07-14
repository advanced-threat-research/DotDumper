using System.Collections.Generic;
using DotDumper.Models;

namespace DotDumper.Hooks
{
    /// <summary>
    /// All methods within this class refer to unmanaged functions. This class contains static functions which obtain the pointer to the unmanaged function. The pointer, for the corresponding function, is used in the hooks of DotDumper, and when logging certain calls.
    /// </summary>
    class OriginalUnmanagedFunctions
    {
        #region kernel32.dll
        /// <summary>
        /// Gets the UnmanagedMethodInfo object for bool WriteProcessMemory(IntPtr process, int baseAddress, IntPtr buffer, int bufferSize, ref int bytesWritten)
        /// </summary>
        /// <returns></returns>
        public static UnmanagedMethodInfo Kernel32WriteProcessMemory()
        {
            string dll = "kernel32.dll";
            string fullMethodName = "bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, IntPtr lpBuffer, int nSize, ref int lpNumberOfBytesWritten)";
            string methodName = "WriteProcessMemory";
            List<string> argumentTypes = new List<string>();
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("int32");
            argumentTypes.Add("byte[]");
            argumentTypes.Add("int32");
            argumentTypes.Add("IntPtr&");
            return new UnmanagedMethodInfo(dll, fullMethodName, methodName, argumentTypes);
        }

        /// <summary>
        /// Gets the UnmanagedMethodInfo object for bool CreateProcessA(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation)
        /// </summary>
        /// <returns></returns>
        public static UnmanagedMethodInfo Kernel32CreateProcessA()
        {
            string dll = "kernel32.dll";
            string fullMethodName = "bool CreateProcessA(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation)";
            string methodName = "CreateProcessA";
            List<string> argumentTypes = new List<string>();
            argumentTypes.Add("string");
            argumentTypes.Add("string");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("Boolean");
            argumentTypes.Add("UInt32");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("string");
            argumentTypes.Add("STARTUP_INFORMATION&");
            argumentTypes.Add("PROCESS_INFORMATION&");
            return new UnmanagedMethodInfo(dll, fullMethodName, methodName, argumentTypes);
        }

        /// <summary>
        /// Gets the UnmanagedMethodInfo object for bool CreateProcessW(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation)
        /// </summary>
        /// <returns></returns>
        public static UnmanagedMethodInfo Kernel32CreateProcessW()
        {
            string dll = "kernel32.dll";
            string fullMethodName = "bool CreateProcessW(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation)";
            string methodName = "CreateProcessW";
            List<string> argumentTypes = new List<string>();
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("Boolean");
            argumentTypes.Add("Int32");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("IntPtr&");
            argumentTypes.Add("IntPtr&");
            return new UnmanagedMethodInfo(dll, fullMethodName, methodName, argumentTypes);
        }
        #endregion

        #region user32.dll
        /// <summary>
        /// Gets the UnmanagedMethodInfo object for int MessageBoxW([in, optional] HWND hWnd, [in, optional] LPCWSTR lpText, [in, optional] LPCWSTR lpCaption, [in] UINT uType)
        /// </summary>
        /// <returns></returns>
        public static UnmanagedMethodInfo User32MessageBoxW()
        {
            string dll = "user32.dll";
            string fullMethodName = "int MessageBoxW([in, optional] HWND hWnd, [in, optional] LPCWSTR lpText, [in, optional] LPCWSTR lpCaption, [in] UINT uType);";
            string methodName = "MessageBoxW";
            List<string> argumentTypes = new List<string>();
            argumentTypes.Add("int32");
            argumentTypes.Add("string");
            argumentTypes.Add("string");
            argumentTypes.Add("uint32");
            return new UnmanagedMethodInfo(dll, fullMethodName, methodName, argumentTypes);
        }
        #endregion

        #region ntdll.dll
        /// <summary>
        /// Gets the UnmanagedMethodInfo object for bool ZwMapViewOfSection()
        /// </summary>
        /// <returns></returns>
        public static UnmanagedMethodInfo NtdllZwMapViewOfSection()
        {
            string dll = "ntdll.dll";
            string fullMethodName = "bool ZwMapViewOfSection(IntPtr hProcess, int lpBaseAddress, IntPtr lpBuffer, int nSize, ref int lpNumberOfBytesWritten)";
            string methodName = "WriteProcessMemory";
            List<string> argumentTypes = new List<string>();
            argumentTypes.Add("IntPtr");
            argumentTypes.Add("int32");
            argumentTypes.Add("byte[]");
            argumentTypes.Add("int32");
            argumentTypes.Add("IntPtr&");
            return new UnmanagedMethodInfo(dll, fullMethodName, methodName, argumentTypes);
        }
        //ZwMapViewOfSection //ntdll.dll
        //NtMapViewOfSection //ntdll.dll
        //NtWriteVirtualMemory //ntdll.dll
        #endregion

        #region urlmon.dll
        //URLDownloadToFile 
        //URLDownloadToCacheFile
        #endregion
    }
}
