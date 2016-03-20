namespace FurnitureManufacturer.Models.Chairs
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public abstract class BaseChair : IChair
    {
        private string model;
        private decimal price;
        private decimal height;
        private int numberOfLegs;

        protected BaseChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The {0}'s legs cannot be negative."));
                }

                this.numberOfLegs = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format("The model of the {0} cannot be empty", this.GetType().Name));
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException(string.Format("The model of the {0} cannot be less than 3 symbols.", this.GetType().Name));
                }

                this.model = value;
            }
        }

        public string Material { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The price of the {0} cannot be less or eqeual to 0", this.GetType().Name));
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The height of the {0} cannot be less or eqeual to 0", this.GetType().Name));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}