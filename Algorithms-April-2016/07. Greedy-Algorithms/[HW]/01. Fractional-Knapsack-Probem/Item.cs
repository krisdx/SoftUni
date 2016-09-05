using System;

namespace FractionalKnapsackProbem
{
    public class Item : IComparable<Item>
    {
        public Item(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get; private set; }

        public double Weight { get; private set; }

        public int CompareTo(Item other)
        {
            return (other.Price / other.Weight).CompareTo(this.Price / this.Weight);
        }

        public override string ToString()
        {
            return string.Format("Price: {0}, Weight: {1}", this.Price, this.Weight);
        }
    }
}