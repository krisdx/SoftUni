namespace MassEffect.Engine.Commands
{
    using System.Linq;

    using MassEffect.Interfaces;
    using System.Text;
    using System;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            var intactStarships = this.GameEngine.Starships
                .Where(ship => ship.Health > 0 && ship.Location.Name == locationName)
                .OrderByDescending(ship => ship.Health)
                .ThenByDescending(ship => ship.Shields);

            StringBuilder output = new StringBuilder();
            output.AppendLine("Intact ships:");
            output.AppendLine(intactStarships.Any() ?
                string.Join("\n", intactStarships) : "N/A");

            var destroyedStarships = this.GameEngine.Starships
                .Where(ship => ship.Health <= 0 && ship.Location.Name == locationName)
                .OrderBy(ship => ship.Name);
            output.AppendLine("Destroyed ships:");
            output.Append(destroyedStarships.Any() ?
                string.Join("\n", destroyedStarships) : "N/A");

            Console.WriteLine(output);
        }
    }
}