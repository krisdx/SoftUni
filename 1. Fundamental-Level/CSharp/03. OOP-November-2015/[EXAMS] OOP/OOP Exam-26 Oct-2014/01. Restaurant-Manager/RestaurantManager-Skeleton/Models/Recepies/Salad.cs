namespace RestaurantManager.Models.Recepies
{
    using RestaurantManager.Interfaces;

    public class Salad : Meal, ISalad
    {
        private const bool isSaladVegan = true;

        public Salad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isSaladVegan)
        {
            this.ContainsPasta = containsPasta;
        }

        public bool ContainsPasta { get; private set; }

        public override string ToString()
        {
            return "[VEGAN] " +
                base.ToString() +
                string.Format("\nContains pasta: {0}",
                    this.ContainsPasta ? "yes" : "no");
        }
    }
}