namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ReversedList<T> : IList<T>
    {
        private const int DefaultCapacity = 16;
        private const int AddingIndex = 0;

        private T[] elements;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public ReversedList(ICollection<T> collection)
        {
            this.elements = collection.ToArray();
            this.Capacity = collection.Count;
            this.Count = collection.Count;
        }

        public bool IsReadOnly { get; }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValideteIndex(index);
                return this.elements[index];
            }

            set
            {
                this.ValideteIndex(index);
                this.elements[index] = value;
            }
        }

        /// <summary>
        /// Adds an element at the start of the list.
        /// </summary>
        /// <param name="element">The element that has to be added</param>
        public void Add(T element)
        {
            this.CheckForResize();

            this.Insert(AddingIndex, element);
        }

        /// <summary>
        /// Inserts a element to the specified index.
        /// </summary>
        /// <param name="indexToInsert">The insert index</param>
        /// <param name="elementToInsert">The element that has to be inserted</param>
        public void Insert(int indexToInsert, T elementToInsert)
        {
            if (indexToInsert < 0 || indexToInsert > this.Count)
            {
                throw new IndexOutOfRangeException("The index cannot be smaller than zero or bigger than the list count.");
            }

            this.InsertElementAndMoveElementsToRight(indexToInsert, elementToInsert);

            this.CheckForResize();
        }

        /// <summary>
        /// Reverses the order of the elements in the list. 
        /// </summary>
        /// <returns>Returns the list in reversed order</returns>
        public ReversedList<T> Reverse()
        {
            var reversedArrayList = new ReversedList<T>(this.Count);

            for (int index = this.Count - 1; index >= 0; index--)
            {
                reversedArrayList.Add(this.elements[index]);
            }

            return reversedArrayList;
        }

        /// <summary>
        /// Clears the list and sets the capacity to it's initial value (16)
        /// </summary>
        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.Count = 0;
            this.Capacity = DefaultCapacity;
        }

        /// <summary>
        /// Searches the list for the specified element and returns it's index.
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>Returns the index of the specified element. Returns -1 if the element does not exists.</returns>
        public int IndexOf(T element)
        {
            for (int index = 0; index < this.Count; index++)
            {
                if (this.elements[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Determines weather the specified element exists in the list.
        /// </summary>
        /// <param name="element">The element to search for</param>
        /// <returns>Returns true if the specified element exists in the list. Returns false if the specified element does not exists in the list.</returns>
        public bool Contains(T element)
        {
            int searchIndex = this.IndexOf(element);
            if (searchIndex == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Copies all the elements to the given array.
        /// </summary>
        /// <param name="array">The array that the elements should be copied in</param>
        public void CopyTo(T[] array)
        {
            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this.elements[i];
            }
        }

        /// <summary>
        /// Copies all the elements to the given array, starting from the specified index.
        /// </summary>
        /// <param name="array">The array that the elements should be copied in</param>
        /// <param name="startIndex">Starting index</param>
        public void CopyTo(T[] array, int startIndex)
        {
            for (int i = 0; i < this.Count; i++)
            {
                array[startIndex] = this.elements[i];
                startIndex++;
            }
        }

        /// <summary>
        /// Finds the element that match the certain conditions.
        /// </summary>
        /// <param name="condition">The conditions</param>
        /// <returns>Returns the element that match the conditions. Returns the default value, if the element cannot be found.</returns>
        public T Find(Predicate<T> condition)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (condition(this.elements[i]))
                {
                    return this.elements[i];
                }
            }

            return default(T);
        }

        /// <summary>
        /// Finds all elements that match the certain conditions.
        /// </summary>
        /// <param name="condition">The conditions</param>
        /// <returns>Returns a collection of the elements that match the conditions, or an empty collection.</returns>
        public IList<T> FindAll(Predicate<T> condition)
        {
            var foundElements = new ReversedList<T>();

            for (int i = 0; i < this.Count; i++)
            {
                if (condition(this.elements[i]))
                {
                    foundElements.Add(this.elements[i]);
                }
            }

            return foundElements;
        }

        /// <summary>
        /// Removes the specified element from the list.
        /// </summary>
        /// <param name="element">The element that has to be removed</param>
        /// <returns></returns>
        public bool Remove(T element)
        {
            int elementIndex = this.IndexOf(element);
            if (elementIndex == -1)
            {
                return false;
            }

            this.RemoveElementAndMoveElementsToLeft(elementIndex);
            return true;
        }

        /// <summary>
        /// Removes the element on the specified index.
        /// </summary>
        /// <param name="index">The index to remove</param>
        public void RemoveAt(int index)
        {
            this.RemoveElementAndMoveElementsToLeft(index);
        }

        /// <summary>
        /// Removes all the elements that match the specified conditions.
        /// </summary>
        /// <param name="condition">The conditions</param>
        public void RemoveAll(Predicate<T> condition)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (condition(this.elements[i]))
                {
                    this.Remove(this.elements[i]);
                }
            }
        }

        /// <summary>
        /// Removes the all the elements in the specified range.
        /// </summary>
        /// <param name="startIndex">The starting index</param>
        /// <param name="count">The count</param>
        public void RemoveRange(int startIndex, int count)
        {
            if (startIndex > this.Count)
            {
                throw new ArgumentOutOfRangeException("The start index is bigger than the count of the list.");
            }

            int endIndex = startIndex + count;
            if (endIndex > this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid count");
            }

            for (int index = startIndex; index < endIndex; index++)
            {
                this.RemoveAt(0);
            }
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

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append("[ ");
            for (int i = 0; i < this.Count; i++)
            {
                if (i + 1 == this.Count)
                {
                    output.Append(this.elements[i]);
                }
                else
                {
                    output.AppendFormat("{0}, ", this.elements[i]);
                }
            }

            output.Append(" ]");

            return output.ToString();
        }

        private void CheckForResize()
        {
            if (this.Count == this.Capacity)
            {
                var extendedArray = new T[this.Capacity * 2];
                for (int i = 0; i < this.elements.Length; i++)
                {
                    extendedArray[i] = this.elements[i];
                }

                this.elements = extendedArray;
                this.Capacity *= 2;
            }
        }

        private void RemoveElementAndMoveElementsToLeft(int removedElementIndex)
        {
            var newElements = new T[this.Count - 1];

            int newArrayIndex = 0;
            for (int index = 0; index < this.Count; index++)
            {
                if (index == removedElementIndex)
                {
                    continue;
                }

                newElements[newArrayIndex] = this.elements[index];
                newArrayIndex++;
            }

            this.elements = newElements;
            this.Count--;
        }

        private void InsertElementAndMoveElementsToRight(int indexToInsert, T elementToInsert)
        {
            var newElements = new T[this.Count + 1];

            int index = 0;
            for (int currentIndex = 0; currentIndex < newElements.Length; currentIndex++)
            {
                if (currentIndex == indexToInsert)
                {
                    newElements[currentIndex] = elementToInsert;
                    continue;
                }

                newElements[currentIndex] = this.elements[index];
                index++;
            }

            this.elements = newElements;
            this.Count++;
        }

        private void ValideteIndex(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("The index cannot be negative.");
            }

            if (index >= this.Count)
            {
                throw new IndexOutOfRangeException("The index must be less than the count of the list.");
            }
        }
    }
}