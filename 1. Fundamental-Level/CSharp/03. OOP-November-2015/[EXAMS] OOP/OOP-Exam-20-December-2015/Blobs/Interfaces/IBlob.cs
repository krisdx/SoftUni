namespace Blobs.Interfaces
{
    public interface IBlob : IUnit, IDestroyable, IAttacking
    {
        void TriggerBehavior();

        void ApplyBehaviorSecondaryEffect();

        bool HasTriggeredBehavior { get; set; }
    }
}