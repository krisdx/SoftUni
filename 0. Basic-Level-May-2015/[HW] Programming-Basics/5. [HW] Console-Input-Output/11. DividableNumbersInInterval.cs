using System;

// Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0. 

class DividableNumbersInInterval
{
    static void Main()
    {
        Console.Write("Please, enter an integer = ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Please, enter a second integer = ");
        int b = int.Parse(Console.ReadLine());

        if (a > b) // If b is greater than a, we have to swich them
        {
            int temp = a;
            a = b;
            b = temp;
        }

        int p = 0;

        for (int i = a; i <= b; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }
        Console.WriteLine("\nThe numbers between {0} and {1} that are divisible by 5 are: {2}\n", a, b, p);
    }
}