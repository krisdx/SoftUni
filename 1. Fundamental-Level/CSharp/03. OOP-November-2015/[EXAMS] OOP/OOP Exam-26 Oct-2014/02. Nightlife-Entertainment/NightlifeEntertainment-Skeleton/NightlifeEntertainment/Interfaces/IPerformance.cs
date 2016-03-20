namespace NightlifeEntertainment.Interfaces
{
    using System;
    using System.Collections.Generic;

    using NightlifeEntertainment.Performances;
    using NightlifeEntertainment.Tickets;

    public interface IPerformance
    {
        string Name { get; }

        decimal BasePrice { get; }
        
        IVenue Venue { get; }

        DateTime StartTime { get; }

        PerformanceType Type { get; }

        IList<ITicket> Tickets { get; }

        void AddTicket(ITicket ticket);

        string SellTicket(TicketType type);
    }
}
