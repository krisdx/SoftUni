namespace NightlifeEntertainment.Tickets
{
    using System;
    using NightlifeEntertainment.Interfaces;

    public class RegularTicket : Ticket
    {
        public RegularTicket(IPerformance performance)
            : base(performance, TicketType.Regular)
        {
        }
    }
}