namespace LoggerLibrary.Models
{
    using System;

    using Interfaces;

    /// <summary>
    /// A class for logging reports. It must hold appenders, otherwise it will not append the reports.
    /// </summary>
    public class Logger : ILogger
    {
        private const ReportLevel DefaultReportLevel = ReportLevel.Info;

        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
            this.ReportLevel = DefaultReportLevel;
        }

        public Logger(ReportLevel reportLevel, params IAppender[] appenders)
            : this(appenders)
        {
            this.ReportLevel = reportLevel;
        }

        public ReportLevel ReportLevel { get; set; }

        public void LogInfo(string message)
        {
            this.Log(message, ReportLevel.Info);
        }

        public void LogWarning(string message)
        {
            this.Log(message, ReportLevel.Warning);
        }

        public void LogError(string message)
        {
            this.Log(message, ReportLevel.Error);
        }

        public void LogCriticalError(string message)
        {
            this.Log(message, ReportLevel.Critical);
        }

        public void LogFatalError(string message)
        {
            this.Log(message, ReportLevel.Fatal);
        }

        private void Log(string message, ReportLevel reportLevel)
        {
            foreach (var appender in this.appenders)
            {
                if (reportLevel >= this.ReportLevel)
                {
                    appender.Append(message, reportLevel.ToString(), DateTime.Now);
                }
            }
        }
    }
}