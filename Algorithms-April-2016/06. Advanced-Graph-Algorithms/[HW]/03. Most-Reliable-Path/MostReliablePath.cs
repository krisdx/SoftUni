namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostReliablePath // Not Finished
    {
        private static Dictionary<Node, Dictionary<Node, int>> graph = new Dictionary<Node, Dictionary<Node, int>>();
        private static Dictionary<int, Node> nodes = new Dictionary<int, Node>();

        private static int destinationNode;

        public static void Main()
        {
            int startNode = ReadInput();

            //Console.WriteLine();
            //foreach (var node in graph)
            //{
            //    Console.Write(node.Key.Index + " -> ");
            //    foreach (var child in graph[node.Key])
            //    {
            //        Console.Write(child.Key + " ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine();

            var path = Dijkstra(startNode);
            Console.WriteLine("Most reliable path reliability: {0}", 1);
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

                var startNode = new Node(startNodeIndex);
                var endNode = new Node(endNodeIndex);
                if (!graph.ContainsKey(startNode))
                {
                    graph[startNode] = new Dictionary<Node, int>();
                    if (!graph[startNode].ContainsKey(endNode))
                    {
                        graph[startNode].Add(endNode, 0);
                    }
                }
                if (!graph.ContainsKey(endNode))
                {
                    graph[endNode] = new Dictionary<Node, int>();
                    if (!graph[endNode].ContainsKey(startNode))
                    {
                        graph[endNode].Add(startNode, 0);
                    }
                }
                graph[startNode][endNode] = weight;
                graph[endNode][startNode] = weight;

                if (!nodes.ContainsKey(startNodeIndex))
                {
                    nodes[startNodeIndex] = startNode;
                }
                if (!nodes.ContainsKey(endNodeIndex))
                {
                    nodes[endNodeIndex] = endNode;
                }
            }

            destinationNode = int.Parse(path[2]);
            return int.Parse(path[1]);
        }

        public static List<int> Dijkstra(int sourceNode)
        {
            int[] previous = new int[graph.Count];
            bool[] visited = new bool[graph.Count];
            var priorityQueue = new MaxHeap<Node>();

            var startNode = nodes[sourceNode];
            startNode.Reliability = 100;
            for (int i = 0; i < previous.Length; i++)
            {
                previous[i] = -1;
            }

            visited[startNode.Index] = true;
            priorityQueue.Insert(startNode);
            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMax();
                if (currentNode.Index == destinationNode)
                {
                    break; 
                }

                foreach (var node in graph[currentNode])
                {
                    if (!visited[node.Key.Index])
                    {
                        priorityQueue.Insert(node.Key);
                        visited[node.Key.Index] = true;

                        var reliability = (currentNode.Reliability * node.Value) / 100;
                        if (reliability > node.Key.Reliability)
                        {
                            node.Key.Reliability = reliability;
                            previous[node.Key.Index] = currentNode.Index;
                            priorityQueue.Reorder(node.Key);
                        }
                    }
                }
            }

            if (previous[destinationNode] == -1)
            {
                return null;
            }

            List<int> path = ReconstructPath(destinationNode, previous);
            return path;
        }

        private static List<int> ReconstructPath(int destinationNode, int[] previous)
        {
            List<int> path = new List<int>();
            int current = destinationNode;
            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }
}











//using System;
//using System.Collections.Generic;
//using System.Linq;

//public class MostReliablePath
//{
//    public static void Main()
//    {
//        int nodes = int.Parse(Console.ReadLine().Substring(7));
//        string line = Console.ReadLine();
//        string[] pathString = line
//            .Substring(line.IndexOf(' '))
//            .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
//        int pathStart = int.Parse(pathString[0]);
//        int pathEnd = int.Parse(pathString[1]);
//        int edgesCount = int.Parse(Console.ReadLine().Substring(7));

//        int[] previous = new int[nodes];
//        bool[] visited = new bool[nodes];
//        List<Node> graph = new List<Node>();

//        for (int i = 0; i < nodes; i++)
//        {
//            graph.Add(new Node(i, -1));
//        }

//        for (int i = 0; i < edgesCount; i++)
//        {
//            string[] parameters = Console.ReadLine().Split();
//            int start = int.Parse(parameters[0]);
//            int end = int.Parse(parameters[1]);
//            double reliability = double.Parse(parameters[2]);
//            Edge edge = new Edge(start, end, reliability);
//            Edge reverseEdge = new Edge(end, start, reliability);

//            graph[start].Edges.Add(edge);
//            graph[end].Edges.Add(reverseEdge);
//        }

//        Dijkstra(pathStart, pathEnd, visited, graph, previous);
//        List<int> result = ReconstructPath(previous, pathStart, pathEnd, graph);
//        Console.WriteLine("Most reliable path reliability: {0:0.00}", graph[pathEnd].Reliability);
//        Console.WriteLine(result.Count > 0 ? string.Join(" -> ", result) : "Unreachable");
//    }

//    private static void Dijkstra(int node, int end, bool[] visited, List<Node> graph, int[] previous)
//    {
//        graph[node].Reliability = 100;
//        var priorityQueue = new MaxHeap<Node>();
//        priorityQueue.Insert(graph[node]);
//        visited[node] = true;

//        while (priorityQueue.Count > 0)
//        {
//            Node currentNode = priorityQueue.ExtractMax();
//            if (currentNode.Value == end)
//            {
//                break;
//            }

//            foreach (var edge in currentNode.Edges)
//            {
//                // Dijkstra with priority queue is faster, because we can save the need to check edges leading to already traversed elements,
//                // this comes from the fact that by always taking the shortest total distance possible, when we step on a node there is no shorter 
//                // path to it from an already traversed node
//                if (!visited[edge.Child])
//                {
//                    priorityQueue.Insert(graph[edge.Child]);
//                    visited[edge.Child] = true;

//                    double currentReliability = (currentNode.Reliability * edge.Weight) / 100;
//                    if (graph[edge.Child].Reliability < currentReliability)
//                    {
//                        graph[edge.Child].Reliability = currentReliability;
//                        previous[edge.Child] = edge.Parent;
//                        priorityQueue.Reorder(graph[edge.Child]);
//                    }
//                }
//            }
//        }
//    }

//    private static List<int> ReconstructPath(int[] previous, int start, int end, List<Node> graph)
//    {
//        if (graph[end].Reliability < 0)
//        {
//            return new List<int>();
//        }

//        List<int> path = new List<int>();
//        path.Add(end);
//        while (end != start)
//        {
//            path.Add(previous[end]);
//            end = previous[end];
//        }

//        path.Reverse();
//        return path;
//    }
//}

//public class Edge : IComparable<Edge>
//{
//    public Edge(int parent, int child, double weight)
//    {
//        this.Parent = parent;
//        this.Child = child;
//        this.Weight = weight;
//    }

//    public int Parent { get; set; }

//    public int Child { get; set; }

//    public double Weight { get; set; }

//    public int CompareTo(Edge other)
//    {
//        return this.Weight.CompareTo(other.Weight);
//    }

//    public override string ToString()
//    {
//        return string.Format("({0} {1}) -> {2}", this.Parent, this.Child, this.Weight);
//    }
//}

//public class Node : IComparable<Node>
//{
//    public Node(int value, double reliability)
//    {
//        this.Value = value;
//        this.Edges = new List<Edge>();
//        this.Reliability = reliability;
//    }

//    public int Value { get; set; }

//    public double Reliability { get; set; }

//    public List<Edge> Edges { get; private set; }

//    public int CompareTo(Node other)
//    {
//        return this.Reliability.CompareTo(other.Reliability);
//    }
//}