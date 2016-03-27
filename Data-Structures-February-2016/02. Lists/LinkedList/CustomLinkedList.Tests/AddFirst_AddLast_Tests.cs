namespace CustomLinkedList.Tests
{
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddFirst_AddLast_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void AddFirst_EmptyList_ShouldAddCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.customLinkedList.AddFirst(addedElement);

            // Assert
            Assert.AreEqual(1, this.customLinkedList.Count);
            Assert.IsTrue(this.customLinkedList.Contains(addedElement));
            Assert.AreEqual(addedElement, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(addedElement, this.customLinkedList.TailNode.Value);
        }

        [TestMethod]
        public void AddFirst_NonEmptyList_ShouldAddCorrectly()
        {
            // Arrange
            int addedElementsCount = 5;
            int firstElement = 1;

            // Act
            for (int num = 2; num <= addedElementsCount; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            this.customLinkedList.AddFirst(firstElement);

            // Assert
            for (int num = 1; num <= addedElementsCount; num++)
            {
                Assert.IsTrue(this.customLinkedList.Contains(num));
            }

            Assert.AreEqual(addedElementsCount, this.customLinkedList.Count);
            Assert.AreEqual(firstElement, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(addedElementsCount, this.customLinkedList.TailNode.Value);
        }

        [TestMethod]
        public void AddLast_EmptyList_ShouldAddCorrectly()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.customLinkedList.AddLast(addedElement);

            // Arrange
            Assert.AreEqual(1, this.customLinkedList.Count);
            Assert.IsTrue(this.customLinkedList.Contains(addedElement));
            Assert.AreEqual(addedElement, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(addedElement, this.customLinkedList.TailNode.Value);
        }

        [TestMethod]
        public void AddLast_NonEmptyList_ShouldAddCorrectly()
        {
            // Arrange
            int lastElement = 6;

            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            this.customLinkedList.AddLast(lastElement);

            // Arrange
            Assert.AreEqual(6, this.customLinkedList.Count);

            for (int num = 1; num <= 6; num++)
            {
                Assert.IsTrue(this.customLinkedList.Contains(num));
            }

            Assert.AreEqual(lastElement, this.customLinkedList.TailNode.Value);
        }
    }
}