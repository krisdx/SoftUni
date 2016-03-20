namespace _01.Galactic_GPS
{
    using System;

    public struct Location
    {
        private double latitude;
        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value < 0 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("The latitude must be in range [0...90]");
                }

                this.latitude = value;
            }

        }

        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < 0 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("The latitude must be in range [0...180]");
                }

                this.longitude = value;
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.latitude, this.longitude, this.Planet);
        }
    }
}