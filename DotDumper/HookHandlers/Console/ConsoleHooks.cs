using System;
using System.Runtime.CompilerServices;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ConsoleHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookString(string value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteString(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookObject(object value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteObject(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookUlong(ulong value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteUlong(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookLong(long value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLong(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookInt(int value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteInt(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookUint(uint value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteUint(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookBool(bool value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteBool(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookChar(char value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteChar(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookDecimal(decimal value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteDecimal(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookFloat(float value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteFloat(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookDouble(double value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteDouble(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookStringObject(string format, object arg0)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteStringObject(), new object[] { format, arg0 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookStringObjectObject(string format, object arg0, object arg1)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteStringObjectObject(), new object[] { format, arg0, arg1 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookStringObjectObjectObject(string format, object arg0, object arg1, object arg2)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteStringObjectObjectObject(), new object[] { format, arg0, arg1, arg2 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookStringObjectObjectObjectObject(string format, object arg0, object arg1, object arg2, object arg3)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteStringObjectObjectObjectObject(), new object[] { format, arg0, arg1, arg2, arg3 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookStringObjectArray(string format, params object[] arg)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteStringObjectArray(), new object[] { format, arg }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookCharArray(char[] buffer)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteCharArray(), new object[] { buffer }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteHookCharArrayIntInt(char[] buffer, int index, int count)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteCharArrayIntInt(), new object[] { buffer, index, count }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookString(string value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteString(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookObject(object value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineObject(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookUlong(ulong value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineUlong(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookLong(long value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineLong(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookInt(int value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineInt(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookUint(uint value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineUint(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookBool(bool value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineBool(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookChar(char value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineChar(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookDecimal(decimal value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineDecimal(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookFloat(float value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineFloat(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookDouble(double value)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineDouble(), new object[] { value }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookStringObject(string format, object arg0)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineStringObject(), new object[] { format, arg0 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookStringObjectObject(string format, object arg0, object arg1)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineStringObjectObject(), new object[] { format, arg0, arg1 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookStringObjectObjectObject(string format, object arg0, object arg1, object arg2)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineStringObjectObjectObject(), new object[] { format, arg0, arg1, arg2 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookStringObjectObjectObjectObject(string format, object arg0, object arg1, object arg2, object arg3)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineStringObjectObjectObjectObject(), new object[] { format, arg0, arg1, arg2, arg3 }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookStringObjectArray(string format, params object[] arg)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineStringObjectArray(), new object[] { format, arg }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookCharArray(char[] buffer)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineCharArray(), new object[] { buffer }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHookCharArrayIntInt(char[] buffer, int index, int count)
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLineCharArrayIntInt(), new object[] { buffer, index, count }, null);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLineHook()
        {
            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                Console.WriteLine();
                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.Log(1, OriginalManagedFunctions.ConsoleWriteLine(), new object[] { }, null);
            }
        }
    }
}