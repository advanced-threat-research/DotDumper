namespace DotDumper.HookHandlers
{
    class ResourceManagerHooksHelper
    {
        public static void Handle(string functionName, string resourceName)
        {
            //Causes a loop, as the String.Replace call within the stacktrace call requires a resource
            //string message = GenericHookHelper.GetStackTrace(2);
            string message = "The following resource was requested: " + resourceName + "\n";
            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(functionName, message);
        }
    }
}