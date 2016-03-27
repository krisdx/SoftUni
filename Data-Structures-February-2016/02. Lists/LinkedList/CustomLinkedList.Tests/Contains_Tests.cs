namespace CustomLinkedList.Tests
{
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Contains_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void Contains_Element_ShoudReturnTrue()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.customLinkedList.AddLast(addedElement);

            bool containsNum = this.customLinkedList.Contains(addedElement);

            // Assert
            Assert.IsTrue(containsNum);
        }

        [TestMethod]
        public void Contains_NonExistingElement_ShoudReturnFalse()
        {
            // Assert
            Assert.IsFalse(this.customLinkedList.Contains(1));
            Assert.IsFalse(this.customLinkedList.Contains(200));
            Assert.IsFalse(this.customLinkedList.Contains(-517));
            Assert.IsFalse(this.customLinkedList.Contains(0));
        }
    }
}