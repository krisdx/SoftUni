using System;

// Write an expression that checks if given positive integer number n (n ≤ 100) is prime (i.e. it is divisible without remainder only to itself and 1). 

class PrimeNumberCheck
{
    static void Main()
    {
        Console.Write("Enter a number (max 100), to see if it is prime: ");
        int n = int.Parse(Console.ReadLine());

        while (n > 100)
        {
            Console.WriteLine("The number is invalid. Please enter a number from 0 to 100");
            n = int.Parse(Console.ReadLine());
        }

        bool isPrime = true;

        if (n == 0 || n == 1)
        {
            Console.WriteLine("\nThe number is not prime\n");
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                }
            }
            
            if (isPrime)
            {
                Console.WriteLine("\nThe number is prime\n");
            }
            else
            {
                Console.WriteLine("\nThe number is not prime\n");
            }
        }
    }
}