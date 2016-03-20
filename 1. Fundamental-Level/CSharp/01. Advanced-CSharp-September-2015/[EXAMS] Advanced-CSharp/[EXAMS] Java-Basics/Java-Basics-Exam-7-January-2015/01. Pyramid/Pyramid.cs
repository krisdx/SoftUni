using System;
using System.Collections.Generic;
using System.Linq;

class Pyramid
{
    static bool foundNum = false;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        long[][] pyramid = new long[n][];
        for (int i = 0; i < n; i++)
        {
            pyramid[i] = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
        }

        List<long> growingSequence = new List<long>();
        growingSequence.Add(pyramid[0][0]);
        long previosuNum = growingSequence[0];
        int index = 0;
        for (int i = 1; i < n; i++)
        {
            long closestNum = GetClosestNum(pyramid[i], previosuNum);

            if (closestNum == previosuNum + 1 && !foundNum)
            {
                previosuNum = closestNum;
            }
            else if (previosuNum < closestNum && foundNum)
            {
                growingSequence.Add(closestNum);
                index++;
                previosuNum = growingSequence[index];
            }

            foundNum = false;
        }

        Console.WriteLine(string.Join(", ", growingSequence));
    }

    static long GetClosestNum(long[] currentRow, long previousNum)
    {
        long closestNum = long.MaxValue;

        for (int i = 0; i < currentRow.Length; i++)
        {
            if (currentRow[i] > previousNum && currentRow[i] < closestNum)
            {
                closestNum = currentRow[i];
                foundNum = true;
            }
        }

        if (closestNum == long.MaxValue)
        {
            return previousNum + 1;
        }

        return closestNum;
    }
}