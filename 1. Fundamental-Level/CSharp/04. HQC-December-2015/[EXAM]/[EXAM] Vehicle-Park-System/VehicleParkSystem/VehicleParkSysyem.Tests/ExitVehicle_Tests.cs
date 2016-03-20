namespace VehicleParkSysyem.Tests
{
    using System;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Data;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ExitVehicle_Tests
    {
        private const int NumberOfSectors = 3;
        private const int NumberOfPlacesPerSector = 3;

        private IVehiclePark vehiclePark;

        [TestInitialize]
        public void TestInitialize()
        {
            var parkLayout = new ParkLayout(NumberOfSectors, NumberOfPlacesPerSector);
            var parkData = new VehicleParkSystemData(NumberOfSectors);

            this.vehiclePark = new VehiclePark(parkData, parkLayout);
        }

        [TestMethod]
        public void ExitVehicle_ShouldRemoveVehicle()
        {
            // Arrange
            string licensePlate = "CA1879PP";

            DateTime startTime = DateTime.Now;
            DateTime enDateTime = startTime.AddHours(2);
            var truck = new Truck(licensePlate, "Owner", 3);

            // Act
            this.vehiclePark.InsertTruck(truck, 1, 1, startTime);
            this.vehiclePark.ExitVehicle(licensePlate, enDateTime, 100m);

            string actualMessage = this.vehiclePark.FindVehicle(licensePlate);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingVehicleWithSuchLicensePlate, licensePlate);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is not removing vehicles.");
        }

        [TestMethod]
        public void ExitVehicle_WithUnExistingLicensePlate_ShouldReturnErrorMessage()
        {
            // Arrange
            string licensePlate = "CA1879PP";
            string wrongLicensePlate = licensePlate + "Wrong";
            var truck = new Truck(licensePlate, "Owner", 3);

            // Act
            this.vehiclePark.InsertTruck(truck, 1, 1, DateTime.Now);
            string actualMessage = this.vehiclePark.ExitVehicle(wrongLicensePlate, DateTime.Now.AddHours(3), 100m);

            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingVehicleWithSuchLicensePlate, wrongLicensePlate);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is not removing vehicles.");
        }

        [TestMethod]
        public void ExitVehicle_ExitBeforrReservedHours_ShouldChargeForReservedHours()
        {
            // Arrange
            string licensePlate = "CA1001HH";
            string owner = "Jay Margareta";
            int reservedHours = 3;
            var car = new Car(licensePlate, owner, reservedHours);

            DateTime starTime = DateTime.Now;
            DateTime endTime = starTime.AddHours(1);

            // Act
            this.vehiclePark.InsertCar(car, 1, 1, starTime);
            string actualMessage = this.vehiclePark.ExitVehicle(licensePlate, endTime, 100m);

            string expectedMessage =
                "********************\r\n" +
                "Car [CA1001HH], owned by Jay Margareta\r\n" +
                "at place (1,1)\r\n" +
                "Rate: $6,00\r\n" +
                "Overtime rate: $0,00\r\n" +
                "--------------------\r\n" +
                "Total: $6,00\r\n" +
                "Paid: $100,00\r\n" +
                "Change: $94,00\r\n" +
                "********************";

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is not the reserved hours.");
        }

        [TestMethod]
        public void ExitVehicle_ExitAfterReservedHours_ShouldChargeForOverTime()
        {
            // Arrange
            string licensePlate = "CA1001HH";
            string owner = "Jay Margareta";
            int reservedHours = 3;
            var car = new Car(licensePlate, owner, reservedHours);

            DateTime starTime = DateTime.Now;
            DateTime endTime = starTime.AddHours(6);

            // Act
            this.vehiclePark.InsertCar(car, 1, 1, starTime);
            string actualMessage = this.vehiclePark.ExitVehicle(licensePlate, endTime, 100m);

            string expectedMessage =
                "********************\r\n" +
                "Car [CA1001HH], owned by Jay Margareta\r\n" +
                "at place (1,1)\r\n" +
                "Rate: $6,00\r\n" +
                "Overtime rate: $10,50\r\n" +
                "--------------------\r\n" +
                "Total: $16,50\r\n" +
                "Paid: $100,00\r\n" +
                "Change: $83,50\r\n" +
                "********************";

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is not charging for overtime.");
        }
    }
}