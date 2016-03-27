namespace DoublyLinkedList.Tests
{
    using System.Collections.Generic;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ForEach_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Act
            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>());
        }

        [TestMethod]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            this.doublyLinkedList.AddLast(5);

            // Act
            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            this.doublyLinkedList.AddLast(5);
            this.doublyLinkedList.AddLast(6);
            this.doublyLinkedList.AddLast(7);

            // Act
            var items = new List<int>();
            this.doublyLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items,
                new List<int>() { 5, 6, 7 });
        }
    }
}