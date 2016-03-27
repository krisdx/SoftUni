namespace DoublyLinkedList.Tests
{
    using System.Collections.Generic;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddFirst_AddLast_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void AddFirst_EmptyList_ShouldAddElement()
        {
            // Act
            this.doublyLinkedList.AddFirst(5);

            // Assert
            Assert.AreEqual(1, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int> { 5 });
        }

        [TestMethod]
        public void AddFirst_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Act
            this.doublyLinkedList.AddFirst(10);
            this.doublyLinkedList.AddFirst(5);
            this.doublyLinkedList.AddFirst(3);

            // Assert
            Assert.AreEqual(3, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 3, 5, 10 });

            Assert.AreEqual(3, this.doublyLinkedList.HeadNode.Value);
        }

        [TestMethod]
        public void AddLast_EmptyList_ShouldAddElement()
        {
            // Act
            this.doublyLinkedList.AddLast(5);

            // Assert
            Assert.AreEqual(1, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void AddLast_SeveralElements_ShouldAddElementsCorrectly()
        {
            // Act
            this.doublyLinkedList.AddLast(5);
            this.doublyLinkedList.AddLast(10);
            this.doublyLinkedList.AddLast(15);

            // Assert
            Assert.AreEqual(3, this.doublyLinkedList.Count);

            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);
            CollectionAssert.AreEqual(items, new List<int>() { 5, 10, 15 });
        }
    }
}