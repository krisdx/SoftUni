using System;

public class BinaryTreeExample
{
    public static void Main()
    {
        var binaryTree = new BinaryTree<int>();
        Console.WriteLine("The binary tree created.");

        AddNumber(binaryTree, 5);
        AddNumber(binaryTree, 20);
        AddNumber(binaryTree, 14);
        AddNumber(binaryTree, 11);
        AddNumber(binaryTree, 8);
        AddNumber(binaryTree, 3);
        AddNumber(binaryTree, 1);
        AddNumber(binaryTree, 5);
            
        binaryTree.Remove(5);
        Console.WriteLine("Deleted 5");

        Traverse(binaryTree.Root, "");
        Console.WriteLine("----------------------");
    }

    public static void AddNumber(BinaryTree<int> tree, int number)
    {
        tree.Add(number);
        Console.WriteLine("Added " + number);
        Traverse(tree.Root, "");
        Console.WriteLine("----------------------");
    }

    public static void Traverse(BinaryTreeNode<int> node, string intend)
    {
        Console.WriteLine(intend + node.Value);
        if (node.HasLeftChild)
        {
            Traverse(node.LeftChild, intend + "  ");
        }

        if (node.HasRightChild)
        {
            Traverse(node.RightChild, intend + "  ");
        }
    }
}
