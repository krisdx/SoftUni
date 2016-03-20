using System;

// Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer. 

class BitsExchange
{
    static void Main()
    {
        Console.Write("n = ");
        uint n = uint.Parse(Console.ReadLine());

        uint rightBitsMaks = (n >> 3) & 7;
        uint LeftBitsMask = (n >> 24) & 7;

        n = n & ~((uint)7 << 3);
        n = n | (LeftBitsMask << 3);

        n = n & ~((uint)7 << 24);
        n = n | (rightBitsMaks << 24);

        Console.WriteLine("\nReult: {0}\n", n);
    }
}