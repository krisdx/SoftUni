using System;

class BitCopy //-k.d
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        int bit = (n >> p) & 1;

        if (bit == 0)
        {
            n &= ~(1 << 2);
        }
        else
        {
            n |= (1 << 2);
        }
        Console.WriteLine(n);
    }
}