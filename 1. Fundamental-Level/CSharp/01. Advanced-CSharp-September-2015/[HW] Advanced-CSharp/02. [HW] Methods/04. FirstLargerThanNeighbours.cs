using System;
using System.Collections.Generic;
using System.Linq;

// Write a method that returns the index of the first element in array that is larger than its neighbours, or -1 if there's no such element. Use the method from the previous exercise in order to re.

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        Console.WriteLine(GetIndexOfFirstElementLargerThanNeighbours(numbers));
    }

    private static int GetIndexOfFirstElementLargerThanNeighbours(int[] numbers)
    {
        int index = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            bool hasRightNeighbour = i + 1 < numbers.Length;
            bool hasLeftNeighnour = i - 1 >= 0;

            if (hasLeftNeighnour && hasRightNeighbour)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
                {
                    index = i;                   
                }
            }
        }

        if (index == 0)
        {
            return -1;
        }

        return index;
    }
}