namespace Theatre.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Theatre.Interfaces;
    using Theatre.Data;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListTheatres_Tests
    {
        [TestMethod]
        public void ListTheatres_ShouldRerutnList()
        {
            // Arrange
            IPerformanceDatabase database = new TheatreDatabase();

            // Act
            int theatresAddedCount = 5;
            for (int i = 0; i < theatresAddedCount; i++)
            {
                database.AddTheatre(string.Format("theatre{0}", i));
            }

            var theatresList = database.ListTheatres().ToList();

            // Assert
            for (int i = 0; i < theatresAddedCount; i++)
            {
                var expectedValue = string.Format("theatre{0}", i);
                Assert.AreEqual(expectedValue, theatresList[i], "The database is not returning the same elements, that have been added.");
            }

            // Assert.AreEqual(theatresAddedCount, theatresList.Count, "Incorrect count.");
        }

        [TestMethod]
        public void ListTheatres_EmptyList_ShouldRerutnList()
        {
            // Arrange
            IPerformanceDatabase database = new TheatreDatabase();
            var expectedList = new List<string>();

            // Act
            var theatresList = database.ListTheatres().ToList();

            // Assert
            CollectionAssert.AreEqual(expectedList, theatresList);

            // Assert.AreEqual(expectedList.Count, theatresList.Count, "Incorrect count.");
        }
    }
}