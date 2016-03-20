using FarmersCreed.Interfaces;

namespace FarmersCreed.Units
{
    using System;

    using FarmersCreed.Units.Products;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
            this.IsAlive = true;
        }

        public int Health { get; set; }

        public bool IsAlive { get; protected set; }

        public int ProductionQuantity { get; set; }

        public abstract Product GetProduct();
    }
}