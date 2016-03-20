using Estates.Interfaces;

namespace Estates.Data.Estates
{
    using System;

    public abstract class Estate : IEstate
    {
        private double area;

        public string Name { get; set; }

        public EstateType Type { get; set; }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("The area should be in range [0...10000].");
                }

                this.area = value;
            }
        }

        public string Location { get; set; }

        public bool IsFurnished { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}", 
                this.GetType().Name, 
                this.Name, 
                this.Area, 
                this.Location,
                this.IsFurnished ? "Yes" : "No");
        }
    }
}