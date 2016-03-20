namespace LoggerLibrary.Interfaces
{
    using System;

    public interface IAppender
    {
        void Append(string message, string reportType, DateTime timeOfReport);
    }
}