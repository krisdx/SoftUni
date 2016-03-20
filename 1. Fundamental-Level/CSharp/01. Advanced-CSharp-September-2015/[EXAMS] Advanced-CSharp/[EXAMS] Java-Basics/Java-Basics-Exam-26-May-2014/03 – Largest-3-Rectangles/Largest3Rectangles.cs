using System;
using System.Collections.Generic;
using System.Linq;

class Largest3Rectangles
{
    static void Main()
    {
        int[][] rectangles = new int[1][];

        rectangles[0] = Console.ReadLine().Split(new char[] { ' ', '\t', '[', ']', 'x' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

        int totalArea = int.MinValue;
        for (int i = 0; i < rectangles[0].Length - 5; i += 2)
        {
            int currentArea =
                rectangles[0][i] * rectangles[0][i + 1] +
                rectangles[0][i + 2] * rectangles[0][i + 3] +
                rectangles[0][i + 4] * rectangles[0][i + 5];

            if (currentArea > totalArea)
            {
                totalArea = currentArea;
            }
        }

        Console.WriteLine(totalArea);
    }
}