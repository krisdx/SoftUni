using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visited;
    private LinkedList<string> sortedNodes;
    private HashSet<string> cycleNodes;    

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        this.visited = new HashSet<string>();
        this.sortedNodes = new LinkedList<string>();
        this.cycleNodes = new HashSet<string>();

        foreach (var node in this.graph.Keys)
        {
            TopSortDFS(node);
        }

        return sortedNodes;
    }

    private void TopSortDFS(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        if (!this.visited.Contains(node))
        {
            this.visited.Add(node);
            this.cycleNodes.Add(node);

            if (this.graph.ContainsKey(node))
            {
                foreach (var vertex in this.graph[node])
                {
                    TopSortDFS(vertex);
                }
            }

            this.sortedNodes.AddFirst(node);
            this.cycleNodes.Remove(node);
        }
    }

    //public ICollection<string> TopSort()
    //{
    //    var predecessors = FindPredecessorCount();
    //    //foreach (var node in dictionary)
    //    //{
    //    //    Console.WriteLine("{0} -> {1} predecessors", node.Key, node.Value);
    //    //}

    //    var removedNodes = new List<string>();
    //    while (true)
    //    {
    //        string nodeToRemove = this.graph.Keys.FirstOrDefault(node => predecessors[node] == 0);
    //        if (nodeToRemove == null)
    //        {
    //            break;
    //        }

    //        foreach (var node in this.graph[nodeToRemove])
    //        {
    //            predecessors[node]--;
    //        }

    //        this.graph.Remove(nodeToRemove);
    //        removedNodes.Add(nodeToRemove);
    //    }

    //    if (graph.Count > 0)
    //    {
    //        throw new InvalidOperationException("A cycle detected in the graph");
    //    }

    //    return removedNodes;
    //}

    private Dictionary<string, int> FindPredecessorCount()
    {
        var dictionary = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!dictionary.ContainsKey(node.Key))
            {
                dictionary[node.Key] = 0;
            }

            foreach (var successor in node.Value)
            {
                if (!dictionary.ContainsKey(successor))
                {
                    dictionary[successor] = 0;
                }

                dictionary[successor]++;
            }
        }

        return dictionary;
    }
}