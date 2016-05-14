namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceBetweenVertices
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

        public static void Main()
        {
            var distancesToFind = ReadGraph();

            FindDistances(distancesToFind);
        }

        private static void FindDistances(List<Tuple<int, int>> distancesToFind)
        {
            foreach (var node in distancesToFind)
            {
                int resultDistance = BFS(node.Item1, node.Item2);
                Console.WriteLine("[{0}, {1}] -> {2}", node.Item1, node.Item2, resultDistance);
            }
        }

        private static int BFS(int startNode, int valueToFind)
        {
            var queue = new Queue<Vertex>();
            var visited = new HashSet<int>();

            queue.Enqueue(new Vertex(startNode));
            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                if (currentVertex.Value == valueToFind)
                {
                    return currentVertex.Count;
                }

                foreach (var child in graph[currentVertex.Value])
                {
                    if (!visited.Contains(child))
                    {
                        queue.Enqueue(new Vertex(child, currentVertex.Count + 1));
                        visited.Add(child);
                    }
                }
            }

            return -1;
        }

        private static List<Tuple<int, int>> ReadGraph()
        {
            Console.ReadLine();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Distances to find:")
                {
                    break;
                }

                string[] vertexParams = line.Split(new char[] { ' ', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int vertex = int.Parse(vertexParams[0]);
                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<int>();
                }

                for (int i = 1; i < vertexParams.Length; i++)
                {
                    int successor = int.Parse(vertexParams[i]);
                    graph[vertex].Add(successor);
                }
            }

            var distancesToFind = new List<Tuple<int, int>>();
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                string[] searchParams = line.Split('-');
                int vertex = int.Parse(searchParams[0]);
                int successor = int.Parse(searchParams[1]);
                distancesToFind.Add(new Tuple<int, int>(vertex, successor));
            }

            return distancesToFind;
        }
    }

    public class Vertex
    {
        public Vertex(int value, int count = 0)
        {
            this.Value = value;
            this.Count = count;
        }

        public int Count { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}