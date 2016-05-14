namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int startNode, int destinationNode)
        {
            // Initialize distance array
            int n = graph.GetLength(0);
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[startNode] = 0;

            bool[] used = new bool[n];
            int?[] prev = new int?[n];
            while (true)
            {
                // Find the next minimal node and distance to it 
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    break;
                }

                // Calculate the distances for the nearest nodes
                used[minNode] = true;
                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        int newDistance = distance[minNode] +graph[minNode, i]; 
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            prev[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = ReconstructPath(destinationNode, prev);
            return path;
        }

        private static List<int> ReconstructPath(int destinationNode, int?[] prev)
        {
            var path = new List<int>();

            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = prev[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}