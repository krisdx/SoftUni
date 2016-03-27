namespace DoublyLinkedList.Tests
{
    using System;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddAfter_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void AddAfter_OnlyOneElementInList_ShouldAddCorrectly()
        {
            // Arrange
            int firstElementAdded = 1;
            int secondAddedElement = 2;

            // Act
            this.doublyLinkedList.AddLast(firstElementAdded);

            var nodeToAddAfter = this.doublyLinkedList.HeadNode;
            this.doublyLinkedList.AddAfter(nodeToAddAfter, secondAddedElement);

            // Assert
            Assert.AreEqual(firstElementAdded, this.doublyLinkedList.HeadNode.Value);
            Assert.AreEqual(secondAddedElement, this.doublyLinkedList.TailNode.Value);
            Assert.AreEqual(2, this.doublyLinkedList.Count);
        }

        [TestMethod]
        public void AddAfter_ElementInMiddleOfTheList_ShouldAddCorrectly()
        {
            // Act
            this.doublyLinkedList.AddLast(1);
            this.doublyLinkedList.AddLast(2);
            this.doublyLinkedList.AddLast(4);
            this.doublyLinkedList.AddLast(5);

            var nodeToAddAfter = this.doublyLinkedList.HeadNode.NextNode;
            this.doublyLinkedList.AddAfter(nodeToAddAfter, 3);

            // Assert
            for (int num = 1; num <= 5; num++)
            {
                Assert.IsTrue(this.doublyLinkedList.Contains(num));
            }

            Assert.AreEqual(5, this.doublyLinkedList.Count);

            Assert.AreEqual(1, this.doublyLinkedList.HeadNode.Value);
            Assert.AreEqual(5, this.doublyLinkedList.TailNode.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfter_NullHeadNode_ShouldThrow()
        {
            // Act
            var headNode = this.doublyLinkedList.HeadNode;
            this.doublyLinkedList.AddAfter(headNode, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfter_NullTailNode_ShouldThrow()
        {
            // Act
            var headNode = this.doublyLinkedList.TailNode;
            this.doublyLinkedList.AddAfter(headNode, 1);
        }
    }
}