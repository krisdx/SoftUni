using System;
using System.Linq;

// Write a method that checks if the element at given position in a given array of integers is larger than its two neighbours (when such exist).

class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLatgerThanNeighbours(numbers, i));
        }
    }

    private static bool IsLatgerThanNeighbours(int[] numbers, int index)
    {
        bool isBiggerThanNeighbours = false;

        bool hasRightNeighbour = index + 1 < numbers.Length;
        bool hasLeftNeighnour = index - 1 >= 0;
        if (hasLeftNeighnour && !hasRightNeighbour)
        {
            if (numbers[index - 1] < numbers[index])
            {
                isBiggerThanNeighbours = true;
            }
        }
        else if (!hasLeftNeighnour && hasRightNeighbour)
        {
            if (numbers[index] > numbers[index + 1])
            {
                isBiggerThanNeighbours = true;
            }
        }
        else if (hasLeftNeighnour && hasRightNeighbour)
        {
            if (numbers[index] > numbers[index + 1] && numbers[index] > numbers[index - 1])
            {
                isBiggerThanNeighbours = true;
            }
        }

        return isBiggerThanNeighbours; 
    }
}