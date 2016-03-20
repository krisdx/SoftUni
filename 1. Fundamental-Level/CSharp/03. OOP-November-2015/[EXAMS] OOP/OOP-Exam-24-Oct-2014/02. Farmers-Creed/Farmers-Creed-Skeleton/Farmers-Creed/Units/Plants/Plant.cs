namespace FarmersCreed.Units.Plants
{
    using FarmersCreed.Units.Products;
    using System;

    public abstract class Plant : FarmUnit
    {
        private int growTime;

        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown { get; protected set; }

        public int GrowTime
        {
            get
            {
                return this.growTime;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The grow time of the plant cannot be negative.");
                }

                this.growTime = value;
            }
        }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health += 1;
        }

        public virtual void Grow()
        {
            this.GrowTime -= 1;
            if (this.GrowTime == 0)
            {
                this.HasGrown = true;
            }
        }

        public override string ToString()
        {
            return string.Format("--{0} {1}{2}", this.GetType().Name, this.Id,
                 this.IsAlive ? ", Health: " + this.Health : ", DEAD");
        }
    }
}