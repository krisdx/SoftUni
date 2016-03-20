namespace LoggerLibrary.Interfaces
{
    using System;

    public interface ILayout
    {
        string FormatMessage(string message, string reportType, DateTime timeOfReport);
    }
}