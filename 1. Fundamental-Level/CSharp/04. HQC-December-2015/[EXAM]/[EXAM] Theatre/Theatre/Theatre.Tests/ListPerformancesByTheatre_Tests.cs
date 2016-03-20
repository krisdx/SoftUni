namespace Theatre.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Data;
    using Theatre.Exceptions;
    using Theatre.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListPerformancesByTheatre_Tests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void Initialize()
        {
            this.database = new TheatreDatabase();
        }

        [TestMethod]
        public void ListPerformances_ShouldReturnPerformances()
        {
            // Assert
            string theatreName = "theatre";
            int numberOfTheatresAdded = 3;

            this.database.AddTheatre(theatreName);
            var performancesAdded = new IPerformance[]
            {
                this.database.AddPerformance(theatreName, "performance1", DateTime.Now, TimeSpan.Zero, 1m),
                this.database.AddPerformance(theatreName, "performance2", DateTime.Now.AddDays(1), TimeSpan.Zero, 2m),
                this.database.AddPerformance(theatreName, "performance3", DateTime.Now.AddDays(2), TimeSpan.Zero, 3m)
            };

            // Act
            var actualPerformances = this.database.ListPerformances(theatreName).ToList();

            // Assert
            for (int i = 0; i < numberOfTheatresAdded; i++)
            {
                Assert.AreEqual(performancesAdded[i], actualPerformances[i]);
            }

            Assert.AreEqual(numberOfTheatresAdded, actualPerformances.Count, "The count of the list is incorrect");
        }

        [TestMethod]
        public void ListPerformances_EmptyList_ShouldShouldReturnEmptyList()
        {
            // Assert
            string theatreName = "theatre";
            var expectedList = new List<string>();

            // Act
            this.database.AddTheatre(theatreName);
            var actualList = this.database.ListPerformances(theatreName).ToList();

            CollectionAssert.AreEqual(expectedList, actualList);
            Assert.AreEqual(expectedList.Count, actualList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void ListPerformances_UnExistingTheatre_ShouldThrow()
        {
            this.database.ListPerformances("theatre");
        }
    }
}