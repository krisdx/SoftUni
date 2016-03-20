using System;
using System.Collections.Generic;

class XRemoval
{
    static void Main() // bad code quality :(
    {
        List<string> inputLines = new List<string>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            inputLines.Add(inputLine);

            inputLine = Console.ReadLine();
        }

        char[][] matrix = new char[inputLines.Count][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = inputLines[i].ToCharArray();
        }

        List<int> plusShapesStartingIndexes = GetStartingIndexex(matrix);

        for (int i = 0; i < plusShapesStartingIndexes.Count - 1; i += 2)
        {
            int rowIndex = i;
            int colIndex = i + 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].GetLength(0); col++)
                {
                    if (row == plusShapesStartingIndexes[rowIndex] &&
                        col == plusShapesStartingIndexes[colIndex])
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] &&
                        col == plusShapesStartingIndexes[colIndex] + 2)
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 1 &&
                        col == plusShapesStartingIndexes[colIndex] + 1)
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 2 &&
                        col == plusShapesStartingIndexes[colIndex])
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 2 &&
                        col == plusShapesStartingIndexes[colIndex] + 2)
                    {
                        matrix[row][col] = '`';
                    }
                }
            }
        }

        Print(matrix);
    }

    private static void Print(char[][] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix[row].GetLength(0); col++)
            {
                if (matrix[row][col] != '`')
                {
                    Console.Write(matrix[row][col]);
                }
            }
            Console.WriteLine();
        }
    }

    static List<int> GetStartingIndexex(char[][] matrix)
    {
        List<int> startingIndexes = new List<int>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix[row].GetLength(0); col++)
            {
                bool canFormAPlusShape = CanFormAnXShape(matrix, row, col);
                if (canFormAPlusShape)
                {
                    bool isPlusShapeCorrect = IsXShapeCorrect(matrix, row, col);
                    if (isPlusShapeCorrect)
                    {
                        startingIndexes.Add(row);
                        startingIndexes.Add(col);
                    }
                }
            }
        }

        return startingIndexes;
    }

    static bool IsXShapeCorrect(char[][] matrix, int row, int col)
    {
        bool isLetter = char.IsLetter(matrix[row][col]);
        if (isLetter)
        {
            bool isCenterCharEqual =
            matrix[row][col] - 32 == matrix[row + 1][col + 1] ||
            matrix[row][col] + 32 == matrix[row + 1][col + 1] ||
            matrix[row][col] == matrix[row + 1][col + 1] ||
            matrix[row][col] == matrix[row + 1][col + 1] + 32 ||
            matrix[row][col] == matrix[row + 1][col + 1] - 32;

            bool isLeftCharEqual =
            matrix[row][col] - 32 == matrix[row][col + 2] ||
            matrix[row][col] + 32 == matrix[row][col + 2] ||
            matrix[row][col] == matrix[row][col + 2] ||
            matrix[row][col] == matrix[row][col + 2] + 32 ||
            matrix[row][col] == matrix[row][col + 2] - 32;

            bool isDownRightCharEqual =
                matrix[row][col] - 32 == matrix[row + 2][col + 2] ||
                matrix[row][col] + 32 == matrix[row + 2][col + 2] ||
                matrix[row][col] == matrix[row + 2][col + 2] ||
                matrix[row][col] == matrix[row + 2][col + 2] + 32 ||
                matrix[row][col] == matrix[row + 2][col + 2] - 32;

            bool isDownLeftCharEqual =
                matrix[row][col] - 32 == matrix[row + 2][col] ||
                matrix[row][col] + 32 == matrix[row + 2][col] ||
                matrix[row][col] == matrix[row + 2][col] ||
                matrix[row][col] == matrix[row + 2][col] - 32 ||
                matrix[row][col] == matrix[row + 2][col] + 32;

            if (isCenterCharEqual && isDownLeftCharEqual && isLeftCharEqual && isDownRightCharEqual)
            {
                return true;
            }

        }
        else
        {
            if (matrix[row][col].Equals(matrix[row][col + 2]) &&
                 matrix[row][col].Equals(matrix[row + 1][col + 1]) &&
                 matrix[row][col].Equals(matrix[row + 2][col]) &&
                 matrix[row][col].Equals(matrix[row + 2][col + 2]))
            {
                return true;
            }
        }

        return false;
    }

    static bool CanFormAnXShape(char[][] matrix, int row, int col)
    {
        if (row + 2 > matrix.GetLength(0) - 1)
        {
            return false;
        }
        if (col + 2 > matrix[row].GetLength(0) - 1 ||
            col + 1 > matrix[row + 1].GetLength(0) - 1 ||
            col + 2 > matrix[row + 2].GetLength(0) - 1)
        {
            return false;
        }

        return true;
    }
}