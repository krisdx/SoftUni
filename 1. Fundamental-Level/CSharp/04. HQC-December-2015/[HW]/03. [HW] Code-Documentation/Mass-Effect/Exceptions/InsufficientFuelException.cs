namespace MassEffect.Exceptions
{
    public class InsufficientFuelException : ShipException
    {
        public InsufficientFuelException(string message)
            : base(message)
        {
        }
    }
}