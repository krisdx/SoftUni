using System;

// Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + n!/xn. Use only one loop. Print the result with 5 digits after the decimal point.

class CalculateSumWithFactorials
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        double n = double.Parse(Console.ReadLine());

        Console.Write("Please, enter x = ");
        double x = double.Parse(Console.ReadLine());
        
        double factorial = 1;
        double sum = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            double xPow = Math.Pow(x, i);
            double result = factorial / xPow;
            sum += result;
        }
        Console.WriteLine("\nResult: {0:F5}\n", sum);
    }
}