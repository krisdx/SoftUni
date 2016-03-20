using System;

public class ManipulateMatrices
{
    public static void Main()
    {
        var firstMatrix = new double[,] 
        { 
            { 1, 3 }, 
            { 5, 7 } 
        };
        var secondMatrix = new double[,] 
        { 
            { 4, 2 },
            { 1, 5 } 
        };

        var resultMatrix = MultiplyMatrices(firstMatrix, secondMatrix);

        PrintMatrix(resultMatrix);
    }

    private static double[,] MultiplyMatrices(double[,] firstMatrix, double[,] secondMatrix)
    {
        if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
        {
            throw new ArgumentException("The matrices are not with equal lengths!");
        }

        var firstMatrixColsCount = firstMatrix.GetLength(1);
        var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                for (int k = 0; k < firstMatrixColsCount; k++)
                {
                    resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            }
        }

        return resultMatrix;
    }

    private static void PrintMatrix(double[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }

            Console.WriteLine();
        }
    }
}