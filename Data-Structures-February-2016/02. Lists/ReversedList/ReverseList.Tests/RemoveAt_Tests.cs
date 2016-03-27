namespace ReversedListTests
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class RemoveAt_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void RemoveElement_AtIndex_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElement = 1;

            // Act
            this.reversedList.Add(addedElement);
            this.reversedList.RemoveAt(0);

            // Assert
            Assert.IsFalse(this.reversedList.Contains(addedElement));
            Assert.AreEqual(0, this.reversedList.Count);
        }

        [TestMethod]
        public void RemoveAt_ManyElements_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElementsCount = 10;

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.reversedList.Add(num);
            }

            for (int i = 0; i < addedElementsCount; i++)
            {
                this.reversedList.RemoveAt(0);
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

            var expectedNumbers = new List<int>();
            for (int num = addedElementsCount; num >= 1; num--)
            {
                if (num == 6)
                {
                    continue;
                }

                expectedNumbers.Add(num);
            }

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.RemoveAt(4);

            // Assert
            for (int i = 0; i < expectedNumbers.Count; i++)
            {
                Assert.AreEqual(expectedNumbers[i], this.reversedList[i]);
            }

            Assert.AreEqual(expectedNumbers.Count, this.reversedList.Count);
        }
    }
}