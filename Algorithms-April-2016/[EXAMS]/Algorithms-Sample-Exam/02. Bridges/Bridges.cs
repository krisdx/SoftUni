namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Bridges
    {
        private static int[,] bridgesCount;

        public static void Main()
        {
            int[] north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] south = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bridgesCount = new int[north.Length + 1, south.Length + 1];
            for (int northIndex = 1; northIndex < bridgesCount.GetLength(0); northIndex++)
            {
                for (int southIndex = 1; southIndex < bridgesCount.GetLength(1); southIndex++)
                {
                    if (north[northIndex - 1] == south[southIndex - 1])
                    {
                        bridgesCount[northIndex, southIndex] = GetMax(
                            bridgesCount[northIndex - 1, southIndex],
                            bridgesCount[northIndex, southIndex - 1],
                            bridgesCount[northIndex - 1, southIndex - 1]);
                        bridgesCount[northIndex, southIndex]++;
                    }
                    else
                    {
                        bridgesCount[northIndex, southIndex] = GetMax(
                            bridgesCount[northIndex - 1, southIndex],
                            bridgesCount[northIndex, southIndex - 1],
                            bridgesCount[northIndex - 1, southIndex - 1]);
                    }
                }
            }

            Console.WriteLine(bridgesCount[north.Length, south.Length]);
        }

        private static int GetMax(int firstNum, int secondNum, int thirdNum)
        {
            int currentMax = Math.Max(firstNum, secondNum);
            return Math.Max(currentMax, thirdNum);
        }
    }
}