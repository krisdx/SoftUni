namespace MassEffect.Interfaces
{
    /// <summary>
    /// Defines methods and properties for handling input.
    /// </summary>
    public interface ICommandManager
    {
        IGameEngine Engine { get; set; }

        void ProcessCommand(string command);

        void SeedCommands();
    }
}