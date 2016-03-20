namespace VehicleParkSystem.Interfaces
{
    public interface ICommandExecutor 
    {
         IVehiclePark VehiclePark { get;  }

        string Execute(ICommand command);
    }
}