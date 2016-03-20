using System;

class GameOfLife
{
    static void Main() //-k.d
    {
        int[] presentGeneration = new int[10];
        int[] nextGeneration = new int[10];

        int liveCellsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < liveCellsCount; i++)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());
            presentGeneration[row] |= 1 << col;
            nextGeneration[row] |= 1 << col;
        }

        for (int row = 0; row < nextGeneration.Length; row++)
        {
            for (int col = 0; col < nextGeneration.Length; col++)
            {
                int currentBit = (nextGeneration[row] >> col) & 1;

                int startRow = row - 1;
                if (startRow < 0)
                {
                    startRow = 0;
                }
                int endRow = row + 1;
                if (endRow > nextGeneration.Length - 1)
                {
                    endRow = nextGeneration.Length - 1;
                }
                int startCol = col - 1;
                if (startCol < 0)
                {
                    startCol = 0;
                }
                int endCol = col + 1;
                if (endCol > nextGeneration.Length - 1)
                {
                    endCol = nextGeneration.Length - 1;
                }

                int liveNeighbours = 0;
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        if (i == row && j == col) // at same position as currentBit
                        {
                            continue;
                        }

                        bool isCurrentBitOne = ((presentGeneration[i] >> j) & 1) == 1;
                        if (isCurrentBitOne)
                        {
                            liveNeighbours++;
                        }
                    }
                }

                if (currentBit == 1 && (liveNeighbours < 2 || liveNeighbours > 3))
                {
                    nextGeneration[row] &= ~(1 << col); // dies
                }
                else if (currentBit == 0 && liveNeighbours == 3)
                {
                    nextGeneration[row] |= 1 << col; // lives
                }
            }
        }

        // Print
        foreach (int num in nextGeneration)
        {
            Console.WriteLine(Convert.ToString(num, 2).PadLeft(10, '0'));
        }
    }
}