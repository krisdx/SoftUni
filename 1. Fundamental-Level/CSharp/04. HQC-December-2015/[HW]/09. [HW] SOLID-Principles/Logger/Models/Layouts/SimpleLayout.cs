namespace LoggerLibrary.Models.Layouts
{
    using System;

    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string message, string reportType, DateTime timeOfReport)
        {
            string formatedMessage = string.Format("{0} - {1} - {2}", timeOfReport, reportType, message);

            return formatedMessage;
        }
    }
}