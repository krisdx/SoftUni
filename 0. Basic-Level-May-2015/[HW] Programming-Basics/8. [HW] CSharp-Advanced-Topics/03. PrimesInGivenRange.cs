using System;
using System.Collections.Generic;

// Write a method that calculates all prime numbers in given range and returns them as list of integers.

class PrimesInGivenRange
{
    static void Main()
    {
        Console.WriteLine("Please, enter two integers: ");

        Console.Write("x = ");
        long startNum = long.Parse(Console.ReadLine());

        Console.Write("y = ");
        long endNum = long.Parse(Console.ReadLine());

        FindPrimesInRange(startNum, endNum);

    }
    static void FindPrimesInRange(long startNum, long endNum)
    {
        if (startNum > endNum)
        {
            Console.WriteLine("\n(Empty list)\n");
        }
        else
        {
            List<long> primeNumbersList = new List<long>();

            for (long p = startNum; p <= endNum; p++)
            {
                long numberDividers = 0;
                if (p != 1 && p != 0)
                {
                    for (int i = 2; i <= p / 2; i++)
                    {
                        if (p % i == 0)
                        {
                            numberDividers = numberDividers + 1;
                            break;
                        }
                    }
                }

                if (numberDividers == 0)
                {
                    primeNumbersList.Add(p);
                }
            }

            for (int i = 0; i < primeNumbersList.Count - 1; i++)
            {
                Console.Write("{0}, ", primeNumbersList[i]);
            }
            Console.WriteLine("Result:");
            Console.WriteLine(primeNumbersList[primeNumbersList.Count - 1]);
        }
    }
}