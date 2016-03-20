namespace NightlifeEntertainment.Performances
{
    using System;
    using NightlifeEntertainment.Interfaces;

    public class Concert : Performance
    {
        public Concert(string name, decimal basePrice, IVenue venue, DateTime startTime)
            : base(name, basePrice, venue, startTime, PerformanceType.Concert)
        {
        }

        protected override void ValidateVenue()
        {
            if (!this.Venue.AllowedTypes.Contains(PerformanceType.Concert) &&
                   !this.Venue.AllowedTypes.Contains(PerformanceType.Opera))
            {
                throw new InvalidOperationException(
                    string.Format("The venue {0} does not supports concerts and operas", this.Venue.Name));
            }
        }
    }
}