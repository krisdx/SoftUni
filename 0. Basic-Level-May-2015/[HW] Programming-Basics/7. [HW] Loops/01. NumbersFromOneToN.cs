using System;

// Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space. 

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Please, enter a positive integer: ");
        int inputNumber = int.Parse(Console.ReadLine());

        if (inputNumber < 0)
        {
            Console.WriteLine("\nSorry, the integer is not positive.\n");
        }
        else
        {
            Console.WriteLine("\nResult: ");

            for (int i = 1; i <= inputNumber; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine("\n");
        }
    }
}