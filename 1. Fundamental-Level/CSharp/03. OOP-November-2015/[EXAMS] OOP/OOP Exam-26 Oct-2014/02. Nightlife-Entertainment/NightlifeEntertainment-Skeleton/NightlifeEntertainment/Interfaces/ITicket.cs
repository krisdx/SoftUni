namespace NightlifeEntertainment.Interfaces
{
    using System;

    using NightlifeEntertainment.Tickets;

    public interface ITicket
    {
        IPerformance Performance { get; }

        decimal Price { get; }

        int Seat { get; }

        TicketStatus Status { get; }

        TicketType Type { get; }

        void AssignSeat(int seat);

        void Sell();
    }
}
