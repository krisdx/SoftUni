namespace Blobs.Models.Attacks
{
    using Blobs.Interfaces;

    public class Blobplode : Attack, IAttack
    {
        public Blobplode(int damage)
            : base(damage)
        {
        }

        public void ProceedAttack(IBlob target, IBlob attacker)
        {
            attacker.Health = attacker.Health - attacker.Health / 2;
            target.Health -= this.Damage * 2;
        }
    }
}