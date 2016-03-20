namespace MassEffect.Interfaces
{
    using MassEffect.GameObjects.Locations;

    /// <summary>
    /// Defines the properties and methods that every ship must implement.
    /// </summary>
    public interface IStarship : IEnhanceable
    {
        string Name { get; set; }

        int Health { get; set; }

        int Shields { get; set; }

        int Damage { get; set; }

        double Fuel { get; set; }

        StarSystem Location { get; set; }

        IProjectile ProduceAttack();

        void RespondToAttack(IProjectile attack);
    }
}