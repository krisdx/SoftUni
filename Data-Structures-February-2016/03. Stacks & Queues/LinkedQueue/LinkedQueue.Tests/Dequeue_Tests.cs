namespace LinkedQueue.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Dequeue_Tests
    {
        private LinkedQueue<int> linkedQueue;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedQueue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void DequeueElement_ShouldDequeueCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedQueue.Enqueue(addedElement);

            var dequeuedElement = this.linkedQueue.Dequeue();

            // Assert
            Assert.AreEqual(addedElement, dequeuedElement);
            Assert.AreEqual(0, this.linkedQueue.Count);
        }

        [TestMethod]
        public void DequeueElement_HeadAndTailShouldBeNull()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedQueue.Enqueue(addedElement);
            this.linkedQueue.Dequeue();

            // Assert
            Assert.AreEqual(0, this.linkedQueue.Count);
            Assert.IsNull(this.linkedQueue.HeadNode);
            Assert.IsNull(this.linkedQueue.TailNode);
        }

        [TestMethod]
        public void DequeueManyElements_ShouldDequeueCorrectly()
        {
            // Act
            for (int num = 1; num <= 1000; num++)
            {
                this.linkedQueue.Enqueue(num);
            }

            // Assert
            Assert.AreEqual(1000, this.linkedQueue.Count);
            Assert.AreEqual(1, this.linkedQueue.HeadNode.Value);
            Assert.AreEqual(1000, this.linkedQueue.TailNode.Value);

            for (int num = 1; num <= 1000; num++)
            {
                Assert.AreEqual(num, this.linkedQueue.Dequeue());
            }

            Assert.AreEqual(0, this.linkedQueue.Count);
            Assert.IsNull(this.linkedQueue.HeadNode);
            Assert.IsNull(this.linkedQueue.TailNode);
        }
    }
}