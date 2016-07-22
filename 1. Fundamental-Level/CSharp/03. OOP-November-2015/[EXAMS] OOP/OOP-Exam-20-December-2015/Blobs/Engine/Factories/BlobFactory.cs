namespace Blobs.Engine.Factories
{
    using Blobs.Models;
    using Blobs.Interfaces;
    using Blobs.Interfaces.Factories;

    public class BlobFactory : IBlobFactory
    {
        public IBlob CreateBlob(string name, int health, int damage, IBehavior behavior, IAttack attack)
        {
            return new Blob(name, health, damage, behavior, attack);
        }
    }
}