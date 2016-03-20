namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = RotatingWalk(n);

            Print(matrix);
        }

        public static int[,] RotatingWalk(int n)
        {
            int[,] matrix = new int[n, n];

            int row = 0;
            int col = 0;
            int rowDirection = 1;
            int colDirection = 1;

            int numberCount = 0;

            while (numberCount < matrix.Length)
            {
                numberCount++;
                matrix[row, col] = numberCount;

                int nextX = row + rowDirection;
                int nextY = col + colDirection;

                bool isNextXInRange = 0 <= nextX && nextX < matrix.GetLength(0);
                bool isNextYInRange = 0 <= nextY && nextY < matrix.GetLength(1);
                bool isNextCellOccupied = false;
                bool hasJumpedToNonAdjacentEmptyCell = false;

                if (isNextXInRange && isNextYInRange)
                {
                    isNextCellOccupied = matrix[nextX, nextY] != 0;
                }

                int loopCount = 0;
                while (!isNextXInRange || !isNextYInRange || isNextCellOccupied)
                {
                    ChangeDirection(ref rowDirection, ref colDirection);

                    nextX = row + rowDirection;
                    nextY = col + colDirection;

                    isNextXInRange = 0 <= nextX && nextX < matrix.GetLength(0);
                    isNextYInRange = 0 <= nextY && nextY < matrix.GetLength(1);

                    if (isNextXInRange && isNextYInRange)
                    {
                        isNextCellOccupied = matrix[nextX, nextY] != 0;
                    }

                    loopCount++;

                    // If the loop was executed 7 times all adjacent cells are filled, jump to a non-adjacent empty cell
                    if (loopCount == 7)
                    {
                        SetPositionToFirstEmptyCell(matrix, out row, out col);
                        hasJumpedToNonAdjacentEmptyCell = true;
                        break;
                    }
                }

                if (!hasJumpedToNonAdjacentEmptyCell)
                {
                    row += rowDirection;
                    col += colDirection;
                }
            }

            return matrix;
        }

        private static void ChangeDirection(ref int rowDirection, ref int colDirection)
        {
            int[] rowDirections = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] colDirections = { 1, 0, -1, -1, -1, 0, 1, 1 };

            int currentDirectionIndex = 0;
            for (int count = 0; count < 8; count++)
            {
                if (rowDirections[count] == rowDirection && colDirections[count] == colDirection)
                {
                    currentDirectionIndex = count;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                rowDirection = rowDirections[0];
                colDirection = colDirections[0];
            }
            else
            {
                rowDirection = rowDirections[currentDirectionIndex + 1];
                colDirection = colDirections[currentDirectionIndex + 1];
            }
        }

        private static void SetPositionToFirstEmptyCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    if (arr[row, col] == 0)
                    {
                        x = row;
                        y = col;
                        return;
                    }
                }
            }
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}