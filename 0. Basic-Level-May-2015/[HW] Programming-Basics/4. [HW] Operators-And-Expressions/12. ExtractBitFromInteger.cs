using System;

// Write an expression that extracts from given integer n the value of given bit at index p.

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.Write("You want ot see the bit on position: ");
        int p = int.Parse(Console.ReadLine());
        
        int mask = (1 << p);
        int pBit = (n & mask) >> p;

        Console.WriteLine();
       
        Console.WriteLine("The digit on positon {0} is {1}.", p, pBit);
    }
}

