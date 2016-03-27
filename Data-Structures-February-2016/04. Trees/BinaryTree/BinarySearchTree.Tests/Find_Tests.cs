namespace BinarySearchTree.Tests
{
    using BinaryTree;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Find_Tests
    {
        private BinarySearchTree<int> binarySearchTree;

        [TestInitialize]
        public void Initialize()
        {
            this.binarySearchTree = new BinarySearchTree<int>();
        }

        [TestMethod]
        public void FindElement_ShouldFind()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.binarySearchTree.Insert(addedElement);

            // Assert
            var actulaElement = this.binarySearchTree.Find(5);

            Assert.AreEqual(addedElement, actulaElement.Value);
        }

        [TestMethod]
        public void FindUnExistingElement_ShouldReturnNull()
        {
            // Assert
            var actulaElement = this.binarySearchTree.Find(5);

            Assert.AreEqual(null, actulaElement);
        }
    }
}