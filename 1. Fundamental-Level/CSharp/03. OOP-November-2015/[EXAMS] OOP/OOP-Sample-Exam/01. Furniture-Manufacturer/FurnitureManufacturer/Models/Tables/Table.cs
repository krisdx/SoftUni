namespace FurnitureManufacturer.Models.Tables
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Table : ITable
    {
        private string model;
        private decimal price;
        private decimal height;
        private decimal width;
        private decimal length;

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
            this.Width = width;
            this.Length = length;
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

        public decimal Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The width of the {0} cannot be less or eqeual to 0", this.GetType().Name));
                }

                this.width = value;
            }
        }

        public decimal Length
        {
            get { return this.length; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The length of the {0} cannot be negative", this.GetType().Name));
                }
                this.length = value;
            }
        }

        public decimal Area
        {
            get { return this.Width * this.Length; }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }
    }
}