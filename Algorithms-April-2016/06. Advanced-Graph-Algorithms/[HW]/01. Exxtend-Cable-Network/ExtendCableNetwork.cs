namespace ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendCableNetwork
    {
        private static List<Edge> graph = new List<Edge>();
        private static HashSet<int> spanningTreeNodes = new HashSet<int>();

        private static int budget;

        public static void Main()
        {
            var unconnectedEdges = ReadInput();

            unconnectedEdges.Sort();

            var addedEdges = new List<Edge>();
            int usedBudget = 0;
            foreach (var edge in unconnectedEdges)
            {
                if (usedBudget + edge.Weight >= budget)
                {
                    break;
                }

                if (spanningTreeNodes.Contains(edge.StartNode) ^ 
                    spanningTreeNodes.Contains(edge.EndNode))
                {
                    addedEdges.Add(edge);
                    graph.Add(edge);
                    spanningTreeNodes.Add(spanningTreeNodes.Contains(edge.StartNode) ? edge.EndNode : edge.StartNode);

                    usedBudget += edge.Weight;
                }
            }

            foreach (var edge in addedEdges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("Budget used: " + usedBudget);
        }

        private static List<Edge> ReadInput()
        {
            budget = int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);

            var unconnectedEdges = new List<Edge>();
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

                var newEdge = new Edge(startNode, endNode, weight);
                if (edge.Length > 3)
                {
                    graph.Add(newEdge);
                    spanningTreeNodes.Add(startNode);
                    spanningTreeNodes.Add(endNode);
                }
                else
                {
                    unconnectedEdges.Add(newEdge);
                }
            }

            return unconnectedEdges;
        }
    }
}