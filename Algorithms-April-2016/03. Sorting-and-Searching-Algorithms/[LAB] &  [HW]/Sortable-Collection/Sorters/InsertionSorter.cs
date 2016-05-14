namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            this.InsertionSortFast(collection);
        }
        
        private void InsertionSortFast(IList<T> collection)
        {
            for (int currentIndex = 1; currentIndex < collection.Count; currentIndex++)
            {
                var element = collection[currentIndex];
                int swapIndex = currentIndex;
                while (swapIndex > 0 &&
                  element.CompareTo(collection[swapIndex - 1]) < 0)
                {
                    swapIndex--;
                }

                if (swapIndex < currentIndex)
                {
                    collection.RemoveAt(currentIndex);
                    collection.Insert(swapIndex, element);
                }
            }
        }

        private void InsertionSortSlow(IList<T> collection)
        {
            for (int currentIndex = 0; currentIndex < collection.Count; currentIndex++)
            {
                int nextIndex = currentIndex;
                while (nextIndex >= 0 && nextIndex + 1 < collection.Count &&
                    collection[nextIndex].CompareTo(collection[nextIndex + 1]) > 0)
                {
                    Swap(collection, nextIndex, nextIndex + 1);
                    nextIndex--;
                }
            }
        }

        private void Swap(IList<T> collection, int currentIndex, int nextIndex)
        {
            var swapValue = collection[currentIndex];
            collection[currentIndex] = collection[nextIndex];
            collection[nextIndex] = swapValue;
        }
    }
}