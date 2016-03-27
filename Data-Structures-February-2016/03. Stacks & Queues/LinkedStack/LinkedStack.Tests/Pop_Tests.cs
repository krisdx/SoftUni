namespace LinkedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Pop_Tests
    {
        private LinkedStack<int> linkedStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedStack = new LinkedStack<int>();
        }

        [TestMethod]
        public void PopElement_NonEmptyStack_ShouldPopCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.linkedStack.Push(addedElement);
            var popedElement = this.linkedStack.Pop();

            // Assert
            Assert.AreEqual(addedElement, popedElement);
            Assert.AreEqual(0, this.linkedStack.Count);
            Assert.IsNull(this.linkedStack.HeadNode);
            Assert.IsNull(this.linkedStack.TailNode);
        }

        [TestMethod]
        public void PopManyElements_NonEmptyStack_ShouldPopCorrectly()
        {
            // Act
            for (int num = 1; num <= 100; num++)
            {
                this.linkedStack.Push(num);
            }

            // Assert
            for (int num = 100; num > 0; num--)
            {
                Assert.AreEqual(num, this.linkedStack.Pop());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopElement_EmptyStack_ShouldThrow()
        {
            this.linkedStack.Pop();
        }
    }
}