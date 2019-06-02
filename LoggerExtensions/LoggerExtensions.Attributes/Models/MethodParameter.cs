using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerExtensions.Attributes.Models
{
    public class MethodParameter
    {
        public string Type { get; }
        public string Name { get; }
        public object Value { get; }

        public MethodParameter(string type, string name, object value)
        {
            Type = type;
            Name = name;
            Value = value;
        }
    }
}
