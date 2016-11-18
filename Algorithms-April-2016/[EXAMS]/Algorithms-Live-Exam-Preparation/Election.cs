using System;
using System.Numerics;

public class Election
{
    public static void Main(string[] args)
    {
        int maxSum = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        BigInteger[] arr = new BigInteger[(100 * 1000) + 1];

        long tempMax = 0;

        arr[0] = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            for (long sum = tempMax; sum >= 0; sum--)
            {
                if (arr[sum] > 0)
                {
                    arr[sum + numbers[i]] += arr[sum];
                    if (sum + numbers[i] > tempMax)
                    {
                        tempMax = sum + numbers[i];
                    }
                }
            }
        }

        BigInteger count = new BigInteger(0);
        for (int i = maxSum; i <= tempMax; i++)
        {
            count += arr[i];
        }

        Console.WriteLine(count);
    }
}