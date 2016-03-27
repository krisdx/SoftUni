namespace CustomList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Clear_Tests
    {
        private CustomList<int> customList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customList = new CustomList<int>();
        }

        [TestMethod]
        public void ClearList_ShouldClearCorrectly()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.customList.Add(num);
            }

            this.customList.Clear();

            // Assert
            for (int num = 1; num <= 10; num++)
            {
                Assert.IsFalse(this.customList.Contains(num));
            }

            Assert.AreEqual(0, this.customList.Count);
        }
    }
}