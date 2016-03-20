using System;
using System.Collections.Generic;
using System.Linq;

class LinearAndBinarySearch
{
    static void Main()
    {
       int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        int numberToSearch = int.Parse(Console.ReadLine());

        int binarySearchIndex = BinarySearch(numbers, numberToSearch);
        Console.WriteLine(binarySearchIndex);
    }

    static int BinarySearch(int[] numbers, int numberToSearch)
    {
        Array.Sort(numbers);

        int startIndex = 0;
        int endIndex = numbers.Length - 1;
        int middleIndex = numbers.Length / 2;
        while (true)
        {
            if (numbers[middleIndex] == numberToSearch)
            {
                return middleIndex;
            }
            else if (numbers[middleIndex] < numberToSearch)
            {
                startIndex = middleIndex + 1;
            }
            else if (numbers[middleIndex] > numberToSearch)
            {
                endIndex = middleIndex - 1;
            }

            middleIndex = (startIndex + endIndex) / 2;
            if (middleIndex == 0)
            {
                break;
            }
        }

        return -1;
    }
}