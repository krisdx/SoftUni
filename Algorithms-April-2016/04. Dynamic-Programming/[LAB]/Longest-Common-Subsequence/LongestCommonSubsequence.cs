namespace Longest_Common_Subsequence
{
    using System;
    using System.Collections.Generic;
    public class LongestCommonSubsequence
    {
        public static void Main()
        {
            var firstStr = "tree";
            var secondStr = "team";

            var lcs = FindLongestCommonSubsequence(firstStr, secondStr);

            Console.WriteLine("Longest common subsequence:");
            Console.WriteLine("  first  = {0}", firstStr);
            Console.WriteLine("  second = {0}", secondStr);
            Console.WriteLine("  lcs    = {0}", lcs);
        }

        public static string FindLongestCommonSubsequence(string firstStr, string secondStr)
        {
            int[,] memo = new int[firstStr.Length + 1, secondStr.Length + 1];
            for (int firstStrIndex = 1; firstStrIndex < memo.GetLength(0); firstStrIndex++)
            {
                for (int secondStrIndex = 1; secondStrIndex < memo.GetLength(1); secondStrIndex++)
                {
                    if (firstStr[firstStrIndex - 1] == secondStr[secondStrIndex - 1])
                    {
                        memo[firstStrIndex, secondStrIndex] =
                            memo[firstStrIndex - 1, secondStrIndex - 1] + 1;
                    }
                    else
                    {
                        memo[firstStrIndex, secondStrIndex] =
                            Math.Max(memo[firstStrIndex - 1, secondStrIndex], memo[firstStrIndex, secondStrIndex - 1]);
                    }
                }
            }

            return RetriveLCS(firstStr, secondStr, memo);
        }

        private static string RetriveLCS(string firstStr, string secondStr, int[,] memo)
        {
            var sequence = new List<char>();

            int firstStrIndex = memo.GetLength(0) - 1;
            int secondStrIndex = memo.GetLength(1) - 1;
            while (firstStrIndex > 0 && secondStrIndex > 0)
            {
                if (firstStr[firstStrIndex - 1] == secondStr[secondStrIndex - 1])
                {
                    sequence.Add(firstStr[firstStrIndex - 1]);
                    firstStrIndex--;
                    secondStrIndex--;
                }
                else if (memo[firstStrIndex, secondStrIndex] == memo[firstStrIndex - 1, secondStrIndex])
                {
                    firstStrIndex--;
                }
                else
                {
                    secondStrIndex--;
                }
            }

            sequence.Reverse();
            return new string(sequence.ToArray());
        }
    }
}