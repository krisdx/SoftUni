namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DividingPresents
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
            .Split(',')
            .Select(int.Parse)
            .ToArray();

            int totalSum = FindSum(numbers);
            int median = totalSum / 2;
            var possibleSums = FindPossibleSubsetSums(numbers, median);

            int firstPersonSum = possibleSums.OrderByDescending(x => x.Key).First().Key;
            int secondPersonSum = totalSum - firstPersonSum;
            var firstPersonPresents = GetPresents(numbers, possibleSums, firstPersonSum);

            Console.WriteLine("Difference: {0}", Math.Abs(firstPersonSum- secondPersonSum));
            Console.WriteLine("Alan:{0} Bob:{1}", firstPersonSum, secondPersonSum);
            Console.WriteLine("Alan takes: {0}", string.Join(" ", firstPersonPresents));
            Console.WriteLine("Bob takes the rest.");
        }

        private static int FindSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static Dictionary<int, int> FindPossibleSubsetSums(int[] numbers, int targetSum)
        {
            var possibleSums = new Dictionary<int, int>();

            possibleSums.Add(0, 0);
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums)
                {
                    int newSum = sum.Key + numbers[i];
                    if (!possibleSums.ContainsKey(newSum) && newSum <= targetSum)
                    {
                        currentSums.Add(newSum, numbers[i]);
                    }
                }

                foreach (var sum in currentSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }

            return possibleSums;
        }

        private static List<int> GetPresents(int[] numbers, Dictionary<int, int> possibleSums, int targetSum)
        {
            var subset = new List<int>();
            while (targetSum > 0)
            {
                subset.Add(possibleSums[targetSum]);
                targetSum -= possibleSums[targetSum];
            }

            return subset;
        }
    }
}