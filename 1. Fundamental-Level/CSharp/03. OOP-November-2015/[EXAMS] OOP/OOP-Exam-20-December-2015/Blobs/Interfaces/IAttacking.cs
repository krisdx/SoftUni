namespace Blobs.Interfaces
{
    public interface IAttacking
    {
        int InitialDamage { get; set; }

        int Damage { get; set; }

        void Attack(IBlob blob);
    }
}
