﻿namespace CustomList.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Find_FindAll_Tests
    {
        private CustomList<DateTime> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<DateTime>();
        }

        [TestMethod]
        public void FindElement_ShouldFind()
        {
            // Arrange
            var expectedDateTime = new DateTime(2016, 02, 08);

            // Act
            this.customList.Add(new DateTime(2016, 02, 07));
            this.customList.Add(expectedDateTime);

            var actualDate = this.customList.Find(date => date.Day == 8);

            // Assert
            Assert.AreEqual(expectedDateTime, actualDate);
        }

        [TestMethod]
        public void TestFindNonExistingElement_ShouldReturnDefaultValue()
        {
            // Act
            this.customList.Add(new DateTime(2016, 02, 07));

            // Assert
            var actualDate = this.customList.Find(date => date.Day == 21);
            Assert.AreEqual(default(DateTime), actualDate);
        }

        [TestMethod]
        public void TestFindAllElements_ShouldFind()
        {
            // Act
            for (int month = 1; month <= 2; month++)
            {
                for (int day = 1; day <= 20; day++)
                {
                    this.customList.Add(new DateTime(2016, month, day));
                }
            }

            var actualDates = this.customList.FindAll(date => date.Month == 2);

            // Assert
            int expectedDay = 1;
            for (int index = 0; index < actualDates.Count; index++)
            {
                Assert.AreEqual(2, actualDates[index].Month);
                Assert.AreEqual(expectedDay, actualDates[index].Day);
                expectedDay++;
            }
        }

        [TestMethod]
        public void FindAllElements_NonExistingElements_ShouldReturnEmptyList()
        {
            // Act
            for (int month = 1; month <= 2; month++)
            {
                for (int day = 1; day <= 20; day++)
                {
                    this.customList.Add(new DateTime(2016, month, day));
                }
            }

            var actualDates = this.customList.FindAll(date => date.Month == 6);

            // Assert
            Assert.AreEqual(0, actualDates.Count);
        }
    }
}