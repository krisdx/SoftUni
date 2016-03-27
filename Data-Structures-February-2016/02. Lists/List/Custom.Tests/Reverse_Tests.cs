namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Reverse_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void ReverseList_ShouldReverseCorrectly()
        {
            // Act
            for (int num = 100; num >= 1; num--)
            {
                this.customList.Add(num);
            }

            var reversedList = this.customList.Reverse();

            // Assert
            int expectedNum = 1;
            for (int index = 0; index < this.customList.Count; index++)
            {
                Assert.AreEqual(expectedNum, reversedList[index]);
                expectedNum++;
            }

            Assert.AreEqual(reversedList.Count, this.customList.Count);
        }

        [TestMethod]
        public void ReverseListWithOneElemet_ShouldReturnListWithOneElement()
        {
            // Arrange
            int elementAdded = 1;

            // Act
            this.customList.Add(elementAdded);
            var reversedEmptyList = this.customList.Reverse();

            // Assert
            Assert.AreEqual(elementAdded, reversedEmptyList[0]);
            Assert.AreEqual(reversedEmptyList.Count, this.customList.Count);
        }

        [TestMethod]
        public void ReverseEmptyList_ShouldReturnEmptyList()
        {
            // Act
            var reversedEmptyList = this.customList.Reverse();

            // Assert
            Assert.AreEqual(reversedEmptyList.Count, this.customList.Count);
        }
    }
}