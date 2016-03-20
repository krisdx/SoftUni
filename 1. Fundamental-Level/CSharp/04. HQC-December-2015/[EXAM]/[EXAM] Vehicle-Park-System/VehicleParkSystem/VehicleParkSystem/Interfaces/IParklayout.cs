namespace VehicleParkSystem.Interfaces
{
    public interface IParkLayout
    {
        int NumberOfSectors { get; }

        int PlacesPerSector { get; }
    }
}