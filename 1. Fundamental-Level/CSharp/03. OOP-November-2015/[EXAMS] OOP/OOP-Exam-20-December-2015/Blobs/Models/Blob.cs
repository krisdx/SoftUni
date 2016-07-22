namespace Blobs.Models
{
    using System;

    using Blobs.Interfaces;

    public class Blob : Unit, IBlob
    {
        private int health;
        private int damage;
        private IAttack attack;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attack)
            : base(name)
        {
            this.Damage = damage;
            this.Health = health;

            this.InitialHealth = health;
            this.InitialDamage = damage;

            this.Behavior = behavior;
            this.attack = attack;
        }

        public int InitialDamage { get; set; }

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
                    throw new ArgumentOutOfRangeException("The damage of the blob cannot be negative.");
                }

                this.damage = value;
            }
        }

        public int InitialHealth { get; set; }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                this.health =
                    value < 0 ? 0 : value;
            }
        }

        public bool HasTriggeredBehavior { get; set; }

        public IBehavior Behavior { get; set; }

        public void Attack(IBlob target)
        {
            this.attack.ProceedAttack(target, this);
        }

        public void TriggerBehavior()
        {
            this.Behavior.Trigger(this);
            this.HasTriggeredBehavior = true;
        }

        public void ApplyBehaviorSecondaryEffect()
        {
            this.Behavior.ApplyBehaviorSecondaryEffect(this);
        }

        public override string ToString()
        {
            string output = string.Empty;

            if (this.Health <= 0)
            {
                output = string.Format("Blob {0} KILLED", this.Name);
            }
            else
            {
                output = string.Format("Blob {0}: {1} HP, {2} Damage", this.Name, this.Health, this.Damage);
            }

            return output;
        }
    }
}