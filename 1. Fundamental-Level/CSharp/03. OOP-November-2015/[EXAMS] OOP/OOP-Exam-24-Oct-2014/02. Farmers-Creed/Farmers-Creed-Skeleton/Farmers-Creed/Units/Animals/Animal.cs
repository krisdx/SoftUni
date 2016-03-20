namespace FarmersCreed.Units.Animals
{
    using System;
    using FarmersCreed.Interfaces;

    public abstract class Animal : FarmUnit
    {
        protected Animal(string id, int health, int productionQuantity)
            : base(id, health, productionQuantity)
        {
        }

        public virtual void Starve()
        {
            this.Health -= 1;
        }

        public abstract void Eat(IEdible food, int quantity);

        public override string ToString()
        {
            return string.Format("--{0} {1}{2}", this.GetType().Name, this.Id,
                 this.IsAlive ? ", Health: " + this.Health : ", DEAD");
        }
    }
}