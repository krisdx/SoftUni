namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class Clear_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void ClearList_ShouldClearCorrectly()
        {
            // Act
            for (int num = 1; num <= 10; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.Clear();

            // Assert
            for (int num = 1; num <= 10; num++)
            {
                Assert.IsFalse(this.reversedList.Contains(num));
            }

            Assert.AreEqual(0, this.reversedList.Count);
        }
    }
}