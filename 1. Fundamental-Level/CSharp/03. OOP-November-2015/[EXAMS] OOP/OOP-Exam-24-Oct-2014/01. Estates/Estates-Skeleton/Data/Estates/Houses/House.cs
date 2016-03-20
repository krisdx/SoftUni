using Estates.Interfaces;

namespace Estates.Data.Estates.Houses
{
    using System;

    public class House : Estate, IHouse
    {
        private int floorsCount;

        public int Floors
        {
            get
            {
                return this.floorsCount;
            }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("The floors must be int range [0...10]");
                }

                this.floorsCount = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}