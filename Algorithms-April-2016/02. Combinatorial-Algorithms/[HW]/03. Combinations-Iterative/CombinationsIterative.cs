namespace CombinationsIterative
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinationsIterative
    {
        private static int[] combination;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            combination = new int[k];
            for (int num = 1; num <= k; num++)
            {
                int index = num - 1;
                combination[index] = num;
            }

            GenerateCombinations(n, k);
        }

        private static void GenerateCombinations(int n, int k)
        {
            while (true)
            {
                Print();
                if (combination[0] + k > n)
                {
                    break;
                }

                int currentDigitIndex = k - 1;
                combination[currentDigitIndex]++;

                while (combination[currentDigitIndex] + (k - 1 - currentDigitIndex) > n)
                {
                    currentDigitIndex--;
                    combination[currentDigitIndex]++;
                }

                for (int i = currentDigitIndex + 1; i < k; i++)
                {
                    combination[i] = combination[i - 1] + 1;
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(" ", combination));
        }
    }
}