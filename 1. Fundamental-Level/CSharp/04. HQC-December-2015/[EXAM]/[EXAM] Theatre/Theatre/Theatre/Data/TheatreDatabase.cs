namespace Theatre.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Exceptions;
    using Theatre.Interfaces;
    using Theatre.Models;

    public class TheatreDatabase : IPerformanceDatabase
    {
        private readonly IDictionary<string, SortedSet<IPerformance>> theatreDatabase;

        public TheatreDatabase()
        {
            this.theatreDatabase = new SortedDictionary<string, SortedSet<IPerformance>>();
        }

        public void AddTheatre(string theatre)
        {
            if (this.theatreDatabase.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theatreDatabase[theatre] = new SortedSet<IPerformance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatresList = this.theatreDatabase.Keys;
            return theatresList;
        }

        public IPerformance AddPerformance(string theatre, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price)
        {
            if (!this.theatreDatabase.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var theatrePerformancesList = this.theatreDatabase[theatre];

            var endTime = startDateTime + duration;
            if (AreTimesOverlaping(theatrePerformancesList, startDateTime, endTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatre, performanceTitle, startDateTime, duration, price);
            theatrePerformancesList.Add(performance);

            return performance;
        }

        public IEnumerable<IPerformance> ListPerformances(string theatreName)
        {
            if (!this.theatreDatabase.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var theatrePerformancesList = this.theatreDatabase[theatreName];

            return theatrePerformancesList;
        }

        public IEnumerable<IPerformance> ListAllPerformances()
        {
            var theatres = this.theatreDatabase.Keys;

            var allPerformances = new List<IPerformance>();
            foreach (var theatre in theatres)
            {
                var performances = this.theatreDatabase[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        protected internal static bool AreTimesOverlaping(
            IEnumerable<IPerformance> performances, DateTime startTime, DateTime endTime)
        {
            var performancesList = performances.ToList();
            for (int i = 0; i < performancesList.Count; i++)
            {
                var performance = performancesList[i];

                var currentStartTime = performance.StartTime;

                var currentEndTime = performance.StartTime + performance.Duration;
                var areTimesOverlaping =
                    (currentStartTime <= startTime && startTime <= currentEndTime) ||
                    (currentStartTime <= endTime && endTime <= currentEndTime) ||
                    (startTime <= currentStartTime && currentStartTime <= endTime) ||
                    (startTime <= currentEndTime && currentEndTime <= endTime);
                if (areTimesOverlaping)
                {
                    return true;
                }
            }

            return false;
        }
    }
}