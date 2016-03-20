namespace LoggerLibrary.Models.Appenders
{
    using System;
    using Interfaces;

    /// <summary>
    /// A class for printing reports on the Console.
    /// </summary>
    public class ConsoleAppender : IAppender
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public void Append(string message, string reportType, DateTime timeOfReport)
        {
            string formatedMessage =
                this.layout.FormatMessage(message, reportType, timeOfReport);

            Console.WriteLine(formatedMessage); 
        }
    }
}