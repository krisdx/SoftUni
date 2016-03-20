using System;

// Write a program that shows the sign (+, - or 0) of the product of three real numbers, without calculating it. Use a sequence of if operators.

class MultiplicationSign
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

        if ((a * b * c) > 0)
        {
            Console.WriteLine("\nResult: +\n");
        }
        else if ((a * b * c) < 0)
        {
            Console.WriteLine("\nResult: -\n");
        }
        else if ((a * b * c) == 0)
        {
            Console.WriteLine("\nResult: 0\n");
        }
    }
}

