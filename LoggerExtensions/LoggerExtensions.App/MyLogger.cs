using System;
using LoggerExtensions.Abstract;
using LoggerExtensions.Interfaces;

namespace LoggerExtensions.App
{
    internal class MyLogger : LoggerBase
    {
        public MyLogger()
            : base("{level,-5} {date:dd.MM.yyyy HH:mm:ss.fff} [{threadId}] [{fileName}:{lineNumber}] [{caller}()] - {message}")
        {
            
        }

        public override void LogInternal(string formattedMessage)
        {
            Console.WriteLine(formattedMessage);
        }
    }
}