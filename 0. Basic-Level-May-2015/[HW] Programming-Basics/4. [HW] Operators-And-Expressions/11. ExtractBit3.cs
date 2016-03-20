using System;

// Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer. The bits are counted from right to left, starting from bit #0. The result of the expression should be either 1 or 0.

class ExtractBit3
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        
        int n = 3;
        int mask = (1 << n);
        int thirdBit = (mask & number) >> n;
        
        Console.WriteLine("\nThe third bit of {0} is: {1}\n", number, thirdBit);
    }
}