using System;

// Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n has value of 1. 

class CheckBitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Enter a number and bit positon, and the program will check if that bit is equal to one.");

        Console.WriteLine();

        Console.Write("Please enret a number: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please enret the position : ");
        int p = int.Parse(Console.ReadLine());

        int mask = ((1 << p) & n) >> p;

        bool chekingDigit = (mask == 1);

        Console.WriteLine("\n{0}\n", chekingDigit);
    }
}