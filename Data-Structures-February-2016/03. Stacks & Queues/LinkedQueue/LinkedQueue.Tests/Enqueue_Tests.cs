namespace LinkedQueue.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Enqueue_Tests
    {
        private LinkedQueue<int> linkedQueue;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedQueue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void EnqueueElement_ShouldEnqueueCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedQueue.Enqueue(addedElement);

            // Assert
            Assert.AreEqual(1, this.linkedQueue.Count);
            Assert.AreEqual(addedElement, this.linkedQueue.Peek());
        }

        [TestMethod]
        public void EnqueueElement_HeadAndTailShouldPointToElement()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedQueue.Enqueue(addedElement);

            // Assert
            Assert.AreEqual(1, this.linkedQueue.Count);
            Assert.AreEqual(addedElement, this.linkedQueue.HeadNode.Value);
            Assert.AreEqual(addedElement, this.linkedQueue.TailNode.Value);
        }

        [TestMethod]
        public void EnqueueManyElement_ShouldEnqueueCorrectly()
        {
            // Act & Assert
            for (int count = 1; count <= 100000; count++)
            {
                this.linkedQueue.Enqueue(count);
                Assert.AreEqual(count, this.linkedQueue.Count);
                Assert.AreEqual(count, this.linkedQueue.TailNode.Value);
            }
        }
    }
}