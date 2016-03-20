using System;
using System.Collections.Generic;
using System.Linq;

class CouplesFrequency
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Dictionary<string, double> couples = new Dictionary<string, double>();
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            string currentCouple = numbers[i] + " " + numbers[i + 1];

            if (couples.ContainsKey(currentCouple))
            {
                couples[currentCouple] += 1;
            }
            else
            {
                couples.Add(currentCouple, 1);
            }
        }

        foreach (var couple in couples)
        {
            double frequency = (couple.Value * 100) / (numbers.Length - 1);
            Console.WriteLine("{0} -> {1:f2}%", couple.Key, frequency);
        }
    }
}