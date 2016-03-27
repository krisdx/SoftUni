namespace ReversedListTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReversedList;

    [TestClass]
    public class CopyTo_Tests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void CopyTo_ShouldCopyCorrectly()
        {
            // Arrange
            var array = new int[15];

            // Act
            for (int num = 1; num <= 5; num++)
            {
                this.reversedList.Add(num);
            }

            this.reversedList.CopyTo(array);
            this.reversedList.CopyTo(array, 5);
            this.reversedList.CopyTo(array, 10);

            // Assert
            int index = 0;
            for (int num = 5; num >= 1; num--)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }

            for (int num = 5; num >= 1; num--)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }

            for (int num = 5; num >= 1; num--)
            {
                Assert.AreEqual(num, array[index]);
                index++;
            }
        }
    }
}