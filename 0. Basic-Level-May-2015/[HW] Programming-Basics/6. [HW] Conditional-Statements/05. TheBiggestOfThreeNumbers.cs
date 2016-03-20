using System;

// Write a program that finds the biggest of three numbers.

class TheBiggestOfThreeNumbers
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

        if ((a > b) && (a > c))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", a);
        }
        else if ((b > a) && (b > a))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", b);
        }
        else if ((c > a) && (c > b))
        {
            Console.WriteLine("\nThe biggest number is: {0}\n", c);
        }
    }
}
