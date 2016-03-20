using System;
using System.Numerics;

class TrailingZeroesInNFactorial
{
    static void Main()
    {
        Console.Write("Please, enter n = ");
        int n = int.Parse(Console.ReadLine());

        int divide = 0;
        int sum = 0;
        for (int i = 1; i < 100; i++)
        {
            divide = n / (int)Math.Pow(5, i);
            sum += divide;
            if (divide <= 1)
            {
                Console.WriteLine("\nTrailing zeroes of {0}! = {1}\n", n, sum);
                break;
            }
        }
    }
}
// http://www.purplemath.com/modules/factzero.htm