namespace LoggerLibrary.Models.Layouts
{
    using System;
    using System.Text;

    using LoggerLibrary.Interfaces;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string message, string reportType, DateTime timeOfReport)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("<log>");

            output.AppendFormat("<date>{0}</date>{1}", timeOfReport, Environment.NewLine);
            output.AppendFormat("<level>{0}</level>{1}", reportType, Environment.NewLine);
            output.AppendFormat("<message>{0}</message>{1}", message, Environment.NewLine);

            output.AppendLine("</log>");

            return output.ToString();
        }
    }
}