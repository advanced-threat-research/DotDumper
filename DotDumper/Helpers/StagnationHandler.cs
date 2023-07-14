using System;
using DotDumper.HookHandlers;
using DotDumper.Hooks;
using DotDumper.Models;

namespace DotDumper.Helpers
{
    /// <summary>
    /// A class which contains the stagnation timer's callback function. This function is called with an interval that is defined upon the timer's creation (see program.cs in the project's root). 
    /// If a third interval of the given time span passes without an increase logged messages, the callback function ensures that DotDumper is shut down. This is done to escape situations where
    /// process injection took place (often with native functions) and DotDumper erroneously waits for the function to return (even though it wont until the malware stops its own execution).
    /// When using a sandbox, this cuts down the runtime to the point where it only runs if DotDumper is actually active, thus saving time.
    /// </summary>
    class StagnationHandler
    {
        /// <summary>
        /// The amount of logs that were logged by the logger
        /// </summary>
        private static int _Count = 0;

        /// <summary>
        /// The stage of the handler, where 0 is the start, and 2 is the moment to trigger the termination clause. The stage is increased with 1 every time the callback function is called and the amount of logs (as saved in count) is equal to the amount of logs the logger saved.
        /// </summary>
        private static int _Stage = 0;

        /// <summary>
        /// The stagnation handler timer's callback function, which is called at every interval of the timer
        /// </summary>
        /// <param name="o">Optional parameters, as specified by the interface, but not used by this instance of the timer</param>
        public static void TimerCallback(object o)
        {
            //If the logging count and the current count are equal, raise the stage variable. The condition where the logging is empty is not a real case, as the reflective loading of the sample already creates a single log.
            if (GenericHookHelper._Logger.Count == _Count)
            {
                _Stage++;
            }
            else //If the values are not equal, the local count variable is made equal to the amount of logs that were written, and the stage is set back to 0
            {
                _Count = GenericHookHelper._Logger.Count;
                _Stage = 0;
            }

            //If the stage is equal to, or more than, two, it means that the timer has called this callback twice without the creation of a single log
            if (_Stage >= 2)
            {
                //If the DEBUG variable set to false, it means it is running in a normal environment
                if (Program.DEBUG == false)
                {
                    //Remove all hooks
                    HookManager.UnHookAll();
                    //Create a new exception with a message
                    Exception ex = new Exception("DotDumper stagnated, and is shutting down!");
                    //Create a new log entry with the exception
                    LogEntry entry = LogEntryHelper.Create(0, ex);
                    //Log the entry
                    GenericHookHelper._Logger.Log(entry, true, true);
                    //Remove all hooks
                    HookManager.UnHookAll();
                    //Set the time a year ahead, forcing the sandbox to time out
                    SetTime();
                    //Exit normally, which is called directly as all hooks are removed
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Sets the system date and time to a year in the future, forcing the sandbox to time out of its runtime
        /// </summary>
        public static void SetTime()
        {
            //Declares and initialises the SystemTime structure with a future time
            InteropFunctions.SystemTime updatedTime = new InteropFunctions.SystemTime
            {
                Year = (ushort)(2200),
                Month = (ushort)12,
                Day = (ushort)30,
                Hour = (ushort)12,
                Minute = (ushort)00,
                Second = (ushort)0
            };

            //Set the time to next year, forcing the sandbox to time out
            InteropFunctions.SetSystemTime(ref updatedTime);
        }
    }
}
