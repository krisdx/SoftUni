using System;
using System.Linq;

public class VariationsNoRepsSlow
{
    private const int n = 10;
    private const int k = 2;
    private static string[] objects = new string[n]
    {
        "banana", "apple", "orange", "strawberry", "raspberry",
        "apricot", "cherry", "lemon", "grapes", "melon"
    };
    static int[] arr = new int[k];
    static bool[] used = new bool[n];

    public static void Main()
    {
        GenerateVariationsNoRepetitions(0);
    }

    static void GenerateVariationsNoRepetitions(int index)
    {
        if (index >= k)
        {
            PrintVariations();
            return;
        }

        for (int num = 0; num < n; num++)
        {
            if (!used[num])
            {
                used[num] = true;
                arr[index] = num;
                GenerateVariationsNoRepetitions(index + 1);
                used[num] = false;
            }
        }
    }

    static void PrintVariations()
    {
        Console.WriteLine("({0}) --> ({1})",
            string.Join(", ", arr),
            string.Join(", ", arr.Select(i => objects[i])));
    }
}