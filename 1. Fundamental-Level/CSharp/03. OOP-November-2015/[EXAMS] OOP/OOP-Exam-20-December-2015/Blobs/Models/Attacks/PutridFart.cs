namespace Blobs.Models.Attacks
{
    using Blobs.Interfaces;

    public class PutridFart : Attack, IAttack
    {
        public PutridFart(int damage)
            : base(damage)
        {
        }

        public void ProceedAttack(IBlob target, IBlob attacker)
        {
            target.Health -= this.Damage;
        }
    }
}