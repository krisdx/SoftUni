namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> array, int start, int end)
        {
            if (start < end)
            {
                int partitionIndex = Partition(array, start, end);

                // Sort the left sub array
                QuickSort(array, start, partitionIndex - 1);

                // Sort the right sub array
                QuickSort(array, partitionIndex + 1, end);
            }
        }

        private int Partition(IList<T> array, int start, int end)
        {
            var pivot = array[start];
            int partitionIndex = start + 1;
            for (int currentIndex = partitionIndex; currentIndex <= end; currentIndex++)
            {
                if (array[currentIndex].CompareTo(pivot) <= 0)
                {
                    Swap(array, currentIndex, partitionIndex);
                    partitionIndex++;
                }
            }

            partitionIndex--;
            Swap(array, start, partitionIndex);

            return partitionIndex;
        }

        private void Swap(IList<T> array, int currentIndex, int partitionIndex)
        {
            var swapValue = array[currentIndex];
            array[currentIndex] = array[partitionIndex];
            array[partitionIndex] = swapValue;
        }
    }
}