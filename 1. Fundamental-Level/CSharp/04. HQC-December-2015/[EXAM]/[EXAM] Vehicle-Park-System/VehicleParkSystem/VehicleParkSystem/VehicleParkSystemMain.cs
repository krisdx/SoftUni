namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    using VehicleParkSystem.Core;
    using VehicleParkSystem.UserInterface;

    public class VehicleParkSystemMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            
            var userInterface = new ConsoleUserInterface();
            var commandExecutor = new CommandExecutor();

            var engine = new VehicleParkSystemEngine(commandExecutor, userInterface);
            engine.Run();
        }
    }
}