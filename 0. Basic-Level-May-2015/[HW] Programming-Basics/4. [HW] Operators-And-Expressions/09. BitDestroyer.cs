using System;

class BitDestroyer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());

        int mask = ~(1 << p);
        int result = mask & n;
        Console.WriteLine(result);
    }
}