namespace DoublyLinkedList.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    using DoubleLinkedList;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IEnumerable_Tests
    {
        [TestMethod]
        public void IEnumerable_Foreach_MultipleElements()
        {
            // Arrange
            var doublyLinkedList = new DoublyLinkedList<string>();
            doublyLinkedList.AddLast("Five");
            doublyLinkedList.AddLast("Six");
            doublyLinkedList.AddLast("Seven");

            // Act
            var items = new List<string>();
            foreach (var element in doublyLinkedList)
            {
                items.Add(element);
            }

            // Assert
            CollectionAssert.AreEqual(items,
                new List<string>() { "Five", "Six", "Seven" });
        }

        [TestMethod]
        public void IEnumerable_NonGeneric_MultipleElements()
        {
            // Arrange
            var doublyLinkedList = new DoublyLinkedList<object>();
            doublyLinkedList.AddLast("Five");
            doublyLinkedList.AddLast(6);
            doublyLinkedList.AddLast(7.77);

            // Act
            var enumerator = ((IEnumerable)doublyLinkedList).GetEnumerator();
            var items = new List<object>();
            while (enumerator.MoveNext())
            {
                items.Add(enumerator.Current);
            }

            // Assert
            CollectionAssert.AreEqual(items, new List<object>() { "Five", 6, 7.77 });
        }
    }
}