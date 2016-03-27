namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Add_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void AddElement_ShouldAddToList()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.reversedList.Add(addedElement);

            // Assert
            var actualElement = this.reversedList[0];
            Assert.AreEqual(addedElement, actualElement, "The list is not adding elements.");

            Assert.AreEqual(1, this.reversedList.Count, "The count of the list is not changing.");
        }

        [TestMethod]
        public void AddElements_ShouldReziseOnetimeCorrectly_CapacityShouldBeDoubled()
        {
            int initialCapacity = this.reversedList.Capacity;
            for (int num = 0; num <= initialCapacity; num++)
            {
                this.reversedList.Add(num);
            }

            Assert.AreEqual(initialCapacity * 2, this.reversedList.Capacity);
        }

        [TestMethod]
        public void AddManyElements_ShouldResizeCorrectly()
        {
            // Arrange
            int elementsAddedCount = 10000;

            // Act
            for (int num = 0; num < elementsAddedCount; num++)
            {
                this.reversedList.Add(num);
            }

            // Assert
            Assert.AreEqual(elementsAddedCount, this.reversedList.Count, "The count of the list is not correct.");
        }

        [TestMethod]
        public void AddManyElements_ShouldAddSameElements()
        {
            // Arrange
            int elementsAddedCount = 10000;

            // Act
            for (int num = 1; num <= elementsAddedCount; num++)
            {
                this.reversedList.Add(num);
            }

            // Assert
            int index = 0;
            for (int num = elementsAddedCount; num >= 1; num--)
            {
                Assert.AreEqual(num, this.reversedList[index]);
                index++;
            }

            Assert.AreEqual(elementsAddedCount, this.reversedList.Count, "The count of the list is not correct.");
        }
    }
}