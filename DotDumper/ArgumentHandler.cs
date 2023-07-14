using System;
using System.IO;
using System.Reflection;

namespace DotDumper
{
    /// <summary>
    /// This class handles user-provided arguments by parsing them, and updating the fields in the Config class when need be. At last, a check is performed to ensure that the required arguments are provided.
    /// </summary>
    class ArgumentHandler
    {
        #region Argument markers and descriptions
        /// <summary>
        /// The marker for the sample path (equals "-file")
        /// </summary>
        public const string SamplePathMarker = "-file";

        /// <summary>
        /// The description for the sample path
        /// </summary>
        public const string SamplePathDescription = "The complete path to the file to launch. This is the only mandatory argument, if the provided file has\n\t\tan entry point. Note that providing only a single CLI argument with the file's location also works!";

        /// <summary>
        /// The marker for the logging folder name (equals "-log")
        /// </summary>
        public const string LoggingFolderNameMarker = "-log";

        /// <summary>
        /// The description of the logging folder name
        /// </summary>
        public const string LoggingFolderNameDescription = "The name of the folder to place artifacts in, which will be placed within the same folder as DotDumper.\n\t\tIf this argument is missing, the sample's file name will be used.";

        /// <summary>
        /// The marker for the deprecated function inclusion/exclusion
        /// </summary>
        public const string DeprecatedFunctionMarker = "-deprecated";

        /// <summary>
        /// The description for the deprecated function inclusion/exclusion
        /// </summary>
        public const string DeprecatedFunctionDescription = "Hook deprecated functions, needs to be true or false. The default value is true";

        /// <summary>
        /// The marker for the argument which decides if the loaded hooks should be displayed
        /// </summary>
        public const string LogHooksMarker = "-displayHooks";

        /// <summary>
        /// The description for the logging of all loaded hooks
        /// </summary>
        public const string LogHooksDescription = "Print all hooked functions upon startup, needs to be true or false. The default value is true";

        /// <summary>
        /// The race condition marker, which indicates an overwrite of the delay on the race condition timer
        /// </summary>
        public const string RaceConditionDueTimeMarker = "-raceTime";

        /// <summary>
        /// The decription of the race condition delay argument
        /// </summary>
        public const string RaceConditionDueTimeDescription = "The amount of milliseconds that are between the hook and re-hook of Invoke-related functions.\n\t\tThe default value is 20";

        /// <summary>
        /// Decides if the entry point of the binary should be ignored
        /// </summary>
        public const string OverrideEntryPointMarker = "-overrideEntry";

        /// <summary>
        /// The description of the override functionality
        /// </summary>
        public const string OverrideEntryPointDescription = "Defines if the default entry point should be overridden, needs to be true or false. The default value\n\t\tis false. The use of -fqcn and -functionName is mandatory with this argument, whereas -args and\n\t\t-argc are optional (though both -args and -argc need to be used together when they are used).";

        /// <summary>
        /// The marker for the fully qualified class name (including the namespace)
        /// </summary>
        public const string DllFullyQualifiedClassNameMarker = "-fqcn";

        /// <summary>
        /// The description of the fully qualified class name (including the namespace)
        /// </summary>
        public const string DllFullyQualifiedClassDescription = "The fully qualified class, including namespace, to find the function in. Only used when overriding\n\t\tthe entry point. Needs to be used together with -functionName.";

        /// <summary>
        /// The marker for the function name
        /// </summary>
        public const string DllFunctionNameMarker = "-functionName";

        /// <summary>
        /// The description for the function name's description
        /// </summary>
        public const string DllFunctionNameDescription = "The function name to call, excluding types and parameters, within the fully qualified class.\n\t\tOnly used when overriding the entry point. Needs to be used together with -fqcn.";

        /// <summary>
        /// The marker for the arguments
        /// </summary>
        public const string PayloadArgumentsMarker = "-args";

        /// <summary>
        /// The description for the arguments
        /// </summary>
        public const string PayloadArgumentsDescription = "The arguments for the function, providing the type and value at once, split by a pipe,\n\t\tsuch as int|7, double|3.14, or string|myValue\n\t\tThe following types are supported: bool, byte, sbyte, char, decimal, double, float, int, uint, long,\n\t\tulong, short, ushort, string, as well as arrays of each of those types. Arrays are indicated using \"[]\"\n\t\tdirectly after the type, such as \"string[]\". The values are to be split using commas.\n\t\tAn example: string[]|string1,string2,string3\n\t\tNull is also possible, but note that this value (or lack thereof) should not be capitalised.\n\t\tNeeds to be used together with -argc.";

        /// <summary>
        /// The index of the first argument in the provided array of DotDumper arguments by the user
        /// </summary>
        private static int PayloadArgumentsIndex = -1;

        /// <summary>
        /// The marker for the argument count
        /// </summary>
        public const string PayloadArgumentCountMarker = "-argc";

        /// <summary>
        /// The description for the argument count
        /// </summary>
        public const string PayloadArgumentCountDescription = "The number of arguments that are provided, as an integer. Needs to be used together with -args.";

        /// <summary>
        /// The amount of arguments, as provided by the user
        /// </summary>
        private static int PayloadArgumentCount = -1;

        /// <summary>
        /// The marker to decide if sleep calls should be skipped
        /// </summary>
        public const string SleepSkipMarker = "-sleepSkip";

        /// <summary>
        /// The description for the sleep skip functionality
        /// </summary>
        public const string SleepSkipDescription = "Defines if Thread.Sleep calls need to be skipped, needs to be true or false. The default value is true.";

        /// <summary>
        /// The marker to decide if logs should be printed to the console
        /// </summary>
        public const string ConsolePrintingMarker = "-console";

        /// <summary>
        /// The description for the optional console logging functionality
        /// </summary>
        public const string ConsolePrintingDescription = "Defines if the logging should be printed to the console window or not. The default value is true.";

        /// <summary>
        /// The help marker
        /// </summary>
        public const string HelpMarker = "-help";

        /// <summary>
        /// The description of the help marker
        /// </summary>
        public const string HelpDescription = "Prints the help menu. This cannot be used in combination with other options, as they will be ignored.";
        #endregion

        /// <summary>
        /// A helper function to combine a marker and a description, including the required newlines and tabs
        /// </summary>
        /// <param name="marker">The marker to combine with the description</param>
        /// <param name="description">The description to combine with the marker</param>
        /// <returns>The combined marker and description</returns>
        private static string CombineMarkerAndDescription(string marker, string description)
        {
            return marker + "\n" +
                "\t\t" + description + "\n";
        }

        /// <summary>
        /// A helper function to get the complete help message as a single string
        /// </summary>
        /// <returns>The complete help message</returns>
        private static string GetHelpMessage()
        {
            //Initialises the program's version, and a note that all arguments are case sensitive
            string help = Program.VERSION + "\n" +
                "Note that all arguments are cases sensitive!\n";

            //Adds all the markers and their descriptions into the help message
            help += CombineMarkerAndDescription(SamplePathMarker, SamplePathDescription);
            help += CombineMarkerAndDescription(LoggingFolderNameMarker, LoggingFolderNameDescription);
            help += CombineMarkerAndDescription(DeprecatedFunctionMarker, DeprecatedFunctionDescription);
            help += CombineMarkerAndDescription(LogHooksMarker, LogHooksDescription);
            help += CombineMarkerAndDescription(RaceConditionDueTimeMarker, RaceConditionDueTimeDescription);
            help += CombineMarkerAndDescription(OverrideEntryPointMarker, OverrideEntryPointDescription);
            help += CombineMarkerAndDescription(DllFullyQualifiedClassNameMarker, DllFullyQualifiedClassDescription);
            help += CombineMarkerAndDescription(DllFunctionNameMarker, DllFunctionNameDescription);
            help += CombineMarkerAndDescription(PayloadArgumentsMarker, PayloadArgumentsDescription);
            help += CombineMarkerAndDescription(PayloadArgumentCountMarker, PayloadArgumentCountDescription);
            help += CombineMarkerAndDescription(SleepSkipMarker, SleepSkipDescription);
            help += CombineMarkerAndDescription(ConsolePrintingMarker, ConsolePrintingDescription);
            help += CombineMarkerAndDescription(HelpMarker, HelpDescription);

            //Adds the well known message to keep the console open, if it wasn't launched via a terminal
            help += "\nPress any key to exit...";

            //Return the complete message
            return help;
        }

        /// <summary>
        /// Checks if the help marker is used as an argument at any point, or if the given array is null or empty. If any of the mentioned conditions is met, the help menu is printed, after which DotDumper will await for the user to press any key, leading to DotDumper's shutdown.
        /// </summary>
        /// <param name="args">The args array to check for the help parameter</param>
        private static void CheckHelp(string[] args)
        {
            //Declare the variable which will incidate if the help marker has been found
            bool help = false;

            //If the provided argument is null or empty, the help menu must be shown, as one at least needs to provide a file to DotDumper
            if (args == null || args.Length == 0)
            {
                help = true;
            }
            else
            {
                //If it is not null nor empty, iterate over all arguments
                for (int i = 0; i < args.Length; i++)
                {
                    //Check if the current argument equals the helpmarker
                    if (args[i].Equals(HelpMarker))
                    {
                        //Set the help variable to true
                        help = true;
                        //Break the loop, as the help marker has been found
                        break;
                    }
                }
            }

            //If the help variable is true
            if (help)
            {
                //Get and write the help message
                Console.WriteLine(GetHelpMessage());
                //Wait for any user input
                Console.ReadKey();
                //Exit
                Environment.Exit(0);
            }
            //If the variable is false, nothing has to be done
        }

        /// <summary>
        /// Checks (in the listed order) if the given value is a file in the current directory, the directory of DotDumper, or if it is a full path.
        /// </summary>
        /// <param name="value">The (partial) path and file name of the target file</param>
        private static void CheckFile(string value)
        {
            //Check if the sample is located in the current working directory
            string filePath = Directory.GetCurrentDirectory() + @"\" + value;
            if (File.Exists(filePath))
            {
                Config.SamplePath = filePath;
            }

            //Check if the sample is located in the same folder as DotDumper
            filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\" + value;
            if (File.Exists(filePath))
            {
                Config.SamplePath = filePath;
            }

            //Check if a full path is given, but only after the two other defined directions have been checked, as the Assembly object can only be loaded with a full path, not a relative one
            if (File.Exists(value))
            {
                Config.SamplePath = value;
            }

            //Only throw the exception if the sample path hasn't been set (meaning the sample hasn't been found)
            if (Config.SamplePath == null)
            {
                //Throw an error if none of the above options results in a match with a file on the user's file system
                throw new Exception("The provided sample path at \"" + value + "\" does not exist, and cannot be found in the current working directory nor in DotDumper's folder!");
            }

        }

        /// <summary>
        /// Parses the arguments and sets the config fields that need to be updated based on the arguments. The checks afterwards ensure that only correct combinations of arguments are allowed, or an error is thrown.
        /// </summary>
        /// <param name="args"></param>
        public static void ParseArguments(string[] args)
        {
            //Check if the help marker is provided. If so, this function does not return
            CheckHelp(args);

            /*
             * Ensure that a single argument leading to the path is possible, when the size of args equals 1, 
             * it is to be redefined as an array with the size of two, where the first argument is "-file"
             */
            try
            {
                //Only attempt this if there is a single argument
                if (args.Length == 1)
                {
                    //Call the check file function, which throws an exception if it fails
                    CheckFile(args[0]);
                    /*
                     * If this code is reached, the function call above was successful, otherwise I'd throw an exception.
                     * Because of that, the normal CLI parsing can continue if the string array is set again, with the file
                     * path marker as the first argument, and its value as the second, as if it were done manually
                     */
                    args = new string[] { SamplePathMarker, args[0] };
                }
            }
            catch (Exception)
            {
                /*
                 * The sole argument was not equal to the file path marker. There is no need to handle this error, other than
                 * ignoring it.
                 */
            }


            //Open the try block to handle wrong argument exceptions
            try
            {
                //Declare i prior to the loop, as it is also used outside of the loop in some cases
                int i;
                for (i = 0; i < args.Length; i++)
                {
                    //Get the current argument, in lower case
                    string arg = args[i];

                    //Check if the next index exists, as the marker is always accompanied by at least one argument
                    if (NextIndexExists(args, i))
                    {
                        //Get the value of the next index, which is known to exist at this point
                        string value = args[i + 1];

                        //Handle all marker options (aside from the help one, which was handled before the try block)
                        if (IsEqual(arg, SamplePathMarker))
                        {

                            CheckFile(value);
                        }
                        else if (IsEqual(arg, LoggingFolderNameMarker))
                        {
                            Config.LoggerFolder = value;
                        }
                        else if (IsEqual(arg, DeprecatedFunctionMarker))
                        {
                            try
                            {
                                Config.IncludeDeprecatedFunctions = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                throw new Exception("The boolean to determine if deprecated functions should also be hooked is not a valid boolean: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, LogHooksMarker))
                        {
                            try
                            {
                                Config.LogHooks = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                throw new Exception("The boolean to determine if the hooks should be logged is not a valid boolean: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, RaceConditionDueTimeMarker))
                        {
                            try
                            {
                                int raceConditionTime = Convert.ToInt32(value);
                                if (raceConditionTime <= 0)
                                {
                                    throw new Exception();
                                }
                                Config.RaceConditionDueTime = raceConditionTime;
                            }
                            catch (Exception)
                            {
                                throw new Exception("The integer to determine the duration of the time the timer should wait before rehooking invoke related functions is not a valid integer with a size of more than zero: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, OverrideEntryPointMarker))
                        {
                            try
                            {
                                Config.OverrideEntryPoint = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                throw new Exception("The boolean to determine if a user-specified entry point should be used is not a valid boolean: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, DllFullyQualifiedClassNameMarker))
                        {
                            Config.DllFullyQualifiedClassName = value;
                        }
                        else if (IsEqual(arg, DllFunctionNameMarker))
                        {
                            Config.DllFunctionName = value;
                        }
                        else if (IsEqual(arg, PayloadArgumentsMarker))
                        {
                            PayloadArgumentsIndex = i + 1;
                        }
                        else if (IsEqual(arg, PayloadArgumentCountMarker))
                        {
                            try
                            {
                                int argCount = Convert.ToInt32(value);
                                if (argCount <= 0)
                                {
                                    throw new Exception();
                                }
                                PayloadArgumentCount = argCount;
                            }
                            catch (Exception)
                            {
                                throw new Exception("The integer that indicates the amount of arguments the function requires is not a valid integer that is bigger than one: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, SleepSkipMarker))
                        {
                            try
                            {
                                Config.SleepSkip = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                throw new Exception("The boolean to determine if sleep calls need to be skipped is not a valid boolean: \"" + value + "\"!");
                            }
                        }
                        else if (IsEqual(arg, ConsolePrintingMarker))
                        {
                            try
                            {
                                Config.PrintLogsToConsole = Convert.ToBoolean(value);
                            }
                            catch (Exception)
                            {
                                throw new Exception("The boolean to determine if logs need to be printed to the console window is not a valid boolean: \"" + value + "\"!");
                            }
                        }
                    }
                }

                #region Mandatory value checks
                //If no sample was provided, an error is thrown
                if (Config.SamplePath == null)
                {
                    throw new Exception("No file has been provided! Use \"" + SamplePathMarker + "\" to specify the file, or use \"" + HelpMarker + "\" to show the help menu!");
                }
                //If the name of the logger folder is not provided, the name of the given sample is used. The sample exists and is not null, as previous checks already ensured that
                if (Config.LoggerFolder == null)
                {
                    SetLoggerFolderName();
                }
                #endregion

                #region Optional value checks
                //If the entry point should be overridden
                if (Config.OverrideEntryPoint == true)
                {
                    //The fully qualified class name needs to be present
                    if (Config.DllFullyQualifiedClassName == null)
                    {
                        throw new Exception("The default entry point is to be overridden, but the fully qualified class name that is to be used, is null!");
                    }
                    //As well as the function name
                    if (Config.DllFunctionName == null)
                    {
                        throw new Exception("The default entry point is to be overridden, but the function name that is to be used, is null!");
                    }
                    //Arguments are optional, and can also be used for an entry point, which is why they are outside this if-block
                }

                //If the index and count are not equal to their initial value of -1, it means that they were both provided
                if (PayloadArgumentsIndex > 0 && PayloadArgumentCount > 0)
                {
                    //Given that they are both provided, they need to be handled
                    SetDllArguments(args, PayloadArgumentsIndex, PayloadArgumentCount);
                }
                else //In case one or both of these values is still equal to -1
                {
                    //If the payload count is missing, an error is thrown
                    if (PayloadArgumentCount > 0)
                    {
                        throw new Exception("No argument count was found, even though arguments were specified!");
                    }
                    else if (PayloadArgumentsIndex > 0) //If the payload count is more than zero, it means that the index is missing, for which an error needs to be thrown
                    {
                        throw new Exception("No arguments were found, even though an argument count was specified!");
                    }
                }
                #endregion
            }
            catch (Exception ex) //Any thrown exception is caught, printed to the standard output, after which DotDumper waits for any key to exit
            {
                Console.WriteLine("[ERROR] " + ex.Message + "\n\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Sets the logger folder name to the given file name, appending "_DotDumper" to it until the folder does not exist
        /// </summary>
        private static void SetLoggerFolderName()
        {
            string loggerFolder = Path.GetFileNameWithoutExtension(Config.SamplePath);
            while (true)
            {
                if (Directory.Exists(loggerFolder) == false && File.Exists(loggerFolder) == false)
                {
                    break;
                }
                else
                {
                    loggerFolder += "_DotDumper";
                }
            }

            Config.LoggerFolder = loggerFolder;
        }

        /// <summary>
        /// Tries to fetch the next index from the array, based on the provided array and index
        /// </summary>
        /// <param name="args">The array to use</param>
        /// <param name="index">The index to check if there is a next element</param>
        /// <returns>True if a next element exists, false if not</returns>
        private static bool NextIndexExists(string[] args, int index)
        {
            try
            {
                string element = args[index + 1];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the DllArguments field in the config, based on the provided parameters.
        /// </summary>
        /// <param name="args">The complete set of parameters that DotDumper received</param>
        /// <param name="payloadArgumentsIndex">The index at which the first argument is found</param>
        /// <param name="payloadArgumentCount">The amount of arguments that are provided by the user</param>
        private static void SetDllArguments(string[] args, int payloadArgumentsIndex, int payloadArgumentCount)
        {
            //The object array that will contain all arguments
            object[] dllArgs = new object[payloadArgumentCount];

            //The string array that contains the split array for each of the provided types
            string[] arrayValues;

            //Iterate as many times as there are arguments
            for (int i = 0; i < payloadArgumentCount; i++)
            {
                //Get the index to fetch data from the args array
                int index = payloadArgumentsIndex + i;
                //Get and split the data
                string[] splitted = args[index].Split('|');
                //If there are more or less than two fields, something is wrong, thus an error is thrown
                if (splitted.Length != 2)
                {
                    throw new Exception("The provided type-value combination is invalid: \"" + args[index] + "\"!");
                }
                //Get the type from the array, as a lowercase string (so a typo wont influence the outcome here)
                string type = splitted[0].ToLowerInvariant();
                //Get the value of the given argument
                string value = splitted[1];

                //Handle any type of supported variables
                switch (type)
                {
                    case "bool":
                        dllArgs[i] = Convert.ToBoolean(value);
                        break;
                    case "bool[]":
                        arrayValues = HandleArray(value);
                        bool[] bools = new bool[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            bools[count] = Convert.ToBoolean(arrayValues[count]);
                        }
                        dllArgs[i] = bools;
                        break;
                    case "byte":
                        dllArgs[i] = Convert.ToByte(value);
                        break;
                    case "byte[]":
                        arrayValues = HandleArray(value);
                        byte[] bytes = new byte[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            bytes[count] = Convert.ToByte(arrayValues[count]);
                        }
                        dllArgs[i] = bytes;
                        break;
                    case "sbyte":
                        dllArgs[i] = Convert.ToSByte(value);
                        break;
                    case "sbyte[]":
                        arrayValues = HandleArray(value);
                        sbyte[] sbytes = new sbyte[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            sbytes[count] = Convert.ToSByte(arrayValues[count]);
                        }
                        dllArgs[i] = sbytes;
                        break;
                    case "char":
                        dllArgs[i] = Convert.ToChar(value);
                        break;
                    case "char[]":
                        arrayValues = HandleArray(value);
                        char[] chars = new char[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            chars[count] = Convert.ToChar(arrayValues[count]);
                        }
                        dllArgs[i] = chars;
                        break;
                    case "decimal":
                        dllArgs[i] = Convert.ToDecimal(value);
                        break;
                    case "decimal[]":
                        arrayValues = HandleArray(value);
                        decimal[] decimals = new decimal[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            decimals[count] = Convert.ToDecimal(arrayValues[count]);
                        }
                        dllArgs[i] = decimals;
                        break;
                    case "double":
                        dllArgs[i] = Convert.ToDouble(value);
                        break;
                    case "double[]":
                        arrayValues = HandleArray(value);
                        double[] doubles = new double[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            doubles[count] = Convert.ToDouble(arrayValues[count]);
                        }
                        dllArgs[i] = doubles;
                        break;
                    case "float":
                        dllArgs[i] = Convert.ToSingle(value);
                        break;
                    case "float[]":
                        arrayValues = HandleArray(value);
                        float[] floats = new float[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            floats[count] = Convert.ToSingle(arrayValues[count]);
                        }
                        dllArgs[i] = floats;
                        break;
                    case "int":
                        dllArgs[i] = Convert.ToInt32(value);
                        break;
                    case "int[]":
                        arrayValues = HandleArray(value);
                        int[] integers = new int[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            integers[count] = Convert.ToInt32(arrayValues[count]);
                        }
                        dllArgs[i] = integers;
                        break;
                    case "uint":
                        dllArgs[i] = Convert.ToUInt32(value);
                        break;
                    case "uint[]":
                        arrayValues = HandleArray(value);
                        uint[] unsignedIntegers = new uint[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            unsignedIntegers[count] = Convert.ToUInt32(arrayValues[count]);
                        }
                        dllArgs[i] = unsignedIntegers;
                        break;
                    case "long":
                        dllArgs[i] = Convert.ToInt64(value);
                        break;
                    case "long[]":
                        arrayValues = HandleArray(value);
                        long[] longs = new long[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            longs[count] = Convert.ToInt64(arrayValues[count]);
                        }
                        dllArgs[i] = longs;
                        break;
                    case "ulong":
                        dllArgs[i] = Convert.ToUInt64(value);
                        break;
                    case "ulong[]":
                        arrayValues = HandleArray(value);
                        ulong[] unsignedLongs = new ulong[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            unsignedLongs[count] = Convert.ToUInt64(arrayValues[count]);
                        }
                        dllArgs[i] = unsignedLongs;
                        break;
                    case "short":
                        dllArgs[i] = Convert.ToInt16(value);
                        break;
                    case "short[]":
                        arrayValues = HandleArray(value);
                        short[] shorts = new short[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            shorts[count] = Convert.ToInt16(arrayValues[count]);
                        }
                        dllArgs[i] = shorts;
                        break;
                    case "ushort":
                        dllArgs[i] = Convert.ToUInt16(value);
                        break;
                    case "ushort[]":
                        arrayValues = HandleArray(value);
                        ushort[] unsignedShorts = new ushort[arrayValues.Length];
                        for (int count = 0; count < arrayValues.Length; count++)
                        {
                            unsignedShorts[count] = Convert.ToUInt16(arrayValues[count]);
                        }
                        dllArgs[i] = unsignedShorts;
                        break;
                    case "string":
                        dllArgs[i] = value;
                        break;
                    case "string[]":
                        dllArgs[i] = HandleArray(value);
                        break;
                    case "null":
                        dllArgs[i] = null;
                        break;
                    default:
                        throw new Exception("The given type is not supported: \"" + type + "\"");
                }
            }
            //Once all arguments have been parsed without errors, the field in the Config class is set, and the function returns
            Config.DllArguments = dllArgs;
        }

        /// <summary>
        /// A helper function to split an array. This function is created to be able to quickly replace the split value if need be
        /// </summary>
        /// <param name="value">The value to split, using a comma as the splitter</param>
        /// <returns>The split string as a string array</returns>
        private static string[] HandleArray(string value)
        {
            return value.Split(',');
        }

        /// <summary>
        /// A helper function to check if two given strings are equal, regardless of the used casing in either string
        /// </summary>
        /// <param name="string1">The first string to compare</param>
        /// <param name="string2">The second string to compare</param>
        /// <returns>True if the strings are equal (regardless of the used casing), false if not</returns>
        private static bool IsEqual(string string1, string string2)
        {
            if (string1.Equals(string2, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}