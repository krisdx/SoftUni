namespace FarmersCreed.Units.Animals
{
    using System;

    using FarmersCreed.Units.Products;

    public class Swine : Animal
    {
        private const int DefaultSwineHealth = 20;
        private const int DefaultSwineProductionQuantity = 5;
        private const int DefaultSwineHealthEffect = 1;

        public Swine(string id)
            : base(id, DefaultSwineHealth, DefaultSwineProductionQuantity)
        {
        }

        public override void Eat(Interfaces.IEdible food, int quantity)
        {
            this.Health += food.HealthEffect * 2;
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead swines cannot produce meat.");
            }

            this.IsAlive = false;
            return new Food(this.Id, ProductType.PorkMeat, FoodType.Meat, this.ProductionQuantity, DefaultSwineHealthEffect);
        }

        public override void Starve()
        {
            this.Health -= 3;
        }
    }
}