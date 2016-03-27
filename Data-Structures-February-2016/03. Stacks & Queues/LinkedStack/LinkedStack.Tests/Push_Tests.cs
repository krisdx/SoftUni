namespace LinkedStack.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Push_Tests
    {
        private LinkedStack<int> linkedStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.linkedStack = new LinkedStack<int>();
        }

        [TestMethod]
        public void PushElement_EmptyStack_ShouldPushCorrectly()
        {
            // Arrange
            int pushedElement = 5;

            // Act
            this.linkedStack.Push(pushedElement);

            // Assert
            Assert.AreEqual(1, this.linkedStack.Count);
            Assert.AreEqual(pushedElement, this.linkedStack.Peek());
        }


        [TestMethod]
        public void PushElement_EmptyStack_HeadAndTailShouldPointToElement()
        {
            // Arrange
            int pushedElement = 5;

            // Act
            this.linkedStack.Push(pushedElement);

            // Assert
            Assert.AreEqual(pushedElement, this.linkedStack.HeadNode.Value);
            Assert.AreEqual(pushedElement, this.linkedStack.TailNode.Value);
        }

        [TestMethod]
        public void PushManyElements_ShouldPushCorrectly()
        {
            // Act 
            for (int num = 1; num <= 1000; num++)
            {
                this.linkedStack.Push(num);
            }

            // Assert
            Assert.AreEqual(1000, this.linkedStack.Count);
            Assert.AreEqual(1000, this.linkedStack.Peek());
            Assert.AreEqual(1000, this.linkedStack.TailNode.Value);
        }
    }
}