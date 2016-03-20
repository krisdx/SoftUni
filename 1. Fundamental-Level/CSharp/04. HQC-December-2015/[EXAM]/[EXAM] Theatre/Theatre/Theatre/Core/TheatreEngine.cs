namespace Theatre.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Theatre.Interfaces;
    using Theatre.Interfaces.IO;

    public class TheatreEngine
    {
        private readonly IPerformanceDatabase database;
        private readonly IInputReader reader;
        private readonly IOutputWriter writer;

        public TheatreEngine(IPerformanceDatabase database, IInputReader reader, IOutputWriter writer)
        {
            this.database = database;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string inputLine = this.reader.ReadLine();
                if (inputLine == null)
                {
                    return;
                }

                if (inputLine == string.Empty)
                {
                    continue;
                }

                string[] commandArgs = inputLine.Split(
                    new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];

                string commandResult;
                try
                {
                    switch (command)
                    {
                        case "AddTheatre":
                            string theatreName = commandArgs[1].Trim();
                            commandResult = ExecuteAddTheatreCommand(theatreName);
                            break;
                        case "AddPerformance":
                            commandResult = ExecuteAddPerformanceCommand(commandArgs);
                            break;
                        case "PrintAllTheatres":
                            commandResult = ExecutePrintAllTheatresCommand();
                            break;
                        case "PrintAllPerformances":
                            commandResult = ExecutePrintAllPerformancesCommand();
                            break;
                        case "PrintPerformances":
                            commandResult = ExecutePrintPerformancesCommand(commandArgs);
                            break;
                        default:
                            commandResult = "Invalid command!";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    commandResult = "Error: " + ex.Message;
                }

                this.writer.WriteLine(commandResult);
            }
        }

        private string ExecuteAddPerformanceCommand(string[] commandArgs)
        {
            string theatreName = commandArgs[1].Trim();
            string performanceTitle = commandArgs[2].Trim();
            DateTime startDateTime = DateTime.ParseExact(commandArgs[3].Trim(), "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandArgs[4].Trim());
            decimal price = decimal.Parse(commandArgs[5].Trim(), NumberStyles.Float);

            database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);

            return "Performance added";
        }

        private string ExecutePrintPerformancesCommand(string[] commandArgs)
        {
            string theatre = commandArgs[1].Trim();
            var performances = database.ListPerformances(theatre)
                .Select(p =>
                {
                    string result1 = p.StartTime.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.PerformanceTitle, result1);
                }).ToList();

            if (performances.Any())
            {
                return string.Join(", ", performances);
            }

            return "No performances";
        }

        private string ExecutePrintAllPerformancesCommand()
        {
            var performances = database.ListAllPerformances().ToList();

            if (!performances.Any())
            {
                return "No performances";
            }

            var output = new StringBuilder();
            for (int i = 0; i < performances.Count; i++)
            {
                if (i > 0)
                {
                    output.Append(", ");
                }

                string dateTime = performances[i].StartTime.ToString("dd.MM.yyyy HH:mm");
                output.AppendFormat("({0}, {1}, {2})", performances
                    [i].PerformanceTitle, performances[i].TheatreName, dateTime);
            }

            return output.ToString();
        }

        private string ExecuteAddTheatreCommand(string theatreName)
        {
            database.AddTheatre(theatreName);

            return "Theatre added";
        }

        private string ExecutePrintAllTheatresCommand()
        {
            var theatresList = database
                .ListTheatres()
                .OrderBy(theatre => theatre);

            if (!theatresList.Any())
            {
                return "No theatres";
            }

            return string.Join(", ", theatresList);
        }
    }
}