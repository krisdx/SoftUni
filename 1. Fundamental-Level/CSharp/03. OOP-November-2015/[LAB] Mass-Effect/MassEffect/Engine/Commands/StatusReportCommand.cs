namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using MassEffect.Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship starship =
                this.GameEngine.Starships.FirstOrDefault(ship => ship.Name == shipName);
            if (starship == null)
            {
                string message = string.Format("{0} does not exists.", shipName);
                throw new ArgumentNullException(message);
            }

            Console.WriteLine(starship);
        }
    }
}