using System;
using System.Text;

class MatrixShuffle
{
    static int matrixSize = int.Parse(Console.ReadLine());
    static char[,] matrix = new char[matrixSize, matrixSize];
    static string direction = "right";

    static int row = 0;
    static int col = -1;

    static void Main()
    {
        string input = Console.ReadLine();

        FillMatrix(input);
        //Print(matrix);

        StringBuilder result = GetSquares(matrix);

        bool arePalindromes = ArePolindromes(result);
        if (arePalindromes)
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
        }
    }

    public static bool ArePolindromes(StringBuilder result)
    {
        StringBuilder trimmedResult = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            if (char.IsLetter(result[i]))
            {
                trimmedResult.Append(char.ToLower(result[i]));
            }
        }

        StringBuilder reversedTrimmedResult = new StringBuilder();
        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (char.IsLetter(result[i]))
            {
                reversedTrimmedResult.Append(char.ToLower(result[i]));
            }
        }

        if (trimmedResult.Equals(reversedTrimmedResult))
        {
            return true;
        }

        return false;
    }

    public static StringBuilder GetSquares(char[,] matrix)
    {
        StringBuilder result = new StringBuilder();

        int colIndex = 0;
        bool oddStart = false;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            while (colIndex < matrix.GetLength(1))
            {
                result.Append(matrix[row, colIndex]);
                colIndex += 2;
            }

            oddStart = !oddStart;
            if (oddStart)
            {
                colIndex = 1;
            }
            else
            {
                colIndex = 0;
            }
        }

        oddStart = true;
        colIndex = 1;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            while (colIndex < matrix.GetLength(1))
            {
                result.Append(matrix[row, colIndex]);
                colIndex += 2;
            }

            oddStart = !oddStart;
            if (!oddStart)
            {
                colIndex = 0;
            }
            else
            {
                colIndex = 1;
            }
        }

        return result;
    }

    public static void FillMatrix(string input)
    {
        int index = -1;
        while (index < input.Length)
        {
            if (direction == "right")
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
            else if (direction == "down")
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
            else if (direction == "left")
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
            else if (direction == "up")
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

            bool isFilled = IsFilled(matrix);
            if (isFilled)
            {
                break;
            }

            index++;
            if (index >= input.Length)
            {
                matrix[row, col] = ' ';
            }
            else
            {
                matrix[row, col] = input[index];
            }
        }
    }

    public static bool IsFilled(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static void ChangeDirection()
    {
        switch (direction)
        {
            case "right": direction = "down"; break;
            case "down": direction = "left"; break;
            case "left": direction = "up"; break;
            case "up": direction = "right"; break;
        }
    }

    //public static void Print(char[,] matrix)
    //{
    //    for (int i = 0; i < matrix.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < matrix.GetLength(1); j++)
    //        {
    //            Console.Write("{0,3}", matrix[i, j]);
    //        }
    //        Console.WriteLine();
    //    }
    //}
}