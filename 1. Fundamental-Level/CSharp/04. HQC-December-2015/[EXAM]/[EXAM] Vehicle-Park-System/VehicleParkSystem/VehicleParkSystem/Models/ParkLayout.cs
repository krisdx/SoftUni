namespace VehicleParkSystem.Models
{
    using System;

    using VehicleParkSystem.Interfaces;

    public class ParkLayout : IParkLayout
    {
        private int numberOfSectors;
        private int placesPerSector;

        public ParkLayout(int numberOfSectors, int placesPerSector)
        {
            this.numberOfSectors = numberOfSectors;
            this.placesPerSector = placesPerSector;
        }

        public int NumberOfSectors
        {
            get
            {
                return this.numberOfSectors;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}