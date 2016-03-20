using System;
using System.Linq;

public class TargetPractice
{
    static void Main()
    {
        int[] matrixRowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string text = Console.ReadLine();
        int[] shootParams = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int matrixRows = matrixRowsAndCols[0];
        int matrixCols = matrixRowsAndCols[1];
        char[,] matrix = new char[matrixRows, matrixCols];

        matrix = FillMatrix(matrix, text);

        matrix = ShootMatrix(matrix, shootParams);

        matrix = BringDownChars(matrix);

        PrintMatrix(matrix);
    }

    private static char[,] FillMatrix(char[,] matrix, string text)
    {
        int textIndex = 0;
        int colIndex = matrix.GetLength(1) - 1;
        bool isDirectionLeft = true;
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            while (true)
            {
                matrix[row, colIndex] = text[textIndex];

                textIndex++;
                if (textIndex == text.Length)
                {
                    textIndex = 0;
                }

                if (isDirectionLeft)
                {
                    if (colIndex == 0)
                    {
                        break;
                    }

                    colIndex--;
                }
                else
                {
                    if (colIndex == matrix.GetLength(1) - 1)
                    {
                        break;
                    }

                    colIndex++;
                }

            }

            isDirectionLeft = !isDirectionLeft;
        }

        return matrix;
    }

    private static char[,] ShootMatrix(char[,] matrix, int[] shootParams)
    {
        int shootRow = shootParams[0];
        int shootCol = shootParams[1];
        int radius = shootParams[2];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                bool isInside =
                    (row - shootRow) * (row - shootRow) +
                    (col - shootCol) * (col - shootCol)
                    <= radius * radius;
                if (isInside)
                {
                    matrix[row, col] = ' ';
                }
            }
        }

        return matrix;
    }

    private static char[,] BringDownChars(char[,] matrix)
    {
        for (int row = matrix.GetLength(0) - 2; row >= 0; row--)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row + 1, col] == ' ')
                {
                    int rowIndex = row + 1;
                    do
                    {
                        rowIndex++;
                    } while (rowIndex <= matrix.GetLength(0) - 1 && matrix[rowIndex, col] == ' ');
                    rowIndex--;
                    matrix[rowIndex, col] = matrix[row, col];
                    matrix[row, col] = ' ';
                }
            }
        }

        return matrix;
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLongLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}