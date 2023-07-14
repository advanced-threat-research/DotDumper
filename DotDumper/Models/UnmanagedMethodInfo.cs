using System;
using System.Collections.Generic;
using DotDumper.Hooks;

namespace DotDumper.Models
{
    /// <summary>
    /// An object which contains all required information to set an unmanaged hook
    /// </summary>
    class UnmanagedMethodInfo
    {
        /// <summary>
        /// The full method name of the hook's target function
        /// </summary>
        public string FullMethodName { get; private set; }

        /// <summary>
        /// The function name (excluding arguments and return type) of the target function. This is also used to fetch the address of the function.
        /// </summary>
        public string MethodName { get; private set; }

        /// <summary>
        /// The name of the DLL where the targeted function resides
        /// </summary>
        public string Dll { get; private set; }

        /// <summary>
        /// The pointer of the targeted function
        /// </summary>
        public IntPtr Pointer { get; private set; }

        /// <summary>
        /// The types of the parameters, in order, disregards casing
        /// </summary>
        public List<string> ParameterTypes { get; private set; }


        /// <summary>
        /// Creates an unmanaged method info object, which is used when hooking unmanaged functions
        /// </summary>
        /// <param name="dll">The DLL where the target function resides</param>
        /// <param name="fullMethodName">The full method name (including return type and arguments), only used to print data to the logs</param>
        /// <param name="methodName">The targeted method's name (excluding return type and arguments)</param>
        /// <param name="parameterTypes">A list of the argument types of the function, need to be in order</param>
        public UnmanagedMethodInfo(string dll, string fullMethodName, string methodName, List<string> parameterTypes)
        {
            this.Dll = dll;
            this.FullMethodName = fullMethodName;
            this.MethodName = methodName;
            this.Pointer = GetPointer(dll, methodName);
            this.ParameterTypes = parameterTypes;
        }

        /// <summary>
        /// Gets the pointer for the given function from the given DLL, using interop Windows API calls. No hooks are set nor removed, since this object is only made prior to setting hooks.
        /// </summary>
        /// <param name="dll">The DLL where the targeted function resides</param>
        /// <param name="methodName">The targeted function's name</param>
        /// <returns>A pointer to the memory address of the given function</returns>
        private IntPtr GetPointer(string dll, string methodName)
        {
            IntPtr pointer = InteropFunctions.GetProcAddress(InteropFunctions.GetModuleHandle(dll), methodName);
            if (pointer == IntPtr.Zero)
            {
                InteropFunctions.LoadLibrary(dll);
                pointer = InteropFunctions.GetProcAddress(InteropFunctions.GetModuleHandle(dll), methodName);
            }
            return pointer;
        }
    }
}
