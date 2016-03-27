namespace CustomLinkedList.Tests
{
    using LinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Remove_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void RemoveOneElement_ShouldRemoveCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.customLinkedList.AddLast(addedElement);

            bool hasRemoved = this.customLinkedList.Remove(addedElement);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.IsFalse(this.customLinkedList.Contains(addedElement));
            Assert.AreEqual(0, this.customLinkedList.Count);
            Assert.IsNull(this.customLinkedList.HeadNode);
            Assert.IsNull(this.customLinkedList.TailNode);
        }

        [TestMethod]
        public void RemoveLastElement_ShouldRemoveAndChangeTail()
        {
            // Arrange
            int elementToRemove = 11;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            this.customLinkedList.AddLast(elementToRemove);

            bool hasRemoved = this.customLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.IsFalse(this.customLinkedList.Contains(elementToRemove));
            Assert.AreEqual(10, this.customLinkedList.TailNode.Value);
            Assert.AreEqual(10, this.customLinkedList.Count);
        }

        [TestMethod]
        public void RemoveHeadElement_ShouldRemoveAndChangeHead()
        {
            // Arrange
            int elementToRemove = 1;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customLinkedList.AddLast(num);
            }
            
            bool hasRemoved = this.customLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            Assert.AreEqual(2, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(9, this.customLinkedList.Count);
        }

        [TestMethod]
        public void RemoveElement_AtTheMiddleOfTheList_ShouldRemoveCorrectly()
        {
            // Arrange
            int elementToRemove = 5;

            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            bool hasRemoved = this.customLinkedList.Remove(elementToRemove);

            // Assert
            Assert.IsTrue(hasRemoved);
            for (int num = 1; num <= 10; num++)
            {
                if (num == elementToRemove)
                {
                    Assert.IsFalse(this.customLinkedList.Contains(elementToRemove));
                    continue;
                }

                Assert.IsTrue(this.customLinkedList.Contains(num));
            }

            Assert.AreEqual(9, this.customLinkedList.Count);
        }
    }
}