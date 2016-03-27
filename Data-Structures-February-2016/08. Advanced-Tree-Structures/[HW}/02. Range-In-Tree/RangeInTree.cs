namespace RangeInTree
{
    using System;
    using AvlTree;

    public class RangeInTree
    {
        public static void Main()
        {
            var avlTree = new AvlTree<int>();

            string[] items = Console.ReadLine().Trim().Split();
            foreach (string item in items)
            {
                avlTree.Add(int.Parse(item));
            }

            string[] ranges = Console.ReadLine().Trim().Split();
            int from = int.Parse(ranges[0]);
            int to = int.Parse(ranges[1]);

            var itemsInRange = avlTree.Range(from, to);
            foreach (var item in itemsInRange)
            {
                Console.Write(item + " ");
            }
        }
    }
}