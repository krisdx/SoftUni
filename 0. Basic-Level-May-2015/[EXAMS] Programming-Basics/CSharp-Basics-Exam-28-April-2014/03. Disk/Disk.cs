using System;

class Disk
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        int radius = int.Parse(Console.ReadLine());

        int diskCenterRow = fieldSize / 2;
        int diskCenterCol = fieldSize / 2;
        for (int row = 0; row < fieldSize; row++)
        {
            for (int col = 0; col < fieldSize; col++)
            {
                bool isInside =
                    (row - diskCenterRow) * (row - diskCenterRow) +
                    (col - diskCenterCol) * (col - diskCenterCol)
                    <= radius * radius;
                if (isInside)
                {
                    Console.Write('*');
                    continue;
                }

                Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}