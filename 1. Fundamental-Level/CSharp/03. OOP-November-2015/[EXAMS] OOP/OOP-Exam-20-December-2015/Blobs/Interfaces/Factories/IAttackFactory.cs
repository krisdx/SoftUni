namespace Blobs.Interfaces.Factories
{
    public interface IAttackFactory
    {
        IAttack CreateAttack(string attackType, int damage);
    }
}