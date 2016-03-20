namespace MassEffect.GameObjects.Ships
{
    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Projectiles;

    public class Dreadnought : Starship
    {
        private const int DefaulHealth = 200;
        private const int DefaulShields = 300;
        private const int DefaulDamage = 150;
        private const int DefaulFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, DefaulHealth, DefaulShields, DefaulDamage, DefaulFuel, location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            int damage = this.Damage + (this.Shields / 2);
            return new Laser(damage);
        }

        public override void RespondToAttack(IProjectile projectile)
        {
            this.Shields += 50;

            base.RespondToAttack(projectile);

            this.Shields -= 50;
        }
    }
}