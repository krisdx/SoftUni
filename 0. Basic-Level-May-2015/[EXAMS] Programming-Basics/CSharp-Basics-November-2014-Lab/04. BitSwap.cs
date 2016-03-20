using System;

class BitSwap // -k.d
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());

        long bit3 = (n >> 3) & 1;
        long bit24 = (n >> 24) & 1;

        if (bit3 == 0)
        {
            n &= ~(1 << 24);
        }
        else
        {
            n |= (1 << 24);
        }

        if (bit24 == 0)
        {
            n &= ~(1 << 3);
        }
        else
        {
            n |= (1 << 3);
        }

        Console.WriteLine(n);
    }
}