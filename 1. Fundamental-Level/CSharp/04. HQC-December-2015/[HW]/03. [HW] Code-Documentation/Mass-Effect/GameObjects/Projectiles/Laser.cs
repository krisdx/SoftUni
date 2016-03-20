namespace MassEffect.GameObjects.Projectiles
{
    using System;

    using MassEffect.Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            ship.Shields -= this.Damage;
            if (ship.Shields < 0)
            {
                ship.Health -= Math.Abs(ship.Shields);
            }
        }
    }
}