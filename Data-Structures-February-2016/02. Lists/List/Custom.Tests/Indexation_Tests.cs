namespace CustomList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Indexation_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void TestIndex_ShouldGetValueCorrectly()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.customList.Add(addedElement);

            // Assert
            var actualElemnt = this.customList[0];
            Assert.AreEqual(addedElement, actualElemnt, "The list is not returning the right element.");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_SmallerThanZeroIndex_ShouldThrow()
        {
            // Act
            // Assert
            var element = this.customList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_LargerThanCountIndex_ShouldThrow()
        {
            // Act
            this.customList.Add(1);

            // Assert
            var element = this.customList[50];
        }
    }
}
