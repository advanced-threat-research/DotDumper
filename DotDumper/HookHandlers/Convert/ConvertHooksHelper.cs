namespace DotDumper.HookHandlers
{
    class ConvertHooksHelper
    {
        public static void Process(string functionName, string encoded, byte[] decoded)
        {
            //string message = ""; // GenericHookHelper.GetStackTraceAndAssemblyMapping(2);
            //string encodedPath = GenericHookHelper.SaveFile(encoded);
            //string decodedPath = GenericHookHelper.SaveFile(decoded);
            //message += "The encoded string (" + encoded.Length + " characters in size) has been saved at \"" + encodedPath + "\"\n";
            //message += "The decoded data (" + decoded.Length + " bytes in size) has been saved at \"" + decodedPath + "\"\n";
            //message += "\n";

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(2, OriginalFunctions.ConvertFromBase64StringString(), new object[] { encoded }, decoded);
        }

        public static void Process(string functionName, char[] inArray, int offset, int length, byte[] decoded)
        {
            //char[] encoded = new char[length];
            //for (int i = 0; i < length; i++)
            //{
            //    encoded[i] = inArray[offset + i];
            //}

            //string inArrayPath = GenericHookHelper.SaveFile(new String(inArray));
            //string encodedPath = GenericHookHelper.SaveFile(new String(encoded));
            //string decodedPath = GenericHookHelper.SaveFile(decoded);

            //string message = ""; //GenericHookHelper.GetStackTraceAndAssemblyMapping(2);
            //message += "The complete input array (" + inArray.Length + " characters in size) has been saved at \"" + inArrayPath + "\"\n";
            //message += "The encoded string (" + encoded.Length + " characters in size) has been saved at \"" + encodedPath + "\"\n";
            //message += "The decoded data (" + decoded.Length + " bytes in size) has been saved at \"" + decodedPath + "\"\n";
            //message += "\n";

            //Write the aggregated data to the log and the console
            //GenericHookHelper._Logger.Log(2, OriginalFunctions.ConvertFromBase64CharArrayCharArrayIntInt(), new object[] { inArray, offset, length }, decoded);
        }
    }
}
