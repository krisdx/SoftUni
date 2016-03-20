namespace RestaurantManager.Models.Recepies
{
    using RestaurantManager.Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = true;
        }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {   
            string sugarLabel = this.WithSugar ? "" : "[NO SUGAR] ";
            string veganLabel = this.IsVegan ? "[VEGAN] " : "";
            return string.Format("{0}{1}", sugarLabel, veganLabel) +
                base.ToString();
        }
    }
}