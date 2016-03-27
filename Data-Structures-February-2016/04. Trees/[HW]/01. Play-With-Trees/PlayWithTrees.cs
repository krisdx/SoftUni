namespace PlayWithTrees
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        private static readonly List<Tree> currentPath = new List<Tree>();

        private static readonly List<List<Tree>> allPathsWithGivenSum = new List<List<Tree>>();
        private static readonly List<List<Tree>> allSubtreesWithGivenSum = new List<List<Tree>>();

        private static int pathSum;
        private static int subtreeSum;

        public static void Main()
        {
            Tree tree = null;

            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split();

                int parentValue = int.Parse(edge[0]);
                if (tree == null)
                {
                    tree = new Tree(parentValue);
                }
                var parentNode = tree.GetTreeNodeByValue(parentValue);

                int childValue = int.Parse(edge[1]);
                var childNode = tree.GetTreeNodeByValue(childValue);

                tree.AddChild(childNode, parentNode);
            }

            pathSum = int.Parse(Console.ReadLine());
            subtreeSum = int.Parse(Console.ReadLine());

            Console.WriteLine("Root node: " + tree.RootNode().Value);

            Console.Write("Leaf nodes: ");
            var leafNodes = tree.GetLeafNodes();
            foreach (var leafNode in leafNodes)
            {
                Console.Write(leafNode.Value + " ");
            }
            Console.WriteLine();

            Console.Write("Middle nodes: ");
            var middleNodes = tree.GetMiddleNodes();
            foreach (var middleNode in middleNodes)
            {
                Console.Write(middleNode.Value + " ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Longest Path: ");
            var longestPath = tree.FindLongestPath();
            Console.Write(string.Join(" -> ", longestPath));
            Console.WriteLine(" (length = {0})", longestPath.Count);
            Console.WriteLine();

            Console.WriteLine("Paths with sum {0}: ", pathSum);
            GetPathsWithGivenSum(tree.RootNode());
            foreach (var path in allPathsWithGivenSum)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
            Console.WriteLine();

            Console.WriteLine("Subtrees of sum {0}:", subtreeSum);
            GetSubtreesWithGivenSum(tree.RootNode());
            foreach (var path in allSubtreesWithGivenSum)
            {
                Console.WriteLine(string.Join(" + ", path));
            }
        }

        private static void GetPathsWithGivenSum(Tree currentNode)
        {
            currentPath.Add(currentNode);
            foreach (var child in currentNode.Children)
            {
                GetPathsWithGivenSum(child);
            }

            var currentPathSum = currentPath.Sum(node => node.Value);
            if (currentPathSum == pathSum)
            {
                allPathsWithGivenSum.Add(new List<Tree>(currentPath));
            }

            currentPath.Remove(currentNode);
        }

        private static void GetSubtreesWithGivenSum(Tree currentNode)
        {
            foreach (var child in currentNode.Children)
            {
                var childSubTree = GetSubtree(child);
                if (childSubTree.Sum(node => node.Value) == subtreeSum)
                {
                    allSubtreesWithGivenSum.Add(new List<Tree>(childSubTree));
                }
            }
        }

        private static List<Tree> GetSubtree(Tree currentNode)
        {
            var currentPath = new List<Tree> { currentNode };

            foreach (var child in currentNode.Children)
            {
                var childSubtree = GetSubtree(child);
                currentPath.AddRange(childSubtree);
            }

            return currentPath;
        }
    }
}