using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using DotDumper.Hooks;

namespace DotDumper.Helpers
{
    /// <summary>
    /// This class is used to convert a given object to JSON using the built-in JavaScriptSerializer object
    /// </summary>
    class Serialise
    {
        /// <summary>
        /// Converts the given object into its JSON equivalent
        /// </summary>
        /// <param name="input">The object to obtain the JSON equivalent from</param>
        /// <returns>The JSON equivalent of the given object</returns>
        public static string ToJson(object input)
        {
            //If the input is null, return null in string format
            if (input == null)
            {
                return "null";
            }
            //Remove all hooks
            HookManager.UnHookAll();
            //Initialise a serialiser object
            JavaScriptSerializer serialiser = new JavaScriptSerializer();
            //Serialise the input
            string result = serialiser.Serialize(input);
            //Restore all hooks
            HookManager.HookAll();
            //Return the result
            return result;
        }

        /// <summary>
        /// Converts the given object into its XML equivalent
        /// </summary>
        /// <param name="input">The object to obtain the XML equivalent from</param>
        /// <returns>The XML equivalent of the given object</returns>
        public static string ToXml(object input)
        {
            //If the input is null, return null in string format
            if (input == null)
            {
                return "null";
            }
            //Remove all hooks
            HookManager.UnHookAll();
            //Initialise the serialiser objects
            StringWriter stringWriter = new StringWriter();
            XmlSerializer serialiser = new XmlSerializer(input.GetType());
            //Serialise the input
            serialiser.Serialize(stringWriter, input);
            string result = stringWriter.ToString();
            //Restore all hooks
            HookManager.HookAll();
            //Return the result
            return result;

        }

        /// <summary>
        /// Gets the given method as a string, formatted as "Full.ReturnType Full.Class.Path.With.Function(Complete.Argument.Type argumentName)". An example is "System.Reflection.Assembly System.Reflection.Assembly.Load(System.Byte[] rawAssembly)".
        /// </summary>
        /// <returns>The method's full name as a string, i.e. "System.Reflection.Assembly System.Reflection.Assembly.Load(System.Byte[] rawAssembly)"</returns>
        public static string Method(MethodBase method)
        {
            //Declare and initialise the output variable
            string output = "";
            //If the input is null, the output is set to null in string form, which is then returned
            if (method == null)
            {
                return "null";
            }
            //If the method is a MethodInfo instance (rather than the MethodBase object that is expected in the function's argument), which is possible as the MethodInfo object inherits the MethodBase class, the return type is accessible, and is subsequently used in the output
            if (method is MethodInfo)
            {
                output += ((MethodInfo)method).ReturnType.FullName + " ";
            }
            //Get the declaring type, the functino name, and open the arguments bracket
            output += method.DeclaringType + "." + method.Name + "(";

            //Iterate over all parameters
            foreach (ParameterInfo parameterInfo in method.GetParameters())
            {
                //Get the parameter type and name, and include a comma for the potential following argument
                output += parameterInfo.ParameterType + " " + parameterInfo.Name + ", ";
            }

            //If there is at least 1 argument, and all argumguments have been iterated over
            if (method.GetParameters().Length > 0)
            {
                //The last two characters are to be removed, which equal the comma and a space, as there is no following argument
                output = output.Substring(0, output.Length - 2);
            }
            //The closing bracket is then added
            output += ")";

            //And finally the output is returned
            return output;
        }
    }
}
