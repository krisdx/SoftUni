using System;
using System.Linq;

// Write a program to sort an array of numbers and then print them back on the console. The numbers should be entered from the console on a single line, separated by a space.

// Note: Do not use the built-in sorting method, you should write your own. Use the selection sort algorithm. 

class SelectionSort
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        SelectionSortNumbers(numbers);

        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void SelectionSortNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int minValue = numbers[i];
            int swapPosition = 0;
            bool haveToSwap = false;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (minValue > numbers[j])
                {
                    minValue = numbers[j];
                    swapPosition = j;
                    haveToSwap = true;
                }
            }

            if (haveToSwap)
            {
                int swapValue = numbers[i];
                numbers[i] = numbers[swapPosition];
                numbers[swapPosition] = swapValue;
            }
        }
    }
}