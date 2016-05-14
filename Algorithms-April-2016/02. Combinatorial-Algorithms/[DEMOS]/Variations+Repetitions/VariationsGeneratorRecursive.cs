using System;
using System.Linq;

public class VariationsGeneratorRecursive
{
    private const int k = 3;
    private const int n = 10;
    private static string[] objects = new string[n]
    {
        "banana", "apple", "orange", "strawberry", "raspberry",
        "apricot", "cherry", "lemon", "grapes", "melon"
    };
    static int[] arr = new int[k];

    public static void Main()
    {
        GenerateVariationsWithRepetitions(0);
    }

    static void GenerateVariationsWithRepetitions(int index)
    {
        if (index >= k)
        {
            PrintVariations();
            return;
        }

        for (int i = 0; i < n; i++)
        {
            arr[index] = i;
            GenerateVariationsWithRepetitions(index + 1);
        }
    }

    static void PrintVariations()
    {
        Console.WriteLine("({0}) --> ({1})",
            string.Join(", ", arr),
            string.Join(", ", arr.Select(i => objects[i])));
    }
}