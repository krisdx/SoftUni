namespace Theatre.Tests
{

    using System;
    using System.Linq;

    using Theatre.Data;
    using Theatre.Interfaces;
    using Theatre.Exceptions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddPerformance_Tests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeParams()
        {
            this.database = new TheatreDatabase();
        }

        [TestMethod]
        public void AddPerformance_WithCorrectParams_ShouldAddToDatabase()
        {
            // Arrange
            string theatreName = "theatreName";
            string performanceTitle = "performanceTitle";
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            decimal price = 13m;

            // Act
            this.database.AddTheatre(theatreName);
            var performance = this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);

            var performancesList = this.database.ListAllPerformances().ToList();
            var expectedPerformance = performancesList[0];

            // Assert
            Assert.AreEqual(expectedPerformance, performance);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void AddPerformance_AtUnexistingTheatre_ShouldThrow()
        {
            // Arrange
            string theatreName = "theatreName";
            string performanceTitle = "performanceTitle";
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            decimal price = 13m;

            // Act
            var performance = this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void AddPerformance_TimesOverlap_ShouldThrow()
        {
            // Arrange
            string theatreName = "theatreName";
            string performanceTitle = "performanceTitle";
            DateTime startTime = new DateTime(2016, 1, 5, 5, 20, 19);
            TimeSpan duration = new TimeSpan(6, 0, 0);
            decimal price = 13m;

            // Act
            this.database.AddTheatre(theatreName);
            var firstPerformance = this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);

            var secondPerformance = this.database.AddPerformance(theatreName, performanceTitle, startTime.AddHours(1), duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPerformance_WithEmptyTheatreName_ShouldThrow()
        {
            // Arrange
            string theatreName = null;
            string performanceTitle = "performanceTitle";
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            decimal price = 13m;

            // Act
            var performance = this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPerformance_WithEmptyPerformanceName_ShouldThrow()
        {
            // Arrange
            string theatreName = "theatreName";
            string performanceTitle = string.Empty;
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            decimal price = 13m;

            // Act
            this.database.AddTheatre(theatreName);
            var performance = this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddPerformance_WithNegativePrice_ShouldThrow()
        {
            // Arrange
            string theatreName = "theatreName";
            string performanceTitle = "performanceTitle";
            DateTime startTime = DateTime.Now;
            TimeSpan duration = TimeSpan.Zero;
            decimal price = -2.13m;

            // Act
            this.database.AddTheatre(theatreName);
            this.database.AddPerformance(theatreName, performanceTitle, startTime, duration, price);
        }
    }
}