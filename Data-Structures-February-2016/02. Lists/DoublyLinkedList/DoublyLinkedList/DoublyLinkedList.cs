namespace DoubleLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedList()
        {
            this.HeadNode = null;
            this.TailNode = null;
            this.Count = 0;
        }

        /// <summary>
        /// The first element of the list
        /// </summary>
        public DoublyLinkedListNode<T> HeadNode { get; private set; }

        /// <summary>
        /// The last element of the list. The next node points to null.
        /// </summary>
        public DoublyLinkedListNode<T> TailNode { get; private set; }

        public int Count { get; private set; }

        /// <summary>
        /// Adds the specified element at the start of the list
        /// </summary>
        /// <param name="element">The element to add</param>
        public void AddFirst(T element)
        {
            var newNode = new DoublyLinkedListNode<T>(element);
            if (this.HeadNode == null)
            {
                this.HeadNode = newNode;
                this.TailNode = newNode;
            }
            else
            {
                newNode.NextNode = this.HeadNode;
                this.HeadNode.PreviousNode = newNode;
                this.HeadNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds an element after the specified node
        /// </summary>
        /// <param name="nodeToAddAfter">The node to add after</param>
        /// <param name="element">The element to add</param>
        /// <exception cref="ArgumentNullException">Throws when the node to add after if null</exception>
        public void AddAfter(DoublyLinkedListNode<T> nodeToAddAfter, T element)
        {
            if (nodeToAddAfter == null)
            {
                throw new ArgumentNullException("The node to add after cannot be null.");
            }

            var currentNode = this.HeadNode;
            while (currentNode != null)
            {
                if (currentNode == nodeToAddAfter)
                {
                    var newNode = new DoublyLinkedListNode<T>(element);

                    newNode.NextNode = nodeToAddAfter.NextNode;
                    nodeToAddAfter.NextNode = newNode;
                    if (this.TailNode == this.HeadNode)
                    {
                        // The list was only one element and after adding the new element we have to redirect the tail.
                        this.TailNode = newNode;
                    }

                    break;
                }

                currentNode = currentNode.NextNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Adds the specified element at the end of the list
        /// </summary>
        /// <param name="element">The element to add</param>
        public void AddLast(T element)
        {
            var newNode = new DoublyLinkedListNode<T>(element);

            if (this.TailNode == null)
            {
                this.HeadNode = newNode;
                this.TailNode = newNode;
            }
            else
            {
                this.TailNode.NextNode = newNode;
                newNode.PreviousNode = this.TailNode;
                this.TailNode = newNode;
            }

            this.Count++;
        }

        /// <summary>
        /// Clears the elements in the list
        /// </summary>
        public void Clear()
        {
            this.HeadNode = null;
            this.TailNode = null;
            this.Count = 0;
        }

        /// <summary>
        /// Searches the list for the specified element and returns it's index.
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>The index of the first element that is equal to the given element. Returns -1 if the element does not exists.</returns>
        public int FirstIndexOf(T element)
        {
            var currentNode = this.HeadNode;

            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                {
                    return index;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Searches the list for the specified element and returns the index of the last equal element.
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>The index of the last element that is equal to the given element. Returns -1 if the element does not exists.</returns>
        public int LastIndexOf(T element)
        {
            var currentNode = this.HeadNode;

            int lastElementIndex = -1;
            int currentIndex = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(element))
                {
                    lastElementIndex = currentIndex;
                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            return lastElementIndex;
        }

        /// <summary>
        /// Searches the list for the specified element
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>Returns true or false weather the element exists in the list.</returns>
        public bool Contains(T element)
        {
            int searchIndex = this.FirstIndexOf(element);
            if (searchIndex == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes the specified element from the list
        /// </summary>
        /// <param name="elementToRemove">Element to remove</param>
        /// <returns>Returns true of false weather the element was successfully removed</returns>
        public bool Remove(T elementToRemove)
        {
            var currentNode = this.HeadNode;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(elementToRemove))
                {
                    this.RemoveNode(currentNode, currentNode.PreviousNode);
                    return true;
                }

                currentNode = currentNode.NextNode;
            }

            return false;
        }

        /// <summary>
        /// Removes the first element in the list
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws then the list is empty</exception>
        public T RemoveFirst()
        {
            this.ValidateListEmpty();

            this.Count--;
            if (this.Count == 0)
            {
                var elementToRemove = this.HeadNode.Value;
                this.HeadNode = null;
                this.TailNode = null;

                return elementToRemove;
            }

            var nodeToRemove = this.HeadNode;

            this.HeadNode = this.HeadNode.NextNode;
            this.HeadNode.PreviousNode = null;

            return nodeToRemove.Value;
        }

        /// <summary>
        /// Removes the last element in the list
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws when the list is empty</exception>
        public T RemoveLast()
        {
            this.ValidateListEmpty();

            this.Count--;
            if (this.Count == 0)
            {
                var elementToRemove = this.HeadNode.Value;
                this.HeadNode = null;
                this.TailNode = null;

                return elementToRemove;
            }

            var nodeToRemove = this.TailNode;

            this.TailNode = this.TailNode.PreviousNode;
            this.TailNode.NextNode = null;

            return nodeToRemove.Value;
        }

        /// <summary>
        /// Goes through all elements and applies the specified function.
        /// </summary>
        /// <param name="action">The function that has to be preformed</param>
        public void ForEach(Action<T> action)
        {
            var currentNode = this.HeadNode;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        /// <summary>
        /// Converts the list into an array
        /// </summary>
        /// <returns>Returns the list as an array.</returns>
        public T[] ToArray()
        {
            var array = new T[this.Count];

            var currentNode = this.HeadNode;
            int index = 0;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.HeadNode;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateListEmpty()
        {
            if (this.HeadNode == null || this.TailNode == null)
            {
                throw new InvalidOperationException("The list is empty");
            }
        }

        private void RemoveNode(DoublyLinkedListNode<T> currentNode, DoublyLinkedListNode<T> previousNodeNode)
        {
            this.Count--;
            if (this.Count == 0)
            {
                // The list becomes empty after removing the node. 
                this.HeadNode = null;
                this.TailNode = null;
                return;
            }

            if (previousNodeNode == null)
            {
                // The removed element is the head. Redirect the head to point to the correct element.
                this.HeadNode = currentNode.NextNode;
            }
            else
            {
                previousNodeNode.NextNode = currentNode.NextNode;
                if (previousNodeNode.NextNode == null)
                {
                    // The removed element is the tail. Redirect the head to point to the correct element.
                    this.TailNode = previousNodeNode;
                }
            }
        }
    }
}