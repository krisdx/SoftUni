namespace DoublyLinkedList.Tests
{
    using System;
    using System.Collections.Generic;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveFirst_RemoveLast_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void RemoveFirst_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            this.doublyLinkedList.AddLast(5);

            // Act
            var element = this.doublyLinkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>());
        }

        [TestMethod]
        public void RemoveFirst_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // Arrange
            this.doublyLinkedList.AddLast(5);
            this.doublyLinkedList.AddLast(6);
            this.doublyLinkedList.AddLast(7);

            // Act
            var removedElement = this.doublyLinkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(5, removedElement);
            Assert.AreEqual(2, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 6, 7 });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirst_EmptyList_ShouldThrowException()
        {
            // Act
            this.doublyLinkedList.RemoveFirst();
        }

        [TestMethod]
        public void RemoveLast_OneElement_ShouldMakeListEmpty()
        {
            // Arrange
            this.doublyLinkedList.AddFirst(5);

            // Act
            var element = this.doublyLinkedList.RemoveLast();

            // Assert
            Assert.AreEqual(5, element);
            Assert.AreEqual(0, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLast_EmptyList_ShouldThrowException()
        {
            // Act
            this.doublyLinkedList.RemoveLast();
        }

        [TestMethod]
        public void RemoveLast_SeveralElements_ShouldRemoveElementsCorrectly()
        {
            // ArrangedoublyLinkedList
            this.doublyLinkedList.AddFirst(10);
            this.doublyLinkedList.AddFirst(9);
            this.doublyLinkedList.AddFirst(8);

            // Act
            var element = this.doublyLinkedList.RemoveLast();

            // Assert
            Assert.AreEqual(10, element);
            Assert.AreEqual(2, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 8, 9 });
        }
    }
}