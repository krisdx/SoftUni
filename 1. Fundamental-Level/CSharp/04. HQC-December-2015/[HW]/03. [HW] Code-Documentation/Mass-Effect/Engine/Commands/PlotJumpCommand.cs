namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;
    using MassEffect.Exceptions;
    using MassEffect.GameObjects.Locations;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string starshipName = commandArgs[1];
            string destinationName = commandArgs[2];

            IStarship starship =
                this.GameEngine.Starships.FirstOrDefault(ship => ship.Name == starshipName);
            if (starship == null)
            {
                throw new ShipException(@"Ship ""{0}"" does not exists.");
            }

            this.IsAlive(starship);

            StarSystem previousLocation = starship.Location;
            StarSystem desiredLocation = this.GameEngine.Galaxy.GetStarSystemByName(destinationName);
            if (previousLocation.Name == desiredLocation.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, previousLocation.Name));
            }

            this.GameEngine.Galaxy.TravelTo(starship, desiredLocation);
            Console.WriteLine(Messages.ShipTraveled, starship.Name, previousLocation.Name, desiredLocation.Name);
        }
    }
}