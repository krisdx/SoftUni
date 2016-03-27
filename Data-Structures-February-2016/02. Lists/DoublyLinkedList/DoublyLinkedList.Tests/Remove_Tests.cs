namespace DoublyLinkedList.Tests
{
    using DoubleLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Remove_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void RemoveOneElement_ShouldRemoveCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.doublyLinkedList.AddLast(addedElement);

            bool hasRemoved = this.doublyLinkedList.Remove(addedElement);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.IsFalse(this.doublyLinkedList.Contains(addedElement));
            Assert.AreEqual(0, this.doublyLinkedList.Count);
            Assert.IsNull(this.doublyLinkedList.HeadNode);
            Assert.IsNull(this.doublyLinkedList.TailNode);
        }

        [TestMethod]
        public void RemoveLastElement_ShouldRemoveAndChangeTail()
        {
            // Arrange
            int elementToRemove = 11;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.doublyLinkedList.AddLast(num);
            }

            this.doublyLinkedList.AddLast(elementToRemove);

            bool hasRemoved = this.doublyLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.IsFalse(this.doublyLinkedList.Contains(elementToRemove));
            Assert.AreEqual(10, this.doublyLinkedList.TailNode.Value);
            Assert.AreEqual(10, this.doublyLinkedList.Count);
        }

        [TestMethod]
        public void RemoveHeadElement_ShouldRemoveAndChangeHead()
        {
            // Arrange
            int elementToRemove = 1;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.doublyLinkedList.AddLast(num);
            }

            bool hasRemoved = this.doublyLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(2, this.doublyLinkedList.HeadNode.Value);
            Assert.AreEqual(9, this.doublyLinkedList.Count);
        }

        [TestMethod]
        public void RemoveElement_AtTheMiddleOfTheList_ShouldRemoveCorrectly()
        {
            // Arrange
            int elementToRemove = 5;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.doublyLinkedList.AddLast(num);
            }

            bool hasRemoved = this.doublyLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            for (int num = 1; num <= 10; num++)
            {
                if (num == elementToRemove)
                {
                    Assert.IsFalse(this.doublyLinkedList.Contains(elementToRemove));
                    continue;
                }

                Assert.IsTrue(this.doublyLinkedList.Contains(num));
            }

            Assert.AreEqual(9, this.doublyLinkedList.Count);
        }
    }
}