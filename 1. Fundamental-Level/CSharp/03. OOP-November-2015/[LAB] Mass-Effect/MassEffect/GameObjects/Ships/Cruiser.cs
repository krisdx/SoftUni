namespace MassEffect.GameObjects.Ships
{
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;

    public class Cruiser : Starship
    {
        private const int DefaulHealth = 100;
        private const int DefaulShields = 100;
        private const int DefaulDamage = 50;
        private const int DefaulFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, DefaulHealth, DefaulShields, DefaulDamage, DefaulFuel, location)
        {
        }
        
        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}