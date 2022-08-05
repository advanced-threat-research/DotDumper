using System.Globalization;
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
                //Sets the title for the log
                string functionName = "MethodBase.Invoke(object obj, object[] parameters)";
                //Process the given data via the helper class
                MethodBaseHooksHelper.Invoke(methodBase, parameters);
            }

            //Start the timer to induce the race condition
            RaceConditionHandler.StartTimer("InvokeHookObjectObjectArray");
            //Call the original function
            result = methodBase.Invoke(obj, parameters);

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object InvokeHookObjectBindingFlagsBinderObjectArrayCultureInfo(MethodBase methodBase, object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
        {
            //Declare the local variable to store the assembly object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Thread thread = new Thread(new ThreadStart(ThreadHandler.RaceHook));
                //thread.Start();


                //Disable the placed hook
                //Hooks.UnhookByHookName("InvokeHookObjectObjectArray");
                //Call the original function
                result = methodBase.Invoke(obj, invokeAttr, binder, parameters, culture);
                //Restore the hook
                //Hooks.HookByHookName("InvokeHookObjectObjectArray");

                //Sets the title for the log
                string functionName = "MethodBase.Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)";
                //Process the given data via the helper class
                //AssemblyHooksHelper.Process(functionName, result);
            }

            //Return the process object to the caller
            return result;
        }
    }
}
