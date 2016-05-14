namespace SumWithLimitedAmoutCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumWithLimitedAmoutCoins
    {
        private static int result;

        public static void Main()
        {
            int targetSum = 13;
            int[] coins = new int[] { 1, 2, 2, 5, 5, 10 };

            GenerateSubsetSums(coins, targetSum);
            Console.WriteLine(result);
        }

        private static void GenerateSubsetSums(int[] coins, int targetSum)
        {
            var possibleSums = new HashSet<int>();

            possibleSums.Add(0);
            for (int i = 0; i < coins.Length; i++)
            {
                var currentSums = new HashSet<int>();
                foreach (var sum in possibleSums)
                {
                    int newSum = sum + coins[i];
                    if (!possibleSums.Contains(newSum))
                    {
                        currentSums.Add(newSum);
                    }

                    if (newSum == targetSum)
                    {
                        result++;
                    }
                }

                foreach (var sum in currentSums)
                {
                    possibleSums.Add(sum);
                }
            }
        }
    }
}