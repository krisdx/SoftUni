namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CyclesInGraph
    {
        private static Dictionary<string, List<string>> graph =
            new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        private static bool isAcyclic = true;

        public static void Main()
        {
            ReadInput();

            //// The quick way 
            //// If a graph does not have cycles, is a tree. 
            //// If a tree holds more or equal number edges, than vertices - it a cycled graph.            
            //int sumOfEdges = graph.Values.Sum(successors => successors.Count);
            //int verticesCount = graph.Keys.Count * 2; // Multiplying by 2, because the graph is undirected.
            //if (sumOfEdges < verticesCount)
            //{
            //    Console.WriteLine("Acyclic: Yes");
            //}
            //else
            //{
            //    Console.WriteLine("Acyclic: No");
            //}

            // The DFS way
            bool isAcyclic = IsGraphAcyclic();
            if (isAcyclic)
            {
                Console.WriteLine("Acyclic: Yes");
            }
            else
            {
                Console.WriteLine("Acyclic: No");
            }
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

                string[] vertexParams = line.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string vertex = vertexParams[0];
                string successor = vertexParams[1];

                if (!graph.ContainsKey(vertex))
                {
                    graph[vertex] = new List<string>();
                }
                graph[vertex].Add(successor);

                if (!graph.ContainsKey(successor))
                {
                    graph[successor] = new List<string>();
                }
                graph[successor].Add(vertex);
            }
        }

        private static bool IsGraphAcyclic()
        {
            DFS(graph.First().Key);
            return isAcyclic;
        }

        private static void DFS(string currentVertex, string predecessor = null)
        {
            if (!visited.Contains(currentVertex))
            {
                visited.Add(currentVertex);
                foreach (var successor in graph[currentVertex])
                {
                    // The DFS will just go back to it's predecessor and 
                    // thinks there is a cycle
                    if (successor != predecessor)
                    {
                        DFS(successor, currentVertex);
                    }
                }
            }
            else
            {
                // Detected a cycle
                isAcyclic = false;
            }
        }
    }
}