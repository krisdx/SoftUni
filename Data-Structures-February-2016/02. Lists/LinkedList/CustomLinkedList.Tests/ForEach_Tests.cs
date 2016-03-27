namespace CustomLinkedList.Tests
{
    using System.Collections.Generic;
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ForEach_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void ForEach_EmptyList_ShouldEnumerateElementsCorrectly()
        {
            // Act
            var items = new List<int>();
            this.customLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>());
        }

        [TestMethod]
        public void ForEach_SingleElement_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            this.customLinkedList.AddLast(5);

            // Act
            var items = new List<int>();
            this.customLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items, new List<int>() { 5 });
        }

        [TestMethod]
        public void ForEach_MultipleElements_ShouldEnumerateElementsCorrectly()
        {
            // Arrange
            this.customLinkedList.AddLast(5);
            this.customLinkedList.AddLast(6);
            this.customLinkedList.AddLast(7);

            // Act
            var items = new List<int>();
            this.customLinkedList.ForEach(items.Add);

            // Assert
            CollectionAssert.AreEqual(items,
                new List<int>() { 5, 6, 7 });
        }
    }
}