using System;
using System.Collections.Generic;
using System.Linq;

class InsertionSort
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i - 1] > numbers[i])
            {
                ShiftAndInsert(numbers, i);
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }

    static void ShiftAndInsert(List<int> numbers, int currentIndex)
    {
        int previousIndex = currentIndex - 1;

        while (numbers[previousIndex] > numbers[currentIndex])
        {
            int swapValue = numbers[previousIndex];
            numbers[previousIndex] = numbers[currentIndex];
            numbers[currentIndex] = swapValue;
            if (previousIndex - 1 >= 0)
            {
                previousIndex--;
                currentIndex--;
            }
        }
    }
}