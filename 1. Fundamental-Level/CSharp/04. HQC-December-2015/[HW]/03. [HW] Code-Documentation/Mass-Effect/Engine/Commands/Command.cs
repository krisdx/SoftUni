namespace MassEffect.Engine.Commands
{
    using System;
    using MassEffect.Interfaces;
    using MassEffect.Exceptions;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        protected IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected void IsAlive(IStarship starship)
        {
            if (starship.Health <= 0)
            {
                throw new ShipException(string.Format("{0}  is not alive.", starship.Name));
            }
        }
    }
}