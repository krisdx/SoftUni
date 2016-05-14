namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ModifiedKruskalAlgorithm // Not Finished
    {
        private static List<Edge> edges = new List<Edge>();
        private static Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
        private static int[] root;

        private static int forestWeight;

        public static void Main()
        {
            Init();

            var minimalSpannigForest = GetMinimalSpannigForest();
            Console.WriteLine("Minimum spanning forest weight: " + forestWeight);
            foreach (var edge in minimalSpannigForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> GetMinimalSpannigForest()
        {
            edges.Sort();

            var minimalSpannigForest = new List<Edge>();
            foreach (var edge in edges)
            {
                int startNodeRoot = root[edge.StartNode];
                int endNodeRoot = root[edge.EndNode];
                if (startNodeRoot != endNodeRoot)
                {
                    minimalSpannigForest.Add(edge);
                    forestWeight += edge.Weight;

                    // edge.EndNode.Parent = edge.StartNode.Parent;
                    SetParennt(new bool[root.Length, root.Length], endNodeRoot, startNodeRoot, root[startNodeRoot]);
                }
            }

            return minimalSpannigForest;
        }

        private static void SetParennt(bool[,] visited, int currentNode, int previousNode, int parent)
        {
            //if (visited[currentNode,pri)
            //{

            //}
        }

        private static void Init()
        {
            int nodesCount =
                int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            int edgesCount =
                int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            for (int i = 0; i < edgesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(new char[] { ' ' });
                int startNode = int.Parse(edge[0]);
                int endNode = int.Parse(edge[1]);
                int weight = int.Parse(edge[2]);
                if (!graph.ContainsKey(startNode))
                {
                    graph[startNode] = new HashSet<int>();
                }
                graph[startNode].Add(endNode);

                if (!graph.ContainsKey(endNode))
                {
                    graph[endNode] = new HashSet<int>();
                }
                graph[endNode].Add(startNode);

                var newEdge = new Edge(startNode, endNode, weight);
                edges.Add(newEdge);
            }

            root = new int[nodesCount];
            for (int i = 0; i < root.Length; i++)
            {
                root[i] = i;
            }            
        }
    }
}