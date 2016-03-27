namespace ArrayStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Peek_Tests
    {
        private ArrayStack<int> arrayStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.arrayStack = new ArrayStack<int>();
        }

        [TestMethod]
        public void Peek_NonEmptyStack_ShouldReturnTheCorrectElements()
        {
            // Act & Assert
            for (int num = 0; num < 100; num++)
            {
                this.arrayStack.Push(num);
                Assert.AreEqual(num, this.arrayStack.Peek());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_EmptyStack_ShouldThrow()
        {
            this.arrayStack.Peek();
        }
    }
}