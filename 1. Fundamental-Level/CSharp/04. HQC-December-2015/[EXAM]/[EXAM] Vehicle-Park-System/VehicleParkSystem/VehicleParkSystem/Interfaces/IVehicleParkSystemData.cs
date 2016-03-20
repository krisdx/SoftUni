namespace VehicleParkSystem.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public interface IVehicleParkSystemData
    {
        IDictionary<IVehicle, string> VehiclesInParkPlaces { get; }

        IDictionary<string, IVehicle> ParkPlaces { get; }

        IDictionary<string, IVehicle> VehiclesByLicensePlate { get; }

        IDictionary<IVehicle, DateTime> VehiclesByStartTime { get; }

        MultiDictionary<string, IVehicle> VehiclesByOwner { get; }

        int[] SpacesCount { get; }

        void RemoveVehicle(IVehicle vehicle);

        void InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime);
    }
}