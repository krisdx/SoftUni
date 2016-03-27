using System;

class AvlTreeExample
{
    public static void Main()
    {
        var avlTree = new AvlTree<int>();
        avlTree.Add(10);
        avlTree.Add(5); 
        avlTree.Add(20);
        avlTree.Add(4);
        avlTree.Add(15);
        avlTree.Add(50);
        avlTree.Add(55);
        avlTree.Add(100);

        //AddNumber(binaryTree, 5);
        //AddNumber(binaryTree, 20);
        //AddNumber(binaryTree, 14);
        //AddNumber(binaryTree, 11);
        //AddNumber(binaryTree, 8);
        //AddNumber(binaryTree, 3);
        //AddNumber(binaryTree, 1);
            
        //binaryTree.Remove(5);
        //Console.WriteLine("Deleted 5");

        //Traverse(binaryTree.Root, "");
        //Console.WriteLine("----------------------");
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
