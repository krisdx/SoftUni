namespace VehicleParkSystem.Interfaces
{
   /// <summary>
   /// Provides methods for user interface.
   /// </summary>
    public interface IUserInterface
    {
        string ReadLine();

        void WriteLine(string format, params string[] args);
    }
}