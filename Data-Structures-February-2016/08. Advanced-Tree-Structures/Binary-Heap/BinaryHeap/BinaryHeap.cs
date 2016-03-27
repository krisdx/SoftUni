namespace BinaryHeap
{
    using System;
    using System.Collections.Generic;

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private readonly IList<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public BinaryHeap(T[] elements)
        {
            this.heap = new List<T>(elements);
            for (int i = this.heap.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(i);
            }
        }

        public int Count
        {
            get { return this.heap.Count; }
        }

        /// <summary>
        /// Returns the biggest element or the element with biggest priority
        /// </summary>
        /// <returns>Returns the biggest element or the element with biggest priority</returns>
        public T ExtractMax()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            var max = this.heap[0];
            this.heap[0] = this.heap[this.heap.Count - 1];
            this.heap.RemoveAt(this.heap.Count - 1);
            if (this.heap.Count > 0)
            {
                this.HeapifyDown(0);
            }

            return max;
        }

        /// <summary>
        /// Peeks the biggest element or the element with biggest priority
        /// </summary>
        /// <returns>Peeks the biggest element or the element with biggest priority</returns>
        public T PeekMax()
        {
            var max = this.heap[0];
            return max;
        }

        /// <summary>
        /// Inserts an element to the binary heap 
        /// </summary>
        /// <param name="value">The value to be inserted</param>
        public void Insert(T value)
        {
            this.heap.Add(value);

            int addedNodeIndex = this.heap.Count - 1;
            this.HeapifyUp(addedNodeIndex);
        }

        private void HeapifyDown(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left < this.heap.Count &&
                this.heap[left].CompareTo(this.heap[largest]) > 0)
            {
                largest = left;
            }
            if (right < this.heap.Count &&
                this.heap[right].CompareTo(this.heap[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                var swapValue = this.heap[i];
                this.heap[i] = this.heap[largest];
                this.heap[largest] = swapValue;

                this.HeapifyDown(largest);
            }
        }

        private void HeapifyUp(int i)
        {
            var parent = (i - 1) / 2;
            while (i > 0 &&
                this.heap[i].CompareTo(this.heap[parent]) > 0)
            {
                var swapValue = this.heap[i];
                this.heap[i] = this.heap[parent];
                this.heap[parent] = swapValue;

                i = parent;
                parent = (i - 1) / 2;
            }
        }
    }
}