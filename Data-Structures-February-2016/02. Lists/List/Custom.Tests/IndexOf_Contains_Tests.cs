namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexOf_Contains_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void IndexOf_Element_ShoudlReturnCorrectIndex()
        {
            // Arrange
            int elementAdded = 5;

            // Act
            this.customList.Add(elementAdded);
            int elementIndex = this.customList.IndexOf(elementAdded);

            // Assert
            Assert.AreEqual(0, elementIndex, "The returned index is incorrect.");
        }

        [TestMethod]
        public void IndexOf_UexistingElement_ShoudlReturnMinusOne()
        {
            // Ac
            int elementIndex = this.customList.IndexOf(5);

            // Assert
            Assert.AreEqual(-1, elementIndex, "The returned index is incorrect.");
        }

        [TestMethod]
        public void Contains_Element_ShoudlReturnTrue()
        {
            // Arrange
            int elementAdded = 5;

            // Act
            this.customList.Add(elementAdded);
            bool containsElement = this.customList.Contains(elementAdded);

            // Assert
            Assert.IsTrue(containsElement, "The list cannot find existing elements.");
        }

        [TestMethod]
        public void Contains_UexistingElement_ShoudlReturnFalse()
        {
            // Act
            bool containsElement = this.customList.Contains(5);

            // Assert
            Assert.IsFalse(containsElement);
        }
    }
}