namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Remove_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void RemoveElement_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElement = 1;

            // Act
            this.customList.Add(addedElement);
            this.customList.Remove(addedElement);

            // Assert
            Assert.IsFalse(this.customList.Contains(addedElement));
            Assert.AreEqual(0, this.customList.Count);
        }

        [TestMethod]
        public void RemoveManyElements_ShouldRemoveCorrectly()
        {
            // Arrange
            var addedElementsCount = 1000;

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.customList.Add(num);
            }

            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.customList.Remove(num);
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
            var expectedList = new CustomList<int> { 1, 2, 3, 4, 6, 7, 8, 9, 10 };

            // Act
            for (int num = 1; num <= addedElementsCount; num++)
            {
                this.customList.Add(num);
            }

            Assert.AreEqual(expectedList.Count, this.customList.Count - 1);
            this.customList.Remove(5);

            // Assert
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i], this.customList[i]);
            }
        }
    }
}