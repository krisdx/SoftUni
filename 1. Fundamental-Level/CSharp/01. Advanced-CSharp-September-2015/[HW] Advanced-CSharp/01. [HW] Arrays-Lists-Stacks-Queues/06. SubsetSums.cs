using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads from the console a number N and an array of integers given on a single line. Your task is to find all subsets within the array which have a sum equal to N and print them on the console (the order of printing is not important). Find only the unique subsets by filtering out repeating numbers first. In case there aren't any subsets with the desired sum, print "No matching subsets." 

class SubsetSums
{
    static void Main()
    {
        int targetSum = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).Distinct().ToArray();

        PrintSubsets(targetSum, numbers);
    }

    private static void PrintSubsets(int targetSum, int[] numbers)
    {
        bool solutionFound = false;
        for (int mask = 1; mask < 1 << numbers.Length; mask++)
        {
            List<int> currentSubset = new List<int>();
            for (int bit = 0; bit < numbers.Length; bit++)
            {
                if ((mask >> bit & 1) == 1)
                {
                    currentSubset.Add(numbers[bit]);
                }
            }

            if (currentSubset.Sum() != targetSum)
            {
                continue;
            }

            Console.WriteLine("{0} = {1}", string.Join(" + ", currentSubset), targetSum);
            solutionFound = true;
        }

        if (!solutionFound)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}