using System;
using System.Configuration.Assemblies;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;
using System.Security.Policy;
using DotDumper.Hooks;

namespace DotDumper.HookHandlers
{
    class ActivatorHooks
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm(string assemblyName, string typeName, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateComInstanceFrom(string assemblyName, string typeName, byte[] hashValue, AssemblyHashAlgorithm hashAlgorithm)";

                HookManager.UnHookByHookName("CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm");
                //Call the original function
                result = Activator.CreateComInstanceFrom(assemblyName, typeName, hashValue, hashAlgorithm);
                HookManager.HookByHookName("CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateComInstanceFromStringStringByteArrayAssemblyHashAlgorithm(), new object[] { assemblyName, typeName, hashValue, hashAlgorithm }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateComInstanceFromHookStringString(string assemblyName, string typeName)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Within the DotNet framework, another CreateComInstance function is used, which is also hooked. To avoid duplicate entries in the logging, both are unhooked and rehooked
                HookManager.UnHookByHookName("CreateComInstanceFromHookStringString");
                HookManager.UnHookByHookName("CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm");
                //Call the original function
                result = Activator.CreateComInstanceFrom(assemblyName, typeName);
                HookManager.HookByHookName("CreateComInstanceFromHookStringString");
                HookManager.HookByHookName("CreateComInstanceFromHookStringStringByteArrayAssemblyHashAlgorithm");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateComInstanceFromStringString(), new object[] { assemblyName, typeName }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookType(Type type)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Double unhook due to DotNet internal wrappers, thereby avoiding double logging
                HookManager.UnHookByHookName("CreateInstanceHookType");
                HookManager.UnHookByHookName("CreateInstanceHookTypeBool");
                //Call the original function
                result = Activator.CreateInstance(type);
                HookManager.HookByHookName("CreateInstanceHookType");
                HookManager.HookByHookName("CreateInstanceHookTypeBool");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceTypeBool(), new object[] { type }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookTypeBool(Type type, bool nonPublic)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(Type type, bool nonPublic)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookTypeBool");
                //Call the original function
                result = Activator.CreateInstance(type, nonPublic);
                HookManager.HookByHookName("CreateInstanceHookTypeBool");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceTypeBool(), new object[] { type, nonPublic }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookActivationContext(ActivationContext activationContext)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(ActivationContext activationContext)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookActivationContext");
                //Call the original function
                result = Activator.CreateInstance(activationContext);
                HookManager.HookByHookName("CreateInstanceHookActivationContext");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceActivationContext(), new object[] { activationContext }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookTypeObjectArray(Type type, params object[] args)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Double unhook due to 
                HookManager.UnHookByHookName("CreateInstanceHookTypeObjectArray");
                HookManager.UnHookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(type, args);
                HookManager.HookByHookName("CreateInstanceHookTypeObjectArray");
                HookManager.HookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceActivationContext(), new object[] { type, args }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookStringString(string assemblyName, string typeName)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(assemblyName, typeName);
                HookManager.HookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceStringString(), new object[] { assemblyName, typeName }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfo(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Double unhook due to an internal wrapper within the DotNet framework
                HookManager.UnHookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfo");
                HookManager.UnHookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(type, bindingAttr, binder, args, culture);
                HookManager.HookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfo");
                HookManager.HookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceActivationContext(), new object[] { type, bindingAttr, binder, args, culture }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            object result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(type, bindingAttr, binder, args, culture, activationAttributes);
                HookManager.HookByHookName("CreateInstanceHookTypeBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceActivationContext(), new object[] { type, bindingAttr, binder, args, culture, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes);
                HookManager.HookByHookName("CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), new object[] { assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookActivationContextStringArray(ActivationContext activationContext, string[] activationCustomData)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(ActivationContext activationContext, string[] activationCustomData)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookActivationContextStringArray");
                //Call the original function
                result = Activator.CreateInstance(activationContext, activationCustomData);
                HookManager.HookByHookName("CreateInstanceHookActivationContextStringArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceActivationContextStringArray(), new object[] { activationContext, activationCustomData }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookStringStringObjectArray(string assemblyName, string typeName, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(string assemblyName, string typeName, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookStringStringObjectArray");
                //Call the original function
                result = Activator.CreateInstance(assemblyName, typeName, activationAttributes);
                HookManager.HookByHookName("CreateInstanceHookStringStringObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceStringStringObjectArray(), new object[] { assemblyName, typeName, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookAppDomainStringString(AppDomain domain, string assemblyName, string typeName)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(AppDomain domain, string assemblyName, string typeName)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookAppDomainStringString");
                //Call the original function
                result = Activator.CreateInstance(domain, assemblyName, typeName);
                HookManager.HookByHookName("CreateInstanceHookAppDomainStringString");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringString(), new object[] { domain, assemblyName, typeName }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");
                //Call the original function
                result = Activator.CreateInstance(assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo);
                HookManager.HookByHookName("CreateInstanceHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstance(domain, assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes);
                HookManager.HookByHookName("CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), new object[] { domain, assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstance(AppDomain domain, string assemblyName, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");
                //Call the original function
                result = Activator.CreateInstance(domain, assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes);
                HookManager.HookByHookName("CreateInstanceHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { domain, assemblyName, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookAppDomainStringString(AppDomain domain, string assemblyFile, string typeName)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstanceFrom(AppDomain domain, string assemblyName, string typeName)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceFromHookAppDomainStringString");
                //Call the original function
                result = Activator.CreateInstanceFrom(domain, assemblyFile, typeName);
                HookManager.HookByHookName("CreateInstanceFromHookAppDomainStringString");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringString(), new object[] { domain, assemblyFile, typeName }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstanceFrom(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityInfo)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");
                //Call the original function
                result = Activator.CreateInstanceFrom(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo);
                HookManager.HookByHookName("CreateInstanceFromHookStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityInfo }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstanceFrom(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstanceFrom(domain, assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes);
                HookManager.HookByHookName("CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArray(), new object[] { domain, assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstanceFrom(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");
                //Call the original function
                result = Activator.CreateInstanceFrom(domain, assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes);
                HookManager.HookByHookName("CreateInstanceFromHookAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { domain, assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes, securityAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookStringString(string assemblyFile, string typeName)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Multi unhooking due to DotNet wrapper calls
                HookManager.UnHookByHookName("CreateInstanceFromHookStringString");
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringObjectArray");
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstanceFrom(assemblyFile, typeName);
                HookManager.HookByHookName("CreateInstanceFromHookStringString");
                HookManager.HookByHookName("CreateInstanceFromHookStringStringObjectArray");
                HookManager.HookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromStringString(), new object[] { assemblyFile, typeName }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookStringStringObjectArray(string assemblyFile, string typeName, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Sets the title for the log
                string functionName = "Activator.CreateInstanceFrom(AppDomain domain, string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, Evidence securityAttributes)";
                //Process the given data via the helper class
                //MethodBaseHooksHelper.Invoke(methodBase, functionName, parameters);
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringObjectArray");
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstanceFrom(assemblyFile, typeName, activationAttributes);
                HookManager.HookByHookName("CreateInstanceFromHookStringStringObjectArray");
                HookManager.HookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { assemblyFile, typeName, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ObjectHandle CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray(string assemblyFile, string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
        {
            //Declare the local variable to store the object in
            ObjectHandle result;

            //Enable the thread safe lock, as a launched program can be multi-threaded
            lock (GenericHookHelper.SyncLock)
            {
                //Multi unhook due to internal wrappers in the DotNet framework
                HookManager.UnHookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");
                //Call the original function
                result = Activator.CreateInstanceFrom(assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes);
                HookManager.HookByHookName("CreateInstanceFromHookStringStringBoolBindingFlagsBinderObjectArrayCultureInfoObjectArray");

                //Write the aggregated data to the log and the console
                GenericHookHelper._Logger.LogSampleCall(1, OriginalManagedFunctions.ActivatorCreateInstanceFromAppDomainStringStringBooleanBindingFlagsBinderObjectArrayCultureInfoObjectArrayEvidence(), new object[] { assemblyFile, typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes }, result);
            }

            //Return the process object to the caller
            return result;
        }
    }
}
