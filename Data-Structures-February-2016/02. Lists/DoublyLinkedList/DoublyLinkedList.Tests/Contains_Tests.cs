namespace DoublyLinkedList.Tests
{
    using DoubleLinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Contains_Tests
    {
        private DoublyLinkedList<int> doublyLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.doublyLinkedList = new DoublyLinkedList<int>();
        }

        [TestMethod]
        public void Contains_Element_ShoudReturnTrue()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.doublyLinkedList.AddLast(addedElement);

            bool containsNum = this.doublyLinkedList.Contains(addedElement);

            // Assert
            Assert.IsTrue(containsNum);
        }

        [TestMethod]
        public void Contains_NonExistingElement_ShoudReturnFalse()
        {
            // Assert
            Assert.IsFalse(this.doublyLinkedList.Contains(1));
            Assert.IsFalse(this.doublyLinkedList.Contains(200));
            Assert.IsFalse(this.doublyLinkedList.Contains(-517));
            Assert.IsFalse(this.doublyLinkedList.Contains(0));
        }
    }
}