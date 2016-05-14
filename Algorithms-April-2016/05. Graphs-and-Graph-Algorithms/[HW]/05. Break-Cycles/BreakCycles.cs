namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BreakCycles
    {
        private static SortedDictionary<string, List<string>> graph =
            new SortedDictionary<string, List<string>>();

        private static StringBuilder output = new StringBuilder();
        private static int removedEdgesCount;

        public static void Main()
        {
            ReadInput();

            RemoveCycles();

            Console.WriteLine("Edges to remove: " + removedEdgesCount);
            Console.WriteLine(output.ToString().Trim());
        }

        private static void RemoveCycles()
        {
            foreach (var vertex in graph.Keys)
            {
                graph[vertex].Sort();
                for (int i = 0; i < graph[vertex].Count; i++)
                {
                    string startVertex = vertex;
                    string endVertex = graph[vertex][i];

                    // Temporary remove the edge
                    graph[startVertex].Remove(endVertex);
                    graph[endVertex].Remove(startVertex);

                    bool hasCycle = HasCycle(startVertex, endVertex);
                    if (hasCycle)
                    {
                        output.AppendFormat("{0} - {1}\n", startVertex, endVertex);
                        removedEdgesCount++;
                    }
                    else
                    {
                        // Put back the edge, if don't close a cycle
                        graph[startVertex].Insert(i, endVertex);
                        graph[endVertex].Add(startVertex);
                    }
                }
            }
        }

        private static bool HasCycle(string startVertex, string endVertex)
        {
            var queue = new Queue<string>();
            var visited = new HashSet<string>();

            visited.Add(startVertex);
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                if (currentVertex == endVertex)
                {
                    return true;
                }

                foreach (var successor in graph[currentVertex])
                {
                    if (!visited.Contains(successor))
                    {
                        visited.Add(successor);
                        queue.Enqueue(successor);
                    }
                }
            }

            return false;
        }

        private static void ReadInput()
        {
            while (true)
            {
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                string[] vertexParams = line.Split(new char[] { ' ', ',', '>', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string vertex = vertexParams[0];
                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<string>();
                }

                for (int i = 1; i < vertexParams.Length; i++)
                {
                    string successor = vertexParams[i];
                    graph[vertex].Add(successor);
                }
            }
        }
    }
}