namespace RestaurantManager.Models.Recepies
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class Drink : Recipe, IDrink
    {
        public Drink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsCarbonated = isCarbonated;
            this.Unit = MetricUnit.Milliliters;
        }

        public override int Calories
        {
            get
            {
                return this.calories;
            }
            protected set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("The calories in a drink must not be greater than 100.");
                }

                this.calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            protected set
            {
                if (value > 20)
                {
                    throw new ArgumentOutOfRangeException("The time to prepare a drink must not be greater than 20 minutes.");
                }

                this.timeToPrepare = value;
            }
        }

        public bool IsCarbonated { get; private set; }

        public override string ToString()
        {
            return base.ToString() +
                "\nCarbonated: " + (this.IsCarbonated ? "yes" : "no");
        }
    }
}