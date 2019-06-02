using LoggerExtensions.Interfaces;

namespace LoggerExtensions.App
{
    internal class LoggerFactory : ILoggerFactory
    {
        public ILogger GetLogger()
        {
            return new MyLogger();
        }
    }
}