using System;
using System.Collections.Generic;
using System.Linq;

// Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. 

//On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row with its columns.

//Print the elements of the 3 x 3 square as a matrix, along with their sum.

class MaximalSum
{
    static void Main()
    {
        int[] rowsAndColsOfMatrix = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        if (rowsAndColsOfMatrix[0] < 3 || rowsAndColsOfMatrix[1] < 3)
        {
            Console.WriteLine("Matrix rows and columns can not be smaller than 3.");
            return;
        }

        int[][] matrix = new int[rowsAndColsOfMatrix[0]][];

        FillMatrix(rowsAndColsOfMatrix, matrix);

        long maxSum;
        int startRow;
        int startCol;
        FindSubMatrixWithMaxSum(matrix, out maxSum, out startRow, out startCol);

        Console.WriteLine("\nSum = {0}\nMatrix:", maxSum);
        PrintPartOfMatrixWithMaxSum(matrix, startRow, startCol);
    }

    private static void FillMatrix(int[] rowsAndColsOfMatrix, int[][] matrix)
    {
        for (int row = 0; row < rowsAndColsOfMatrix[0]; row++)
        {
            matrix[row] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        }
    }

    private static void FindSubMatrixWithMaxSum(int[][] matrix, out long maxSum, out int startRow, out int startCol)
    {
        maxSum = int.MinValue;
        startRow = 0;
        startCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < matrix.GetLength(0) - 2; col++)
            {
                long currentSum = 0;
                for (int platformRow = row; platformRow < row + 3; platformRow++)
                {
                    for (int platformCol = col; platformCol < col + 3; platformCol++)
                    {
                        currentSum += matrix[platformRow][platformCol];
                    }
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }
    }

    private static void PrintPartOfMatrixWithMaxSum(int[][] matrix, int startRow, int startCol)
    {
        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startCol; col < startCol + 3; col++)
            {
                Console.Write("{0,4}", matrix[row][col]);
            }
            Console.WriteLine();
        }
    }
}