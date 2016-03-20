using System;
using System.Collections.Generic;
using System.Linq;

public class SecondProblem
{
    static string winOrLose = string.Empty;

    static int playerRow = 0;
    static int playerCol = 0;

    public static void Main()
    {
        int[] rowsAndCols = Console.ReadLine().Trim().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int rows = rowsAndCols[0];
        int cols = rowsAndCols[1];

        char[][] matrix = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = Console.ReadLine().Trim().ToCharArray();
        }

        GetInitialPositionOfPlayer(matrix);
        matrix[playerRow][playerCol] = '.';

        char[] commands = Console.ReadLine().Trim().ToCharArray();
        int index = 0;
        while (winOrLose != "won" &&
                winOrLose != "lost" && 
                index < commands.Length)
        {
            char currentDirection = commands[index];

            if (currentDirection == 'U')
            {
                if (playerRow - 1 < 0)
                {
                    winOrLose = "won";
                }
                else
                {
                    playerRow--;
                }
            }
            else if (currentDirection == 'D')
            {
                if (playerRow + 1 >= matrix.Length)
                {
                    winOrLose = "won";
                }
                else
                {
                    playerRow++;
                }
            }
            else if (currentDirection == 'L')
            {
                if (playerCol - 1 < 0)
                {
                    winOrLose = "won";
                }
                else
                {
                    playerCol--;
                }
            }
            else if (currentDirection == 'R')
            {
                if (playerCol + 1 >= matrix[playerCol].Length)
                {
                    winOrLose = "won";
                }
                else
                {
                    playerRow++;
                }
            }

            if (matrix[playerRow][playerCol] == 'B')
            {
                winOrLose = "lost";
            }

            MultiplyBunnies(matrix);

            if (matrix[playerRow][playerCol] == 'B')
            {
                winOrLose = "lost";
            }

            index++;
        }

        Print(matrix);

        if (winOrLose == "won")
        {
            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
        }
        else
        {
            Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
        }
    }

    private static void Print(char[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(matrix[row][col]);
            }
            Console.WriteLine();
        }
    }

    private static void MultiplyBunnies(char[][] matrix)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'B')
                {
                    if (row - 1 >= 0)
                    {
                        matrix[row - 1][col] = 'b';
                    }
                    if (row + 1 < matrix.Length)
                    {
                        matrix[row + 1][col] = 'b';
                    }
                    if (col - 1 >= 0)
                    {
                        matrix[row][col - 1] = 'b';
                    }
                    if (col + 1 < matrix[row].Length)
                    {
                        matrix[row][col + 1] = 'b';
                    }
                }
            }
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                matrix[row][col] = char.ToUpper(matrix[row][col]);
            }
        }
    }

    private static void GetInitialPositionOfPlayer(char[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 'P')
                {
                    playerRow = i;
                    playerCol = j;
                    return;
                }
            }
        }
    }
}