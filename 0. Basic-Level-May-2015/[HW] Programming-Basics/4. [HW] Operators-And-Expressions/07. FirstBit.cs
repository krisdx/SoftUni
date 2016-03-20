using System;

class FirstBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        int mask = (1 << 1);
        int result = (n & mask) >> 1;
        Console.WriteLine(result);
    }
}