namespace NightlifeEntertainment.Venues
{
    using System.Collections.Generic;
    using NightlifeEntertainment.Performances;

    public class OperaHall : Venue
    {
        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List<PerformanceType> { PerformanceType.Opera, PerformanceType.Theatre })
        {
        }
    }
}