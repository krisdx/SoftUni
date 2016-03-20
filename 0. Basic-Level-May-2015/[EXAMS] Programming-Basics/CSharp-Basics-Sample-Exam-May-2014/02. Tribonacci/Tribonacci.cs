using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger num1 = BigInteger.Parse(Console.ReadLine());
        BigInteger num2 = BigInteger.Parse(Console.ReadLine());
        BigInteger num3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(num1);
        }
        else if (n == 2)
        {
            Console.WriteLine(num2);
        }
        else if (n == 3)
        {
            Console.WriteLine(num3);
        }
        else
        {
            for (int i = 4; i <= n; i++)
            {
                BigInteger nthNumber = num1 + num2 + num3;
                num1 = num2;
                num2 = num3;
                num3 = nthNumber;
            }
            Console.WriteLine(num3);
        }
    }
}