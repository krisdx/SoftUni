namespace Kurskal
{
    using System;
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();

            int[] parent = new int[numberOfVertices];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }

            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                var startNodeParent = FindRoot(edge.StartNode, parent);
                var endNodeParent = FindRoot(edge.EndNode, parent);
                if (startNodeParent != endNodeParent)
                {
                    spanningTree.Add(edge);
                    parent[endNodeParent] = startNodeParent;
                }
            }

            return spanningTree;
        }

        // Iterative way 
        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Path compression
            while (root != node)
            {
                int currentRoot = parent[node];
                parent[node] = root;
                node = currentRoot;
            }

            return root;
        }

        //// Recursive way with path compression
        //public static int FindRoot(int node, int[] parent)
        //{
        //    int currentParent = parent[node];
        //    if (node == currentParent)
        //    {
        //        return currentParent;
        //    }

        //    parent[node] = FindRoot(currentParent, parent);
        //    return parent[node];
        //}
    }
}