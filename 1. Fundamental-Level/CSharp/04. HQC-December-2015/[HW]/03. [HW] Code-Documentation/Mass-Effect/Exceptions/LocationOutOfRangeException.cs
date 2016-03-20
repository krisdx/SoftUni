namespace MassEffect.Exceptions
{
    public class LocationOutOfRangeException : ShipException
    {
        public LocationOutOfRangeException(string message)
            : base(message)
        {
        }
    }
}