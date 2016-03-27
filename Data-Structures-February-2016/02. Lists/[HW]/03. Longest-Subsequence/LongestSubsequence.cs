namespace LongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestSubsequence
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Trim()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> longestSubsequenceOfEqualElements = GetLongestSubsequenceOfEqualElements(numbers);
            Console.WriteLine(string.Join(" ", longestSubsequenceOfEqualElements));
        }

        private static List<int> GetLongestSubsequenceOfEqualElements(List<int> numbers)
        {
            List<int> longestSubsequenceOfEqualElements = new List<int>();

            int maxSubseuqnceCount = 0;
            int maxSubseuqnceStartIndex = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentSubsequnceCount = 0;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] != numbers[j])
                    {
                        break;
                    }

                    currentSubsequnceCount++;
                    if (currentSubsequnceCount > maxSubseuqnceCount)
                    {
                        maxSubseuqnceCount = currentSubsequnceCount;
                        maxSubseuqnceStartIndex = i;
                    }
                }
            }

            int indexIndex = maxSubseuqnceStartIndex + maxSubseuqnceCount;
            for (int index = maxSubseuqnceStartIndex; index <= indexIndex; index++)
            {
                longestSubsequenceOfEqualElements.Add(numbers[index]);
            }

            return longestSubsequenceOfEqualElements;
        }
    }
}