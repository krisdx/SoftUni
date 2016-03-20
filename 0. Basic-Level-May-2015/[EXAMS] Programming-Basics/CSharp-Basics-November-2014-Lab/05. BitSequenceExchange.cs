using System;

class BitSequenceExchange //-k.d
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        
        long bit3 = (n >> 3) & 7;
        long bit24 = (n >> 24) & 7;

        n &= ~(7 << 3);
        n &= ~(7 << 24);

        n |= (bit3 << 24);
        n |= (bit24 << 3);

        Console.WriteLine(n);
    }
}