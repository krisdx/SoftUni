namespace LongestPathInTree
{
    using System;
    using System.Collections.Generic;

    public class LongestPathInTree
    {
        private static Dictionary<int, List<int>> nodesWithChildren;
        private static Dictionary<int, int> nodesWithParents;

        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            nodesWithChildren = new Dictionary<int, List<int>>(numberOfNodes);
            nodesWithParents = new Dictionary<int, int>(numberOfNodes);

            int numberOfEdges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEdges; i++)
            {
                string[] edge = Console.ReadLine().Split();
                int parentValue = int.Parse(edge[0]);
                int childValue = int.Parse(edge[1]);

                if (!nodesWithChildren.ContainsKey(parentValue))
                {
                    nodesWithChildren.Add(parentValue, new List<int>());
                }
                nodesWithChildren[parentValue].Add(childValue);

                if (!nodesWithParents.ContainsKey(childValue))
                {
                    nodesWithParents.Add(childValue, parentValue);
                }
            }

            int rootValue = GetRoot();

            int leftChildOfRoot = nodesWithChildren[rootValue][0];
            int leftChildBiggestSum = GetPathWithBiggestSum(leftChildOfRoot);

            int rightChildOfRoot = nodesWithChildren[rootValue][1];
            int rightChildBiggestSum = GetPathWithBiggestSum(rightChildOfRoot);

            Console.WriteLine(leftChildBiggestSum + rootValue + rightChildBiggestSum);
        }

        private static int GetPathWithBiggestSum(int currentNode)
        {
            int bestPathSum = 0;

            if (nodesWithChildren.ContainsKey(currentNode))
            {
                foreach (var child in nodesWithChildren[currentNode])
                {
                    var currnetPathSum = GetPathWithBiggestSum(child);
                    if (currnetPathSum > bestPathSum)
                    {
                        bestPathSum = currnetPathSum;
                    }
                }
            }

            return bestPathSum + currentNode;
        }

        private static int GetRoot()
        {
            foreach (var parent in nodesWithChildren)
            {
                if (!nodesWithParents.ContainsKey(parent.Key))
                {
                    return parent.Key;
                }
            }

            return -1;
        }
    }
}