namespace FindTheRoot
{
    using System;
    using System.Collections.Generic;

    public class FindTheRoot
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            // int holds value, bool holds hasParent
            var nodes = new Dictionary<int, bool>(numberOfNodes);

            int numberOfEdges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edge = Console.ReadLine().Split();

                int parentValue = int.Parse(edge[0]);
                if (!nodes.ContainsKey(parentValue))
                {
                    nodes.Add(parentValue, false);
                }

                int childValue = int.Parse(edge[1]);
                nodes[childValue] = true;
            }

            int root = 0;
            int rootsCounter = 0;
            foreach (var node in nodes)
            {
                if (node.Value == false)
                {
                    if (rootsCounter == 0)
                    {
                        root = node.Key;
                    }

                    rootsCounter++;
                    if (rootsCounter >= 2)
                    {
                        Console.WriteLine("Multiple root nodes!");
                        return;
                    }
                }
            }

            if (rootsCounter == 1)
            {
                Console.WriteLine(root);
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}