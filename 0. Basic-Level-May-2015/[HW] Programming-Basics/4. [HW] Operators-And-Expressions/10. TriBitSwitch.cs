using System;

class TriBitSwitch
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        long mask = 7;

        mask = (mask << p);
        long result = mask ^ n;
        Console.WriteLine(result);
    }
}