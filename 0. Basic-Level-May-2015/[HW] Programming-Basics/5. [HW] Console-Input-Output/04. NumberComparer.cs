using System;

// Write a program that gets two numbers from the console and prints the greater of them. Try to implement this without if statements.

class NumberComparer
{
    static void Main()
    {
        Console.Write("a = ");
        float a = float.Parse(Console.ReadLine());

        Console.Write("b = ");
        float b = float.Parse(Console.ReadLine());

        float greaterNumber = (float)Math.Max(a, b);

        Console.WriteLine("\nThe greater number is: {0}\n", greaterNumber);
    }
}