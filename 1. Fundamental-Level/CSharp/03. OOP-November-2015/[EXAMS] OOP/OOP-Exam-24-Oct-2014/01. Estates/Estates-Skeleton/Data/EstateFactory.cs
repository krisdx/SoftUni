using Estates.Engine;
using Estates.Interfaces;
using Estates.Data.Estates.BuildingEstates;
using Estates.Data.Estates.Houses;
using Estates.Data.Estates.Garages;
using Estates.Data.Offers;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ExtendedEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment();
                case EstateType.Office:
                    return new Office();
                case EstateType.House:
                    return new House();
                case EstateType.Garage:
                    return new Garage();
                default:
                    return null;
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Sale:
                    return new SaleOffer();
                case OfferType.Rent:
                    return new RentOffer();
                default:
                    return null;
            }
        }
    }
}