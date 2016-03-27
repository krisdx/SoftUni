namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class IndexOf_Contains_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void IndexOf_Element_ShoudlReturnCorrectIndex()
        {
            // Arrange
            int elementAdded = 5;

            // Act
            this.reversedList.Add(elementAdded);
            int elementIndex = this.reversedList.IndexOf(elementAdded);

            // Assert
            Assert.AreEqual(0, elementIndex, "The returned index is incorrect.");
        }

        [TestMethod]
        public void IndexOf_UexistingElement_ShoudlReturnMinusOne()
        {
            // Ac
            int elementIndex = this.reversedList.IndexOf(5);

            // Assert
            Assert.AreEqual(-1, elementIndex, "The returned index is incorrect.");
        }

        [TestMethod]
        public void Contains_Element_ShoudlReturnTrue()
        {
            // Arrange
            int elementAdded = 5;

            // Act
            this.reversedList.Add(elementAdded);
            bool containsElement = this.reversedList.Contains(elementAdded);

            // Assert
            Assert.IsTrue(containsElement, "The list cannot find existing elements.");
        }

        [TestMethod]
        public void Contains_UexistingElement_ShoudlReturnFalse()
        {
            // Act
            bool containsElement = this.reversedList.Contains(5);

            // Assert
            Assert.IsFalse(containsElement);
        }
    }
}