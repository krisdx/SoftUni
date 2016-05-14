namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(IList<T> collection, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;
                MergeSort(collection, start, middle);
                MergeSort(collection, middle + 1, end);

                this.Merge(collection, start, middle, end);
            }
        }

        private void Merge(IList<T> collection, int start, int middle, int end)
        {
            var tempCollection = new T[end - start+1];

            int tempIndex = 0;
            int leftPartIndex = start;
            int rightPartIndex = middle + 1;
            while (leftPartIndex <= middle && rightPartIndex <= end)
            {
                if (collection[leftPartIndex].CompareTo(collection[rightPartIndex]) <= 0)
                {
                    tempCollection[tempIndex] = collection[leftPartIndex];
                    leftPartIndex++;
                }
                else
                {
                    tempCollection[tempIndex] = collection[rightPartIndex];
                    rightPartIndex++;
                }

                tempIndex++;
            }

            while (leftPartIndex <= middle)
            {
                tempCollection[tempIndex] = collection[leftPartIndex];
                tempIndex++;
                leftPartIndex++;
            }
            while (rightPartIndex <= end)
            {
                tempCollection[tempIndex] = collection[rightPartIndex];
                tempIndex++;
                rightPartIndex++;
            }

            // Coping the sorted elements to the original collection
            int index = start;
            for (int i = 0; i < tempCollection.Length; i++)
            {
                collection[index] = tempCollection[i];
                index++;
            }
        }
    }
}