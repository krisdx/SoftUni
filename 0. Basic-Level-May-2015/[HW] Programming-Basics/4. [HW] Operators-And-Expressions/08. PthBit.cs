using System;

class PthBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        int mask = (1 << p);
        int result = (n & mask) >> p;
        Console.WriteLine(result);
    }
}