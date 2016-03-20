using System;

// Write a Boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time

class DivideBy7And5
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());

        bool isDivisbleBy5And7 = (n % 7 == 0 && n % 5 == 0);

        if (isDivisbleBy5And7)
        {
            Console.WriteLine("\nTrue\n");
        }
        else
        {
            Console.WriteLine("\nFalse\n");
        }
    }
}