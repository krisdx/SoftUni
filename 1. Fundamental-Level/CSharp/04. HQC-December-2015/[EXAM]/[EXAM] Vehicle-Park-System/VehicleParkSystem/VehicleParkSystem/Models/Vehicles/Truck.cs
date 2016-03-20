namespace VehicleParkSystem.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal TruckRegularRate = 4.75M;
        private const decimal TruckOvertimeRate = 6.2M;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, TruckRegularRate, TruckOvertimeRate)
        {
        }
    }
}