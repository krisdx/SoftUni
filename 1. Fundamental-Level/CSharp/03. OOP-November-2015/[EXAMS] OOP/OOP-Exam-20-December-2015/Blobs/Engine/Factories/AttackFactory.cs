namespace Blobs.Engine.Factories
{
    using System;

    using Blobs.Interfaces;
    using Blobs.Models.Attacks;
    using Blobs.Interfaces.Factories;

    public class AttackFactory : IAttackFactory
    {
        public IAttack CreateAttack(string attackType, int damage)
        {
            switch (attackType)
            {
                case "PutridFart":
                    return new PutridFart(damage);
                case "Blobplode":
                    return new Blobplode(damage);
                default:
                    throw new ArgumentException("Unknown attack type.");
            }
        }
    }
}