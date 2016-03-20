namespace RestaurantManager.Models.Recepies
{
    using System;
    using System.Text;

    using RestaurantManager.Interfaces;

    public abstract class Recipe : IRecipe
    {
        private string name;
        private decimal price;
        protected int calories;
        private int quantityPerServing;
        protected int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.QuantityPerServing = quantityPerServing;
            this.TimeToPrepare = timeToPrepare;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the restaurant cannot be empty.");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price of the recipe must be positive.");
                }

                this.price = value;
            }
        }

        public virtual int Calories
        {
            get
            {
                return this.calories;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The calories of the recipe must be positive.");
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The quantity per serving of the recipe must be positive.");
                }

                this.quantityPerServing = value;
            }
        }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The time to prepare of the recipe must be positive.");
                }

                this.timeToPrepare = value;
            }
        }

        public MetricUnit Unit { get; protected set; }

        public override string ToString()
        {
            return
                string.Format("==  {0} == ${1:f2}\n", this.Name, this.Price) +

                string.Format("Per serving: {0} {1}, {2} kcal\n",
                this.QuantityPerServing,
                this.Unit == MetricUnit.Grams ? "g" : "ml",
                this.Calories) +

                string.Format("Ready in {0} minutes", this.TimeToPrepare);
        }
    }
}