using System;
using System.Collections.Generic;

class PlusRemove
{
    static void Main()
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

        for (int i = 0; i < plusShapesStartingIndexes.Count - 1; i+=2)
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
                    else if (row == plusShapesStartingIndexes[rowIndex] + 1 &&
                        col == plusShapesStartingIndexes[colIndex])
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 1 &&
                        col == plusShapesStartingIndexes[colIndex] + 1)
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 1 &&
                        col == plusShapesStartingIndexes[colIndex] - 1)
                    {
                        matrix[row][col] = '`';
                    }
                    else if (row == plusShapesStartingIndexes[rowIndex] + 2 &&
                        col == plusShapesStartingIndexes[colIndex])
                    {
                        matrix[row][col] = '`';
                    }
                }
            }
        }


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
                bool canFormAPlusShape = CanFormAPlusShape(matrix, row, col);
                if (canFormAPlusShape)
                {
                    bool isPlusShapeCorrect = IsPlusShapeCorrect(matrix, row, col);
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

    static bool IsPlusShapeCorrect(char[][] matrix, int row, int col)
    {
        bool isLetter = char.IsLetter(matrix[row][col]);
        if (isLetter)
        {
            bool isCenterCharEqual =
            matrix[row][col] - 32 == matrix[row + 1][col] ||
            matrix[row][col] + 32 == matrix[row + 1][col] ||
            matrix[row][col] == matrix[row + 1][col] ||
            matrix[row][col] == matrix[row + 1][col] + 32 ||
            matrix[row][col] == matrix[row + 1][col] - 32;

            bool isLeftCharEqual =
                matrix[row + 1][col] - 32 == matrix[row + 1][col - 1] ||
                matrix[row + 1][col] + 32 == matrix[row + 1][col - 1] ||
                matrix[row + 1][col] == matrix[row + 1][col - 1] ||
                matrix[row + 1][col] == matrix[row + 1][col - 1] - 32 ||
                matrix[row + 1][col] == matrix[row + 1][col - 1] + 32;

            bool isRightCharEqual =
                matrix[row + 1][col] - 32 == matrix[row + 1][col + 1] ||
                matrix[row + 1][col] + 32 == matrix[row + 1][col + 1] ||
                matrix[row + 1][col] == matrix[row + 1][col + 1] ||
                matrix[row + 1][col] == matrix[row + 1][col + 1] + 32 ||
                matrix[row + 1][col] == matrix[row + 1][col + 1] - 32;

            bool isDownCharEqual =
                matrix[row + 1][col] - 32 == matrix[row + 2][col] ||
                matrix[row + 1][col] + 32 == matrix[row + 2][col] ||
                matrix[row + 1][col] == matrix[row + 2][col] ||
                matrix[row + 1][col] == matrix[row + 2][col] - 32 ||
                matrix[row + 1][col] == matrix[row + 2][col] + 32;

            if (isCenterCharEqual && isDownCharEqual && isLeftCharEqual && isRightCharEqual)
            {
                return true;
            }

        }
        else
        {
            if (matrix[row][col].Equals(matrix[row + 1][col]) &&
                 matrix[row][col].Equals(matrix[row + 1][col + 1]) &&
                 matrix[row][col].Equals(matrix[row + 1][col - 1]) &&
                 matrix[row][col].Equals(matrix[row + 2][col]))
            {
                return true;
            }
        }

        return false;
    }

    static bool CanFormAPlusShape(char[][] matrix, int row, int col)
    {
        if (row + 2 > matrix.GetLength(0) - 1)
        {
            return false;
        }
        if (col + 1 > matrix[row + 1].GetLength(0) - 1 ||
            col > matrix[row + 2].GetLength(0) - 1 ||
            col - 1 < 0)
        {
            return false;
        }

        return true;
    }
}