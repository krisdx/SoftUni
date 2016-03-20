namespace VehicleParkSystem.Models.Vehicles
{
    public class Motorbike : Vehicle
    {
        private const decimal MotorbikeRegularRate = 1.35M;
        private const decimal MotorbikeOvertimeRate = 3M;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, MotorbikeRegularRate, MotorbikeOvertimeRate)
        {
        }
    }
}