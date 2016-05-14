namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithPriorityQueue
    {
        public static List<int> DijkstraAlgorithm(
            Dictionary<Node, Dictionary<Node, int>> graph, Node sourceNode, Node destinationNode)
        {
            var prev = new int?[graph.Count];
            var visited = new bool[graph.Count];
            var priorityQueue = new PriorityQueue<Node>();

            foreach (var pair in graph)
            {
                pair.Key.DistanceFromStart = double.PositiveInfinity;
            }
            sourceNode.DistanceFromStart = 0;

            priorityQueue.Enqueue(sourceNode);
            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMin();
                if (currentNode == destinationNode)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }

                    double distance = currentNode.DistanceFromStart + edge.Value;
                    if (distance < edge.Key.DistanceFromStart)
                    {
                        edge.Key.DistanceFromStart = distance;

                        prev[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsPositiveInfinity(destinationNode.DistanceFromStart))
            {
                return null;
            }

            var path = ReconstructPath(destinationNode, prev);
            return path;
        }

        private static List<int> ReconstructPath(Node destinationNode, int?[] prev)
        {
            var path = new List<int>();
            int? node = destinationNode.Id;
            while (node != null)
            {
                path.Add(node.Value);
                node = prev[node.Value];
            }

            path.Reverse();
            return path;
        }
    }
}