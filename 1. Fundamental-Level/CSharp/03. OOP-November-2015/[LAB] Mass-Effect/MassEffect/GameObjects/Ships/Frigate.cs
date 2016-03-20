namespace MassEffect.GameObjects.Ships
{
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;
    using MassEffect.Interfaces;

    public class Frigate : Starship
    {
        private const int DefaulHealth = 60;
        private const int DefaulShields = 50;
        private const int DefaulDamage = 30;
        private const int DefaulFuel = 220;

        private int projectileFired;

        public Frigate(string name, StarSystem location)
            : base(name, DefaulHealth, DefaulShields, DefaulDamage, DefaulFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            this.projectileFired++;
            return new ShieldReaver(this.Damage);
        }

        public override string ToString()
        {
            string output = base.ToString();

            if (this.Health > 0)
            {
                output += string.Format("\n-Projectiles fired: {0}", this.projectileFired);
            }

            return output;
        }
    }
}