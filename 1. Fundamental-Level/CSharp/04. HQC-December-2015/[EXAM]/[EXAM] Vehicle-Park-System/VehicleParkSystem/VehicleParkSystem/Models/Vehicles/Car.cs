namespace VehicleParkSystem.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const decimal CarRegularRate = 2M;
        private const decimal CarOvertimeRate = 3.5M;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, CarRegularRate, CarOvertimeRate)
        {
        }
    }
}