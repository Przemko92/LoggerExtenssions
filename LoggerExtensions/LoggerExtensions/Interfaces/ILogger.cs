using System;

namespace LoggerExtensions.Interfaces
{
    public interface ILogger
    {
        void LogItem(DateTime date, int threadId, LogLevel level, string message, string fileName, string caller, string filePath, int lineNumber);
        void LogInternal(string formattedMessage);
    }
}