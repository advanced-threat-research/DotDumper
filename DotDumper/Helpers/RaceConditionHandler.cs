using System.Threading;
using DotDumper.Hooks;
using System;
using System.Collections.Generic;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class handles the race condition that allows to rehook invoke related functions during their execution
    /// </summary>
    class RaceConditionHandler
    {
        /// <summary>
        /// The dictionary that contains all timers (as multiple can be created via multiple threads), where a GUID is the key, and the timer object is the value
        /// </summary>
        private static readonly Dictionary<string, Timer> timers = new Dictionary<string, Timer>();

        /// <summary>
        /// This function unhooks the given hook based on its name, after which it waits 20 milliseconds. It then calls the timer callback function, which rehooks the given hook. The timer callback is only called once, after which the Timer object is destroyed.
        /// </summary>
        /// <param name="hookName">The function to unhook and rehook</param>
        public static void StartTimer(string hookName)
        {
            //Create a string with the GUID and the hook name, split by a pipe
            string data = hookName + "|" + Guid.NewGuid().ToString();
            //Unhook the hook
            HookManager.UnHookByHookName(hookName);
            //Create a timer object which calls the callback function once, after a 20 ms delay, using the data string as an argument
            Timer timer = new Timer(TimerCallback, data, Config.RaceConditionDueTime, Timeout.Infinite); //Timeout.Infinite (aka -1) means no repeated calls, see https://docs.microsoft.com/en-us/dotnet/api/system.threading.timeout.infinite
            //Add the timer to the dictionary
            timers.Add(data, timer);

        }

        /// <summary>
        /// The callback function for the timer that rehooks the unhooked function
        /// </summary>
        /// <param name="o">The function argument has to be an argument, but it is actually a string array in this case. The format should be "my-guid|hookName"</param>
        private static void TimerCallback(object o)
        {
            //Split the string into the GUID and function name respectively
            string[] array = ((string)o).Split('|');
            //Set the hook again
            HookManager.HookByHookName(array[0]);
            //Get the GUID
            string guid = array[1];
            //Remove the GUID from the dictionary
            timers.Remove(guid);
        }
    }
}
