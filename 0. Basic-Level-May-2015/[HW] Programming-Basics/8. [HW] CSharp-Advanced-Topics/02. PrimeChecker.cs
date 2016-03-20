using System;

// Write a Boolean method IsPrime(n) that check whether a given integer number n is prime. 

class PrimeChecker
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        ulong n = ulong.Parse(Console.ReadLine());
        bool isPrime = true;
        IsPrime(isPrime, n);
    }

    static void IsPrime(bool isPrime, ulong n)
    {
        if (n == 0 || n == 1)
        {
            isPrime = false;    
        }
        else
        {
            for (ulong i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }
        }

        Console.WriteLine("\n{0}\n", isPrime);
    }
}