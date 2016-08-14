using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class Divisores
{
    public static void Main()
    {
        string str = Console.ReadLine();

        IDictionary<char, int> colors = new Dictionary<char, int>();
        foreach (var color in str)
        {
            if (!colors.ContainsKey(color))
            {
                colors.Add(color, 0);
            }

            colors[color]++;
        }

        Console.WriteLine(Factorial(str.Length) / SumFactorials(colors));
    }

    private static BigInteger SumFactorials(IDictionary<char, int> colors)
    {
        BigInteger divosor = 1;
        foreach (var color in colors)
        {
            divosor *= Factorial(color.Value);
        }

        return divosor;
    }

    private static BigInteger Factorial(BigInteger n)
    {
        BigInteger result = 1;
        for (BigInteger i = n; i >= 1; i--)
        {
            result *= i;
        }

        return result;
    }
}