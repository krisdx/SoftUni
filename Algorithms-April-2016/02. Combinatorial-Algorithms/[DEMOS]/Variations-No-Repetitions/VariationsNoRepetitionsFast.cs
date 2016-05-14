using System;

public class VariationsNoRepetitionsFast
{
    private const int n = 3;
    private const int k = 2;

    private static int[] arr = new int[k];
    private static int[] free = new int[n] { 1, 2, 3 };

    public static void Main()
    {
        GenerateVariationsNoRepetitions();
    }

    private static void GenerateVariationsNoRepetitions(int startIndex = 0)
    {
        if (startIndex >= k)
        {
            PrintVariations();
            return;
        }

        for (int currentIndex = startIndex; currentIndex < n; currentIndex++)
        {
            arr[startIndex] = free[currentIndex];
            Swap(ref free[startIndex], ref free[currentIndex]);
            GenerateVariationsNoRepetitions(startIndex + 1);
            Swap(ref free[startIndex], ref free[currentIndex]);
        }
    }

    private static void Swap(ref int firstNum, ref int secondNum)
    {
        int swapValue = firstNum;
        firstNum = secondNum;
        secondNum = swapValue;
    }

    private static void PrintVariations()
    {
        Console.WriteLine("(" + string.Join(", ", arr) + ")");
    }
}