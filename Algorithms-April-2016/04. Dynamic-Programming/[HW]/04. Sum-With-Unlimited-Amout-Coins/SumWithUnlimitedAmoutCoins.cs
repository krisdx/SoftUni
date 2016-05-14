namespace SumWithUnlimitedAmoutCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumWithUnlimitedAmoutCoins
    {
        public static void Main()
        {
            int targetSum = 6;
            int[] coins = new int[] { 1, 2, 3 ,4,6};

            int[,] matrix = new int[coins.Length, targetSum + 1];

            Console.WriteLine(NumberOfSolutionsOnSpace(coins, targetSum));
            PrintActualSolution(new List<int>(), targetSum, coins,0);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);

                }
                Console.WriteLine();
            }
        }

        public static int NumberOfSolutions(int[] coins, int targetSum)
        {
            int[,] matrix = new int[coins.Length + 1, targetSum + 1];
            for (int i = 0; i <= coins.Length; i++)
            {
                matrix[i, 0] = 1;
            }

            for (int coinIndex = 1; coinIndex <= coins.Length; coinIndex++)
            {
                int currentCoin = coins[coinIndex - 1];
                for (int sum = 1; sum <= targetSum; sum++)
                {
                    if (currentCoin > sum)
                    {
                        matrix[coinIndex, sum] = matrix[currentCoin, sum];
                    }
                    else
                    {
                        matrix[coinIndex, sum] =
                            // The number of ways we can get the sum 
                            // after subtracting the current coin from it
                            matrix[coinIndex, sum - currentCoin] +
                            // The number of ways we can get the current sum 
                            // without the current coin
                            matrix[currentCoin, sum];
                    }
                }
            }

            Print(matrix);
            return matrix[coins.Length, targetSum];
        }

        // Space efficient DP solution
        public static int NumberOfSolutionsOnSpace(int[] coins, int targetSum)
        {
            int[] result = new int[targetSum + 1];

            result[0] = 1;
            for (int i = 0; i < coins.Length; i++)
            {
                int currentCoin = coins[i];
                for (int sum = 1; sum <= targetSum; sum++)
                {
                    if (sum >= currentCoin)
                    {
                        result[sum] += result[sum - currentCoin];
                    }
                }
            }

            return result[targetSum];
        }

        private static void PrintActualSolution(List<int> result, int total, int[] coins, int pos)
        {
            if (total == 0)
            {
                Console.WriteLine(string.Join("+", result));
            }

            for (int i = pos; i < coins.Length; i++)
            {
                if (total >= coins[i])
                {
                    result.Add(coins[i]);
                    PrintActualSolution(result, total - coins[i], coins, i);
                    result.RemoveAt(result.Count - 1);
                }
            }
        }
    }
}