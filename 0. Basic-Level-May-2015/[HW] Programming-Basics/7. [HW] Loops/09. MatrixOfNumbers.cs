using System;

// Write a program that reads from the console a positive integer number n (1 < n < 20) and prints a matrix like in the examples below. Use two nested loops.

class MatrixOfNumbers
{
    static void Main()
    {
        Console.Write("Please, enter n (1 < n < 20) = ");
        int n = int.Parse(Console.ReadLine());

        bool check = (n < 1) || (n > 20);
        while (check)
        {
            Console.Write("Please, enter n (1 < n < 20) = ");
            n = int.Parse(Console.ReadLine());
            check = (n < 1) || (n > 20);
        }

        Console.WriteLine();

        for (int row = 1; row <= n; row++)
        {
            for (int col = row; col <= (n + row - 1); col++)
            {
                Console.Write("{0}" + " ", col);
            }
            Console.WriteLine("\n");
        }
    }
}