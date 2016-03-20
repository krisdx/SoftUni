using System;

class FillTheMatrix
{
    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());

        PrintPatternA(matrixSize);
        Console.WriteLine("\n");
        PrintPatternB(matrixSize);
    }

    private static void PrintPatternA(int size)
    {
        int[,] matrix = new int[size, size];

        int value = 1;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                matrix[row, col] = value;
                value++;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }

    private static void PrintPatternB(int size)
    {

        int[,] matrix = new int[size, size];

        int value = 1;
        bool isDirectionDown = true;
        for (int col = 0; col < matrix.GetLength(0); col++)
        {
            for (int row = 0; row < matrix.GetLength(1); row++)
            {
                if (isDirectionDown)
                {
                    matrix[row, col] = value;
                    value++;
                }
                else
                {
                    matrix[row, col] = value;
                    value--;
                }
            }

            if (isDirectionDown)
            {
                value += matrix.GetLength(0) - 1;
                isDirectionDown = false;
            }
            else
            {
                isDirectionDown = true;
                value += matrix.GetLength(0) + 1;
            }
        }

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}