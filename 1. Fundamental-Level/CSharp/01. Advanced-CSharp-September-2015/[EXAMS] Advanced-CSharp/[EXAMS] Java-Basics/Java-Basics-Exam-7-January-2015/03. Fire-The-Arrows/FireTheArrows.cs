using System;
using System.Collections.Generic;

class FireTheArrows
{
    static int n = int.Parse(Console.ReadLine());
    static char[][] matrix = new char[n][];
    static List<char> arrows = new List<char>() { '^', 'v', '<', '>' };
    static bool hasLeftMovesToMake = true;

    static void Main()
    {
        for (int i = 0; i < n; i++)
        {
            matrix[i] = Console.ReadLine().ToCharArray();
        }

        while (hasLeftMovesToMake)
        {
            hasLeftMovesToMake = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != 'o')
                    {
                        MoveArrow(matrix, row, col);
                    }
                }
            }
        }

        PrintMatrix();
    }

    static void MoveArrow(char[][] matrix, int row, int col)
    {
        bool isOutiseOfMatrix;
        if (matrix[row][col] == '^')
        {
            isOutiseOfMatrix = IsOutsideOfMatrix(matrix, row - 1, col);
            if (!isOutiseOfMatrix && !arrows.Contains(matrix[row - 1][col]))
            {
                matrix[row - 1][col] = '^';
                matrix[row][col] = 'o';
                hasLeftMovesToMake = true;
            }
        }
        else if (matrix[row][col] == 'v')
        {
            isOutiseOfMatrix = IsOutsideOfMatrix(matrix, row + 1, col);
            if (!isOutiseOfMatrix && !arrows.Contains(matrix[row + 1][col]))
            {
                matrix[row + 1][col] = 'v';
                matrix[row][col] = 'o';
                hasLeftMovesToMake = true;
            }
        }
        else if (matrix[row][col] == '<')
        {
            isOutiseOfMatrix = IsOutsideOfMatrix(matrix, row, col - 1);
            if (!isOutiseOfMatrix && !arrows.Contains(matrix[row][col - 1]))
            {
                matrix[row][col - 1] = '<';
                matrix[row][col] = 'o';
                hasLeftMovesToMake = true;
            }
        }
        else if (matrix[row][col] == '>')
        {
            isOutiseOfMatrix = IsOutsideOfMatrix(matrix, row, col + 1);
            if (!isOutiseOfMatrix && !arrows.Contains(matrix[row][col + 1]))
            {
                matrix[row][col + 1] = '>';
                matrix[row][col] = 'o';
                hasLeftMovesToMake = true;
            }
        }
    }

    static bool IsOutsideOfMatrix(char[][] matrix, int row, int col)
    {
        if (row > matrix.GetLength(0) - 1 || row < 0)
        {
            return true;
        }
        if (col > matrix[row].GetLength(0) - 1 || col < 0)
        {
            return true;
        }

        return false;
    }

    static void PrintMatrix()
    {
        foreach (var row in matrix)
        {
            foreach (var col in row)
            {
                Console.Write(col);
            }
            Console.WriteLine();
        }
    }
}