using System;
using System.Numerics;

// Define a method Fib(n) that calculates the nth Fibonacci number.

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        BigInteger n = BigInteger.Parse(Console.ReadLine());
        Fib(n);
    }

    static void Fib(BigInteger n)
    {
        ulong f1 = 0;
        ulong f2 = 1;
        ulong f3 = 0;

        for (ulong i = 0; i < n; i++)
        {
            f3 = f1 + f2;
            f1 = f2;
            f2 = f3;
        }

        Console.WriteLine("\nThe {0} fibonacci number is: {1}\n", n, f3);
    }
}