using System;
using System.Globalization;
using System.Reflection;
using DotDumper.Helpers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.HookHandlers
{
    class TypeHooksHelper
    {
        public static void InvokeMemberHandler(string functionName, Type type, string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, CultureInfo culture)
        {
            MethodInfo methodInfo = GetMethodInfo(type, name, args);
            LogEntry entry = null;
            if (methodInfo == null)
            {
                string fullName = type.FullName + "." + name;
                if (culture == null)
                {
                    methodInfo = OriginalManagedFunctions.TypeInvokeMemberStringBindingFlagsBinderObjectObjectArray();
                }
                else
                {
                    methodInfo = OriginalManagedFunctions.TypeInvokeMemberStringBindingFlagsBinderObjectObjectArrayCultureInfo();
                }
            }
            else
            {
                entry = LogEntryHelper.Create(2, methodInfo, args, null);

            }

            //Write the aggregated data to the log and the console
            GenericHookHelper._Logger.Log(entry, false, true);
        }

        private static MethodInfo GetMethodInfo(Type type, string name, object[] args)
        {
            MethodInfo method = null;
            foreach (MethodInfo methodInfo in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
            {
                if (methodInfo.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    ParameterInfo[] parameterInfos = methodInfo.GetParameters();
                    int argsLength = -1;
                    if (args == null)
                    {
                        argsLength = 0;
                    }
                    else
                    {
                        argsLength = args.Length;
                    }

                    if (parameterInfos.Length == argsLength)
                    {
                        bool match = true;
                        if (argsLength > 0)
                        {
                            for (int i = 0; i < args.Length; i++)
                            {
                                if (parameterInfos[i].ParameterType != args[i].GetType())
                                {
                                    match = false;
                                }
                            }
                        }
                        if (match)
                        {
                            method = methodInfo;
                            return method;
                        }
                    }
                }
            }
            return method;
        }
    }
}
