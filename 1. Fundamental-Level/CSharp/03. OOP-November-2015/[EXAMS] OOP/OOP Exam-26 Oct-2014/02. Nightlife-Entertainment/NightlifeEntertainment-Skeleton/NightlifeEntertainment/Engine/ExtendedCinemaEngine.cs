namespace NightlifeEntertainment.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using NightlifeEntertainment.Interfaces;
    using NightlifeEntertainment.Tickets;
    using NightlifeEntertainment.Venues;
    using NightlifeEntertainment.Performances;

    public class ExtendedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteReportCommand(string[] commandWords)
        {
            IPerformance performance = this.GetPerformance(commandWords[1]);

            var soldTickets = performance.Tickets
                .Where(ticket => ticket.Status == TicketStatus.Sold)
                .Count();
            this.Output.AppendLine(string.Format("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, soldTickets, this.GetTotalSoldTicketsPrice(performance.Tickets)));
            this.Output.AppendLine(string.Format("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location));
            this.Output.AppendLine("Start time: " + performance.StartTime);
        }

        private decimal GetTotalSoldTicketsPrice(IList<ITicket> tickets)
        {
            return tickets
                .Where(ticket => ticket.Status == TicketStatus.Sold)
                .Sum(ticket => ticket.Price);
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            string ticketType = commandWords[1];
            IVenue venue = this.GetVenue(commandWords[2]);
            IPerformance performance = this.GetPerformance(commandWords[3]);
            int ticketsAmount = int.Parse(commandWords[4]);

            switch (ticketType)
            {
                case "vip":
                    for (int i = 0; i < ticketsAmount; i++)
                    {
                        performance.AddTicket(new VipTicket(performance));
                    }
                    break;
                case "student":
                    for (int i = 0; i < ticketsAmount; i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }
                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            string venueType = commandWords[2];
            string venueName = commandWords[3];
            string venueLocation = commandWords[4];
            int numberOfSeats = int.Parse(commandWords[5]);

            switch (venueType)
            {
                case "opera":
                    var opera = new OperaHall(venueName, venueLocation, numberOfSeats);
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportHall(venueName, venueLocation, numberOfSeats);
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(venueName, venueLocation, numberOfSeats);
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            string performanceType = commandWords[2];

            string name = commandWords[3];
            decimal price = decimal.Parse(commandWords[4]);
            var venue = this.GetVenue(commandWords[5]);
            DateTime startTime = DateTime.Parse(commandWords[6] + " " + commandWords[7]);

            switch (performanceType)
            {
                case "theatre":
                    var theatre = new Theatre(name, price, venue, startTime);
                    this.Performances.Add(theatre);
                    break;
                case "concert":
                    var concert = new Concert(name, price, venue, startTime);
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            string searchPhrase = commandWords[1];
            DateTime givenData = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            this.Output.AppendLine(string.Format(@"Search for ""{0}""", searchPhrase));

            this.Output.AppendLine("Performances:");
            var performances = this.Performances
                .Where(performance => performance.Name.IndexOf(searchPhrase, StringComparison.OrdinalIgnoreCase) >= 0)
                .Where(performance => performance.StartTime >= givenData)
                .OrderBy(performance => performance.StartTime)
                .ThenByDescending(performance => performance.BasePrice)
                .ThenBy(performance => performance.Name);
            if (performances.Count() > 0)
            {
                foreach (var performance in performances)
                {
                    this.Output.AppendLine("-" + performance.Name);
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }

            this.Output.AppendLine("Venues:");
            var venues = this.Venues
               .Where(venue => venue.Name.IndexOf(searchPhrase, StringComparison.OrdinalIgnoreCase) >= 0)
               .OrderBy(venue => venue.Name);
            if (venues.Count() > 0)
            {
                foreach (IVenue venue in venues)
                {
                    this.Output.AppendLine("-" + venue.Name);
                    var eventsInCurrentVenue = this.Performances
                        .Where(performance => performance.Venue == venue && performance.StartTime >= givenData)
                        .OrderBy(performance => performance.StartTime)
                        .ThenByDescending(performance => performance.BasePrice)
                        .ThenBy(performance => performance.Name);
                    foreach (var performance in eventsInCurrentVenue)
                    {
                        this.Output.AppendLine("--" + performance.Name);
                    }
                }
            }
            else
            {
                this.Output.AppendLine("no results");
            }
        }
    }
}