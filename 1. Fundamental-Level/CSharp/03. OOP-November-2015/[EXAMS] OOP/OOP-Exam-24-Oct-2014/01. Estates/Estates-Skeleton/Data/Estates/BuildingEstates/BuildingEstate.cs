using Estates.Interfaces;

namespace Estates.Data.Estates.BuildingEstates
{
    using System;

    public abstract class BuildingEstate : Estate, IBuildingEstate
    {
        private int roomsCount;

        public int Rooms
        {
            get
            {
                return this.roomsCount;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentOutOfRangeException("The rooms count should be in range [0...20].");
                }

                this.roomsCount = value;
            }
        }

        public bool HasElevator { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Rooms: {0}, Elevator: {1}",
                this.Rooms, this.HasElevator ? "Yes" : "No");
        }
    }
}