using System;

// Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order. 

class RandomizeTheNumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());
        int[] numbersN = new int[n];
        Random random = new Random();

        Console.WriteLine("\nRandom numbers from 1 ot {0}:\n", n);
        for (int i = 0; i < numbersN.Length; i++)
        {
            numbersN[i] = random.Next(n + 1);
            Console.Write("{0} ", numbersN[i]);
        }
        Console.WriteLine("\n\n");
    }
}