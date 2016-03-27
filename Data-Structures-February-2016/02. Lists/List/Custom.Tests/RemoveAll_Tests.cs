namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveAll_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void RemoveAllElements_ShouldRemoveCorrectly()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customList.Add(num);
            }

            this.customList.Add(5);

            this.customList.RemoveAll(num => num == 5);

            // Assert
            int expectedNum = 1;
            for (int i = 0; i <= 3; i++)
            {
                Assert.AreEqual(expectedNum, this.customList[i]);
                expectedNum++;
            }
        }

        [TestMethod]
        public void RemoveAllElements_FalseCondition_ShouldNotRemove()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customList.Add(num);
            }

            this.customList.RemoveAll(num => num == 100);

            // Assert
            int expectedNum = 1;
            for (int i = 0; i < this.customList.Count; i++)
            {
                Assert.AreEqual(expectedNum, this.customList[i]);
                expectedNum++;
            }
        }

        [TestMethod]
        public void RemoveAllElementsInList_ShouldReturnEmptyList()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customList.Add(num);
            }

            for (int currentNum = 1; currentNum <= 5; currentNum++)
            {
                this.customList.RemoveAll(num => num == currentNum);
            }

            // Assert
            Assert.AreEqual(0, this.customList.Count);
        }

        [TestMethod]
        public void RemoveAllElements_EmptyList()
        {
            // Act
            this.customList.RemoveAll(num => num == 1);

            // Assert
            Assert.AreEqual(0, this.customList.Count);
        }
    }
}