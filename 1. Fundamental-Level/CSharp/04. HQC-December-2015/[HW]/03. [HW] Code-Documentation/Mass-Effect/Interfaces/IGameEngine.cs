namespace MassEffect.Interfaces
{    
    using System.Collections.Generic;

    using MassEffect.Engine.Factories;
    using MassEffect.GameObjects;

    /// <summary>
    /// Defines the properties and methods that every engine for mass effect must implement.
    /// </summary>
    public interface IGameEngine
    {
        ShipFactory ShipFactory { get; }

        EnhancementFactory EnhancementFactory { get; }

        IList<IStarship> Starships { get; }

        Galaxy Galaxy { get; }

        ICommandManager CommandManager { get; }

        bool IsRunning { get; set; }

        void Run();
    }
}