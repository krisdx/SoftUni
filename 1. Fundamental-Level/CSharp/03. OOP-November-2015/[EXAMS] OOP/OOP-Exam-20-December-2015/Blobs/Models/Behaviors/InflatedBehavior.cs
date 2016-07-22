namespace Blobs.Models.Behaviors
{
    using Blobs.Interfaces;

    public class InflatedBehavior : IBehavior
    {
        public void Trigger(IBlob blob)
        {
            blob.Health += 50;
        }

        public void ApplyBehaviorSecondaryEffect(IBlob blob)
        {
            blob.Health -= 10;
        }
    }
}