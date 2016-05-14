namespace LongestZigzagSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        public static void Main()
        {
            // int[] numbers = new int[] { 8, 3, 5, 7, 0, 8, 9, 10, 20, 20, 20, 12, 19, 11 };
            int[] numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            int[] evenLengths = new int[numbers.Length];
            int[] evenPrevious = new int[numbers.Length];
            int[] oddLengths = new int[numbers.Length];
            int[] oddPrevious = new int[numbers.Length];

            int maxLen = int.MinValue;
            int lasIndex = int.MinValue;
            bool evenOddApproach = false;
            for (int i = 0; i < numbers.Length; i++)
            {
                evenLengths[i] = 1;
                evenPrevious[i] = -1;
                oddLengths[i] = 1;
                oddPrevious[i] = -1;
                for (int j = 0; j < i; j++)
                {
                    if (evenLengths[j] + 1 > evenLengths[i])
                    {
                        if ((evenLengths[j] % 2 == 0 && numbers[i] < numbers[j]) ||
                            (evenLengths[j] % 2 == 1 && numbers[i] > numbers[j]))
                        {
                            evenLengths[i] = evenLengths[j] + 1;
                            evenPrevious[i] = j;
                        }
                    }

                    if (oddLengths[j] + 1 > oddLengths[i])
                    {
                        if ((oddLengths[j] % 2 == 0 && numbers[i] > numbers[j]) ||
                            (oddLengths[j] % 2 == 1 && numbers[i] < numbers[j]))
                        {
                            oddLengths[i] = oddLengths[j] + 1;
                            oddPrevious[i] = j;
                        }
                    }
                }

                if (evenLengths[i] > maxLen)
                {
                    maxLen = evenLengths[i];
                    lasIndex = i;
                    evenOddApproach = true;
                }
                if (oddLengths[i] > maxLen)
                {
                    maxLen = oddLengths[i];
                    lasIndex = i;
                    evenOddApproach = false;
                }
            }

            // Retrace sequence
            var longestCommonSubsequence = new List<int>();
            if (evenOddApproach)
            {
                while (lasIndex != -1)
                {
                    longestCommonSubsequence.Add(numbers[lasIndex]);
                    lasIndex = evenPrevious[lasIndex];
                }
            }
            else
            {
                while (lasIndex != -1)
                {
                    longestCommonSubsequence.Add(numbers[lasIndex]);
                    lasIndex = oddPrevious[lasIndex];
                }
            }

            longestCommonSubsequence.Reverse();
            Console.WriteLine(string.Join(", ", longestCommonSubsequence));
        }
    }
}