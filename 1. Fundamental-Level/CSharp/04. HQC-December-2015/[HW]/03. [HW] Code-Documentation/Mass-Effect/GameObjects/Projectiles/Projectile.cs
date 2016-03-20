namespace MassEffect.GameObjects.Projectiles
{
    using MassEffect.Interfaces;

    public abstract class Projectile : IProjectile
    {
        protected Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }

        public abstract void Hit(IStarship ship);
    }
}