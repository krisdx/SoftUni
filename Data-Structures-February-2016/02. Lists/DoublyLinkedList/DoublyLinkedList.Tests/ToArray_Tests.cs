namespace DoublyLinkedList.Tests
{
    using System.Collections.Generic;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToArray_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Act
            var arr = this.doublyLinkedList.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<string>());
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            this.doublyLinkedList.AddLast(5);
            this.doublyLinkedList.AddLast(6);
            this.doublyLinkedList.AddLast(7);

            // Act
            var arr = this.doublyLinkedList.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new int[] { 5, 6, 7 });
        }
    }
}