using System;
using System.Linq;

class BTreeExample
{
    public static void Main()
    {
        var tree = new BTree<int, string>(3);
        Console.WriteLine("The B-tree created.");

        var nums = new[] { 5, 20, -14, 11, 8, -3, 1, 5, 22, 148, 6, 12, 23 };
        for (int i = 0; i < nums.Length; i++)
        {
            AddNumber(tree, nums[i], "value" + nums[i]);
        }
    }

    public static void AddNumber(BTree<int, string> tree, int key, string value)
    {
        tree.Insert(key, value);
        Console.WriteLine("Added: " + key);
        
        DisplayTree(tree.Root, string.Empty);
        Console.WriteLine("----------------------");
    }

    private static void DisplayTree(Node<int, string> node, string intend)
    {
        Console.WriteLine(intend + string.Join(", ", node.Entries.Select(e => e.Key)));
        foreach (var child in node.Children)
        {
            DisplayTree(child, intend + "  ");
        }
    }
}
