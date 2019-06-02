using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Fody;
using LoggerExtensions.Attributes.LoggerExtensions.Attributes.Fody;

namespace LoggerExtensions.Tests
{
    public static class AssemblyWeaver
    {
        public static Assembly Assembly;

        static AssemblyWeaver()
        {
            var weavingTask = new ModuleWeaver();

            TestResult = weavingTask.ExecuteTestRun("LoggerExtensions.App.dll",
                    ignoreCodes: new[] { "0x80131854", "0x801318DE", "0x80131205", "0x80131252", "0x80131869" });

            Assembly = TestResult.Assembly;
            AfterAssemblyPath = TestResult.AssemblyPath;
        }
        public static string AfterAssemblyPath;

        public static TestResult TestResult;
    }
}
