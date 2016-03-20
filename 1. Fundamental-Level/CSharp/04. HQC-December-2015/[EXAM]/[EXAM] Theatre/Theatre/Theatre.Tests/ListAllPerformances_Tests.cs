namespace Theatre.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Data;
    using Theatre.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListAllPerformances_Tests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeParams()
        {
            this.database = new TheatreDatabase();
        }

        [TestMethod]
        public void ListAllPerformances_ShouldReturnList()
        {
            // Arrange
            string theatre = "Theatre";

            // Act
            this.database.AddTheatre(theatre);
            var expectedPerformancesList = new List<IPerformance>
            {
                this.database.AddPerformance(theatre, "Performance1", DateTime.Now, TimeSpan.Zero, 150m),
                this.database.AddPerformance(theatre, "Performance2", DateTime.Now.AddHours(1), TimeSpan.Zero, 150m),
                this.database.AddPerformance(theatre, "Performance3", DateTime.Now.AddHours(2), TimeSpan.Zero, 150m),
            };

            var actualPerformancesList = this.database.ListAllPerformances().ToList();

            // Assert
            CollectionAssert.AreEqual(expectedPerformancesList, actualPerformancesList);
        }

        [TestMethod]
        public void ListAllPerformances_EmptyList_ShouldReturnEmptyList()
        {
            // Arrange
            string theatre = "Theatre";
            var expectedPerformancesList  = new List<IPerformance>();

            // Act
            this.database.AddTheatre(theatre);

            var actualPerformancesList = this.database.ListAllPerformances().ToList();

            // Assert
            CollectionAssert.AreEqual(expectedPerformancesList, actualPerformancesList);
        }
    }
}