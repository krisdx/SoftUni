namespace Estates.Engine
{
    using System.Linq;

    using Estates.Interfaces;

    class ExtendedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(decimal.Parse(cmdArgs[0]), decimal.Parse(cmdArgs[1]));
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByPriceCommand(decimal minPrice, decimal maxPrice)
        {
            var offers = this.Offers
                 .Where(offer => offer.Type == OfferType.Rent && 
                     ((offer as IRentOffer).PricePerMonth >= minPrice &&
                     (offer as IRentOffer).PricePerMonth <= maxPrice))
                  .OrderBy(offer => (offer as IRentOffer).PricePerMonth)
                 .ThenBy(offer => offer.Estate.Name);
            return FormatQueryResults(offers);
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                  .Where(offer => offer.Estate.Location == location && offer.Type == OfferType.Rent)
                  .OrderBy(offer => offer.Estate.Name);
            return FormatQueryResults(offers);
        }
    }
}