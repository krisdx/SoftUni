using System;

// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...

class PrintASequence
{
    static void Main()
    {
        int FirstNumber = 1;
        for (int i = 0; i < 10; i++) // Using the "for" loop, 10 times;
        {
            FirstNumber += 1; // Each time we're adding 1;

            if (FirstNumber % 2 == 0) // We use the operator %, to see if the integer is divisible by 2. If it is, it's even;
            {
                Console.WriteLine(FirstNumber); // And we print it on the console;
            }
            else // If the integer can't be divided by 2, it's odd;
            {
                Console.WriteLine(FirstNumber * (-1)); // We multiply it by (-1) and print it;
            }
        }
    }
}