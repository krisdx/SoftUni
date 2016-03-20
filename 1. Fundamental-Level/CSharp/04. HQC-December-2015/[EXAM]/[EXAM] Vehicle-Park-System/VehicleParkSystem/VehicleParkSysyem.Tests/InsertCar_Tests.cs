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
    public class InsertCar_Tests
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
        public void InsertCar_ShouldInsert()
        {
            // Arrange
            var car = new Car("CA5595TH", "Owner", 5);

            // Act
            string actualMessage = this.vehiclePark.InsertCar(car, 1, 1, DateTime.Now);

            // Assert
            Assert.AreEqual("Car parked successfully at place (1,1)", actualMessage, "Wrong success park message.");

            Assert.AreEqual(
                "Car [CA5595TH], owned by Owner\r\nParked at (1,1)",
                this.vehiclePark.FindVehicle("CA5595TH"),
                "Wrong car information.");
        }

        [TestMethod]
        public void InsertCar_AtBiggerThanExistingSectors_ShouldReturnErrorMessage()
        {
            // Arrange
            var car = new Car("CA5595TH", "Owner", 5);
            int sector = NumberOfSectors + 1;

            // Act
            string actualMessage = this.vehiclePark.InsertCar(car, sector, 1, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingSectorInPark, sector);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is adding vehicles at unexisting sector.");
        }

        [TestMethod]
        public void InsertCar_AtSmallerThanZeroSector_ShouldReturnErrorMessage()
        {
            // Arrange
            var car = new Car("CA5595TH", "Owner", 5);
            int sector = NumberOfSectors + 1;

            // Act
            string actualMessage = this.vehiclePark.InsertCar(car, sector, 1, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingSectorInPark, sector);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park is adding vehicles at unexisting sector.");
        }

        [TestMethod]
        public void InsertCar_AtPlaceBiggerThanExistingPlaces_ShouldReturnErrorMessage()
        {
            // Arrange
            var car = new Car("CA5595TH", "Owner", 5);
            int sector = 1;
            int place = NumberOfPlacesPerSector + 1;

            // Act
            string actualMessage = this.vehiclePark.InsertCar(car, sector, place, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingPlaceInPark, place, sector);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park can add vehicles at unexisting place in sector");
        }

        [TestMethod]
        public void InsertCar_AtSmallerThanZeroPlace_ShouldReturnErrorMessage()
        {
            // Arrange
            var car = new Car("CA5595TH", "Owner", 5);
            int sector = 1;
            int place = -13;

            // Act
            string actualMessage = this.vehiclePark.InsertCar(car, sector, place, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.NonExistingPlaceInPark, place, sector);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park can add vehicles at unexisting place in sector");
        }

        [TestMethod]
        public void InsertCars_AtOccupiedPlace_ShouldReturnErrorMessage()
        {
            // Arrange
            var firstCar = new Car("CA5595TH", "Owner", 5);
            var secondCar = new Car("CA5596TH", "Owner2", 6);

            int sector = 1;
            int place = 1;

            // Act
            this.vehiclePark.InsertCar(firstCar, sector, place, DateTime.Now);
            string actualMessage = this.vehiclePark.InsertCar(secondCar, sector, place, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.OccupiedPlace, sector, place);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park can add vehicles at already occupid places.");
        }

        [TestMethod]
        public void InsertCars_WithSameLicensePlate_ShouldReturnErrorMessage()
        {
            // Arrange
            string licensePlate = "CA5595TH";
            var firstCar = new Car(licensePlate, "Owner", 5);
            var secondCar = new Car(licensePlate, "Owner2", 6);

            // Act
            this.vehiclePark.InsertCar(firstCar, 1, 1, DateTime.Now);
            string actualMessage = this.vehiclePark.InsertCar(secondCar, 1, 2, DateTime.Now);
            string expectedMessage = string.Format(VehicleParkSystemMessages.AlreadyExistingVehicleWithSuchLicensePlate, licensePlate);

            // Assert
            Assert.AreEqual(expectedMessage, actualMessage, "The park can add vehicles with the same license plate.");
        }
    }
}