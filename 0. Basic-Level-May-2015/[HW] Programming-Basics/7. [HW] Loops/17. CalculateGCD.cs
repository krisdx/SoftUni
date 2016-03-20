using System;

// Write a program that calculates the greatest common divisor (GCD) of given two integers a and b. Use the Euclidean algorithm.

class CalculateGCD
{
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());

        int exchangeAB;
        if (b > a)
        {
            exchangeAB = a;
            a = b;
            b = exchangeAB;
        }

        int reminder = a % b;

        if (reminder == 0)
        {
            Console.WriteLine("The GCD is: {0}", b);
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                a = b;
                b = reminder;
                reminder = a % b;
                if (reminder == 0)
                {
                    Console.WriteLine("The GCD is: {0}", b);
                    break;
                }
            }
        }
    }
}
// http://www.math.rutgers.edu/~greenfie/gs2004/euclid.html