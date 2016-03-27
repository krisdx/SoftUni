namespace TreeIndexing
{
    using System;

    using AvlTree;

    public class TreeIndexing
    {
        public static void Main()
        {
            var avlTree = new AvlTree<int>();

            string[] items = Console.ReadLine().Trim().Split();
            foreach (string item in items)
            {
                avlTree.Add(int.Parse(item));
            }

            string str = Console.ReadLine();
            while (!string.IsNullOrWhiteSpace(str))
            {
                try
                {
                    int index = int.Parse(str);
                    Console.WriteLine("The element at index {0} is {1}", index, avlTree[index]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid index");
                }

                str = Console.ReadLine();
            }
        }
    }
}