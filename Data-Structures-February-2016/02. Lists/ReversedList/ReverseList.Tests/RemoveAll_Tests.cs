namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class RemoveAll_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void RemoveAllElements_ShouldRemoveCorrectly()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.Add(5);

            this.reversedList.RemoveAll(num => num == 5);

            // Assert
            int expectedNum = 4;
            for (int index = 0; index <= 3; index++)
            {
                Assert.AreEqual(expectedNum, this.reversedList[index]);
                expectedNum--;
            }
        }

        [TestMethod]
        public void RemoveAllElements_FalseCondition_ShouldNotRemove()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.RemoveAll(num => num == 100);

            // Assert
            int expectedNum = 5;
            for (int i = 0; i < this.reversedList.Count; i++)
            {
                Assert.AreEqual(expectedNum, this.reversedList[i]);
                expectedNum--;
            }
        }

        [TestMethod]
        public void RemoveAllElementsInList_ShouldReturnEmptyList()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.reversedList.Add(num);
            }

            for (int currentNum = 1; currentNum <= 5; currentNum++)
            {
                this.reversedList.RemoveAll(num => num == currentNum);
            }

            // Assert
            Assert.AreEqual(0, this.reversedList.Count);
        }

        [TestMethod]
        public void RemoveAllElements_EmptyList()
        {
            // Act
            this.reversedList.RemoveAll(num => num == 1);

            // Assert
            Assert.AreEqual(0, this.reversedList.Count);
        }
    }
}