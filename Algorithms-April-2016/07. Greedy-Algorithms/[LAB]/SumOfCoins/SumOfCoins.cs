namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main()
        {
            var availableCoins = new int[] { 1, 9, 10 };
            var targetSum = 27;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine("Number of coins to take: {0}", selectedCoins.Values.Sum());
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine("{0} coin(s) with value {1}", selectedCoin.Value, selectedCoin.Key);
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, long targetSum)
        {
            Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

            coins = coins.OrderBy(coin => coin)
                .ToList();

            long remainingSum = targetSum;
            for (int i = coins.Count - 1; i >= 0; i--)
            {
                if (remainingSum == 0)
                {
                    // Found a solution
                    break;
                }

                int currentCoin = coins[i];
                int takeCount = (int)(remainingSum / currentCoin);
                int currentCoinSum = takeCount * currentCoin;
                remainingSum -= currentCoinSum;
                if (remainingSum < 0)
                {
                    // The current coin will not produce a result.
                    remainingSum += currentCoinSum;
                    continue;
                }

                if (takeCount != 0)
                {
                    selectedCoins[coins[i]] = takeCount;
                }
            }

            if (remainingSum != 0)
            {
                throw new InvalidOperationException("No solution");
            }

            return selectedCoins;
        }

        public static Dictionary<int, int> ChooseCoinsSlow(IList<int> coins, long targetSum)
        {
            Dictionary<int, int> selectedCoins = new Dictionary<int, int>();

            coins = coins.OrderBy(coin => coin)
                .ToList();

            long currentSum = 0;
            int index = coins.Count - 1;
            while (currentSum < targetSum)
            {
                if (currentSum == targetSum)
                {
                    // Found a solution.
                    break;
                }

                if (!selectedCoins.ContainsKey(coins[index]))
                {
                    selectedCoins.Add(coins[index], 0);
                }

                selectedCoins[coins[index]]++;
                currentSum += coins[index];
                if (currentSum > targetSum)
                {
                    selectedCoins[coins[index]]--;
                    if (selectedCoins[coins[index]] == 0)
                    {
                        selectedCoins.Remove(coins[index]);
                    }

                    currentSum -= coins[index];
                    index--;
                    if (index < 0)
                    {
                        throw new InvalidOperationException("No solution");
                    }
                }
            }

            return selectedCoins;
        }
    }
}