using System;

namespace LoggerExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, Inherited =
        false)]

    public class LogInputAttribute : Attribute
    {
    }
}
