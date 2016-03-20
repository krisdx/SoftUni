namespace LoggerLibrary
{
    using System.Globalization;
    using System.Threading;

    using Models;
    using Models.Appenders;
    using Models.Layouts;

    public class LoggerLibraryMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;

            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            var xmlLayout = new XmlLayout();
            var fileAppender = new FileAppender(xmlLayout);

            var logger = new Logger(consoleAppender, fileAppender);
            logger.ReportLevel = ReportLevel.Info;

            for (int i = 0; i < 10; i++)
            {
                logger.LogInfo("Just Testing");
            }
        }
    }
}