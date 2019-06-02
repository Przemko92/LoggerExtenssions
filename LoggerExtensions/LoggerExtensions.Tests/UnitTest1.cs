using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Fody;
using LoggerExtensions.App;
using LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody;
using Xunit;

namespace LoggerExtensions.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var type = AssemblyWeaver.Assembly.GetType("LoggerExtensions.App.TestClass");
            var sample = (dynamic)Activator.CreateInstance(type, 123);

            sample.TTTT = "aaaaaa";
            sample.Method2("Aaaa", 123, 321, null);
            sample.Method1();
            sample.Method3(new MemoryStream());
        }
    }
}
