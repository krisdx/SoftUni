using System;
using System.Linq;

public class CombinationsGeneratorWithReps
{
    private const int k = 3;
    private const int n = 5;
    private static string[] objects = new string[n]
    {
        "banana", "apple", "orange", "strawberry", "raspberry"
    };
    private static int[] arr = new int[k];

    public static void Main()
    {
        GenerateCombinationsNoRepetitions(0, 0);
    }

    static void GenerateCombinationsNoRepetitions(int index, int start)
    {
        if (index >= k)
        {
            PrintCombinations();
            return;
        }

        for (int i = start; i < n; i++)
        {
            arr[index] = i;
            GenerateCombinationsNoRepetitions(index + 1, i);
        }
    }

    static void PrintCombinations()
    {
        Console.WriteLine("({0}) --> ({1})",
            string.Join(", ", arr),
            string.Join(", ", arr.Select(i => objects[i])));
    }
}