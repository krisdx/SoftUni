using System;
using System.Linq;
using System.Numerics;

public class MultiplyIntegersInArray
{
    static void Main()
    {
        BigInteger[] numbers = Console.ReadLine().Split().Select(BigInteger.Parse).ToArray();

        BigInteger[] productNumbers = new BigInteger[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            BigInteger currentProduct = 1;
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i == j)
                {
                    continue;
                }

                currentProduct *= numbers[j];
            }

            productNumbers[i] = currentProduct;
        }

        Console.WriteLine(string.Join(" ", productNumbers));
    }
}