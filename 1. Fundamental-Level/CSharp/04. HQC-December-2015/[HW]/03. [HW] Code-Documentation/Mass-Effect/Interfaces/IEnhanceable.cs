namespace MassEffect.Interfaces
{
    using System.Collections.Generic;
    using MassEffect.GameObjects.Enhancements;

    /// <summary>
    /// Defines methods and properties for enhancement.
    /// </summary>
    public interface IEnhanceable
    {
        IEnumerable<Enhancement> Enhancements { get; }

        void AddEnhancement(Enhancement enhancement);
    }
}