using FarmersCreed.Interfaces;
using FarmersCreed.Units.Products;
using System;
namespace FarmersCreed.Units.Animals
{
    public class Cow : Animal
    {
        private const int DefaultCowHealth = 15;
        private const int DefaultCowProductionQuantity = 6;
        private const int DefaultCowHealthEffect = 4;


        public Cow(string id)
            : base(id, DefaultCowHealth, DefaultCowProductionQuantity)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic)
            {
                this.Health += food.HealthEffect * quantity;
            }
            if (food.FoodType == FoodType.Meat)
            {
                this.Health -= food.HealthEffect * quantity;
            }
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead cows cannot produce milk.");
            }

            this.Health -= 2;
            return new Food(this.Id, ProductType.Milk, FoodType.Organic, this.ProductionQuantity, DefaultCowHealthEffect);
        }
    }
}