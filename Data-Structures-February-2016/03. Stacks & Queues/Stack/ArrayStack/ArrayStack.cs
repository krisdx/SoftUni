namespace ArrayStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ArrayStack<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;

        public ArrayStack(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        /// <summary>
        /// Adds the specified element to the stack
        /// </summary>
        /// <param name="element">The element to add</param>
        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.Count] = element;
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

            this.Count--;
            var popedElement = this.elements[this.Count];

            return popedElement;
        }

        /// <summary>
        /// Looks at he last element, without removing it.
        /// </summary>
        /// <returns>Returns the last element, without removing it</returns>
        /// <exception cref="InvalidOperationException">Throws when the stack is empty</exception>
        public T Peek()
        {
            this.ValidateEmptyStack();

            return this.elements[this.Count - 1];
        }

        /// <summary>
        /// Converts the stack to an array
        /// </summary>
        /// <returns>Returns the stack as an array</returns>
        public T[] ToArray()
        {
            var array = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.elements[i];
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[i];
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

        private void Resize()
        {
            var newElements = new T[this.elements.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}