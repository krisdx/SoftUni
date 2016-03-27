namespace LinkedStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedStack<T> : IEnumerable<T>
    {
        public LinkedStack()
        {
            this.HeadNode = null;
            this.TailNode = null;
            this.Count = 0;
        }

        public LinkedStackNode<T> HeadNode { get; private set; }

        public LinkedStackNode<T> TailNode { get; private set; }

        public int Count { get; private set; }

        /// <summary>
        /// Adds the specified element to the stack
        /// </summary>
        /// <param name="element">The element to add</param>
        public void Push(T element)
        {
            var newNode = new LinkedStackNode<T>(element);
            if (this.TailNode == null)
            {
                // The stack is empty. Head an tail should point to the new node.
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
        /// Removes the last element in the list
        /// </summary>
        /// <returns>Returns the last element in the list</returns>
        /// <exception cref="InvalidOperationException">Throws when the stack is empty</exception>
        public T Pop()
        {
            this.ValidateEmptyStack();

            var elementToPop = this.TailNode.Value;

            this.Count--;
            if (this.Count == 0)
            {
                this.HeadNode = null;
                this.TailNode = null;
            }
            else
            {
                this.TailNode = this.TailNode.PreviousNode;
                this.TailNode.NextNode = null;
            }

            return elementToPop;
        }

        /// <summary>
        /// Looks at he last element, without removing it.
        /// </summary>
        /// <returns>Returns the last element, without removing it</returns>
        /// <exception cref="InvalidOperationException">Throws when the stack is empty</exception>
        public T Peek()
        {
            this.ValidateEmptyStack();

            return this.TailNode.Value;
        }

        /// <summary>
        /// Converts the stack to an array
        /// </summary>
        /// <returns>Returns the stack as an array</returns>
        public T[] ToArray()
        {
            var array = new T[this.Count];

            var currentNode = this.HeadNode;
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
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

        private void ValidateEmptyStack()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
        }

    }
}