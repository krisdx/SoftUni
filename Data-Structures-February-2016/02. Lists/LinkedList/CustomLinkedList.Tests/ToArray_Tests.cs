namespace CustomLinkedList.Tests
{
    using System.Collections.Generic;
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToArray_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void ToArray_EmptyList_ShouldReturnEmptyArray()
        {
            // Act
            var arr = this.customLinkedList.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr, new List<string>());
        }

        [TestMethod]
        public void ToArray_NonEmptyList_ShouldReturnArray()
        {
            // Arrange
            this.customLinkedList.AddLast(5);
            this.customLinkedList.AddLast(6);
            this.customLinkedList.AddLast(7);

            // Act
            var arr = this.customLinkedList.ToArray();

            // Assert
            CollectionAssert.AreEqual(arr,
                new int[] { 5, 6, 7 });
        }
    }
}