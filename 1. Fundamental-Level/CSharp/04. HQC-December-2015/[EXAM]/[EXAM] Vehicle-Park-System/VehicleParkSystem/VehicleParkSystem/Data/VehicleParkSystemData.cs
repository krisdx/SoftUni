namespace VehicleParkSystem.Data
{
    using System;
    using System.Collections.Generic;

    using VehicleParkSystem.Interfaces;

    using Wintellect.PowerCollections;

    public class VehicleParkSystemData : IVehicleParkSystemData
    {
        public VehicleParkSystemData(int numberOfSectors)
        {
            this.VehiclesInParkPlaces = new Dictionary<IVehicle, string>();
            this.ParkPlaces = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.VehiclesByStartTime = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.SpacesCount = new int[numberOfSectors];
        }

        public IDictionary<IVehicle, string> VehiclesInParkPlaces { get; set; }

        public IDictionary<string, IVehicle> ParkPlaces { get; set; }

        public IDictionary<string, IVehicle> VehiclesByLicensePlate { get; set; }

        public IDictionary<IVehicle, DateTime> VehiclesByStartTime { get; set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] SpacesCount { get; set; }

        public void RemoveVehicle(IVehicle vehicle)
        {
            int sector = int.Parse(this.VehiclesInParkPlaces[vehicle]
                .Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.ParkPlaces.Remove(this.VehiclesInParkPlaces[vehicle]);
            this.VehiclesInParkPlaces.Remove(vehicle);
            this.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.VehiclesByStartTime.Remove(vehicle);
            this.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            this.SpacesCount[sector - 1]--;
        }

        public void InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        {
            this.VehiclesInParkPlaces[vehicle] = string.Format("({0},{1})", sector, placeNumber);
            this.ParkPlaces[string.Format("({0},{1})", sector, placeNumber)] = vehicle;
            this.VehiclesByLicensePlate[vehicle.LicensePlate] = vehicle;
            this.VehiclesByStartTime[vehicle] = startTime;
            this.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            this.SpacesCount[sector - 1] += 1;
        }
    }
}