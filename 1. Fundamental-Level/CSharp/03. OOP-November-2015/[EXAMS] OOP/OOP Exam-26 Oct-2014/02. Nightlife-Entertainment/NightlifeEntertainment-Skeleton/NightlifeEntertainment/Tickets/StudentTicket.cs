namespace NightlifeEntertainment.Tickets
{
    using NightlifeEntertainment.Interfaces;

    public class StudentTicket : Ticket
    {
        public StudentTicket(IPerformance performance)
            : base(performance, TicketType.Student)
        {
        }

        protected override decimal CalculatePrice()
        {
            return base.CalculatePrice() * 0.80m;
        }
    }
}