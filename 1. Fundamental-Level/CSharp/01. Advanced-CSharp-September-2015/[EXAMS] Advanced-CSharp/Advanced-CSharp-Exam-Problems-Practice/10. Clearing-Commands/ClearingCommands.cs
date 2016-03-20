using System;
using System.Collections.Generic;
using System.Security;

class ClearingCommands
{
    static List<char> commands = new List<char> { '<', '>', 'v', '^' };

    static void Main()
    {
        List<string> inputLines = new List<string>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            inputLines.Add(inputLine);

            inputLine = Console.ReadLine();
        }

        char[][] matrix = new char[inputLines.Count][];
        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[i] = inputLines[i].ToCharArray();
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (commands.Contains(matrix[row][col]))
                {
                    matrix = ExecuteCommand(matrix, row, col);
                }
            }
        }

        Print(matrix);
    }

    static char[][] ExecuteCommand(char[][] matrix, int row, int col)
    {
        if (matrix[row][col] == '>')
        {
            col++;
            while (col <= matrix[row].Length - 1 && !commands.Contains(matrix[row][col]))
            {
                matrix[row][col] = ' ';
                col++;
            }
        }
        else if (matrix[row][col] == '<')
        {
            col--;
            while (col >= 0 && !commands.Contains(matrix[row][col]))
            {
                matrix[row][col] = ' ';
                col--;
            }
        }
        else if (matrix[row][col] == '^')
        {
            row--;
            while (row >= 0 && !commands.Contains(matrix[row][col]))
            {
                matrix[row][col] = ' ';
                row--;
            }
        }
        else if (matrix[row][col] == 'v')
        { 
            row++;
            while (row <= matrix.Length - 1 && !commands.Contains(matrix[row][col]))
            {
                matrix[row][col] = ' ';
                row++;
            }
        }

        return matrix;
    }

    static void Print(char[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.Write("<p>");
            foreach (var col in row)
            {
                Console.Write(SecurityElement.Escape(col.ToString()));
            }
            Console.WriteLine("</p>");
        }
    }
}