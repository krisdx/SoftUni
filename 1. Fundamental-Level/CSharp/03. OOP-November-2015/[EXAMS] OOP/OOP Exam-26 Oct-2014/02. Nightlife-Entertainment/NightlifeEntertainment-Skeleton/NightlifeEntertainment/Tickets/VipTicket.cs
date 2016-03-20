namespace NightlifeEntertainment.Tickets
{
    using NightlifeEntertainment.Interfaces;

    public class VipTicket : Ticket
    {
        public VipTicket(IPerformance performance)
            : base(performance, TicketType.VIP)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.CalculatePrice() * 1.5m;
        }
    }
}