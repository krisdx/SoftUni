using System;

class RedBlackTreeExample
{
    public static void Main()
    {
        var tree = new RedBlackTree<int>();
        Console.WriteLine("The red-black tree created.");

        AddNumber(tree, 5);
        AddNumber(tree, 20);
        AddNumber(tree, 14);
        AddNumber(tree, 11);
        AddNumber(tree, 8);
        AddNumber(tree, 3);
        AddNumber(tree, 1);
        AddNumber(tree, 5);
    }

    public static void AddNumber(RedBlackTree<int> tree, int number)
    {
        tree.Insert(number);
        Console.WriteLine("Added " + number);
        DisplayTree(tree.RootNode, string.Empty);
        Console.WriteLine("----------------------");
    }

    private static void DisplayTree(
        RedBlackTree<int>.RedBlackNode node, string intend)
    {
        Console.WriteLine(intend + node.NodeValue + "-" + node.Color);
        if (node.LeftNode != null)
        {
            DisplayTree(node.LeftNode, intend + "  ");
        }
        if (node.RightNode != null)
        {
            DisplayTree(node.RightNode, intend + "  ");
        }
    }
}
