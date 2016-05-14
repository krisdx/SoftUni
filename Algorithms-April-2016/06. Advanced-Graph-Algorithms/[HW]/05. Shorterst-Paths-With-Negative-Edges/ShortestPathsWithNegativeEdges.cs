namespace ShortestPathsWithNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPathsWithNegativeEdges // Not finished
    {
        private static List<Edge> edges = new List<Edge>();

        private static int verticeCount;
        private static int destinationNode;

        public static void Main()
        {
            int startNode = ReadInput();

            FindShortestPathBellmanFord(startNode);
        }

        private static void FindShortestPathBellmanFord(int startNode)
        {
            var distance = new double[verticeCount];
            var previous = new int[verticeCount];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                previous[i] = -1;
            }
            distance[startNode] = 0;

            for (int i = 0; i < verticeCount - 1; i++)
            {
                foreach (Edge edge in edges)
                {
                    if (distance[edge.Start] + edge.Distance < distance[edge.End])
                    {
                        distance[edge.End] = distance[edge.Start] + edge.Distance;
                        previous[edge.End] = edge.Start;
                    }
                }
            }

            var visited = new HashSet<int>();
            foreach (Edge edge in edges)
            {
                if (distance[edge.Start] + edge.Distance < distance[edge.End])
                {

                }
                visited.Add(edge.Start);
                visited.Add(edge.End);
            }

            List<int> path = new List<int>();
            int current = destinationNode;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();

            Console.WriteLine("Distance [{0} -> {1}]: {2}", startNode, destinationNode, distance);
            Console.WriteLine(string.Join(" -> ", path));
        }

        private static int ReadInput()
        {
            int nodesCount =
               int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            string[] path = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int edgesCount =
                 int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            for (int i = 0; i < edgesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(new char[] { ' ' });
                int startNodeIndex = int.Parse(edge[0]);
                int endNodeIndex = int.Parse(edge[1]);
                int weight = int.Parse(edge[2]);

                var newEdge = new Edge(startNodeIndex, endNodeIndex, weight);
                edges.Add(newEdge);
            }

            verticeCount = nodesCount;
            destinationNode = int.Parse(path[2]);
            return int.Parse(path[1]);
        }
    }
}