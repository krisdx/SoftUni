namespace NightlifeEntertainment.Venues
{
    using System;
    using System.Collections.Generic;

    using NightlifeEntertainment.Performances;

    public class Cinema : Venue
    {
        public Cinema(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Movie, PerformanceType.Concert })
        {
        }
    }
}
