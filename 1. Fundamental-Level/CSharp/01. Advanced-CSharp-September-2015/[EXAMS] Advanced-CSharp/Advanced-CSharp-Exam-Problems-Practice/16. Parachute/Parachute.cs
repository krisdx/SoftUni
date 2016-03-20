using System;
using System.Collections.Generic;

class Parachute
{
    static void Main()
    {
        List<string> input = new List<string>();
        string inputRow = Console.ReadLine();
        while (inputRow != "END")
        {
            input.Add(inputRow);

            inputRow = Console.ReadLine();
        }

        char[][] matrix = new char[input.Count][];
        for (int i = 0; i < input.Count; i++)
        {
            matrix[i] = input[i].ToCharArray();
        }

        int[] initialPosition = GetInitialPosition(matrix);
        int initialRow = initialPosition[0];
        int initialCol = initialPosition[1];

        int col = initialCol;
        for (int row = initialRow + 1; row < matrix.Length; row++)
        {
            for (int i = 0; i < matrix[row].Length; i++)
            {
                if (matrix[row][i] == '<')
                {
                   col--;
                    matrix[row][i] = '-';
                }
                else if (matrix[row][i] == '>')
                {
                    col++;
                    matrix[row][i] = '-';
                }
            }

            // check where've landed
            if (matrix[row][col] == '_')
            {
                Console.WriteLine("Landed on the ground like a boss!");
                Console.WriteLine("{0} {1}", row, col);
                return;
            }
            else if (matrix[row][col] == '~')
            {
                Console.WriteLine("Drowned in the water like a cat!");
                Console.WriteLine("{0} {1}", row, col);
                return;
            }
            else if (matrix[row][col] == '\\' ||
                     matrix[row][col] == '/' ||
                     matrix[row][col] == '|')
            {
                Console.WriteLine("Got smacked on the rock like a dog!");
                Console.WriteLine("{0} {1}", row, col);
                return;
            }
        }
    }

    public static int[] GetInitialPosition(char[][] matrix)
    {
        int[] initialPosition = new int[2];
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == 'o')
                {
                    initialPosition[0] = row;
                    initialPosition[1] = col;
                }
            }
        }
        return initialPosition;
    }
}