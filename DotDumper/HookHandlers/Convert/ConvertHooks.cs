using System;
using System.Runtime.CompilerServices;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ConvertHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] FromBase64StringString(string s)
        {
            //Declare the local variable to store the object in
            byte[] output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FromBase64StringString");
                //Call the original function
                output = Convert.FromBase64String(s);
                //Restore the hook
                HookManager.HookByHookName("FromBase64StringString");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConvertFromBase64StringString(), new object[] { s }, output);
            }

            //Return the process object to the caller
            return output;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] FromBase64CharArrayCharyArrayIntInt(char[] inArray, int offset, int length)
        {
            //Declare the local variable to store the object in
            byte[] output;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Disable the placed hook
                HookManager.UnHookByHookName("FromBase64CharArrayCharyArrayIntInt");
                //Call the original function
                output = Convert.FromBase64CharArray(inArray, offset, length);
                //Restore the hook
                HookManager.HookByHookName("FromBase64CharArrayCharyArrayIntInt");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConvertFromBase64CharArrayCharArrayIntInt(), new object[] { inArray, offset, length }, output);
            }

            //Return the process object to the caller
            return output;
        }
    }
}
