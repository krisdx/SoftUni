namespace BinarySearchTree.Tests
{
    using BinaryTree;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// In all test for removing node with two children are made of swapping the node that has to be removed with the biggest node int the lest subtree.
    /// </summary>
    [TestClass]
    public class Remove_Tests
    {
        private BinarySearchTree<int> binarySearchTree;

        [TestInitialize]
        public void Initialize()
        {
            this.binarySearchTree = new BinarySearchTree<int>();
        }

        // Tests for removing nodes with two children
        [TestMethod]
        public void RemoveNodeWithTwoChildren_ShouldRemoveCorrectly()
        {
            // 10   ->   10
            //   15        13
            //  13 20        20

            // Act
            this.binarySearchTree.Insert(10);
            this.binarySearchTree.Insert(15);
            this.binarySearchTree.Insert(13);
            this.binarySearchTree.Insert(20);

            bool hasRemoved = this.binarySearchTree.Remove(15);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(15));

            Assert.AreEqual(13, this.binarySearchTree.Root.RightChild.Value);
            Assert.AreEqual(null, this.binarySearchTree.Root.LeftChild);

            Assert.AreEqual(20, this.binarySearchTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void RemoveNodeWithTwoChildren_InBiggerTree_ShouldRemoveCorrectly()
        {
            ////  20      ->   20
            ////    25           22
            ////  22 30         21 30
            //// 21   50            50

            // Act
            this.binarySearchTree.Insert(20);
            this.binarySearchTree.Insert(25);
            this.binarySearchTree.Insert(22);
            this.binarySearchTree.Insert(21);
            this.binarySearchTree.Insert(30);
            this.binarySearchTree.Insert(50);

            bool hasRemoved = this.binarySearchTree.Remove(25);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(25));

            Assert.AreEqual(22, this.binarySearchTree.Root.RightChild.Value);
            Assert.AreEqual(21, this.binarySearchTree.Root.RightChild.LeftChild.Value);
            Assert.AreEqual(30, this.binarySearchTree.Root.RightChild.RightChild.Value);
        }

        [TestMethod]
        public void RemoveRootNodeWithTwoChildren_ShouldChangeRoot()
        {
            ////  5   ->   4
            //// 4 6      -  6
            
            // Act
            this.binarySearchTree.Insert(5);
            this.binarySearchTree.Insert(4);
            this.binarySearchTree.Insert(6);

            bool hasRemoved = this.binarySearchTree.Remove(5);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(5));

            Assert.AreEqual(4, this.binarySearchTree.Root.Value);
            Assert.AreEqual(6, this.binarySearchTree.Root.RightChild.Value);
            Assert.AreEqual(null, this.binarySearchTree.Root.LeftChild);
        }

        [TestMethod]
        public void RemoveRootNodeWithTwoChildren_InBiggerTree_ShouldRemoveCorrectly()
        {
           ////       20           ->      15
           ////   10      30            10    30
           ////  5  15   25 35         5     25 35
           //// 4 6           50      4 6        50

            // Act
            this.binarySearchTree.Insert(20);
            this.binarySearchTree.Insert(10);
            this.binarySearchTree.Insert(15);
            this.binarySearchTree.Insert(5);
            this.binarySearchTree.Insert(4);
            this.binarySearchTree.Insert(6);
            this.binarySearchTree.Insert(30);
            this.binarySearchTree.Insert(25);
            this.binarySearchTree.Insert(35);
            this.binarySearchTree.Insert(50);

            bool hasRemoved = this.binarySearchTree.Remove(20);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(20));

            Assert.AreEqual(15, this.binarySearchTree.Root.Value);
            Assert.AreEqual(10, this.binarySearchTree.Root.LeftChild.Value);
            Assert.AreEqual(null, this.binarySearchTree.Root.LeftChild.RightChild);
        }

        // Tests for removing nodes with one child
        [TestMethod]
        public void RemoveNodeWithOneChild_ShouldRemoveCorrectly()
        {
           //// 5   ->  5
           ////  6       7
           ////   7

            // Act
            this.binarySearchTree.Insert(5);
            this.binarySearchTree.Insert(6);
            this.binarySearchTree.Insert(7);

            bool hasRemoved = this.binarySearchTree.Remove(6);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(6));

            Assert.AreEqual(7, this.binarySearchTree.Root.RightChild.Value);

            Assert.AreEqual(null, this.binarySearchTree.Root.RightChild.LeftChild);
            Assert.AreEqual(null, this.binarySearchTree.Root.RightChild.RightChild);
        }

        [TestMethod]
        public void RemoveRootNodeWithOneChild_ShouldChangeRoot()
        {
            // 5   ->  6
            //  6       7
            //   7

            // Act
            this.binarySearchTree.Insert(5);
            this.binarySearchTree.Insert(6);
            this.binarySearchTree.Insert(7);

            bool hasRemoved = this.binarySearchTree.Remove(5);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(5));

            Assert.AreEqual(6, this.binarySearchTree.Root.Value);

            Assert.AreEqual(7, this.binarySearchTree.Root.RightChild.Value);

            Assert.AreEqual(null, this.binarySearchTree.Root.RightChild.LeftChild);
            Assert.AreEqual(null, this.binarySearchTree.Root.RightChild.RightChild);
        }

        [TestMethod]
        public void RemoveLeafNode_ShouldRemoveCorrectly()
        {
            // 5   ->  5
            //  6       
            
            // Act
            this.binarySearchTree.Insert(5);
            this.binarySearchTree.Insert(6);

            bool hasRemoved = this.binarySearchTree.Remove(6);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(6));

            Assert.AreEqual(5, this.binarySearchTree.Root.Value);
            
            Assert.AreEqual(null, this.binarySearchTree.Root.LeftChild);
            Assert.AreEqual(null, this.binarySearchTree.Root.RightChild);
        }

        [TestMethod]
        public void RemoveLeafRootNode_ShouldRemoveTreTree()
        {
            // 5   ->   

            // Act
            this.binarySearchTree.Insert(5);

            bool hasRemoved = this.binarySearchTree.Remove(5);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(null, this.binarySearchTree.Find(5));

            Assert.AreEqual(null, this.binarySearchTree.Root);
        }
    }
}