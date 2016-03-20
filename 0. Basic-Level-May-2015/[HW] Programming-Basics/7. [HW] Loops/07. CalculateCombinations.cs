using System;
using System.Numerics;

class CalculateCombinations
{
    static void Main()
    {
        Console.Write("Please, enter n (1 < n < 100) = ");
        int n = int.Parse(Console.ReadLine());
        int nN = n;

        Console.Write("Please, enter k (1 < k < n < 100) = ");
        int k = int.Parse(Console.ReadLine());
        int kK = k;

        BigInteger factorialN = 1;
        BigInteger factorialK = 1;
        BigInteger factorialN_K = 1;
        int n_K = n - k;
        
        while (nN >= 1)
        {
            factorialN *= nN;
            nN--;
        }
        while (kK >= 1)
        {
            factorialK *= kK;
            kK--;
        }
        while (n_K >= 1)
        {
            factorialN_K *= n_K;
            n_K--;
        }
        BigInteger result = factorialN / (factorialK * factorialN_K);
        Console.WriteLine("\nResult: {0}\n", result);
    }
}