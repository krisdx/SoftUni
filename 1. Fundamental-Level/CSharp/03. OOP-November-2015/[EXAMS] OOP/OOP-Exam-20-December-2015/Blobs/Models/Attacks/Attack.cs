namespace Blobs.Models.Attacks
{
    using System;

    public abstract class Attack
    {
        private int damage;

        protected Attack(int damage)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The damage of the attack cannot be negative.");
                }

                this.damage = value;
            }
        }
    }
}
