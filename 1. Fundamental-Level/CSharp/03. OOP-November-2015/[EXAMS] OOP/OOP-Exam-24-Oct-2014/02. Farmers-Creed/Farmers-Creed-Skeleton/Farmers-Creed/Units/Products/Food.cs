namespace FarmersCreed.Units.Products
{
    using System;
    using FarmersCreed.Interfaces;

    public class Food : Product, IEdible
    {
        private FoodType foodType;
        private int healthEffect;

        public Food(string id, ProductType productType, FoodType foodType, int quantity, int healthEffect)
            : base(id, productType, quantity)
        {
            this.HealthEffect = healthEffect;
            this.FoodType = foodType;
        }

        public FoodType FoodType
        {
            get { return this.foodType; }
            set { this.foodType = value; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
            set { this.healthEffect = value; }
        }

        public override string ToString()
        {
            return string.Format("--{0} {1}, Quantity: {2}, Product Type: {3}, Food Type: {4}, Health Effect: {5}", this.GetType().Name, this.Id, this.Quantity, this.ProductType, this.FoodType, this.HealthEffect); 
        }
    }
}