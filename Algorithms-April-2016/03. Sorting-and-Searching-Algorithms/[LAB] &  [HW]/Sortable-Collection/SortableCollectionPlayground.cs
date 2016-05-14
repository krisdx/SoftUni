namespace Sortable_Collection
{
    using System;

    using Sortable_Collection.Sorters;
    using System.Collections.Generic;
    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main()
        {
            const int NumberOfElementsToSort = 22;
            const int MaxValue = 150;

            var array = new int[NumberOfElementsToSort];
            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection(array);
            collectionToSort.Sort(new BucketSorter() { MaxValue = MaxValue });

            Console.WriteLine(collectionToSort);

            //var collection = new SortableCollection(2, -1, 5, 0, -3);
            var collection = new SortableCollection(new List<int> { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 });
            Console.WriteLine(collection);

            collection.Sort(new HeapSorter<int>());
            Console.WriteLine(collection);
        }
    }
}