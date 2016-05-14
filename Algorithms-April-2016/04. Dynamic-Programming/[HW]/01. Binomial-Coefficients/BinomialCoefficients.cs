namespace BinomialCoefficients
{
    using System;

    public class BinomialCoefficients
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n + 1];
            int[] secondArr = new int[n + 1];

            firstArr[0] = 1;
            secondArr[0] = 1;
            secondArr[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    CalculateRow(firstArr, secondArr, i);
                }
                else
                {
                    CalculateRow(secondArr, firstArr, i);
                }
            }

            if (n % 2 ==0)
            {
                Console.WriteLine(firstArr[k]);
            }
            else
            {
                Console.WriteLine(secondArr[k]);
            }
        }

        private static void CalculateRow(int[] firstArr, int[] secondArr, int i)
        {
            for (int j = 1; j < i; j++)
            {
                firstArr[j] = secondArr[j - 1] + secondArr[j];
            }

            firstArr[i] = 1;
        }
    }
}