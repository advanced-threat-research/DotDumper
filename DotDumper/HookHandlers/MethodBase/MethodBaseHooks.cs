using System.Reflection;
using System.Runtime.CompilerServices;
using DotDumper.Helpers;

namespace DotDumper.HookHandlers
{
    class MethodBaseHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object InvokeHookObjectObjectArray(MethodBase methodBase, object obj, object[] parameters)
        {
            //Declare the local variable to store the assembly object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                int stackTraceOffset = 1;
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(stackTraceOffset, methodBase, parameters, null);
            }

            //Start the timer to induce the race condition
            RaceConditionHandler.StartTimer("InvokeHookObjectObjectArray");
            //Call the original function
            result = methodBase.Invoke(obj, parameters);

            //Return the process object to the caller
            return result;
        }
    }
}
