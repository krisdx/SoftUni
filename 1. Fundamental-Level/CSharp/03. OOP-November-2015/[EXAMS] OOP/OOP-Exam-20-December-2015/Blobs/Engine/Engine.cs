namespace Blobs.Engine
{
    using System;
    using System.Linq;

    using Blobs.Interfaces;
    using Blobs.Interfaces.IO;
    using Blobs.Interfaces.Data;
    using Blobs.Interfaces.Factories;

    public class Engine : IRunnable
    {
        protected IBlobFactory blobFactory;
        protected IAttackFactory attackFactory;
        protected IBehaviorFactory behaviorFactory;

        protected IData data;

        protected IInputReader reader;
        protected IOutputWriter writer;

        public Engine(IBlobFactory blobFactory, IAttackFactory attackFactory, IBehaviorFactory behaviorFactory, IData data, IInputReader reader, IOutputWriter writer)
        {
            this.data = data;
            this.reader = reader;
            this.writer = writer;
            this.blobFactory = blobFactory;
            this.attackFactory = attackFactory;
            this.behaviorFactory = behaviorFactory;

            this.IsRunning = true;
        }

        public bool IsRunning { get; protected set; }

        public virtual void Run()
        {
            while (this.IsRunning)
            {
                string[] commandDetails = this.reader.ReadLine().Split();

                this.ExecuteCommand(commandDetails);

                this.CheckForUpdates();
            }
        }

        protected virtual void CheckForUpdates()
        {
            foreach (var blob in this.data.Blobs)
            {
                if (blob.HasTriggeredBehavior)
                {
                    blob.ApplyBehaviorSecondaryEffect();
                }
            }

            foreach (var blob in this.data.Blobs)
            {
                bool hasFallBeloowHalfInitialHealth = blob.InitialHealth / 2 >= blob.Health;
                if (hasFallBeloowHalfInitialHealth &&
                    !blob.HasTriggeredBehavior)
                {
                    blob.TriggerBehavior();
                }
            }
        }

        protected virtual void ExecuteCommand(string[] commandDetails)
        {
            string actionType = commandDetails[0];
            switch (actionType)
            {
                case "create":
                    this.ExecuteCreateCommand(commandDetails);
                    break;
                case "attack":
                    this.ExecuteAttackCommand(commandDetails);
                    break;
                case "status":
                    this.ExecuteStatusCommand(commandDetails);
                    break;
                case "pass":
                    break;
                case "drop":
                    this.ExecuteDropCommand();
                    break;
                default:
                    throw new ArgumentException("Unknown command type.");
            }
        }

        protected virtual void ExecuteCreateCommand(string[] commandDetails)
        {
            string name = commandDetails[1];
            int health = int.Parse(commandDetails[2]);
            int damage = int.Parse(commandDetails[3]);
            IBehavior behaviorType = this.behaviorFactory.CreateBehavior(commandDetails[4]);
            IAttack attckType = this.attackFactory.CreateAttack(commandDetails[5], damage);

            var blob = this.blobFactory.CreateBlob(name, health, damage, behaviorType, attckType);
            this.data.AddUnit(blob);
        }

        protected virtual void ExecuteAttackCommand(string[] commandDetails)
        {
            var attacker = this.GetUnit(commandDetails[1]);
            if (attacker.Health == 0)
            {
                throw new InvalidOperationException("Cannot proceed the attack, because the attacking blob is dead.");
            }

            var target = this.GetUnit(commandDetails[2]);
            if (target.Health == 0)
            {
                throw new InvalidOperationException("Cannot proceed the attack, because the target blob is dead.");
            }

            attacker.Attack(target);
        }

        protected IBlob GetUnit(string unitName)
        {
            var blobUnit =
                this.data.Blobs.FirstOrDefault(blob => blob.Name == unitName);
            return blobUnit;
        }

        protected virtual void ExecuteStatusCommand(string[] commandDetails)
        {
            foreach (var blob in this.data.Blobs)
            {
                this.writer.AppendLine(blob.ToString());
            }
        }

        protected virtual void ExecuteDropCommand()
        {
            this.IsRunning = false;
        }
    }
}