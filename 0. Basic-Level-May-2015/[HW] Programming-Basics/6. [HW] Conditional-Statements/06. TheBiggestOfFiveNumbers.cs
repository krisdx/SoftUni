using System;

// Write a program that finds the biggest of five numbers by using only five if statements.

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        Console.Write("Please, enter a = ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter b = ");
        float b = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter c = ");
        float c = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter c = ");
        float d = float.Parse(Console.ReadLine());

        Console.Write("\nPlease, enter c = ");
        float e = float.Parse(Console.ReadLine());

        Console.WriteLine();

        if ((a >= b) && (a >= c) && (a >= d) && (a >= e))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", a);
        }
        else if ((b >= a) && (b >= c) && (b >= d) && (b >= e))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", b);
        }
        else if ((c >= a) && (c >= b) && (c >= d) && (c >= e))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", c);
        }
        else if ((d >= a) && (d >= b) && (d >= c) && (d >= e))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", d);
        }
        else if ((e >= a) && (e >= b) && (e >= c) && (e >= d))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", e);
        }
    }
}

