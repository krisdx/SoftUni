namespace Blobs.Models.Behaviors
{
    using Blobs.Interfaces;

    public class AggresiveBehavior : IBehavior
    {
        public void Trigger(IBlob blob)
        {
            blob.Damage *= 2;
        }

        public void ApplyBehaviorSecondaryEffect(IBlob blob)
        {
            blob.Damage -= 5;
        }
    }
}