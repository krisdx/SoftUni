namespace Blobs.Engine.Factories
{
    using System;

    using Blobs.Interfaces;
    using Blobs.Models.Behaviors;
    using Blobs.Interfaces.Factories;

    public class BehaviorFactory : IBehaviorFactory
    {
        public IBehavior CreateBehavior(string behaviorType)
        {
            switch (behaviorType)
            {
                case "Aggressive":
                    return new AggresiveBehavior();
                case "Inflated":
                    return new InflatedBehavior();
                default:
                    throw new ArgumentException("Unknown behavior type.");
            }
        }
    }
}