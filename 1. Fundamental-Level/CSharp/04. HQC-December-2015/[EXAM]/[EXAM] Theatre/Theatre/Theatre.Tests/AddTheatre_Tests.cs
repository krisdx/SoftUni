namespace Theatre.Tests
{
    using System.Linq;

    using Theatre.Data;
    using Theatre.Exceptions;
    using Theatre.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddTheatre_Tests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeParams()
        {
            this.database = new TheatreDatabase();
        }

        [TestMethod]
        public void AddTheatre_ShouldAdd()
        {
            // Arrange
            string theatreName = "Theatre";

            // Act
            this.database.AddTheatre(theatreName);

            var theatresList = this.database.ListTheatres().ToList();

            // Assert
            Assert.AreEqual(theatreName, theatresList[0], "The databese is not adding theatres.");
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateTheatreException))]
        public void AddTheatre_Twice_ShouldThrow()
        {
            // Arrange
            string theatreName = "Theatre";

            // Act
            this.database.AddTheatre(theatreName);
            this.database.AddTheatre(theatreName);
        }
    }
}