namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Add_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void AddElement_ShouldAddToList()
        {
            // Arrange
            int addedElement = 1;

            // Act
            this.customList.Add(addedElement);

            // Assert
            var actualElement = this.customList[0];
            Assert.AreEqual(addedElement, actualElement, "The list is not adding elements.");

            Assert.AreEqual(1, this.customList.Count, "The count of the list is not changing.");
        }

        [TestMethod]
        public void AddElements_ShouldReziseOnetimeCorrectly_CapacityShouldBeDoubled()
        {
            int initialCapacity = this.customList.Capacity;
            for (int num = 0; num <= initialCapacity; num++)
            {
                this.customList.Add(num);
            }

            Assert.AreEqual(initialCapacity * 2, this.customList.Capacity);
        }

        [TestMethod]
        public void AddManyElements_ShouldResizeCorrectly()
        {
            // Arrange
            int elementsAddedCount = 10000000;

            // Act
            for (int num = 0; num < elementsAddedCount; num++)
            {
                this.customList.Add(num);
            }

            // Assert
            Assert.AreEqual(elementsAddedCount, this.customList.Count, "The count of the list is not correct.");
        }
		
		[TestMethod]
        public void AddManyElements_ShouldAddSameElements()
        {
            // Arrange
            int elementsAddedCount = 10000000;

            // Act
            for (int num = 1; num <= elementsAddedCount; num++)
            {
                this.customList.Add(num);
            }

            // Assert
            int index = 0;
            for (int num = 1; num <= elementsAddedCount; num++)
            {
                Assert.AreEqual(num, this.customList[index]);
                index++;
            }

            Assert.AreEqual(elementsAddedCount, this.customList.Count, "The count of the list is not correct.");
        }
    }
}