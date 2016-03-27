namespace ArrayStack.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Pop_Tests
    {
        private ArrayStack<int> arrayStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.arrayStack = new ArrayStack<int>();
        }

        [TestMethod]
        public void PopElement_NonEmptyStack_ShouldPopCorrectly()
        {
            // Arrange
            int addedElement = 5;

            // Act
            this.arrayStack.Push(addedElement);
            var popedElement = this.arrayStack.Pop();

            // Assert
            Assert.AreEqual(addedElement, popedElement);
        }

        [TestMethod]
        public void PopManyElements_NonEmptyStack_ShouldPopCorrectly()
        {
            // Act
            for (int num = 1; num <= 100; num++)
            {
                this.arrayStack.Push(num);
            }

            // Assert
            for (int num = 100; num > 0; num--)
            {
                Assert.AreEqual(num, this.arrayStack.Pop());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopElement_EmptyStack_ShouldThrow()
        {
            this.arrayStack.Pop();
        }
    }
}
