using System;

// Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Please, enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(n - (n - i));
        }
       
        Console.WriteLine();
    }
}