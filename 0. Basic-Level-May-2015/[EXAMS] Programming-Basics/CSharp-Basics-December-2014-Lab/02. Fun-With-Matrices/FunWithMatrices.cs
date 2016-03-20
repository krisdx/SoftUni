using System;

class FunWithMatrices
{
    const int MatrixSize = 4;

    static void Main()
    {
        double initialValue = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());

        double[,] matrix = FillMatrix(initialValue, step);

        string input = Console.ReadLine();
        while (input != "Game Over!")
        {
            string[] commandDetails = input.Split(' ');
            int row = int.Parse(commandDetails[0]);
            int col = int.Parse(commandDetails[1]);
            string command = commandDetails[2];
            double num = double.Parse(commandDetails[3]);

            if (command == "multiply")
            {
                matrix[row, col] *= num;
            }
            else if (command == "sum")
            {
                matrix[row, col] += num;
            }
            else if (command == "power")
            {
                matrix[row, col] = Math.Pow(matrix[row, col], num);
            }

            input = Console.ReadLine();
        }

        // Getting the best row sum
        double maxRowSum;
        int rowIndex;
        GetRowWithBiggestSum(matrix, out maxRowSum, out rowIndex);

        // Geting the best col sum
        double maxColSum;
        int colIndex;
        GetColWithBIggestSum(matrix, out maxColSum, out colIndex);

        // Geting the bes diagonal sum (and direction)
        double leftDiagonalSum = GetLeftDiagonalSum(matrix);
        double rightDiagonalSum = GetRightDiagonalSum(matrix);
        string directionOfBestDiagonal;
        double bestDiagonalSum;
        if (rightDiagonalSum > leftDiagonalSum)
        {
            directionOfBestDiagonal = "RIGHT-DIAGONAL";
            bestDiagonalSum =  rightDiagonalSum;
        }
        else
        {
            directionOfBestDiagonal = "LEFT-DIAGONAL";
            bestDiagonalSum = leftDiagonalSum;
        }

        // output
        if (maxRowSum >= maxColSum &&
            maxRowSum >= bestDiagonalSum)
        {
            Console.WriteLine("ROW[{0}] = {1:f2}", rowIndex,maxRowSum, 2);
        }
        else if (maxColSum >= maxRowSum &&
                 maxColSum >= bestDiagonalSum)
        {
            Console.WriteLine("COLUMN[{0}] = {1:f2}", colIndex, Math.Round(maxColSum, 2));
        }
        else 
        {
            Console.WriteLine("{0} = {1:f2}", directionOfBestDiagonal, bestDiagonalSum);
        }
    }
    
    private static double GetRightDiagonalSum(double[,] matrix)
    {
        double rightDiagonalSum = 0;
        int rightDiagonalRow = 3;
        int rightDiagonalCol = 0;
        while (rightDiagonalCol < MatrixSize)
        {
            rightDiagonalSum += matrix[rightDiagonalRow, rightDiagonalCol];
            rightDiagonalRow--;
            rightDiagonalCol++;
        }
        return rightDiagonalSum;
    }

    private static double GetLeftDiagonalSum(double[,] matrix)
    {
        double leftDiagonalSum = 0;
        int leftDiagonalRow = 0;
        int leftDiagonalCol = 0;
        while (leftDiagonalRow < MatrixSize)
        {
            leftDiagonalSum += matrix[leftDiagonalRow, leftDiagonalCol];
            leftDiagonalRow++;
            leftDiagonalCol++;
        }
        return leftDiagonalSum;
    }

    private static void GetColWithBIggestSum(double[,] matrix, out double maxColSum, out int colIndex)
    {
        maxColSum = double.MinValue;
        colIndex = 0;
        for (int col = 0; col < MatrixSize; col++)
        {
            double currentSum = 0;
            for (int row = 0; row < MatrixSize; row++)
            {
                currentSum += matrix[row, col];
            }

            if (currentSum > maxColSum)
            {
                maxColSum = currentSum;
                colIndex = col;
            }
        }
    }

    private static void GetRowWithBiggestSum(double[,] matrix, out double maxRowSum, out int rowIndex)
    {
        maxRowSum = double.MinValue;
        rowIndex = 0;
        for (int row = 0; row < MatrixSize; row++)
        {
            double currentSum = 0;
            for (int col = 0; col < MatrixSize; col++)
            {
                currentSum += matrix[row, col];
            }

            if (currentSum > maxRowSum)
            {
                maxRowSum = currentSum;
                rowIndex = row;
            }
        }
    }

    private static double[,] FillMatrix(double initialValue, double step)
    {
        double[,] matrix = new double[MatrixSize, MatrixSize];
        double value = initialValue;
        for (int row = 0; row < MatrixSize; row++)
        {
            for (int col = 0; col < MatrixSize; col++)
            {
                matrix[row, col] += value;
                value += step;
            }
        }
        return matrix;
    }
}