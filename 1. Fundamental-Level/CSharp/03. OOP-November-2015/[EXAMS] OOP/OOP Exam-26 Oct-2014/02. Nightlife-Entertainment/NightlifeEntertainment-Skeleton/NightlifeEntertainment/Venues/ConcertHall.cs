namespace NightlifeEntertainment.Venues
{
    using System.Collections.Generic;
    using NightlifeEntertainment.Performances;

    public class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert })
        {
        }
    }
}