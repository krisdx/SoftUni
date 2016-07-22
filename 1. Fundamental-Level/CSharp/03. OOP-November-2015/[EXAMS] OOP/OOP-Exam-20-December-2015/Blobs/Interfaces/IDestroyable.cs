namespace Blobs.Interfaces
{
    public interface IDestroyable
    {
        int InitialHealth { get; set; }

        int Health { get; set; }
    }
}