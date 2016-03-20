using VehicleParkSystem.Data;
using VehicleParkSystem.Models;

namespace VehicleParkSystem.Core
{
    using System;

    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;

    public class CommandExecutor : ICommandExecutor
    {
        public IVehiclePark VehiclePark { get; set; }
        
        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return VehicleParkSystemMessages.NotSetUppedPark;
            }

            switch (command.Name)
            {
                case "SetupPark":
                    return this.ExecuteSetupParkCommand(command);
                case "Park":
                    string licensePlate = command.Parameters["licensePlate"];
                    string owner = command.Parameters["owner"];
                    int reservedHours = int.Parse(command.Parameters["hours"]);

                    int sectorNumber = int.Parse(command.Parameters["sector"]);
                    int placeNumber = int.Parse(command.Parameters["place"]);
                    DateTime startTime = DateTime.Parse(command.Parameters["time"]);

                    switch (command.Parameters["type"])
                    {
                        case "car":
                            var car = new Car(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertCar(car, sectorNumber, placeNumber, startTime);
                        case "motorbike":
                            var motorbike = new Motorbike(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertMotorbike(motorbike, sectorNumber, placeNumber, startTime);
                        case "truck":
                            var truck = new Truck(licensePlate, owner, reservedHours);
                            return this.VehiclePark.InsertTruck(truck, sectorNumber, placeNumber, startTime);
                        default:
                            throw new ArgumentException(VehicleParkSystemMessages.UnknownVehicleType);
                    }

                case "FindVehicle":
                    return this.ExecuteFindVehicleCommand(command);
                case "VehiclesByOwner":
                    return this.ExecuteFindVehicleByOwnerCommand(command);
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "Exit":
                    return this.ExecuteExitCommand(command);
                default:
                    throw new ArgumentException(VehicleParkSystemMessages.InvalidCommand);
            }
        }

        private string ExecuteFindVehicleCommand(ICommand command)
        {
            string licensePlate = command.Parameters["licensePlate"];
            return this.VehiclePark.FindVehicle(licensePlate);
        }

        private string ExecuteFindVehicleByOwnerCommand(ICommand command)
        {
            string owner = command.Parameters["owner"];
            return this.VehiclePark.FindVehiclesByOwner(owner);
        }

        private string ExecuteSetupParkCommand(ICommand command)
        {
            int numberOfSectors = int.Parse(command.Parameters["sectors"]);
            int placesPerSector = int.Parse(command.Parameters["placesPerSector"]);

            var parkLayout = new ParkLayout(numberOfSectors, placesPerSector);
            var parkData = new VehicleParkSystemData(numberOfSectors);

            this.VehiclePark = new VehiclePark(parkData, parkLayout);

            return VehicleParkSystemMessages.VehicleParkCreated;
        }

        private string ExecuteExitCommand(ICommand command)
        {
            string licensePlate = command.Parameters["licensePlate"];
            DateTime endTime = DateTime.Parse(command.Parameters["time"]);
            decimal money = decimal.Parse(command.Parameters["paid"]);

            return this.VehiclePark.ExitVehicle(licensePlate, endTime, money);
        }
    }
}