using LoggerExtensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LoggerExtensions.Abstract
{
    public abstract class LoggerBase : ILogger
    {
        protected readonly IReadOnlyDictionary<LogLevel, string> _logFormats;

        protected LoggerBase(string logFormat)
        {
            var formats = new Dictionary<LogLevel, string>();
            formats.Add(LogLevel.Debug, logFormat);
            formats.Add(LogLevel.Info, logFormat);
            formats.Add(LogLevel.Warn, logFormat);
            formats.Add(LogLevel.Error, logFormat);
            formats.Add(LogLevel.Fatal, logFormat);
            
            this._logFormats = new ReadOnlyDictionary<LogLevel, string>(ReplaceFormats(formats));
        }

        protected LoggerBase(IDictionary<LogLevel, string> logFormats, string defaultFormat = null)
        {
            if (!logFormats.ContainsKey(LogLevel.Debug))
            {
                logFormats.Add(LogLevel.Debug, defaultFormat);
            }
            if (!logFormats.ContainsKey(LogLevel.Info))
            {
                logFormats.Add(LogLevel.Info, defaultFormat);
            }
            if (!logFormats.ContainsKey(LogLevel.Warn))
            {
                logFormats.Add(LogLevel.Warn, defaultFormat);
            }
            if (!logFormats.ContainsKey(LogLevel.Error))
            {
                logFormats.Add(LogLevel.Error, defaultFormat);
            }
            if (!logFormats.ContainsKey(LogLevel.Fatal))
            {
                logFormats.Add(LogLevel.Fatal, defaultFormat);
            }            

            this._logFormats = new ReadOnlyDictionary<LogLevel, string>(ReplaceFormats(logFormats));
        }

        protected virtual IDictionary<LogLevel, string> ReplaceFormats(IDictionary<LogLevel, string> formats)
        {
            var newFormats = new Dictionary<LogLevel, string>();
            foreach (var item in formats)
            {
                newFormats[item.Key] = item.Value
                .Replace("{level", "{0")
                .Replace("{date", "{1")
                .Replace("{threadId", "{2")
                .Replace("{message", "{3")
                .Replace("{fileName", "{4")
                .Replace("{caller", "{5")
                .Replace("{filePath", "{6")
                .Replace("{lineNumber", "{7");
            }
            return newFormats;
        }

        public virtual void LogItem(DateTime date, int threadId, LogLevel level, string message, string fileName, string caller, string filePath, int lineNumber)
        {
            var format = _logFormats[level];
            LogInternal(string.Format(format, level, date, threadId, message, fileName, caller, filePath, lineNumber));
        }

        public abstract void LogInternal(string formattedMessage);
    }
}
