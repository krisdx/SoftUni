using System;
using System.Collections.Generic;
using System.Linq;

// Modify the program you wrote for the previous problem to print the results in the following way: each line should contain the operands (numbers that form the desired sum) in ascending order; the lines containing fewer operands should be printed before those with more operands; when two lines have the same number of operands, the one containing the smallest operand should be printed first. If two or more lines contain the same number of operands and have the same smallest operand, the order of printing is not important. 

class SortedSubsetSums
{
    static void Main()
    {
        int targetSum = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).Distinct().ToArray();

        List<List<int>> allSubsets = new List<List<int>>();
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
            currentSubset.Sort();

            if (currentSubset.Sum() != targetSum)
            {
                continue;
            }

            allSubsets.Add(currentSubset);
            //Console.WriteLine("{0} = {1}", string.Join(" + ", currentSubset), targetSum);
            solutionFound = true;
        }

        if (!solutionFound)
        {
            Console.WriteLine("No matching subsets.");
            return;
        }

        allSubsets = 
            allSubsets.OrderBy(set => set.Count)
            .ThenBy(set => set.First())
            .ToList();

        allSubsets.ForEach(set => Console.WriteLine("{0} = {1}", string.Join(" + ", set), targetSum));
    }
}