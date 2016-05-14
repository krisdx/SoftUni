namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            // Building Max Heap
            for (int i = collection.Count / 2; i >= 0; i--)
            {
                this.HeapifyDown(collection, i);
            }

            var coppyCollection = new List<T>(collection);
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                collection[i] = ExtractMax(coppyCollection);
            }
        }

        public T ExtractMax(IList<T> heap)
        {
            var min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            if (heap.Count > 0)
            {
                HeapifyDown(heap, 0);
            }

            return min;
        }

        private void HeapifyDown(IList<T> heap, int i)
        {
            int left = (2 * i) + 1;
            int right = (2 * i) + 2;
            int largest = i;
            if (left < heap.Count &&
                heap[left].CompareTo(heap[largest]) > 0)
            {
                largest = left;
            }
            if (right < heap.Count &&
                heap[right].CompareTo(heap[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                var swapValue = heap[i];
                heap[i] = heap[largest];
                heap[largest] = swapValue;

                HeapifyDown(heap, largest);
            }
        }
    }
}