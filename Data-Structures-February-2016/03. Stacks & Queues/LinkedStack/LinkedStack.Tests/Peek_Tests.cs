namespace LinkedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Peek_Tests
    {
        private LinkedStack<int> linkedStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedStack = new LinkedStack<int>();
        }

        [TestMethod]
        public void Peek_NonEmptyStack_ShouldReturnTheCorrectElements()
        {
            // Act & Assert
            for (int num = 0; num < 100; num++)
            {
                this.linkedStack.Push(num);
                Assert.AreEqual(num, this.linkedStack.Peek());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ShouldThrow()
        {
            this.linkedStack.Peek();
        }
    }
}