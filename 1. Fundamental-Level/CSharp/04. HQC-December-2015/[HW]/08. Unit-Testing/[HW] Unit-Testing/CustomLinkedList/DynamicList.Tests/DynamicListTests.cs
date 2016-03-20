namespace DynamicList.Tests
{
    using System;
    using CustomLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicListTests
    {
        // Testing the indexation.
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexing_BiggerThanCount_ShouldThrow()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            dynamicList.Add(1);

            var element = dynamicList[2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Indexing_SmallerThanZero_ShouldThrow()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            var element = dynamicList[-1];
        }

        // Testing the counter.
        [TestMethod]
        public void Add_SeveralElement_CounterShouldIncrease()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            int counter = 0;
            for (int number = 1; number <= 5; number++)
            {
                dynamicList.Add(number);
                counter++;
            }

            Assert.AreEqual(counter, dynamicList.Count, "The counter is not increasing when elements are added.");
        }

        [TestMethod]
        public void AddAndRemove_SeveralElement_CounterShouldChange()
        {
            DynamicList<int> dynamicList = new DynamicList<int>();

            int counter = 0;
            for (int number = 1; number <= 5; number++)
            {
                dynamicList.Add(number);
                counter++;
            }

            for (int number = 5; number >= 1; number--)
            {
                dynamicList.Remove(number);
                counter--;
            }

            Assert.AreEqual(counter, dynamicList.Count, "The counter is not changing when elements are added and removed.");
        }

        // Testing the Add method
        [TestMethod]
        public void Add_OneElement_ShouldAddElement()
        {
            DynamicList<byte> dynamicList = new DynamicList<byte>();

            dynamicList.Add(5);

            bool contains = dynamicList.Contains(5);
            
            Assert.AreEqual(true, contains, "The list is not adding elements.");
        }

        // Testing the RemoveAt method
        [TestMethod]
        public void RemoveAt_Index_ShouldRemoveElementByIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");
            dynamicList.Add("Gosho");

            var removedElement = dynamicList.RemoveAt(0);
            bool contains = dynamicList.Contains(removedElement);

            Assert.AreEqual(false, contains, "The list is not removing elements by index.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAt_UnexistingIndex_ShouldThrow()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");
            dynamicList.Add("Gosho");

            string actualElement = dynamicList.RemoveAt(10);
        }

        // Testing the Remove method
        [TestMethod]
        public void Remove_ExistingElement_ShouldReturnTheIndexOfTheRemovedElement()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");

            int resultIndex = dynamicList.Remove("Pesho");

            Assert.AreEqual(0, resultIndex, "The list does not return correct index when removing an element.");
        }

        [TestMethod]
        public void Remove_UnexistingElement_ShouldReturnMinusOne()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");

            int resultIndex = dynamicList.Remove("Gosho");

            Assert.AreEqual(-1, resultIndex, "Remove method does not return -1 when we search for unexisting element.");
        }

        // Testing IndexOf method
        [TestMethod]
        public void IndexOf_ExistingElement_ShouldShouldReturnTheIndexOfTheElement()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");

            int resultIndex = dynamicList.IndexOf("Pesho");

            Assert.AreEqual(0, resultIndex, "IndexOf method does not return the index of the existing element.");
        }

        [TestMethod]
        public void IndexOf_UnexistingElement_ShouldShouldReturnMinusOne()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Pesho");

            int resultIndex = dynamicList.IndexOf("Mariya");

            Assert.AreEqual(-1, resultIndex, "IndexOf method does not return -1 when we search for unexisting element.");
        }

        // Testing Contains method
        [TestMethod]
        public void Searching_ForExistingElement_ShouldShouldReturnTrue()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("Mariya");
            bool contains = dynamicList.Contains("Mariya");

            Assert.AreEqual(true, contains, "The list does not return true when searching for existing element.");
        }

        [TestMethod]
        public void Searching_ForUnexistingElement_ShouldShouldReturnFalse()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            bool contains = dynamicList.Contains("Mariya");

            Assert.AreEqual(false, contains, "The list does not return false when searching for unexisting element.");
        }
    }
}