using System;
using System.Collections.Generic;
using System.Linq;

// Write a program to find all increasing sequences inside an array of integers. The integers are given on a single line, separated by a space. Print the sequences in the order of their appearance in the input array, each at a single line. Separate the sequence elements by a space. Find also the longest increasing sequence and print it at the last line. If several sequences have the same longest length, print the left-most of them. 

class LongestIncreasingSequence
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToList();

        PrintIncreasingSequences(numbers);
        PrintLongestIncreasingSequence(numbers);
    }

    private static void PrintIncreasingSequences(List<int> numbers)
    {
        numbers.Add(numbers.Last());
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
            {
                Console.Write(numbers[i] + " ");
            }
            else
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }

    private static void PrintLongestIncreasingSequence(List<int> numbers)
    {
        List<int> longestSequence = new List<int>();
        List<int> currentSequence = new List<int>();
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            if (numbers[i] < numbers[i + 1])
            {
                currentSequence.Add(numbers[i]);
            }
            else
            {
                currentSequence.Add(numbers[i]);
                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence = currentSequence.ToList();
                }
                currentSequence.Clear();
            }
        }

        Console.WriteLine("Longest: {0}", string.Join(" ", longestSequence));
    }
}