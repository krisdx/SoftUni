namespace NightlifeEntertainment.Venues
{
    using System.Collections.Generic;
    using NightlifeEntertainment.Performances;

    public class SportHall : Venue
    {
        public SportHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Sport, PerformanceType.Concert })
        {
        }
    }
}