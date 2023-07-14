using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DotDumper.Helpers;
using DotDumper.Models;

namespace DotDumper.Hooks
{
    /// <summary>
    /// The original hook code has been taken from a forum post of the first of May 2017 by Michael 'donrevan' Pekar on <a href = "https://www.unknowncheats.me/forum/c-/213492-hook-managed-function.html">UnknownCheats</a>. The code is also available in  <a href = "https://gist.github.com/mipek/64d6d1ad08dc51c89e9f7d5ae369b203">this</a> GitHub Gist. The code is licensed under the MIT license. Changes have been made by Max 'Libra' Kersten based on the original code in the linked posts.
    /// </summary>
    class Hook
    {
        /// <summary>
        /// This summary is taken from <a href = "https://docs.microsoft.com/en-us/windows/win32/api/memoryapi/nf-memoryapi-virtualprotect">MSDN</a>. Changes the protection on a region of committed pages in the virtual address space of the calling process.
        /// </summary>
        /// <param name="address">The address of the starting page of the region of pages whose access protection attributes are to be changed. All pages in the specified region must be within the same reserved region allocated when calling the VirtualAlloc or VirtualAllocEx function using MEM_RESERVE. The pages cannot span adjacent reserved regions that were allocated by separate calls to VirtualAlloc or VirtualAllocEx using MEM_RESERVE.</param>
        /// <param name="size">The size of the region whose access protection attributes are to be changed, in bytes. The region of affected pages includes all pages containing one or more bytes in the range from the lpAddress parameter to (lpAddress+dwSize). This means that a 2-byte range straddling a page boundary causes the protection attributes of both pages to be changed.</param>
        /// <param name="newProtect">The memory protection option. This parameter can be one of the <a href="https://docs.microsoft.com/en-us/windows/win32/memory/memory-protection-constants">memory protection constants</a>. For mapped views, this value must be compatible with the access protection specified when the view was mapped(see MapViewOfFile, MapViewOfFileEx, and MapViewOfFileExNuma).</param>
        /// <param name="oldProtect">A pointer to a variable that receives the previous access protection value of the first page in the specified region of pages. If this parameter is NULL or does not point to a valid variable, the function fails.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtect(IntPtr address, uint size, uint newProtect, out uint oldProtect);

        /// <summary>
        /// A constant to resemble the RWX memory protection constant
        /// </summary>
        private const int PAGE_READ_WRITE_EXECUTE = 0x40;

        /// <summary>
        /// The amount of bytes that the jump to the hook requires on the x86 architecture
        /// </summary>
        private const uint HOOK_SIZE_X86 = 7;

        /// <summary>
        /// The amount of bytes that the jump to the hook requires on the x86_64 architecture
        /// </summary>
        private const uint HOOK_SIZE_X64 = 12;

        /// <summary>
        /// The bytes of the original method that are overwritten with the hook jump
        /// </summary>
        private byte[] originalBytes;

        /// <summary>
        /// The original method that is hooked
        /// </summary>
        public string OriginalMethod { get; private set; }

        /// <summary>
        /// The method which is called instead of the original method
        /// </summary>
        public string HookMethod { get; private set; }

        /// <summary>
        /// The method which is called instead of the original MethodInfo's name
        /// </summary>
        public string CompactHookMethod { get; private set; }

        /// <summary>
        /// The pointer to the original method
        /// </summary>
        private IntPtr OriginalMethodPointer { get; set; }

        /// <summary>
        /// The pointer to the hook
        /// </summary>
        private IntPtr HookMethodPointer { get; set; }

        /// <summary>
        /// Creates a hook object, which requires two non-null MethodInfo objects. The hook is not set upon the creation of this object. To set and remove a hook, use the SetHook and UnHook methods in this class respectively.
        /// </summary>
        /// <param name="originalMethod">The original method, which is to be replaced by the hookMethod</param>
        /// <param name="hookMethod">The hook to replace the originalMethod</param>
        public Hook(MethodInfo originalMethod, MethodInfo hookMethod)
        {
            //Checks if either of the arguments are null, throwing an error if one or more conditions are true
            if (originalMethod == null || hookMethod == null)
            {
                throw new ArgumentException("Both the original and hook need to be valid methods");
            }

            //Sets the original bytes variable to null, meaning the original method is not hooked
            originalBytes = null;

            //Prepares the method for execution within a constrained execution region
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);
            RuntimeHelpers.PrepareMethod(hookMethod.MethodHandle);

            //Sets the variables in the class for later use
            OriginalMethod = Serialise.Method(originalMethod);
            OriginalMethodPointer = originalMethod.MethodHandle.GetFunctionPointer();
            HookMethod = Serialise.Method(hookMethod);
            HookMethodPointer = hookMethod.MethodHandle.GetFunctionPointer();
            CompactHookMethod = hookMethod.Name;
        }

        /// <summary>
        /// Creates a hook object, which requires two non-null UnmanagedMethodInfo objects. The hook is not set upon the creation of this object. To set and remove a hook, use the SetHook and UnHook methods in this class respectively.
        /// </summary>
        /// <param name="originalMethod">The original method, which is to be replaced by the hookMethod</param>
        /// <param name="hookMethod">The hook to replace the originalMethod</param>
        public Hook(UnmanagedMethodInfo originalMethod, UnmanagedMethodInfo hookMethod)
        {
            //Checks if either of the arguments are null, throwing an error if one or more conditions are true
            if (originalMethod == null || hookMethod == null)
            {
                throw new ArgumentException("Some provided hook arguments are invalid!");
            }

            //Sets the original bytes variable to null, meaning the original method is not hooked
            originalBytes = null;

            //Sets the variables in the class for later use
            OriginalMethod = originalMethod.FullMethodName;
            OriginalMethodPointer = originalMethod.Pointer;
            HookMethod = hookMethod.FullMethodName;
            HookMethodPointer = hookMethod.Pointer;
            CompactHookMethod = hookMethod.MethodName;
        }

        /// <summary>
        /// Creates a hook object, which requires a non-null UnmanagedMethodInfo object and a non-null MethodInfo object. The hook is not set upon the creation of this object. To set and remove a hook, use the SetHook and UnHook methods in this class respectively.
        /// </summary>
        /// <param name="originalMethod">The original method, which is to be replaced by the hookMethod</param>
        /// <param name="hookMethod">The hook to replace the originalMethod</param>
        public Hook(UnmanagedMethodInfo originalMethod, MethodInfo hookMethod)
        {
            //Checks if either of the arguments are null, throwing an error if one or more conditions are true
            if (originalMethod == null || hookMethod == null)
            {
                throw new ArgumentException("Some provided hook arguments are invalid!");
            }

            //Sets the original bytes variable to null, meaning the original method is not hooked
            originalBytes = null;

            //Prepares the method for execution within a constrained execution region
            RuntimeHelpers.PrepareMethod(hookMethod.MethodHandle);

            //Sets the variables in the class for later use
            OriginalMethod = originalMethod.FullMethodName;
            OriginalMethodPointer = originalMethod.Pointer;
            HookMethod = Serialise.Method(hookMethod);
            HookMethodPointer = hookMethod.MethodHandle.GetFunctionPointer();
            CompactHookMethod = hookMethod.Name;
        }

        /// <summary>
        /// Creates a hook object, which requires a non-null MethodInfo object and a non-null UnmanagedMethodInfo object. The hook is not set upon the creation of this object. To set and remove a hook, use the SetHook and UnHook methods in this class respectively.
        /// </summary>
        /// <param name="originalMethod">The original method, which is to be replaced by the hookMethod</param>
        /// <param name="hookMethod">The hook to replace the originalMethod</param>
        public Hook(MethodInfo originalMethod, UnmanagedMethodInfo hookMethod)
        {
            //Checks if either of the arguments are null, throwing an error if one or more conditions are true
            if (originalMethod == null || hookMethod == null)
            {
                throw new ArgumentException("Some provided hook arguments are invalid!");
            }

            //Sets the original bytes variable to null, meaning the original method is not hooked
            originalBytes = null;

            //Prepares the method for execution within a constrained execution region
            RuntimeHelpers.PrepareMethod(originalMethod.MethodHandle);

            //Sets the variables in the class for later use
            OriginalMethod = Serialise.Method(originalMethod);
            OriginalMethodPointer = originalMethod.MethodHandle.GetFunctionPointer();
            HookMethod = hookMethod.FullMethodName;
            HookMethodPointer = hookMethod.Pointer;
            CompactHookMethod = hookMethod.MethodName;
        }

        /// <summary>
        /// Sets the detour for the original method, redirecting it to the previously provided hook. If the original method is not hooked, this method simply returns.
        /// </summary>
        public void Enable()
        {
            /**
             * The overwritten instructions of the original method are saved in a byte array, so they can be restored later on.
             * Upon the creation of this object, and upon unhooking, this byte array is set to null. As such, any case where
             * this byte array is not null, is a case where the hook is already in-place. To avoid overwriting the saved data 
             * with a hooked version, this method returns early.
             */
            if (originalBytes != null)
            {
                return;
            }

            //Declare the variable that is used to store the previous memory protection value in, as returned by the Interop VirtualProtect call, as the memory segment needs to be writable to write the hook
            uint oldProt;

            //Declare the variable that is used to store the size of the hook in
            uint hookSize;

            //Depending on the architecture, the hook size differs
            if (IntPtr.Size == 8)
            {
                hookSize = HOOK_SIZE_X64;
            }
            else
            {
                hookSize = HOOK_SIZE_X86;
            }

            //Initialise the byte array to store the original data in using the architeture specific size
            originalBytes = new byte[hookSize];

            /**
            * Ensure that the hook can be writen to the start of the original function in memory, by making the area from the start of the original method
            * plus the size of the hook executable, readable, and writable
            */
            VirtualProtect(OriginalMethodPointer, hookSize, PAGE_READ_WRITE_EXECUTE, out oldProt);

            //Starts the unsafe code block where the hook is set
            unsafe
            {
                //Declares a byte pointer based on the original method
                byte* ptr = (byte*)OriginalMethodPointer;

                /**
                 * Copies the original bytes into the byte array in this class. The data in this array is used to restore 
                 * the overwritten memory upon unhooking
                 */
                for (int i = 0; i < hookSize; ++i)
                {
                    originalBytes[i] = ptr[i];
                }

                /**
                 * Depending on the architecture, the assembly instructions that need to be written to force the jump to the hook differ.
                 * The location of the hook is writting into the accumulating register (EAX on x86, RAX on x86_64), after which an
                 * unconditional jump to that location is taken. When the original function is called, the hook is called via the jump.
                 * The hook itself can perform the required and desired actions, after which it simply returns, which transfers the 
                 * control back to the caller.
                 */
                if (IntPtr.Size == 8)
                {
                    /**
                    * Writes the following x86_64 assembly instructions at the start of the original function:
                    * movabs rax, addr
                    * jmp rax
                    */
                    *(ptr) = 0x48;
                    *(ptr + 1) = 0xb8;
                    *(IntPtr*)(ptr + 2) = HookMethodPointer;
                    *(ptr + 10) = 0xff;
                    *(ptr + 11) = 0xe0;
                }
                else
                {
                    /**
                     * Writes the following x86 assembly instructions at the start of the original function:
                     * mov eax, addr
                     * jmp eax
                     */
                    *(ptr) = 0xb8;
                    *(IntPtr*)(ptr + 1) = HookMethodPointer;
                    *(ptr + 5) = 0xff;
                    *(ptr + 6) = 0xe0;
                }
            }
            //Restores the memory permissions for the memory segment to the original value
            VirtualProtect(OriginalMethodPointer, hookSize, oldProt, out oldProt);
        }

        /// <summary>
        /// Unhooks the hook of the original method, allowing calls of the original method to work as usual. If the original method has not been hooked, this call simply returns.
        /// </summary>
        public void Disable()
        {
            /**
             * The overwritten instructions of the original method are saved in a byte array, so they can be restored later on.
             * Upon the creation of this object, and upon unhooking, this byte array is set to null. As such, any case where
             * this byte array is null, is a case where the hook is not in-place. If no hook is set, it cannot be removed either.
             * Therefore, this method simply returns if it is called without having a hook in-place.
             */
            if (originalBytes == null)
            {
                return;
            }


            //Declare the variable that is used to store the previous memory protection value in, as returned by the Interop VirtualProtect call, as the memory segment needs to be writable to write the hook
            uint oldProt;

            //The amount of the original bytes
            uint codeSize = (uint)originalBytes.Length;

            /**
            * Ensure that the hook can be writen to the start of the original function in memory, by making the area from the start of the original method
            * plus the size of the hook executable, readable, and writable
            */
            VirtualProtect(OriginalMethodPointer, codeSize, PAGE_READ_WRITE_EXECUTE, out oldProt);

            //Starts the unsafe code block where the hook is removed
            unsafe
            {
                //Declares a byte pointer based on the original method
                byte* ptr = (byte*)OriginalMethodPointer;

                /**
                 * Copies the original bytes from the byte array to the original method, on their original place, thus removing the hook
                 */
                for (var i = 0; i < codeSize; ++i)
                {
                    ptr[i] = originalBytes[i];
                }
            }
            //Restores the memory permissions for the memory segment to the original value
            VirtualProtect(OriginalMethodPointer, codeSize, oldProt, out oldProt);

            //The function has been unhooked, meaning the original bytes need to be nulled again, to avoid a faulty (un)hook function to continue when called in the wrong order
            originalBytes = null;
        }

        /// <summary>
        /// Compares the given method with this instance's hook, based on a string representation of the function's signature, ignoring casing
        /// </summary>
        /// <param name="method">The method to compare the hook with</param>
        /// <returns>True if the two methods are equal in , false if not</returns>
        public bool CompareHook(MethodInfo method)
        {
            return CompareHook(Serialise.Method(method));
        }

        /// <summary>
        /// Compares the given method with this instance's hook, based on a string representation of the function's signature, ignoring casing
        /// </summary>
        /// <param name="method">The method to compare the hook with</param>
        /// <returns>True if the two methods are equal in , false if not</returns>
        public bool CompareHook(string method)
        {
            return method.Equals(HookMethod, StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Compares the given method with this instance's original method, based on a string representation of the function's signature, ignoring casing
        /// </summary>
        /// <param name="method">The method to compare the original method with</param>
        /// <returns>True if the two methods are equal, false if not</returns>
        public bool CompareOriginal(MethodInfo method)
        {
            return CompareOriginal(Serialise.Method(method));
        }

        /// <summary>
        /// Compares the given method with this instance's original method, based on a string representation of the function's signature, ignoring casing
        /// </summary>
        /// <param name="method">The method to compare the original method with</param>
        /// <returns>True if the two methods are equal, false if not</returns>
        public bool CompareOriginal(string method)
        {
            return method.Equals(OriginalMethod, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}