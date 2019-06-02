using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using LoggerExtensions.Attributes;

namespace LoggerExtensions.App
{
    public class TestClass
    {
        [LogInput]
        public TestClass(int aa)
        {
            
        }
        [LogInput]
        public string TTTT { get; set; }

        [LogInput]
        public int Method1()
        {
            Trace.WriteLine("Test");
            Debug.WriteLine("Test2");
            return -1;
        }

        [LogInput]
        public void Method2(string aa, int bb, int cc, string zz)
        {
            var a = string.Format("{0}{1}{2}", aa, bb, cc);
            Trace.WriteLine("Test3");
            Debug.WriteLine("Test4");
        }

        [LogInput]
        public void Method3(Stream an)
        {
            Trace.WriteLine("Test3");
            Debug.WriteLine("Test4");
        }
    }
}
