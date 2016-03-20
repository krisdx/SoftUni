namespace NightlifeEntertainment.Interfaces
{
    using System;
    using System.Collections.Generic;

    using NightlifeEntertainment.Performances;

    public interface IVenue
    {
        string Name { get; }

        string Location { get; }

        int Seats { get; }

        IList<PerformanceType> AllowedTypes { get; }
    }
}
