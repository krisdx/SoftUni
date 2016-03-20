namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;

    using MassEffect.Interfaces;
    using MassEffect.Exceptions;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackStarshipName = commandArgs[1];
            IStarship attackStarship =
                this.GameEngine.Starships.FirstOrDefault(ship => ship.Name == attackStarshipName);
            if (attackStarship == null)
            {
                throw new ArgumentNullException(string.Format(@"Ship ""{0}"" does not exists.", attackStarshipName));
            }

            string targetSratshipName = commandArgs[2];
            IStarship targetStarship =
                this.GameEngine.Starships.FirstOrDefault(ship => ship.Name == targetSratshipName);
            if (targetStarship == null)
            {
                throw new ArgumentNullException(string.Format(@"Ship ""{0}"" does not exists.", targetStarship));
            }

            this.ProcessStarshipBattle(attackStarship, targetStarship);
        }

        private void ProcessStarshipBattle(IStarship attackStarship, IStarship targetStarship)
        {
            this.IsAlive(attackStarship);
            this.IsAlive(targetStarship);

            bool areBothShipsInTheSameStarSystem =
                attackStarship.Location.Name == targetStarship.Location.Name;
            if (!areBothShipsInTheSameStarSystem)
            {
                throw new LocationOutOfRangeException("The starships are from different star systems.");
            }

            IProjectile attack = attackStarship.ProduceAttack();
            targetStarship.RespondToAttack(attack);

            Console.WriteLine(Messages.ShipAttacked, attackStarship.Name, targetStarship.Name);

            if (targetStarship.Shields < 0)
            {
                targetStarship.Shields = 0;
            }

            if (targetStarship.Health <= 0)
            {
                targetStarship.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetStarship.Name);
            }
        }
    }
}