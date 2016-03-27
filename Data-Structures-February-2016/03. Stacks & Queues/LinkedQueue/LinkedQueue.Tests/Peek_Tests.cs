namespace LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Peek_Tests
    {
        private LinkedQueue<int> linkedQueue;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedQueue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void Peek_NonEmptyQueue_ShouldReturnCorrectElement()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedQueue.Enqueue(addedElement);

            // Assert
            Assert.AreEqual(addedElement, this.linkedQueue.Peek());
        }

        [TestMethod]
        public void PushManyElements_PeekShouldReturnTheCorrectElement()
        {
            // Act & Assert
            for (int num = 1; num <= 100; num++)
            {
                this.linkedQueue.Enqueue(num);
                Assert.AreEqual(1, this.linkedQueue.Peek());
            }
        }

        [TestMethod]
        public void PeekManyTimes_ShouldReturnTheCorrectElement()
        {
            // Act & Assert
            this.linkedQueue.Enqueue(1);
            Assert.AreEqual(1, this.linkedQueue.Peek());

            this.linkedQueue.Enqueue(2);
            Assert.AreEqual(1, this.linkedQueue.Peek());

            this.linkedQueue.Dequeue();
            Assert.AreEqual(2, this.linkedQueue.Peek());

            this.linkedQueue.Enqueue(1);
            Assert.AreEqual(2, this.linkedQueue.Peek());

            this.linkedQueue.Dequeue();
            Assert.AreEqual(1, this.linkedQueue.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyQueue_ShouldThrow()
        {
            // Act
            this.linkedQueue.Peek();
        }
    }
}