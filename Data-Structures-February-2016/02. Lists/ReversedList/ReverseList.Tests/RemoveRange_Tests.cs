namespace ReversedListTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class RemoveRange_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void RemoveRange_ShouldRemoveElements()
        {
            // Act
            for (int num = 10; num >= 1; num--)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.RemoveRange(0, 4);

            // Assert
            int index = 0;
            for (int num = 5; num <= 10; num++)
            {
                Assert.AreEqual(num, this.reversedList[index]);
                index++;
            }

            Assert.AreEqual(6, this.reversedList.Count);
        }

        [TestMethod]
        public void RemoveRange_ShouldRemoveAllElements()
        {
            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.RemoveRange(0, 5);

            // Assert
            Assert.AreEqual(0, this.reversedList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveRange_InvalidStartIndex()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.reversedList.Add(1);
            }

            // Assert
            this.reversedList.RemoveRange(100, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveRange_InvalidCount()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.reversedList.Add(1);
            }

            // Assert
            this.reversedList.RemoveRange(0, 50);
        }
    }
}