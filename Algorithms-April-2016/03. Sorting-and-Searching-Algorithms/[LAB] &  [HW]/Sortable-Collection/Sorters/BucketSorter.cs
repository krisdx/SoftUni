namespace Sortable_Collection.Sorters
{
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        public decimal MaxValue { get; set; }

        public void Sort(IList<int> collection)
        {
            var buckets = PutInBuckets(collection);

            SortBuckets(buckets);
            PutElementInCorrectOrder(collection, buckets);
        }

        private List<int>[] PutInBuckets(IList<int> collection)
        {
            var buckets = new List<int>[collection.Count];
            foreach (var element in collection)
            {
                int bucketIndex = (int)(element / this.MaxValue * collection.Count);
                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            return buckets;
        }

        private static void SortBuckets(IList<int>[] buckets)
        {
            var quickSorter = new Quicksorter<int>();
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    quickSorter.Sort(buckets[i]);
                }
            }
        }

        private static void PutElementInCorrectOrder(IList<int> collection, List<int>[] buckets)
        {
            int index = 0;
            foreach (var bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (var num in bucket)
                    {
                        collection[index] = num;
                        index++;
                    }
                }
            }
        }
    }
}