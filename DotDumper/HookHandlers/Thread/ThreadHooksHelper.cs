namespace DotDumper.HookHandlers
{
    class ThreadHooksHelper
    {

        public static void Sleep(string functionName, double milliseconds)
        {
            int offset = 2;
            string message = GenericHookHelper.GetStackTraceAndAssemblyMapping(offset);

            message += "A sleep of " + milliseconds + " milliseconds was requested";
            if (Config.SleepSkip)
            {
                message += " and skipped";
            }
            message += "\n\n";

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(2, OriginalFunctions.Thread(), new object[] { encoded }, decoded);
        }
    }
}
