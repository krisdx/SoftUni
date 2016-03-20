namespace VehicleParkSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VehicleParkSystem.Data;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;

    public class VehiclePark : IVehiclePark
    {
        private readonly IParkLayout parkLayout;
        private readonly IVehicleParkSystemData vehicleParkSystemData;

        public VehiclePark(IVehicleParkSystemData parkData, IParkLayout parkLayout)
        {
            this.parkLayout = parkLayout;
            this.vehicleParkSystemData = parkData;
        }

        public string InsertCar(Car car, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(car, sector, placeNumber, startTime);
        }

        public string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(truck, sector, placeNumber, startTime);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime)
        {
            return this.InsertVehicle(motorbike, sector, placeNumber, startTime);
        }

        public string ExitVehicle(string licensePlate, DateTime endOfParking, decimal amountPaid)
        {
            bool vehicleExists =
                this.vehicleParkSystemData.VehiclesByLicensePlate.ContainsKey(licensePlate);
            if (!vehicleExists)
            {
                return string.Format(VehicleParkSystemMessages.NonExistingVehicleWithSuchLicensePlate, licensePlate);
            }

            var vehicle = this.vehicleParkSystemData.VehiclesByLicensePlate[licensePlate];

            var startTime = this.vehicleParkSystemData.VehiclesByStartTime[vehicle];
            int endTime = (int)(endOfParking - startTime).TotalHours;

            decimal regularRate = vehicle.ReservedHours * vehicle.RegularRate;
            decimal overTimeRate = endTime > vehicle.ReservedHours ?
                 (endTime - vehicle.ReservedHours) * vehicle.OvertimeRate : 0;

            var ticket = new StringBuilder();

            ticket.AppendLine(new string('*', 20))

                .AppendFormat("{0}", vehicle).AppendLine()
                .AppendFormat("at place {0}", this.vehicleParkSystemData.VehiclesInParkPlaces[vehicle])

                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", regularRate)
                .AppendLine()

                .AppendFormat("Overtime rate: ${0:F2}", overTimeRate)

                .AppendLine()
                .AppendLine(new string('-', 20))

                .AppendFormat("Total: ${0:F2}", regularRate + overTimeRate)

                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", amountPaid)

                .AppendLine()
                .AppendFormat("Change: ${0:F2}", amountPaid - (regularRate + overTimeRate))

                .AppendLine()
                .Append(new string('*', 20));

            this.vehicleParkSystemData.RemoveVehicle(vehicle);

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var sectorsReport = this.vehicleParkSystemData
                .SpacesCount
                .Select((vehiclesParked, sectorIndex) =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)",
                        sectorIndex + 1,
                        vehiclesParked,
                        this.parkLayout.PlacesPerSector,
                        Math.Round((double)vehiclesParked / this.parkLayout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, sectorsReport);
        }

        public string FindVehicle(string licensePlate)
        {
            bool hasAnyVehicleByLicensePlate =
                this.vehicleParkSystemData.VehiclesByLicensePlate.ContainsKey(licensePlate);
            if (!hasAnyVehicleByLicensePlate)
            {
                return string.Format(VehicleParkSystemMessages.NonExistingVehicleWithSuchLicensePlate, licensePlate);
            }

            var vehicle = this.vehicleParkSystemData.VehiclesByLicensePlate[licensePlate];

            return this.FormatInput(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            bool hasAnyVehiclesByOwner = this.vehicleParkSystemData
                .ParkPlaces.Values
                .Any(vehicle => vehicle.Owner == owner);

            if (!hasAnyVehiclesByOwner)
            {
                return string.Format(VehicleParkSystemMessages.NoVehiclesByOwner, owner);
            }

            var vehiclesByOwner = this.vehicleParkSystemData
                .ParkPlaces.Values
                .Where(vehicle => vehicle.Owner == owner);

            var orderedVehiclesByOwner = vehiclesByOwner
                .OrderBy(vehicle => this.vehicleParkSystemData.VehiclesByStartTime[vehicle])
                .ThenBy(vehicle => vehicle.LicensePlate)
                .ToList();

            return this.FormatInput(orderedVehiclesByOwner);
        }

        private string FormatInput(IEnumerable<IVehicle> vehicles)
        {
            var formattedVehicles = vehicles
                .Select(vehicle => 
                string.Format(
                    "{0}{1}Parked at {2}",
                    vehicle.ToString(),
                    Environment.NewLine,
                    this.vehicleParkSystemData.VehiclesInParkPlaces[vehicle]));

            return string.Join(Environment.NewLine, formattedVehicles);
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int placeNumber, DateTime startTime)
        {
            if (sector < 0 || sector > this.parkLayout.NumberOfSectors )
            {
                return string.Format(VehicleParkSystemMessages.NonExistingSectorInPark, sector);
            }

            if (placeNumber < 0 || placeNumber > this.parkLayout.PlacesPerSector)
            {
                return string.Format(VehicleParkSystemMessages.NonExistingPlaceInPark, placeNumber, sector);
            }

            if (this.vehicleParkSystemData.ParkPlaces.ContainsKey(string.Format("({0},{1})", sector, placeNumber)))
            {
                return string.Format(VehicleParkSystemMessages.OccupiedPlace, sector, placeNumber);
            }

            if (this.vehicleParkSystemData.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(VehicleParkSystemMessages.AlreadyExistingVehicleWithSuchLicensePlate, vehicle.LicensePlate);
            }

            this.vehicleParkSystemData.InsertVehicle(vehicle, sector, placeNumber, startTime);

            return string.Format(VehicleParkSystemMessages.VehicleSuccessfulPark, vehicle.GetType().Name, sector, placeNumber);
        }
    }
}