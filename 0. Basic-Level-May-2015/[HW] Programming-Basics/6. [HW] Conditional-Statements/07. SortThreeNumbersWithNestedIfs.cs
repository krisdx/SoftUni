using System;

// Write a program that enters 3 real numbers and prints them sorted in descending order. Use nested if statements. Don’t use arrays and the built-in sorting functionality.

class SortThreeNumbersWithNestedIfs
{
    static void Main()
    {
        Console.Write("Please, enter a = ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter b = ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter c = ");
        float c = float.Parse(Console.ReadLine());

        Console.WriteLine();

        if (a >= b && a >= c)
        {
            if (b >= c)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", a, b, c);
            }
            else if (c >= b)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", a, c, b);
            }
        }
        else if (b >= a && b >= c)
        {
            if (c >= a)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", b, c, a);
            }
            else if (a >= c)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", b, a, c);
            }
        }
        else if (c >= a && c >= b)
        {
            if (a >= b)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", c, a, b);
            }
            else if (b >= a)
            {
                Console.WriteLine("\nResult: {0} {1} {2}\n", c, b, a);
            }
        }     
    }
}

