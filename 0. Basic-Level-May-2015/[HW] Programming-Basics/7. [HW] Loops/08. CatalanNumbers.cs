using System;
using System.Numerics;

// Write a program to calculate the nth Catalan number by given n (1 < n < 100). 

class CatalanNumbers
{
    static void Main()
    {
        Console.Write("Please, enter n (1 < n < 100) = ");
        int n = int.Parse(Console.ReadLine());
        int nN = n;
        int n2 = n * 2;
        int n1 = n + 1;

        BigInteger factorialN = 1;
        BigInteger factorialN1 = 1;
        BigInteger factorialN2 = 1;

        while (nN >= 1)
        {
            factorialN *= nN;
            nN--;
        }
        while (n1 >= 1)
        {
            factorialN1 *= n1;
            n1--;
        }
        while (n2 >= 1)
        {
            factorialN2 *= n2;
            n2--;
        }
        BigInteger result = factorialN2 / (factorialN1 * factorialN);
        Console.WriteLine("\nResult: {0}\n", result);
    }
}