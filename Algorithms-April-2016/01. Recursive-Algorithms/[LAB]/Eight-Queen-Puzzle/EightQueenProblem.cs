namespace EightQueenProblem
{
    using System;
    using System.Text;

    public class EightQueenProblem
    {
        private const int ChessBoardSize = 8;

        private static bool[,] chessBoard = new bool[ChessBoardSize, ChessBoardSize];

        private static bool[] colsUnderAttack = new bool[ChessBoardSize];
        private static bool[] rightDiagonalsUnderAttack = new bool[ChessBoardSize * 2];
        private static bool[] leftDiagonalsUnderAttack = new bool[ChessBoardSize * 2];

        private static StringBuilder output = new StringBuilder();

        private static int solutionsFound;

        public static void Main()
        {
            PutQueens(0);
            Console.Write(output);
            Console.WriteLine("Total solutions: " + solutionsFound);
        }

        private static void PutQueens(int row)
        {
            if (row == ChessBoardSize)
            {
                PrintSolution();
                return;
            }

            for (int col = 0; col < ChessBoardSize; col++)
            {
                if (!isPositionUnderAttack(row, col))
                {
                    MarkAllAttackedPositions(row, col);
                    PutQueens(row + 1);
                    UnMarkAllAttakcedPositions(row, col);
                }
            }
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            colsUnderAttack[col] = true;
            leftDiagonalsUnderAttack[(col - row) + ChessBoardSize] = true;
            rightDiagonalsUnderAttack[row + col] = true;
            chessBoard[row, col] = true;
        }

        private static void UnMarkAllAttakcedPositions(int row, int col)
        {
            colsUnderAttack[col] = false;
            rightDiagonalsUnderAttack[row + col] = false;
            leftDiagonalsUnderAttack[(col - row) + ChessBoardSize] = false;
            chessBoard[row, col] = false;
        }

        private static bool isPositionUnderAttack(int row, int col)
        {
            bool isPositionUnderAttack =
                colsUnderAttack[col] ||
                rightDiagonalsUnderAttack[row + col] ||
                leftDiagonalsUnderAttack[(col - row) + ChessBoardSize];
            return isPositionUnderAttack;
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < ChessBoardSize; row++)
            {
                for (int col = 0; col < ChessBoardSize; col++)
                {
                    if (chessBoard[row, col])
                    {
                        // Queen
                        output.Append('*');
                    }
                    else
                    {
                        // Empty cell
                        output.Append('-');
                    }
                }

                output.AppendLine();
            }

            output.AppendLine();
            solutionsFound++;
        }
    }
}