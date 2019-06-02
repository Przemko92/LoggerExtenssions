using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerExtensions.Attributes.Models
{
    public class MethodInvocation
    {
        public string TypeName { get; }
        public string MethodName { get; }
        public IReadOnlyDictionary<int, MethodParameter> Parameters { get; }

        public MethodInvocation(string typeName, string methodName, IReadOnlyDictionary<int, MethodParameter> parameters)
        {
            TypeName = typeName;
            MethodName = methodName;
            Parameters = parameters;
        }
    }
}
