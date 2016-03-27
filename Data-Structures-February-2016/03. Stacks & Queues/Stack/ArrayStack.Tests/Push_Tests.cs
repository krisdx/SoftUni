using System;

namespace ArrayStack.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Push_Tests
    {
        private ArrayStack<int> arrayStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.arrayStack = new ArrayStack<int>();
        }

        [TestMethod]
        public void PushElement_EmptyStack_ShouldPushCorrectly()
        {
            // Arrange
            int pushedElement = 5;

            // Act
            this.arrayStack.Push(pushedElement);

            // Assert
            Assert.AreEqual(1, this.arrayStack.Count);
            Assert.AreEqual(pushedElement, this.arrayStack.Peek());
        }

        [TestMethod]
        public void PushManyElements_ShouldPushAndResizeCorrectly()
        {
            // Act 
            for (int num = 1; num <= 1000; num++)
            {
                this.arrayStack.Push(num);
            }

            // Assert
            Assert.AreEqual(1000, this.arrayStack.Count);
            Assert.AreEqual(1000, this.arrayStack.Peek());
            Assert.IsTrue(this.arrayStack.Capacity > this.arrayStack.Count);
        }

        [TestMethod]
        public void PushManyElements_InitialCapacity1_ShouldResizeCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>(1);

            // Act 
            for (int num = 1; num <= 100000; num++)
            {
                this.arrayStack.Push(num);
            }

            // Assert
            Assert.AreEqual(100000, this.arrayStack.Count);
            Assert.AreEqual(100000, this.arrayStack.Peek());
            Assert.IsTrue(this.arrayStack.Capacity > this.arrayStack.Count);
        }
    }
}