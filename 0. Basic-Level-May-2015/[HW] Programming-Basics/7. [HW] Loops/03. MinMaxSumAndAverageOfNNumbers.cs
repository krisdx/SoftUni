using System;
using System.Linq;

// Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point). The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();
        if (n < 0)
        {
            Console.WriteLine("\nSorry, the integer is not positive.\n");
        }
        else
        {
            double[] numbers = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter number ({0}): ", (i + 1));
                numbers[i] = int.Parse(Console.ReadLine());
            }

            double min = numbers.Min();
            double max = numbers.Max();
            double sum = numbers.Sum();
            double avg = numbers.Average();

            Console.WriteLine("\nResult:\nmin = {0}\nmax = {1}\nsum = {2}\navg = {3:F2}\n", min, max, sum, avg);
        }
    }
}