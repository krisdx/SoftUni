using System;
using System.Linq;

class Tetris
{
    static void Main()
    {
        int[] matrixSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int matrixRows = matrixSizes[0];
        int matrixCols = matrixSizes[1];

        char[][] matrix = new char[matrixRows][];
        for (int i = 0; i < matrixRows; i++)
        {
            matrix[i] = Console.ReadLine().ToLower().ToCharArray();
        }

        int I = 0;
        int L = 0;
        int J = 0;
        int O = 0;
        int Z = 0;
        int S = 0;
        int T = 0;
        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                I += GetI(matrix, row, col);
                L += GetL(matrix, row, col);
                J += GetJ(matrix, row, col);
                O += GetO(matrix, row, col);
                Z += GetZ(matrix, row, col);
                S += GetS(matrix, row, col);
                T += GetT(matrix, row, col);
            }
        }

        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", I, L, J, O, Z, S, T);
    }

    private static int GetT(char[][] matrix, int row, int col)
    {
        if (row + 1 >= matrix.Length || 
            col + 2 >= matrix[row].Length)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
             matrix[row][col + 1] == 'o' &&
             matrix[row][col + 2] == 'o' &&
             matrix[row + 1][col + 1] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetS(char[][] matrix, int row, int col)
    {
        if (row + 1 >= matrix.Length || 
            col + 1 >= matrix[row].Length || 
            col - 1 < 0)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
            matrix[row][col + 1] == 'o' &&
            matrix[row + 1][col] == 'o' &&
            matrix[row + 1][col - 1] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetZ(char[][] matrix, int row, int col)
    {
        if (row + 1 >= matrix.Length || 
            col + 2 >= matrix[row].Length)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
            matrix[row][col + 1] == 'o' &&
            matrix[row + 1][col + 1] == 'o' &&
            matrix[row + 1][col + 2] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetO(char[][] matrix, int row, int col)
    {
        if (row + 1 >= matrix.Length || 
            col + 1 >= matrix[row].Length)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
            matrix[row][col + 1] == 'o' &&
            matrix[row + 1][col] == 'o' &&
            matrix[row + 1][col + 1] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetJ(char[][] matrix, int row, int col)
    {
        if (row + 2 >= matrix.Length ||
            col - 1 < 0)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
               matrix[row + 1][col] == 'o' &&
               matrix[row + 2][col] == 'o' &&
               matrix[row + 2][col - 1] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetL(char[][] matrix, int row, int col)
    {
        if (row + 2 >= matrix.Length || 
            col + 1 >= matrix[row].Length)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
            matrix[row + 1][col] == 'o' &&
            matrix[row + 2][col] == 'o' &&
            matrix[row + 2][col + 1] == 'o')
        {
            return 1;
        }

        return 0;
    }

    private static int GetI(char[][] matrix, int row, int col)
    {
        if (row + 3 >= matrix.Length)
        {
            return 0;
        }

        if (matrix[row][col] == 'o' &&
            matrix[row + 1][col] == 'o' &&
            matrix[row + 2][col] == 'o' &&
            matrix[row + 3][col] == 'o')
        {
            return 1;
        }

        return 0;
    }
}