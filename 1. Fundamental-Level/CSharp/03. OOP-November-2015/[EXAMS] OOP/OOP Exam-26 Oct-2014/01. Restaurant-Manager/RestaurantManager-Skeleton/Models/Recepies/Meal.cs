namespace RestaurantManager.Models.Recepies
{
    using RestaurantManager.Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        protected Meal(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare)
        {
            this.IsVegan = isVegan;
            this.Unit = MetricUnit.Grams;
        }

        public bool IsVegan { get; protected set; }

        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
    }
}