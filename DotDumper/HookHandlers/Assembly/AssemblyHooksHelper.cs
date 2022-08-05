using System.Reflection;
using DotDumper.Helpers;

namespace DotDumper.HookHandlers
{
    class AssemblyHooksHelper
    {

        private static void Process(string functionName, byte[] rawAssembly, Assembly assembly, int stackTraceOffset)
        {
            ////Increment the offset by one, as this function is one layer deeper
            //stackTraceOffset++;

            ////Save the module to the disk, whilst returning the full path to the module
            //string path = GenericHookHelper.SaveFile(rawAssembly);

            ////Add the module dump to the log, including the full path
            //string message = "Wrote " + rawAssembly.Length + " bytes to \"" + path + "\"\n\n";

            ////Get and append the stacktrace related information to the log
            //message += GenericHookHelper.GetStackTraceAndAssemblyMapping(stackTraceOffset);

            ////Get information about the raw assembly
            //string rawAssemblyInfo = GetRawAssemblyInfo(rawAssembly);
            ////Append the raw assembly information to the log
            //message += rawAssemblyInfo;

            //if (assembly != null)
            //{
            //    //Get information from the assembly
            //    string assemblyInfo = GetAssemblyInfo(assembly);
            //    //Append the assembly information to the log
            //    message += assemblyInfo;
            //}

            ////Add the hash of the newly loaded assembly to the known list
            ////This addition needs to be done prior to the logging, as the logger calls the periodic dump check
            //MissedAssemblyDumper.AssemblyHashes.Add(Hashes.Sha256(rawAssembly));

            ////Write the aggregated data to the log and the console
            ////GenericHookHelper._Logger.Log(stackTraceOffset, OriginalFunctions.AssemblyLoadByteArray(), new object[] { rawAssembly }, assembly);
        }

        public static void Process(string functionName, byte[] rawAssembly, Assembly assembly)
        {
            Process(functionName, rawAssembly, assembly, 2);
        }

        public static void Process(string functionName, Assembly assembly)
        {
            byte[] rawAssembly = GenericHookHelper.GetAsByteArray(assembly);
            Process(functionName, rawAssembly, assembly, 2);
        }

        public static void ProcessLateBinding(string functionName, byte[] rawAssembly)
        {
            Process(functionName, rawAssembly, null, 2);
        }

        private static string GetRawAssemblyInfo(byte[] rawAssembly)
        {
            string output = "---Raw assembly information---\n";

            string size = "" + rawAssembly.Length;
            string hashcode = "" + rawAssembly.GetHashCode();
            string md5 = Hashes.Md5(rawAssembly);
            string sha1 = Hashes.Sha1(rawAssembly);
            string sha256 = Hashes.Sha256(rawAssembly);

            output += "Size in bytes: " + size + "\n";
            output += "Hashcode: " + hashcode + "\n";
            output += "MD-5: " + md5 + "\n";
            output += "SHA-1: " + sha1 + "\n";
            output += "SHA-256: " + sha256 + "\n";
            output += "\n";
            return output;
        }

        private static string GetAssemblyInfo(Assembly assembly)
        {
            string output = "---Assembly information---\n";

            output += "Entry point: ";
            if (assembly.EntryPoint != null)
            {
                output += assembly.EntryPoint.DeclaringType + "." + assembly.EntryPoint.Name + "(";
                ParameterInfo[] parameterInfos = assembly.EntryPoint.GetParameters();
                for (int i = 0; i < parameterInfos.Length; i++)
                {
                    string type = parameterInfos[i].ParameterType.ToString();
                    string name = parameterInfos[i].Name;
                    output += type + " " + name;
                    if (i != parameterInfos.Length - 1)
                    {
                        output += ", ";
                    }
                }
                output += ")";
            }
            else
            {
                output += "unknown";
            }
            output += "\n";


            AssemblyName assemblyName = assembly.GetName();

            output += "Full name: " + assemblyName.FullName + "\n";

            output += "Targeted CPU architecture: " + assemblyName.ProcessorArchitecture.ToString() + "\n";

            AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
            output += "Referenced assemblies:";
            if (referencedAssemblies.Length == 0)
            {
                output += " none\n";
            }
            else
            {
                output += "\n";
                foreach (AssemblyName asn in referencedAssemblies)
                {
                    output += "\t" + asn.FullName + "\n";
                }
            }

            output += "Targeted CLR version: " + assembly.ImageRuntimeVersion + "\n";

            string[] resourceNames = assembly.GetManifestResourceNames();
            output += "Embedded resource names:";

            if (resourceNames.Length == 0)
            {
                output += " none\n";
            }
            else
            {
                output += "\n";
                foreach (string resource in resourceNames)
                {
                    output += "\t" + resource + "\n";
                }
            }
            output += "\n";
            return output;
        }
    }
}
