namespace VehicleParkSystem.Models.Vehicles
{
    using System;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private decimal regularRate;
        private decimal overtimeRate;
        private int reservedHours;

        protected Vehicle(string licensePlate, string owner, int reservedHours, decimal regularRate, decimal overtimeRate)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
            this.RegularRate = regularRate;
            this.OvertimeRate = overtimeRate;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            private set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The overtime rate must be non-negative.");
                }

                this.overtimeRate = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0} [{1}], owned by {2}",
                GetType().Name,
                this.LicensePlate,
                this.Owner);
        }
    }
}