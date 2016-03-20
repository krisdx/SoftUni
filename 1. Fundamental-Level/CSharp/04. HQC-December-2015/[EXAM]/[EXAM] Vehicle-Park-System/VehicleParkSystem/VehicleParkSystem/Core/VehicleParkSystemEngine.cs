namespace VehicleParkSystem.Core
{
    using System;

    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;

    public class VehicleParkSystemEngine : IVehicleParkSystemEngine
    {
        private readonly IUserInterface userInterface;
        private readonly ICommandExecutor commandExecutor;

        public VehicleParkSystemEngine(ICommandExecutor commandExecutor, IUserInterface userInterface)
        {
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = this.userInterface.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                if (commandLine == string.Empty)
                {
                    continue;
                }

                try
                {
                    var command = new Command(commandLine);
                    string commandResult = this.commandExecutor.Execute(command);

                    this.userInterface.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    this.userInterface.WriteLine(ex.Message);
                }
            }
        }
    }
}