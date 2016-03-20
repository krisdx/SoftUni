using System;
using System.Collections.Generic;

class PrimeFactorization
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<int> divisors = new List<int>();
        int n = number;
        int divisor = 2;
        while (n > 1)
        {
            if (n % divisor == 0)
            {
                divisors.Add(divisor);
                n /= divisor;
            }
            else
            {
                divisor++;
            }
        }

        Console.WriteLine("{0} = {1}", number, string.Join(" * ", divisors));
    }
}