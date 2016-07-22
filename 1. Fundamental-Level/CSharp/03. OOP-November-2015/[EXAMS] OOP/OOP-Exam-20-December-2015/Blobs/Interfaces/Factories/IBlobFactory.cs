namespace Blobs.Interfaces.Factories
{
    using Blobs.Models;

    public interface IBlobFactory
    {
        IBlob CreateBlob(string name, int health, int damage, IBehavior behavior, IAttack attack);
    }
}