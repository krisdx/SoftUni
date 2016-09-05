namespace KnightTour
{
    using System;

    public class KnightTour
    {
        private const int MaxMoves = 8;

        private static readonly int[] RowMoves =
            new int[] { +1, -1, +1, -1, +2, +2, -2, -2  };

        private static readonly int[] ColMoves =
            new int[] { +2, +2, -2, -2, +1, -1, +1, -1 };

        private static int n;
        private static int[,] board;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            board = new int[n, n];

            int row = 0;
            int col = 0;
            int step = 1;
            board[0, 0] = 1;

            int n2 = n * n;
            while (step < n2)
            {
                int minMovesCount = int.MaxValue;
                int choose = 0;
                for (int i = 0; i < MaxMoves; i++)
                {
                    int currentMovesCount = GetAvailableMovesCount(row + RowMoves[i], col + ColMoves[i]);
                    if (currentMovesCount < minMovesCount)
                    {
                        minMovesCount = currentMovesCount;
                        choose = i;
                    }
                }

                row += RowMoves[choose];
                col += ColMoves[choose];
                board[row, col] = ++step;
            }

            Print();
        }

        private static int GetAvailableMovesCount(int row, int col)
        {
            if (!IsCellValid(row, col) || board[row, col] != 0)
            {
                // Cell not in range or has already been visited.
                return int.MaxValue;
            }

            int avaiableCellsCount = 0;
            for (int i = 0; i < MaxMoves; i++)
            {
                int currentRow = row + RowMoves[i];
                int currentCol = col + ColMoves[i];
                if (IsCellValid(currentRow, currentCol) && board[currentRow, currentCol] == 0)
                {
                    avaiableCellsCount++;
                }
            }

            return avaiableCellsCount;
        }

        private static bool IsCellValid(int row, int col)
        {
            return row >= 0 && row < n &&
                   col >= 0 && col < n;
        }

        private static void Print()
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0, 4}", board[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}