namespace CustomLinkedList.Tests
{
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirstIndexOf_LastIndexOf_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void FirstIndexOfElement_ShouldReturnCorrectIndex()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.customLinkedList.AddLast(addedElement);

            int index = this.customLinkedList.FirstIndexOf(addedElement);

            // Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void FirstIndexOfNonExistingElement_ShouldReturnMinusOne()
        {
            // Act
            int index = this.customLinkedList.FirstIndexOf(-517);

            // Assert
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LastIndexOfElement_ShouldReturnCorrectIndex()
        {
            // Arrange
            int element = 5;

            // Act
            for (int i = 0; i < 5; i++)
            {
                this.customLinkedList.AddLast(element);
            }

            int index = this.customLinkedList.LastIndexOf(element);

            // Assert
            Assert.AreEqual(4, index);
        }

        [TestMethod]
        public void LastIndexOfNonExistingElement_ShouldReturnMinusOne()
        {
            // Act
            int index = this.customLinkedList.LastIndexOf(-517);

            // Assert
            Assert.AreEqual(-1, index);
        }
    }
}