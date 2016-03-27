namespace CustomLinkedList.Tests
{
    using System;
    using LinkedList;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveFirst_RemoveLast_Tests
    {
        private CustomLinkedList<int> customLinkedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.customLinkedList = new CustomLinkedList<int>();
        }

        [TestMethod]
        public void RemoveFirstElement_OnlyOneElementInList_TheListShouldBecomeEmpty()
        {
            // Act
            this.customLinkedList.AddLast(1);

            this.customLinkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(0, this.customLinkedList.Count);
            Assert.IsNull(this.customLinkedList.HeadNode);
            Assert.IsNull(this.customLinkedList.TailNode);
        }

        [TestMethod]
        public void RemoveFirstElement_NonEmptyList_ShouldRemove()
        {
            // Act
            for (int num = 0; num <= 5; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            this.customLinkedList.RemoveFirst();

            // Assert
            Assert.AreEqual(5, this.customLinkedList.Count);
            Assert.AreEqual(1, this.customLinkedList.HeadNode.Value);
            Assert.AreEqual(2, this.customLinkedList.HeadNode.NextNode.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFirstElement_EmptyList_ShouldThrow()
        {
            // Act
            this.customLinkedList.RemoveFirst();
        }

        [TestMethod]
        public void RemoveLastElement_OnlyOneElementInList_TheListShouldBecomeEmpty()
        {
            // Act
            this.customLinkedList.AddLast(1);

            this.customLinkedList.RemoveLast();

            // Assert
            Assert.AreEqual(0, this.customLinkedList.Count);
            Assert.IsNull(this.customLinkedList.HeadNode);
            Assert.IsNull(this.customLinkedList.TailNode);
        }

        [TestMethod]
        public void RemoveLastElement_NonEmptyList_ShouldRemove()
        {
            // Act
            for (int num = 1; num <= 6; num++)
            {
                this.customLinkedList.AddLast(num);
            }

            this.customLinkedList.RemoveLast();

            // Assert
            Assert.AreEqual(5, this.customLinkedList.Count);
            Assert.AreEqual(5, this.customLinkedList.TailNode.Value);
            Assert.IsNull(this.customLinkedList.TailNode.NextNode);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveLastElement_EmptyList_ShouldThrow()
        {
            // Act
            this.customLinkedList.RemoveLast();
        }
    }
}