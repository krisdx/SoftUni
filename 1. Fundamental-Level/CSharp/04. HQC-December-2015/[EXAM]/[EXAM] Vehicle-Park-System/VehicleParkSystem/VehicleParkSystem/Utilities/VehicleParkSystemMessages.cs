namespace VehicleParkSystem.Utilities
{
    public static class VehicleParkSystemMessages
    {
        public const string NonExistingVehicleWithSuchLicensePlate = "There is no vehicle with license plate {0} in the park";
        public const string NonExistingSectorInPark = "There is no sector {0} in the park";
        public const string NonExistingPlaceInPark = "There is no place {0} in sector {1}";
        public const string OccupiedPlace = "The place ({0},{1}) is occupied";
        public const string AlreadyExistingVehicleWithSuchLicensePlate = "There is already a vehicle with license plate {0} in the park";
        public const string VehicleSuccessfulPark = "{0} parked successfully at place ({1},{2})";
        public const string NotSetUppedPark = "The vehicle park has not been set up";
        public const string VehicleParkCreated = "Vehicle park created";
        public const string UnknownVehicleType = "Unknown vehicle type.";
        public const string NoVehiclesByOwner = "No vehicles by {0}";

        public const string InvalidCommand = "Invalid command.";
    }
}