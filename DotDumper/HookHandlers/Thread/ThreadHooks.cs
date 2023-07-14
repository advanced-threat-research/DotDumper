using System;
using System.Runtime.CompilerServices;
using System.Threading;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ThreadHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SleepHookInt(int millisecondsTimeout)
        {
            //Avoids cluttering the log
            if (millisecondsTimeout <= 1)
            {
                return;
            }
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //If sleep is to be skipped, the function is never called
                if (Config.SleepSkip == false)
                {
                    //Disable the placed hook
                    HookManager.UnHookAll();
                    //Call the original function
                    Thread.Sleep(millisecondsTimeout);
                    //Restore the hook
                    HookManager.HookAll();
                }
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ThreadSleepInt(), new object[] { millisecondsTimeout }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SleepHookTimeSpan(TimeSpan timeout)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //If sleep is to be skipped, the function is never called
                if (Config.SleepSkip == false)
                {
                    //Disable the placed hook
                    HookManager.UnHookAll();
                    //Call the original function
                    Thread.Sleep(timeout);
                    //Restore the hook
                    HookManager.HookAll();
                }

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ThreadSleepTimeSpan(), new object[] { timeout }, null);
            }
        }
    }
}
