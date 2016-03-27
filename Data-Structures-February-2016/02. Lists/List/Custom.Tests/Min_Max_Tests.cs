namespace CustomList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Min_Max_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void MinElement_ShouldReturnCorrectElement()
        {
            // Arrange
            int minElement = 1;

            // Act
            this.customList.Add(minElement);
            this.customList.Add(2);
            this.customList.Add(3);

            var actualElement = this.customList.Min();

            // Assert
            Assert.AreEqual(minElement, actualElement);
        }

        [TestMethod]
        public void MinElement_EqualElements_ShouldReturnTheCorrectElement()
        { // Arrange
            int minElement = 2;

            // Act
            this.customList.Add(2);
            this.customList.Add(2);
            this.customList.Add(2);

            var actualElement = this.customList.Min();

            // Assert
            Assert.AreEqual(minElement, actualElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinElement_EmptyList_ShouldThrow()
        {
            // Act & Assert
          this.customList.Min();
        }

        [TestMethod]
        public void MaxElement_ShouldReturnCorrectElement()
        {
            // Arrange
            int maxElement = 5;

            // Act
            this.customList.Add(1);
            this.customList.Add(2);
            this.customList.Add(maxElement);

            var actualElement = this.customList.Max();

            // Assert
            Assert.AreEqual(maxElement, actualElement);
        }

        [TestMethod]
        public void MaxElement_EqualElements_ShouldReturnTheCorrectElement()
        { // Arrange
            int maxElement = 5;

            // Act
            this.customList.Add(maxElement);
            this.customList.Add(maxElement);
            this.customList.Add(maxElement);

            var actualElement = this.customList.Max();

            // Assert
            Assert.AreEqual(maxElement, actualElement);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaxElement_EmptyList_ShouldThrow()
        {
            // Act & Assert
            this.customList.Max();
        }
    }
}