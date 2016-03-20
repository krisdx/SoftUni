namespace LoggerLibrary.Interfaces
{
    using LoggerLibrary.Models;

    public interface ILogger
    {
        ReportLevel ReportLevel { get; set; }

        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogCriticalError(string message);

        void LogFatalError(string message);
    }
}