namespace Longest_Increasing_Subsequence
{
    using System;
    using System.Collections.Generic;

    public class LongestIncreasingSubsequence
    {
        public static void Main()
        {
            var sequence = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            var longestSeq = FindLongestIncreasingSubsequence(sequence);
            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", longestSeq.Length);
            Console.WriteLine("  Sequence: [{0}]", string.Join(", ", longestSeq));
        }

        public static int[] FindLongestIncreasingSubsequence(int[] sequence)
        {
            int[] lengths = new int[sequence.Length];
            int[] prev = new int[sequence.Length];

            int maxLength = 0;
            int lastIndex = -1;
            for (int currentIndex = 0; currentIndex < sequence.Length; currentIndex++)
            {
                lengths[currentIndex] = 1;
                prev[currentIndex] = -1;
                for (int prevIndex = currentIndex - 1; prevIndex >= 0; prevIndex--)
                {
                    if (sequence[prevIndex] < sequence[currentIndex] &&
                        lengths[prevIndex] + 1 >= lengths[currentIndex]) 
                    {
                        lengths[currentIndex] = lengths[prevIndex] + 1;
                        prev[currentIndex] = prevIndex;
                    }
                }

                if (lengths[currentIndex] > maxLength)
                {
                    maxLength = lengths[currentIndex];
                    lastIndex = currentIndex;
                }
            }

            var longestSubSequence = new List<int>();
            while (lastIndex != -1)
            {
                longestSubSequence.Add(sequence[lastIndex]);
                lastIndex = prev[lastIndex];
            }

            longestSubSequence.Reverse();
            return longestSubSequence.ToArray();
        }
    }
}