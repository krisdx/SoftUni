using VehicleParkSystem.Data;
using VehicleParkSystem.Models;

namespace VehicleParkSysyem.Tests
{
    using System;

    using VehicleParkSystem.Core;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindVehiclesByOwner_Tests
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
        public void FindVehicleByOwner_ShouldReturnCorrectVehicle()
        {
            // Arrange
            var car = new Car("CA4444PA", "Ivan", 2);

            // Act
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);
            var actualMessage = this.vehiclePark.FindVehiclesByOwner("Ivan");

            string expectedMessage =
                "Car [CA4444PA], owned by Ivan\r\n" +
                 "Parked at (1,1)";

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FindVehiclesByOwner_ShouldReturnCorrectVehicles()
        {
            // Arrange
            var firstCar = new Car("CA4444PA", "Ivan", 2);
            var secondCar = new Car("CA4445PA", "Ivan", 3);
            var thirdCar = new Car("CA4446PA", "Ivan", 4);
            var fourthCar = new Car("CA4447PA", "Ivan", 5);

            // Act
            this.vehiclePark.InsertCar(firstCar, 1, 1, DateTime.Now);
            this.vehiclePark.InsertCar(secondCar, 1, 2, DateTime.Now);
            this.vehiclePark.InsertCar(thirdCar, 2, 1, DateTime.Now);
            this.vehiclePark.InsertCar(fourthCar, 2, 2, DateTime.Now);

            var actualMessage = this.vehiclePark.FindVehiclesByOwner("Ivan");

            string expectedMessage =
                "Car [CA4444PA], owned by Ivan\r\n" +
                "Parked at (1,1)\r\n" +
                "Car [CA4445PA], owned by Ivan\r\n" +
                "Parked at (1,2)\r\n" +
                "Car [CA4446PA], owned by Ivan\r\n" +
                "Parked at (2,1)\r\n" +
                "Car [CA4447PA], owned by Ivan\r\n" +
                "Parked at (2,2)";

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void FindVehiclesByOwner_ShouldSortCorrectly()
        {
            // Arrange
            var firstCar = new Car("CA4444PA", "Ivan", 2);
            var secondCar = new Car("CA4445PA", "Ivan", 3);
            var thirdCar = new Car("CA4446PA", "Ivan", 4);
            var fourthCar = new Car("CA4447PA", "Ivan", 5);

            DateTime startTime = DateTime.Now;

            // Act
            this.vehiclePark.InsertCar(firstCar, 1, 1, startTime.AddHours(3));
            this.vehiclePark.InsertCar(secondCar, 1, 2, startTime.AddHours(2));
            this.vehiclePark.InsertCar(thirdCar, 2, 1, startTime.AddHours(1));
            this.vehiclePark.InsertCar(fourthCar, 2, 2, startTime);

            var actualMessage = this.vehiclePark.FindVehiclesByOwner("Ivan");

            string expectedMessage =
                "Car [CA4447PA], owned by Ivan\r\n" +
                "Parked at (2,2)\r\n" +
                "Car [CA4446PA], owned by Ivan\r\n" +
                "Parked at (2,1)\r\n" +
                "Car [CA4445PA], owned by Ivan\r\n" +
                "Parked at (1,2)\r\n" +
                "Car [CA4444PA], owned by Ivan\r\n" +
                "Parked at (1,1)";

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "Тhe park is not sorting correctly by start time.");
        }

        [TestMethod]
        public void FindVehiclesByOwner_NoVehiclesByOwner_ShouldReturnErrorMessage()
        {
            // Arrange
            string owner = "John Smith";
            string wrongOwner = "John Raul";
            var car = new Car("CA4444PA", owner, 2);

            // Act
            this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);

            var actualMessage = this.vehiclePark.FindVehiclesByOwner(wrongOwner);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NoVehiclesByOwner, wrongOwner);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}