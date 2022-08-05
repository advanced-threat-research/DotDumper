using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using DotDumper.Helpers;

namespace DotDumper.HookHandlers
{
    class TypeHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object InvokeMemberHookStringBindingFlagsBinderObjectObjectArrayCultureInfo(Type type, string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Type.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture)";
                //Process the given data via the helper class
                TypeHooksHelper.InvokeMemberHandler(functionName, type, name, invokeAttr, binder, target, args, culture);
            }

            //Start the timer to induce the race condition
            RaceConditionHandler.StartTimer("InvokeMemberHookStringBindingFlagsBinderObjectObjectArrayCultureInfo");
            //Call the original function
            result = type.InvokeMember(name, invokeAttr, binder, target, args, culture);

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object InvokeMemberHookStringBindingFlagsBinderObjectObjectArray(Type type, string name, BindingFlags invokeAttr, Binder binder, object target, object[] args)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Type.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args)";
                //Process the given data via the helper class
                TypeHooksHelper.InvokeMemberHandler(functionName, type, name, invokeAttr, binder, target, args, null);
            }

            //Start the timer to induce the race condition
            RaceConditionHandler.StartTimer("InvokeMemberHookStringBindingFlagsBinderObjectObjectArray");
            //Call the original function
            result = type.InvokeMember(name, invokeAttr, binder, target, args);

            //Return the process object to the caller
            return result;
        }
    }
}
