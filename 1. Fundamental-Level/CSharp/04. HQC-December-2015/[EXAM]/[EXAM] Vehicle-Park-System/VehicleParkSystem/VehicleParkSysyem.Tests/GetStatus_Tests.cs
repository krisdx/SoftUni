namespace VehicleParkSysyem.Tests
{
    using System;

    using VehicleParkSystem.Models;
    using VehicleParkSystem.Models.Vehicles;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GetStatus_Tests
    {
        private const int NumberOfSectors = 2;
        private const int NumberOfPlacesPerSector = 2;

        private IVehiclePark vehiclePark;

        [TestInitialize]
        public void TestInitialize()
        {
            var parkLayout = new ParkLayout(NumberOfSectors, NumberOfPlacesPerSector);
            var parkData = new VehicleParkSystemData(NumberOfSectors);

            this.vehiclePark = new VehiclePark(parkData, parkLayout);
        }

        [TestMethod]
        public void GetStatus_EmptyPark_ShouldReturnCorrectMessage()
        {
            // Arrange
            string expectedStatus =
                "Sector 1: 0 / 2 (0% full)\r\n" +
                "Sector 2: 0 / 2 (0% full)";

            // Act
            var parkStatus = this.vehiclePark.GetStatus();

            // Assert
            Assert.AreEqual(expectedStatus, parkStatus);
        }

        [TestMethod]
        public void GetStatus_WithSomeVehicles_ShouldReturnCorrectMessage()
        {
            // Arrange
            var firstCar = new Car("CA5594HH", "Ivan", 1);
            var secondCar = new Car("CA5595HH", "Ivan", 2);
            var truck = new Truck("CA5596HH", "Ivan", 3);
            var motorbike = new Motorbike("CA5597HH", "Ivan", 4);

            string expectedStatus =
                "Sector 1: 2 / 2 (100% full)\r\n" +
                "Sector 2: 2 / 2 (100% full)";

            // Act
            this.vehiclePark.InsertCar(firstCar, 1, 1, DateTime.Now); this.vehiclePark.InsertCar(secondCar, 1, 2, DateTime.Now);
            this.vehiclePark.InsertTruck(truck, 2, 1, DateTime.Now); this.vehiclePark.InsertMotorbike(motorbike, 2, 2, DateTime.Now);

            var parkStatus = this.vehiclePark.GetStatus();

            // Assert
            Assert.AreEqual(expectedStatus, parkStatus);
        }
    }
}