using System.Reflection;

namespace DotDumper.HookHandlers
{
    class MethodBaseHooksHelper
    {
        public static void Invoke(MethodBase method, object[] parameters)
        {
            //TODO invoke related hooks display a hook for the target function in the log, not for the originally hooked function
            //MethodInfo methodInfo = method.DeclaringType.GetMethod(method.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
            int stackTraceOffset = 2;
            //Write the aggregated data to the log and the console
            GenericHookHelper._Logger.Log(stackTraceOffset, method, parameters, null);
        }
    }

}
