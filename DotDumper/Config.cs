namespace DotDumper
{
    /// <summary>
    /// This class contains the default configuration values. Fields are overwritten with user-provided arguments if present.
    /// </summary>
    class Config
    {
        /// <summary>
        /// The complete path to the sample that is to be executed. The default value is null.
        /// </summary>
        public static string SamplePath = null;

        /// <summary>
        /// The name of the folder that is to be used to place all artifacts in. This folder always resides within DotDumper.exe's folder. The default value is null.
        /// </summary>
        public static string LoggerFolder = null;

        /// <summary>
        /// True if deprecated functions should also be hooked (when a hook is present for such a function that is), false if not. The default value is true.
        /// </summary>
        public static bool IncludeDeprecatedFunctions = true;

        /// <summary>
        /// True if the hooks should be printed in string form during DotDumper's startup, false if not. The default value is true.
        /// </summary>
        public static bool LogHooks = true;

        /// <summary>
        /// The amount of milliseconds that the timer waits before calling the callback function for the rehook. The default value is 20.
        /// </summary>
        public static int RaceConditionDueTime = 20;

        /// <summary>
        /// Defines if the entry point (if present) should be overriden. A sample without an entrypoint should still be overridden! The default value is false.
        /// </summary>
        public static bool OverrideEntryPoint = false;

        /// <summary>
        /// The fully qualified class name, including the namespace(s). The default value is null.
        /// </summary>
        public static string DllFullyQualifiedClassName = null;

        /// <summary>
        /// The name of the public function in the given fully qualified class name. The default value is null.
        /// </summary>
        public static string DllFunctionName = null;

        /// <summary>
        /// The provided arguments for the given function (or the entry point). The default value is null.
        /// </summary>
        public static object[] DllArguments = null;

        /// <summary>
        /// True if calls to Thread.Sleep should be skipped, false if not. The default value is true.
        /// </summary>
        public static bool SleepSkip = true;

        /// <summary>
        /// True if the logs should be printed to the console, false if not. The default value is true.
        /// </summary>
        public static bool PrintLogsToConsole = true;
    }
}
