using System;

// Using loops write a program that converts an integer number to its binary representation. The input is entered as long. The output should be a variable of type string. Do not use the built-in .NET functionality.

class DecimalToBinaryNumber
{
    static void Main()
    {
        Console.Write("Please, enter a positive number: ");
        long n = long.Parse(Console.ReadLine());

        string[] reminderArray = new string[64];

        for (int i = 0; i <= 64; i++)
        {
            long reminder = n % 2;
            string reminderInString = reminder.ToString();
            reminderArray[i] += reminderInString;
            n = n / 2;
            if (n == 0)
            {
                goto AFTERDIVIDING;
            }
        }
    AFTERDIVIDING:
        Console.Write("\nBinary representation: ");
        Array.Reverse(reminderArray);
        for (int i = 0; i < reminderArray.Length; i++)
        {
            Console.Write("{0}", reminderArray[i]);
        }
        Console.WriteLine("\n");
    }
}