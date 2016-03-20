using System;

// Write an expression that checks if given integer is odd or even.

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        bool oddOrEven = (number % 2 == 0);
        if (oddOrEven)
        {
            Console.WriteLine("\nThe number is even.\n");
        }
        else
        {
            Console.WriteLine("\nThe number is odd.\n");
        }
    }
}