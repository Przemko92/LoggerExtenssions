using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using LoggerExtensions.Attributes.Models;

namespace LoggerExtensions.Attributes.Helpers
{
    public static class MethodInputLogger
    {
        public static Action<MethodInvocation> LogAction { get; set; }

        static MethodInputLogger()
        {
            Assembly asms = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.GetModule("LoggerExtensions.dll") != null);

            if (asms != null)
            {
                var method = asms.GetType("LoggerExtensions.LoggerExtensions").GetMethod("Log").MakeGenericMethod(typeof(string));

                LogAction = (methodInvocation) =>
                {
                    string joinedParameters = string.Join(",", methodInvocation.Parameters.Select(x => x.Value.Value != null ? x.Value.Value.ToString() : "null"));
                    string joinedArguments = string.Join(",", methodInvocation.Parameters.Select(x => $"{x.Value.Type} {x.Value.Name}"));

                    try
                    {
                        method.Invoke(null,
                                       new object[]
                                       {
                            $"Method {methodInvocation.TypeName}.{methodInvocation.MethodName}({joinedArguments}) was invoked with parameters:({joinedParameters})",
                            0,
                            null,
                            "MethodInputLogger",
                            null,
                            0
                                       });
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine(ex.ToString());
                    }
                };
            }
        }

        public static void WriteLog(
            string methodName, int paramsCount, string declaringType,
            string param1Name, string param2Name, string param3Name, string param4Name, string param5Name, string param6Name, string param7Name, string param8Name, string param9Name, string param10Name,
            string param1Type, string param2Type, string param3Type, string param4Type, string param5Type, string param6Type, string param7Type, string param8Type, string param9Type, string param10Type,
            object param1Value, object param2Value, object param3Value, object param4Value, object param5Value, object param6Value, object param7Value, object param8Value, object param9Value, object param10Value)
        {
            if (LogAction == null)
            {
                throw new InvalidOperationException("Initialize MethodInputLogger.LogAction first or install LoggerExtensions");
            }

            IDictionary<int, MethodParameter> methodParameters = new Dictionary<int, MethodParameter>();

            if (paramsCount > 0) methodParameters.Add(0, new MethodParameter(param1Type, param1Name, param1Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 1) methodParameters.Add(1, new MethodParameter(param2Type, param2Name, param2Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 2) methodParameters.Add(2, new MethodParameter(param3Type, param3Name, param3Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 3) methodParameters.Add(3, new MethodParameter(param4Type, param4Name, param4Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 4) methodParameters.Add(4, new MethodParameter(param5Type, param5Name, param5Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 5) methodParameters.Add(5, new MethodParameter(param6Type, param6Name, param6Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 6) methodParameters.Add(6, new MethodParameter(param7Type, param7Name, param7Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 7) methodParameters.Add(7, new MethodParameter(param8Type, param8Name, param8Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 8) methodParameters.Add(8, new MethodParameter(param9Type, param9Name, param9Value));
            else
            {
                LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
                return;
            }
            if (paramsCount > 9) methodParameters.Add(9, new MethodParameter(param10Type, param10Name, param10Value));

            LogAction(new MethodInvocation(declaringType, methodName, new ReadOnlyDictionary<int, MethodParameter>(methodParameters)));
        }
    }
}
