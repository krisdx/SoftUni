namespace ReversedListTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Insert_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void InsertElement_ShoudInsertCorrectly()
        {
            // Arrange
            int elementsAddedCount = 4;

            // Act
            this.reversedList.Add(2);
            this.reversedList.Add(1);

            this.reversedList.Add(4);

            this.reversedList.Insert(3, 3);

            // Assert
            Assert.AreEqual(4, this.reversedList[0]);

            int num = 1;
            for (int index = 1; index < this.reversedList.Count; index++)
            {
                Assert.AreEqual(num, this.reversedList[index]);
                num++;
            }

            Assert.AreEqual(elementsAddedCount, this.reversedList.Count, "The count of the list is not increasing.");
        }

        [TestMethod]
        public void InsertManyElements_ShoudInsertAndResizeCorrectly()
        {
            // Arrange
            int elementsAddedCount = 100;
            int numberToInsert = 2;

            // Act
            this.reversedList.Add(100);
            this.reversedList.Add(1);

            for (int index = 1; index <= 98; index++)
            {
                this.reversedList.Insert(index, numberToInsert);
                numberToInsert++;
            }

            // Assert
            int expectedNum = 1;
            for (int index = 0; index < elementsAddedCount; index++)
            {
                Assert.AreEqual(expectedNum, this.reversedList[index]);
                expectedNum++;
            }

            Assert.AreEqual(elementsAddedCount, this.reversedList.Count, "The count of the list is not increasing.");
        }

        [TestMethod]
        public void InsertElement_InEmptyList_ShouldInsertCorrectly()
        {
            // Act
            this.reversedList.Insert(0, 1);

            // Assert
            Assert.IsTrue(this.reversedList.Contains(1));
            Assert.AreEqual(1, this.reversedList.Count);
        }

        [TestMethod]
        public void InsertElement_AtTheEndOfTheList_ShouldInsertCorrectly()
        {
            // Act
            this.reversedList.Add(1);
            this.reversedList.Add(2);

            this.reversedList.Insert(this.reversedList.Count, 3);

            // Assert
            Assert.AreEqual(2, this.reversedList[0]);
            Assert.AreEqual(1, this.reversedList[1]);
            Assert.AreEqual(3, this.reversedList[2]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertElement_AtSmallerThanZeroIndex_ShoudThrow()
        {
            // Act
            this.reversedList.Insert(-15, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertElement_AtBiggerThanCountIndex_ShoudThrow()
        {
            // Act
            this.reversedList.Add(1);
            this.reversedList.Insert(3, 1);
        }
    }
}