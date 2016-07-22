namespace Blobs.Interfaces
{
    public interface IBehavior
    {
        void Trigger(IBlob blob);

        void ApplyBehaviorSecondaryEffect(IBlob blob);
    }
}