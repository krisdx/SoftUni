namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;
    using MassEffect.GameObjects.Ships;
    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Enhancements;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists =
                this.GameEngine.Starships.Any(ship => ship.Name == shipName);
            if (shipAlreadyExists)
            {
                throw new InvalidOperationException("The ship already exists");
            }

            StarSystem location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            IStarship starship = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(starship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                EnhancementType enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                Enhancement enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                starship.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}