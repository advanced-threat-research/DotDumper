using System;
using System.Runtime.InteropServices;

namespace DotDumper.Hooks
{
    class InteropFunctions
    {
        #region Structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr ProcessHandle;
            public IntPtr ThreadHandle;
            public uint ProcessId;
            public uint ThreadId;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STARTUP_INFORMATION
        {
            public uint Size;
            public string Reserved1;
            public string Desktop;
            public string Title;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public byte[] Misc;
            public IntPtr Reserved2;
            public IntPtr StdInput;
            public IntPtr StdOutput;
            public IntPtr StdError;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SECURITY_ATTRIBUTES
        {
            uint nLength;
            IntPtr lpSecurityDescriptor;
            bool bInheritHandle;
        }

        /// <summary>
        /// The struct definition for the SystemTime struct
        /// </summary>
        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };
        #endregion

        #region kernel32.dll
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetProcessId(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string libname);

        [DllImport("kernel32.dll")]
        public static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        public static extern int VirtualAllocEx(IntPtr handle, int address, int length, int type, int protect);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr process, int baseAddress, ref int buffer, int bufferSize, ref int bytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool Wow64SetThreadContext(IntPtr thread, int[] context);

        [DllImport("kernel32.dll")]
        public static extern bool SetThreadContext(IntPtr thread, int[] context);

        [DllImport("kernel32.dll")]
        public static extern bool Wow64GetThreadContext(IntPtr thread, int[] context);

        [DllImport("kernel32.dll")]
        public static extern bool GetThreadContext(IntPtr thread, int[] context);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern bool CreateProcessA(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool CreateProcessW(IntPtr applicationName, IntPtr commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, int creationFlags, IntPtr environment, IntPtr currentDirectory, ref IntPtr startupInfo, ref IntPtr processInformation);

        [DllImport("kernel32.dll")]
        public static extern int ResumeThread(IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtect(IntPtr address, uint size, uint newProtect, out uint oldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtectEx(IntPtr hProcess, int lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// The native import of the SetSystemTime function from kernel32.dll
        /// </summary>
        /// <param name="sysTime">A reference to an instance of the SystemTime struct</param>
        /// <returns>True if set correctly, false if not</returns>
        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool SetSystemTime(ref SystemTime sysTime);
        #endregion

        #region ntdll.dll
        [DllImport("ntdll.dll")]
        public static extern int NtUnmapViewOfSection(IntPtr process, int baseAddress);
        #endregion

        #region user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBoxW(int hWnd, String text, String caption, uint type);
        #endregion
    }
}
