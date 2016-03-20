using System;

class SpiralMatrix
{
    static int matrixSize = int.Parse(Console.ReadLine());
    static char[,] matrix = new char[matrixSize, matrixSize];
    static int direction = 1;

    static int row = 0;
    static int col = -1;

    static void Main()
    {
        string input = Console.ReadLine().ToLower();

        FillMatrix(input);
        int[] rowWithBiggestSum = GetRowWithBiggestSum(matrix);
        Console.WriteLine("{0} - {1}", rowWithBiggestSum[0], rowWithBiggestSum[1]);
    }

    public static int[] GetRowWithBiggestSum(char[,] matrix)
    {
        int biggestSum = 0;
        int bestRow = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int currentSum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                currentSum += ((char.ToLower(matrix[i, j]) - 'a') + 1) * 10;
            }

            if (currentSum > biggestSum)
            {
                biggestSum = currentSum;
                bestRow = i;
            }
        }

        int[] rowAndSum = new int[2];
        rowAndSum[0] = bestRow;
        rowAndSum[1] = biggestSum;

        return rowAndSum;
    }

    public static void FillMatrix(string input)
    {
        int index = -1;
        int counter = 0;
        while (index < input.Length)
        {
            if (direction == 1)
            {
                col++;
                if (col == matrix.GetLength(1) - 1)
                {
                    ChangeDirection();
                }

                if (col + 1 <= matrix.GetLength(1) - 1 && matrix[row, col + 1] != 0)
                {
                    ChangeDirection();
                }
            }
            else if (direction == 2)
            {
                row++;
                if (row == matrix.GetLength(0) - 1)
                {
                    ChangeDirection();
                }

                if (row + 1 <= matrix.GetLength(0) - 1 && matrix[row + 1, col] != 0)
                {
                    ChangeDirection();
                }
            }
            else if (direction == 3)
            {
                col--;
                if (col == 0)
                {
                    ChangeDirection();
                }
                if (col - 1 >= 0 && matrix[row, col - 1] != 0)
                {
                    ChangeDirection();
                }
            }
            else if (direction == 4)
            {
                row--;
                if (row == 0)
                {
                    ChangeDirection();
                }

                if (row - 1 >= 0 && matrix[row - 1, col] != 0)
                {
                    ChangeDirection();
                }
            }

            index++;
            if (index == input.Length)
            {
                index = 0;
            }

            matrix[row, col] = input[index];
            counter++;
            if (counter == matrixSize * matrixSize)
            {
                break;
            }
        }
    }

    public static void ChangeDirection()
    {
        switch (direction)
        {
            case 1: direction = 2; break;
            case 2: direction = 3; break;
            case 3: direction = 4; break;
            case 4: direction = 1; break;
        }
    }
}