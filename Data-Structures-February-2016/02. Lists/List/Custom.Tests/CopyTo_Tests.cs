namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CopyTo_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void CopyTo_ShouldCopyCorrectly()
        {
            // Arrange
            var array = new int[15];

            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.customList.Add(num);
            }

            this.customList.CopyTo(array);
            this.customList.CopyTo(array, 5);
            this.customList.CopyTo(array, 10);

            // Assert
            int index = 0;
            for (int num = 1; num <= 5; num++)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }

            for (int num = 1; num <= 5; num++)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }

            for (int num = 1; num <= 5; num++)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }
        }
    }
}
