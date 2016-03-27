namespace CalculateSequence
{
    using System;
    using System.Collections.Generic;

    public class CalculateSequence
    {
        public static void Main()
        {
            string[] numbers = Console.ReadLine().Split();
            int n = int.Parse(numbers[0]);
            int m = int.Parse(numbers[1]);

            FindeShortestSequenceOfOperations(n, m);
        }

        private static void FindeShortestSequenceOfOperations(int n, int m)
        {
            var queue = new Queue<Item>();

            queue.Enqueue(new Item(n, null));
            while (queue.Count > 0)
            {
                var currentItem = queue.Dequeue();
                if (currentItem.Value < m)
                {
                    queue.Enqueue(new Item(currentItem.Value + 1, currentItem));
                    queue.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    queue.Enqueue(new Item(currentItem.Value * 2, currentItem));
                }
                else if (currentItem.Value == m)
                {
                    PrintResult(currentItem);
                    break;
                }
            }

            Console.WriteLine("No solution");
        }

        private static void PrintResult(Item item)
        {
            var result = new List<int>();

            while (item != null)
            {
                result.Add(item.Value);
                item = item.PreviousItem;
            }

            result.Reverse();

            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}