namespace FarmersCreed.Units.Plants
{
    using System;

    using FarmersCreed.Units.Products;

    public class TobaccoPlant : Plant
    {
        private const int DefaultTobaccoPlantHealth = 12;
        private const int DefaultTobaccoPlantProductionQuantity = 10;
        private const int DefaultTobaccoPlantGrowTime = 4;

        public TobaccoPlant(string id)
            : base(id, DefaultTobaccoPlantHealth, DefaultTobaccoPlantProductionQuantity, DefaultTobaccoPlantGrowTime)
        {
        }

        public override void Grow()
        {
            this.GrowTime -= 2;
            this.HasGrown = true;
        }

        public override Product GetProduct()
        {
            if (this.HasGrown)
            {
                throw new InvalidOperationException("Plants that are still growing cannot produce products.");
            }

            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Dead plants cannot produce products.");
            }

            return new Product(this.Id, ProductType.Tobacco, this.ProductionQuantity);
        }
    }
}