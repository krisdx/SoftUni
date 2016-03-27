namespace CustomList.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Insert_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void InsertElement_ShoudInsertCorrectly()
        {
            // Arrange
            int elementsAddedCount = 4;

            // Act
            this.customList.Add(1);
            this.customList.Add(2);

            this.customList.Add(4);

            this.customList.Insert(2, 3);

            // Assert
            int num = 1;
            for (int index = 0; index < elementsAddedCount; index++)
            {
                Assert.AreEqual(num, this.customList[index]);
                num++;
            }

            Assert.AreEqual(elementsAddedCount, this.customList.Count, "The count of the list is not increasing.");
        }

        [TestMethod]
        public void InsertManyElements_ShoudInsertAndResizeCorrectly()
        {
            // Arrange
            int elementsAddedCount = 100;
            int numberToInsert = 2;

            // Act
            this.customList.Add(1);
            this.customList.Add(100);

            for (int index = 1; index <= 98; index++)
            {
                this.customList.Insert(index, numberToInsert);
                numberToInsert++;
            }

            // Assert
            int expectedNum = 1;
            for (int index = 0; index < elementsAddedCount; index++)
            {
                Assert.AreEqual(expectedNum, this.customList[index]);
                expectedNum++;
            }

            Assert.AreEqual(elementsAddedCount, this.customList.Count, "The count of the list is not increasing.");
        }

        [TestMethod]
        public void InsertElement_InEmptyList_ShouldInsertCorrectly()
        {
            // Act
            this.customList.Insert(0, 1);

            // Assert
            Assert.IsTrue(this.customList.Contains(1));
            Assert.AreEqual(1, this.customList.Count);
        }

        [TestMethod]
        public void InsertElement_AtTheEndOfTheList_ShouldInsertCorrectly()
        {
            // Act
            this.customList.Add(1);
            this.customList.Add(2);

            this.customList.Insert(this.customList.Count, 3);

            // Assert
            int expectedNum = 1;
            for (int index = 0; index < this.customList.Count; index++)
            {
                Assert.AreEqual(expectedNum, this.customList[index]);
                expectedNum++;
            }

            Assert.AreEqual(3, this.customList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertElement_AtSmallerThanZeroIndex_ShoudThrow()
        {
            // Act
            this.customList.Insert(-15, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertElement_AtBiggerThanCountIndex_ShoudThrow()
        {
            // Act
            this.customList.Add(1);
            this.customList.Insert(3, 1);
        }
    }
}