namespace ArrayStack.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToArray_Tests
    {
        private ArrayStack<int> arrayStack;

        [TestInitialize]
        public void TestInitialize()
        {
            this.arrayStack = new ArrayStack<int>();
        }

        [TestMethod]
        public void ToArray_NonEmptyStack_ShouldReturnCorrectArray()
        {
            // Act
            for (int i = 0; i < 100; i++)
            {
                this.arrayStack.Push(0);
            }

            var expectedArray = this.arrayStack.ToArray();

            // Assert
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(expectedArray[i], this.arrayStack.Pop());
            }
        }

        [TestMethod]
        public void ToArray_EmptyStack_ShouldReturnEmptyArray()
        {
            // Act
            var expectedArray = this.arrayStack.ToArray();

            // Assert
            Assert.AreEqual(expectedArray.Length, this.arrayStack.Count);
        }
    }
}