using System;

public class PermutationsGenerator
{
    public static void Main()
    {
        string[] arr = { "apple", "banana", "orange" };
        GeneratePermutations(arr, 0);
    }

    private static void GeneratePermutations<T>(T[] arr, int startIndex)
    {
        if (startIndex >= arr.Length)
        {
            Print(arr);
            return;
        }

        for (int currentIndex = startIndex; currentIndex < arr.Length; currentIndex++)
        {
            Swap(ref arr[startIndex], ref arr[currentIndex]);
            GeneratePermutations(arr, startIndex + 1);
            Swap(ref arr[startIndex], ref arr[currentIndex]);
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

    private static void Print<T>(T[] arr)
    {
        Console.WriteLine("(" + string.Join(", ", arr) + ")");
    }
}