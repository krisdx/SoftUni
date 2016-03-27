namespace BinarySearchTree.Tests
{
    using System;
    using System.Diagnostics;
    using BinaryTree;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Insert_Tests
    {
        private BinarySearchTree<int> binarySearchTree;

        [TestInitialize]
        public void Initialize()
        {
            this.binarySearchTree = new BinarySearchTree<int>();
        }

        [TestMethod]
        public void InsertNode_ShouldInsertCorrectly()
        {
            // Arrange
            int rootElement = 5;

            // Act
            this.binarySearchTree.Insert(rootElement);
            this.binarySearchTree.Insert(6);

            // Assert
            Assert.AreEqual(rootElement, this.binarySearchTree.Find(rootElement).Value);
            Assert.AreEqual(rootElement, this.binarySearchTree.Root.Value);

            Assert.IsNotNull(this.binarySearchTree.Find(6));
            Assert.AreEqual(6, this.binarySearchTree.Root.RightChild.Value);
        }

        [TestMethod]
        public void InsertOnlyBiggerThanRootNodes_ShouldInsertOnlyOnRightSubtree()
        {
            // Arrange
            int rootElement = 5;

            // Act
            for (int element = rootElement; element <= 15; element++)
            {
                this.binarySearchTree.Insert(element);
            }

            // Assert
            Assert.AreEqual(rootElement, this.binarySearchTree.Find(rootElement).Value);
            Assert.AreEqual(rootElement, this.binarySearchTree.Root.Value);

            var currentNode = this.binarySearchTree.Root;
            int expectedNum = rootElement;
            while (currentNode != null)
            {
                Assert.AreEqual(expectedNum, currentNode.Value);
                expectedNum++;

                currentNode = currentNode.RightChild;
            }
        }

        [TestMethod]
        public void InsertOnlySmallerThanRootNodes_ShouldInsertOnlyOnLeftSubtree()
        {
            // Arrange
            int rootElement = 15;

            // Act
            for (int element = rootElement; element >= 1; element--)
            {
                this.binarySearchTree.Insert(element);
            }

            // Assert
            Assert.AreEqual(rootElement, this.binarySearchTree.Find(rootElement).Value);
            Assert.AreEqual(rootElement, this.binarySearchTree.Root.Value);

            var currentNode = this.binarySearchTree.Root;
            int expectedNum = rootElement;
            while (currentNode != null)
            {
                Assert.AreEqual(expectedNum, currentNode.Value);
                expectedNum--;

                currentNode = currentNode.LeftChild;
            }
        }

        [TestMethod]
        public void InsertNodeInEmptyTree_ShouldChangeRoot()
        {
            // Arrange
            int rootElement = 5;

            // Act
            this.binarySearchTree.Insert(rootElement);

            // Assert
            Assert.AreEqual(rootElement, this.binarySearchTree.Find(rootElement).Value);
            Assert.AreEqual(rootElement, this.binarySearchTree.Root.Value);
        }

        [TestMethod]
        public void InsertMultipleNodes_TheTreeShouldStaySorted()
        {
            // Arrange
            var randomGenerator = new Random();

            // Act
            for (int i = 0; i < 100; i++)
            {
                int element = randomGenerator.Next(1, 1000);
                this.binarySearchTree.Insert(element);
            }

            // Assert

            // All elements in the left subtree must be smaller.
            int expectedElement = this.binarySearchTree.Root.Value;
            if (this.binarySearchTree.Root.LeftChild != null)
            {
                var currentNode = this.binarySearchTree.Root.LeftChild;
                while (currentNode != null)
                {
                    Assert.IsTrue(expectedElement > currentNode.Value);
                    if (currentNode.RightChild != null)
                    {
                        Assert.IsTrue(expectedElement > currentNode.RightChild.Value);
                    }

                    currentNode = currentNode.LeftChild;
                }
            }

            // All elements in the right subtree must be bigger.
            expectedElement = this.binarySearchTree.Root.Value;
            if (this.binarySearchTree.Root.RightChild != null)
            {
                var currentNode = this.binarySearchTree.Root.RightChild;
                while (currentNode != null)
                {
                    Assert.IsTrue(expectedElement <= currentNode.Value);
                    if (currentNode.LeftChild != null)
                    {
                        Assert.IsTrue(expectedElement <= currentNode.LeftChild.Value);
                    }

                    currentNode = currentNode.RightChild;
                }
            }
        }
    }
}