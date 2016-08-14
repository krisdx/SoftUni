using System;
using System.Collections.Generic;
using System.Linq;

public class ColorRabbits
{
    private const int RabbitsCount = 1000001;

    public static void Main()
    {
        int askedRabbitsCount = int.Parse(Console.ReadLine());

        // Just saving all the answers from the rabbits.
        // The index is the number of rabbits.
        // The value is the count of answers, we've received.
        int[] memo = new int[RabbitsCount + 1];
        for (int i = 0; i < askedRabbitsCount; i++)
        {
            int rabbitAnswer = int.Parse(Console.ReadLine());
            int rabbitsCount = rabbitAnswer + 1;
            memo[rabbitsCount]++;
        }

        Console.WriteLine(GetMinRabbitsCount(memo));
    }

    private static long GetMinRabbitsCount(int[] cache)
    {
        long result = 0;
        for (int i = 0; i <= RabbitsCount; i++)
        {
            int rabbitsCount = i;
            int answersCount = cache[i];
            if (answersCount == 0)
            {
                continue;
            }

            if (answersCount < rabbitsCount)
            {
                // We've asked rabbits from one color only. 
                // So we just add the count to the result.
                result += rabbitsCount;
            }
            else
            {
                // We've asked rabbits from different color groups,
                // witch gave us the same count.
                double differentGroupsCount = Math.Ceiling((double)answersCount / rabbitsCount);
                result += (long)(differentGroupsCount * rabbitsCount);
            }
        }

        return result;
    }
}