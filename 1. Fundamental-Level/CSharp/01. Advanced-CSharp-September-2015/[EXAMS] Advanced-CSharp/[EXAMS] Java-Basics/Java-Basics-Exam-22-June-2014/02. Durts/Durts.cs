using System;
using System.Linq;

class Durts
{
    static void Main()
    {
        int[] centerCoordinates = Console.ReadLine().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int radius = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] trownDurtsCoordinates = Console.ReadLine().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        for (int i = 0; i < trownDurtsCoordinates.Length; i += 2)
        {
            int X = trownDurtsCoordinates[i];
            int Y = trownDurtsCoordinates[i + 1];

            bool isInsideDurt = IsDurtInside(X, Y, centerCoordinates, radius);

            if (isInsideDurt)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }

    public static bool IsDurtInside(int X, int Y, int[] centerCoordinates, int radius)
    {
        bool isInsideDurt = false;

        int centerX = centerCoordinates[0];
        int centerY = centerCoordinates[1];

        bool isXInsideHorizontalBlock = X >= centerX - radius / 2 && X <= centerX + radius / 2;
        bool isYInsideHorizontalBlock = Y >= centerY - radius && Y <= centerY + radius;

        bool isXInsideVerticalBlock = X >= centerX - radius && X <= centerX + radius;
        bool isYInsideVerticalBlock = Y >= centerY - radius / 2 && Y <= centerY + radius / 2;

        if ((isXInsideHorizontalBlock && isYInsideHorizontalBlock) ||
           (isXInsideVerticalBlock && isYInsideVerticalBlock))
        {
            isInsideDurt = true;
        }

        return isInsideDurt;
    }
}