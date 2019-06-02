using System;

namespace LoggerExtensions.App
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerExtensions.InitLogger(new LoggerFactory());

            "Hello world".LogDebug();
            $"Hello world with {args.Length} args".LogError();

            if (MyMethod("a", "b", 123).LogInfo("Wynik my method to:"))
            {

            }

            string aa = null;
            aa.LogInfo();
            aa.LogDebug("Wartość aa to:");
        }

        private static bool MyMethod(string a, string b, int c)
        {
            "Test".LogError();
            return true;
        }
    }
}
