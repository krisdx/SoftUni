namespace ReversedListTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Indexation_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void TestIndex_ShouldGetValueCorrectly()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.reversedList.Add(addedElement);

            // Assert
            var actualElemnt = this.reversedList[0];
            Assert.AreEqual(addedElement, actualElemnt, "The list is not returning the right element.");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_SmallerThanZeroIndex_ShouldThrow()
        {
            // Act
            // Assert
            var element = this.reversedList[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Test_LargerThanCountIndex_ShouldThrow()
        {
            // Act
            this.reversedList.Add(1);

            // Assert
            var element = this.reversedList[50];
        }
    }
}
