namespace Blobs.Interfaces
{
    public interface IAttack
    {
        void ProceedAttack(IBlob attacker, IBlob target);
    }
}