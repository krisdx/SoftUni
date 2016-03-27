namespace CustomList.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveRange_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void RemoveRange_ShouldRemoveElements()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customList.Add(num);
            }

            this.customList.RemoveRange(0, 4);

            // Assert
            int index = 0;
            for (int num = 5; num <= 10; num++)
            {
                Assert.AreEqual(num, this.customList[index]);
                index++;
            }

            Assert.AreEqual(6, this.customList.Count);
        }

        [TestMethod]
        public void RemoveRange_ShouldRemoveAllElements()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customList.Add(num);
            }

            this.customList.RemoveRange(0, 5);

            // Assert
            Assert.AreEqual(0, this.customList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveRange_InvalidStartIndex()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customList.Add(1);
            }

            // Assert
            this.customList.RemoveRange(100, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveRange_InvalidCount()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customList.Add(1);
            }

            // Assert
            this.customList.RemoveRange(0, 50);
        }
    }
}