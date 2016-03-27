namespace Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphConnectedComponents
    {
        private static bool[] visited;
        private static IList<int>[] graph;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            visited = new bool[n];
            graph = new IList<int>[n];
            for (int nodeIndex = 0; nodeIndex < graph.Length; nodeIndex++)
            {
                try
                {
                    graph[nodeIndex] = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToList();
                }
                catch (Exception)
                {
                    graph[nodeIndex] = new List<int>();
                }
            }

            FindGraphConnectedComponents(graph);
        }

        private static void FindGraphConnectedComponents(IList<int>[] graph)
        {
            visited = new bool[graph.Length];
            for (int nodeIndex = 0; nodeIndex < graph.Length; nodeIndex++)
            {
                if (!visited[nodeIndex])
                {
                    Console.Write("Connected component:");
                    DFS(nodeIndex);
                    Console.WriteLine();
                }
            }
        }

        private static void DFS(int nodeIndex)
        {
            if (!visited[nodeIndex])
            {
                visited[nodeIndex] = true;
                foreach (var childNode in graph[nodeIndex])
                {
                    DFS(childNode);
                }

                Console.Write(" " + nodeIndex);
            }
        }
    }
}