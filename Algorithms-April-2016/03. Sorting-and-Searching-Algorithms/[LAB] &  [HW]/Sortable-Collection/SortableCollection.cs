namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<int> items)
        {
            this.Elements = new List<int>(items);
        }

        public SortableCollection(params int[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<int> Elements { get; } = new List<int>();

        public int Count => this.Elements.Count;

        public void Sort(ISorter<int> sorter)
        {
            sorter.Sort(this.Elements);
        }

        public int BinarySearch(int elementToFind)
        {
            return this.PerformBinarySearch(elementToFind, 0, this.Elements.Count - 1);
        }

        public int InterpolationSearch(int elementToFind)
        {
            return PerformInterpolationSearch(elementToFind, 0, this.Elements.Count - 1);
        }

        private int PerformInterpolationSearch(int elementToFind, int start, int end)
        {
            if (start >= end)
            {
                return -1;
            }

            int middleIndex = start + (
                (elementToFind - this.Elements[start]) * (end - start)) /
                (this.Elements[end] - this.Elements[start]);
            while (this.Elements[start] <= elementToFind && this.Elements[end] >= elementToFind)
            {
                if (this.Elements[middleIndex].CompareTo(elementToFind) < 0)
                {
                    start = middleIndex + 1;
                }
                else if (this.Elements[middleIndex].CompareTo(elementToFind) > 0)
                {
                    end = middleIndex - 1;
                }
                else
                {
                    return middleIndex;
                }

                middleIndex = start + ((elementToFind - this.Elements[start]) * (end - start)) / (this.Elements[end] - this.Elements[start]);
            }

            return -1;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public int[] ToArray()
        {
            return this.Elements.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Elements)}]";
        }

        private int PerformBinarySearch(int elementToFind, int startIndex, int endIndex)
        {
            int middleIndex = startIndex + (endIndex - startIndex) / 2;
            while (startIndex <= endIndex)
            {
                if (this.Elements[middleIndex] < elementToFind)
                {
                    startIndex = middleIndex + 1;
                }
                else if (this.Elements[middleIndex] > elementToFind)
                {
                    endIndex = middleIndex - 1;
                }
                else
                {
                    return middleIndex;
                }

                middleIndex = startIndex + (endIndex - startIndex) / 2;
            }

            return -1;
        }
    }
}