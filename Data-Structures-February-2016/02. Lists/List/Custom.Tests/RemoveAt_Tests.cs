namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveAt_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void RemoveElement_AtIndex_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElement = 1;

            // Act
            this.customList.Add(addedElement);
            this.customList.RemoveAt(0);

            // Assert
            Assert.IsFalse(this.customList.Contains(addedElement));
            Assert.AreEqual(0, this.customList.Count);
        }

        [TestMethod]
        public void RemoveAt_ManyElements_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElementsCount = 10;

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.customList.Add(num);
            }

            for (int i = 0; i < addedElementsCount; i++)
            {
                this.customList.RemoveAt(0);
            }

            // Assert
            for (int num = 1; num <= addedElementsCount; num++)
            {
                Assert.IsFalse(this.customList.Contains(num));
            }

            Assert.AreEqual(0, this.customList.Count);
        }

        [TestMethod]
        public void RemoveElement_ElementsShouldBeInCorrectorder()
        {
            // Arrange
            int addedElementsCount = 10;
            var expectedNumbers = new CustomList<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10 };

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.customList.Add(num);
            }

            Assert.AreEqual(expectedNumbers.Count, this.customList.Count - 1);
            this.customList.RemoveAt(4);

            // Assert
            for (int i = 0; i < expectedNumbers.Count; i++)
            {
                Assert.AreEqual(expectedNumbers[i], this.customList[i]);
            }
			
			Assert.AreEqual(expectedNumbers.Count, this.customList.Count);
        }
    }
}