using System;

// Write an if-statement that takes two integer variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.

class ExchangeIfGreater
{
    static void Main()
    {
        Console.Write("Please, enter a = ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("Please, enter b = ");
        float b = float.Parse(Console.ReadLine());

        if (a > b)
        {
            Console.WriteLine("\nResult: {1} {0}\n", a, b);
        }
        else
        {
            Console.WriteLine("\nResult: {0} {1}\n", a, b);
        }
    }
}

