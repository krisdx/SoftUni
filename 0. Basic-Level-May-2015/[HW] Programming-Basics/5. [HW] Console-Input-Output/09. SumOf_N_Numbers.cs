using System;
using System.Linq;

// Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. 

class SumOf_N_Numbers
{
    static void Main()
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();

        long[] numbers = new long[n];

        for (int i = 1; i < n + 1; i++)
        {
            Console.Write("Enter number ({0}): ", n - (n - i)); // n - (n - i)) - this is just for the number sequence in "Enter number ({0})"
            numbers[i - 1] = int.Parse(Console.ReadLine()); // numbers[i - 1] this is also for the sequence in "Enter number ({0})
        }

        Console.WriteLine("\nThe sum of the {0} numbers is: {1}\n", n, numbers.Sum());
    }
}