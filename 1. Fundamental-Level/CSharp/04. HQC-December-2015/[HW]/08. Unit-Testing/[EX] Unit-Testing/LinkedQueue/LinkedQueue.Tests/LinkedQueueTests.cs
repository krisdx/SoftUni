namespace LinkedQueue.Tests
{
    using System;

    using _01.LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void Enqueue_String_ShouldReturnSameString()
        {
            var linkedQueue = new LinkedQueue<string>();

            string enqueuedElement = "Test";
            linkedQueue.Enqueue(enqueuedElement);

            string dequeuedElement = linkedQueue.Dequeue();

            Assert.AreEqual(enqueuedElement, dequeuedElement, "The dequeued element is not the same as the enqueued.");
        }

        [TestMethod]
        public void Enqueue_SeveralElement_ShouldReturnSameElements()
        {
            var linkedQueue = new LinkedQueue<int>();
            
            for (int num = 1; num <= 10; num++)
            {
                linkedQueue.Enqueue(num);
            }

            // Asserting that the enqueued elements are the same as the dequeued.
            for (int num = 1; num <= 10; num++)
            {
                int expectedElement = num;
                int actualElement = linkedQueue.Dequeue();

                Assert.AreEqual(expectedElement, actualElement, "The dequeued element is not the same as the enqueued.");
            }
        }

        [TestMethod]
        public void Enqueue_SeveralElements_CounterShouldIncrease()
        {
            var linkedQueue = new LinkedQueue<int>();

            int couter = 0;
            for (int num = 1; num <= 5; num++)
            {
                linkedQueue.Enqueue(num);
                couter++;
            }

            Assert.AreEqual(couter, linkedQueue.Count, "The count of the linked queue is not increasing.");
        }

        [TestMethod]
        public void EnqueueAndDequeue_SeveralElements_CounterShouldChange()
        {
            var linkedQueue = new LinkedQueue<int>();

            int couter = 0;
            for (int i = 1; i <= 5; i++)
            {
                linkedQueue.Enqueue(i);
                couter++;
            }

            for (int i = 5; i >= 1; i--)
            {
                linkedQueue.Dequeue();
                couter--;
            }

            Assert.AreEqual(couter, linkedQueue.Count, "The count of the linked queue is not changing.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Dequeue_EmptyQueue_ShouldThrow()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Dequeue();
        }
    }
}