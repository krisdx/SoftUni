namespace CustomLinkedList.Tests
{
    using System;
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddAfter_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void AddAfter_OnlyOneElementInList_ShouldAddCorrectly()
        {
            // Arrange
            int firstElementAdded = 1;
            int secondAddedElement = 2;

            // Act
            this.customLinkedList.AddLast(firstElementAdded);

            var nodeToAddAfter = this.customLinkedList.HeadNode;
            this.customLinkedList.AddAfter(nodeToAddAfter, secondAddedElement);

            // Assert
            Assert.AreEqual(firstElementAdded, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(secondAddedElement, this.customLinkedList.TailNode.Value);
            Assert.AreEqual(2, this.customLinkedList.Count);
        }

        [TestMethod]
        public void AddAfter_ElementInMiddleOfTheList_ShouldAddCorrectly()
        {
            // Act
            this.customLinkedList.AddLast(1);
            this.customLinkedList.AddLast(2);
            this.customLinkedList.AddLast(4);
            this.customLinkedList.AddLast(5);

            var nodeToAddAfter = this.customLinkedList.HeadNode.NextNode;
            this.customLinkedList.AddAfter(nodeToAddAfter, 3);

            // Assert
            for (int num = 1; num <= 5; num++)
            {
                Assert.IsTrue(this.customLinkedList.Contains(num));
            }

            Assert.AreEqual(5, this.customLinkedList.Count);

            Assert.AreEqual(1, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(5, this.customLinkedList.TailNode.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfter_NullHeadNode_ShouldThrow()
        {
            // Act
            var headNode = this.customLinkedList.HeadNode;
            this.customLinkedList.AddAfter(headNode, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAfter_NullTailNode_ShouldThrow()
        {
            // Act
            var headNode = this.customLinkedList.TailNode;
            this.customLinkedList.AddAfter(headNode, 1);
        }
    }
}