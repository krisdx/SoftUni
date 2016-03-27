namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Remove_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void RemoveElement_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElement = 1;

            // Act
            this.reversedList.Add(addedElement);
            this.reversedList.Remove(addedElement);

            // Assert
            Assert.IsFalse(this.reversedList.Contains(addedElement));
            Assert.AreEqual(0, this.reversedList.Count);
        }

        [TestMethod]
        public void RemoveManyElements_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElementsCount = 1000;

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.reversedList.Add(num);
            }

            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.reversedList.Remove(num);
            }

            // Assert
            for (int num = 1; num <= addedElementsCount; num++)
            {
                Assert.IsFalse(this.reversedList.Contains(num));
            }

            Assert.AreEqual(0, this.reversedList.Count);
        }

        [TestMethod]
        public void RemoveElement_ElementsShouldBeInCorrectorder()
        {
            // Arrange
            int addedElementsCount = 10;
            var expectedList = new ReversedList<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10 };

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.reversedList.Add(num);
            }

            Assert.AreEqual(expectedList.Count, this.reversedList.Count - 1);
            this.reversedList.Remove(5);

            // Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i], this.reversedList[i]);
            }
        }
    }
}