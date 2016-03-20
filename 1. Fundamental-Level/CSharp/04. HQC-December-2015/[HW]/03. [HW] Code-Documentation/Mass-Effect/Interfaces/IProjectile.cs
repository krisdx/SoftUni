namespace MassEffect.Interfaces
{
    /// <summary>
    /// Defines the properties and methods every projectile must implement.
    /// </summary>
    public interface IProjectile
    {
        int Damage { get; set; }

        void Hit(IStarship ship);
    }
}