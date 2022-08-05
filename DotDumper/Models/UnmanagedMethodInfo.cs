using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotDumper.Models
{
    class UnmanagedMethodInfo
    {
        public string FullMethodName { get; private set; }
        public string MethodName { get; private set; }
        public string Dll { get; private set; }
        public IntPtr Pointer { get; private set; }

        public UnmanagedMethodInfo(string dll, string fullMethodName, string methodName)
        {
            this.Dll = dll;
            this.FullMethodName = fullMethodName;
            this.MethodName = methodName;
            this.Pointer = GetPointer(dll, methodName);
        }

        private IntPtr GetPointer(string dll, string methodName)
        {
            return GetProcAddress(GetModuleHandle(dll), methodName);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
    }
}
