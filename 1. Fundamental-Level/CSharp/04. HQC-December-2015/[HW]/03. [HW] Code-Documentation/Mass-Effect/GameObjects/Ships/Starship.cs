namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Locations;
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Enhancements;

    public abstract class Starship : IStarship
    {
        private string name;
        IList<Enhancement> enhancements;

        protected Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;

            this.enhancements = new List<Enhancement>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The ship name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("The enhancement cannot be null");
            }

            if (enhancement.Name != "ThanixCannon" &&
                enhancement.Name != "KineticBarrier" &&
                enhancement.Name != "ExtendedFuelCells")
            {
                throw new ArgumentNullException("No such enhancment type exists.");
            }

            this.enhancements.Add(enhancement);
            switch (enhancement.Name)
            {
                case "ThanixCannon":
                    this.Damage += 50;
                    break;
                case "KineticBarrier":
                    this.Shields += 100;
                    break;
                case "ExtendedFuelCells":
                    this.Fuel += 200;
                    break;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health > 0)
            {
                output.AppendLine("-Location: " + this.Location.Name);
                output.AppendLine("-Health: " + this.Health);
                output.AppendLine("-Shields: " + this.Shields);
                output.AppendLine("-Damage: " + this.Damage);
                output.AppendLine(string.Format("-Fuel: {0:f1}", this.Fuel));

                output.Append("-Enhancements: ");
                if (this.enhancements.Count == 0)
                {
                    output.Append("N/A");
                }
                else
                {
                    for (int i = 0; i < this.enhancements.Count; i++)
                    {
                        if (i == this.enhancements.Count - 1)
                        {
                            output.Append(this.enhancements[i].Name);
                        }
                        else
                        {
                            output.Append(this.enhancements[i].Name + ", ");
                        }
                    }
                }
            }
            else
            {
                output.Append("(Destroyed)");
            }

            return output.ToString();
        }
    }
}