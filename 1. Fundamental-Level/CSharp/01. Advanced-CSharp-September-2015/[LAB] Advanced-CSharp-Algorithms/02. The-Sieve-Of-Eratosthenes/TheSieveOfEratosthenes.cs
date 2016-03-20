using System;
using System.Collections.Generic;
using System.Linq;

class TheSieveOfEratosthenes
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        List<int> numbers = Enumerable.Range(0, n + 1).ToList();
        int p = 2;

        while (p < numbers.Count)
        {
            for (int i = 2; i < numbers.Count; i++)
            {
                if (i * p >= numbers.Count)
                {
                    break;
                }
                numbers[i * p] = -1;
            }

            p++;
        }

        var primeNumbers = numbers.FindAll(x => x >= 2);
        Console.WriteLine(string.Join(", ", primeNumbers));
    }
}