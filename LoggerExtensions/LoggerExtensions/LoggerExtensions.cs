using LoggerExtensions.Interfaces;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace LoggerExtensions
{
    public enum LogLevel
    {
        Debug = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4
    }

    public static class LoggerExtensions
    {
        public static ILogger _logger { get; private set; }

        public static void InitLogger(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger();
        }
        
        public static T Log<T>(this T context, LogLevel level, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string msg = $"{message}{(context != null ? context.ToString() : "null")}";

            _logger.LogItem(DateTime.Now, Thread.CurrentThread.ManagedThreadId, level, msg, fileName, caller, filePath, lineNumber);
            return context;
        }

        public static T LogInfo<T>(this T context, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            return Log(context, LogLevel.Info, message, caller, filePath, lineNumber);
        }

        public static T LogWarning<T>(this T context, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            return Log(context, LogLevel.Warn, message, caller, filePath, lineNumber);
        }

        public static T LogError<T>(this T context, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            return Log(context, LogLevel.Error, message, caller, filePath, lineNumber);
        }

        public static T LogFatal<T>(this T context, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            return Log(context, LogLevel.Fatal, message, caller, filePath, lineNumber);
        }

        public static T LogDebug<T>(this T context, string message = null, [CallerMemberName]string caller = null, [CallerFilePath]string filePath = null, [CallerLineNumber]int lineNumber = 0)
        {
            return Log(context, LogLevel.Debug, message, caller, filePath, lineNumber);
        }
    }
}
