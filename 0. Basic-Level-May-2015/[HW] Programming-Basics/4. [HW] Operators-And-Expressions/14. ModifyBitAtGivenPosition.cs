using System;

// We are given an integer number n, a bit value v (v = 0 or 1) and a position p. Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n. 

class ModifyBitAtGivenPosition
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please enter an the positon you want to switch : ");
        int p = int.Parse(Console.ReadLine());

        Console.Write("Swich position {0} with (0 or 1): ", p);
        int v;
        bool vParsed = int.TryParse(Console.ReadLine(), out v);

        while (vParsed == false || (v < 0) || (v > 1))
        {
            Console.WriteLine("You must enter 0 or 1.");
            vParsed = int.TryParse(Console.ReadLine(), out v);
        }

        Console.WriteLine();

        int switchedBit;
        if (v == 0)
        {
            switchedBit = ~(1 << p) & n;
            Console.WriteLine("When changing the positon {0} of the number {1} with bit {2} the result is: {3}", p, n, v, switchedBit);
        }
        else if (v == 1)
        {
            switchedBit = (v << p) | n;
            Console.WriteLine("When changing the positon {0} of the number {1} with bit {2} the result is: {3}\n", p, n, v, switchedBit);
        }
    }
}