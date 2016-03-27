namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Reverse_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void ReverseList_ShouldReverseCorrectly()
        {
            // Act
            for (int num = 100; num >= 1; num--)
            {
                this.reversedList.Add(num);
            }

            var reversedList = this.reversedList.Reverse();

            // Assert
            int expectedNum = 1;
            for (int index = 0; index < this.reversedList.Count; index++)
            {
                Assert.AreEqual(expectedNum, reversedList[index]);
                expectedNum++;
            }

            Assert.AreEqual(reversedList.Count, this.reversedList.Count);
        }

        [TestMethod]
        public void ReverseListWithOneElemet_ShouldReturnListWithOneElement()
        {
            // Arrange
            int elementAdded = 1;

            // Act
            this.reversedList.Add(elementAdded);
            var reversedEmptyList = this.reversedList.Reverse();

            // Assert
            Assert.AreEqual(elementAdded, reversedEmptyList[0]);
            Assert.AreEqual(reversedEmptyList.Count, this.reversedList.Count);
        }

        [TestMethod]
        public void ReverseEmptyList_ShouldReturnEmptyList()
        {
            // Act
            var reversedEmptyList = this.reversedList.Reverse();

            // Assert
            Assert.AreEqual(reversedEmptyList.Count, this.reversedList.Count);
        }
    }
}