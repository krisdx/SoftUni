using System;

// Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by spaces) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());

        int f1 = 0;
        int f2 = 1;
        int f3;

        Console.WriteLine();
        Console.WriteLine("Fibonacci sequence from 1 ot {0}:\n", n);
        Console.Write("{0} {1} ", f1, f2);

        
        for (int i = 0; i < n; i++)
        {
            f3 = f1 + f2;
            Console.Write("{0} ", f3);
            f1 = f2;
            f2 = f3;
        }
        Console.WriteLine("\n");
    }
}