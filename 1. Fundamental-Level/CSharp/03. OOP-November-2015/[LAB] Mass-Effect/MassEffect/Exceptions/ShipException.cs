namespace MassEffect.Exceptions
{
    using System;

    public class ShipException : ApplicationException
    {
        public ShipException(string message)
            : base(message)
        {
        }
    }
}