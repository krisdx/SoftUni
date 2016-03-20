namespace FarmersCreed.Units.Plants
{
    using System;

    using FarmersCreed.Units.Products;

    public class CherryTree : Plant
    {
        private const int DefaultCherryTreeHealth = 14;
        private const int DefaultCherryTreeProductionQuantity = 4;
        private const int DefaultCherryTreeGrowTime = 3;
        private const int DefaultTobaccoPlantHealthEffect = 2;

        public CherryTree(string id)
            : base(id, DefaultCherryTreeHealth, DefaultCherryTreeProductionQuantity, DefaultCherryTreeGrowTime)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead cherry trees cannot produce products.");
            }

            return new Food(this.Id, ProductType.Cherry, FoodType.Organic, this.ProductionQuantity, DefaultTobaccoPlantHealthEffect);
        }
    }
}