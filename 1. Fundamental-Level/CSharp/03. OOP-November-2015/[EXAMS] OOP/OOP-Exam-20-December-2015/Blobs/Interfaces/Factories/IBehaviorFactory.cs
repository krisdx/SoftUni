namespace Blobs.Interfaces.Factories
{
    public interface IBehaviorFactory
    {
        IBehavior CreateBehavior(string behaviorType);
    }
}
