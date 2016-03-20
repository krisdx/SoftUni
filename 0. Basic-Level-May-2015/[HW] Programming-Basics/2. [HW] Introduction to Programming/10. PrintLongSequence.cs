using System;

// Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, …

class PrintLongSequence
{
    static void Main()
    {
        int FirstNumber = 1;
        for (int i = 0; i < 1000; i++) 
        {
            FirstNumber += 1; // Each time we are adding one to the intger FirstNmuber;
            if (FirstNumber % 2 == 0) // Using the operator "%" to see if the number is even;
            {
                Console.Write(FirstNumber + ", "); // If it is, print it;
            }
            else
            {
                Console.Write(FirstNumber * (-1) + ", "); // Else multiply it by (-1) and print it;
            }
        }
    }
}