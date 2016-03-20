using System;
using System.Collections.Generic;
using System.Security;

class TextGravity
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string inputText = Console.ReadLine();
        List<List<char>> matrix = GetMatrixFromInput(inputText, length);

        matrix = MoveCharsDown(matrix);

        Print(matrix);
    }

    static List<List<char>> MoveCharsDown(List<List<char>> matrix)
    {
        for (int row = matrix.Count - 2; row >= 0; row--)
        {
            for (int col = 0; col < matrix[row].Count; col++)
            {
                if (matrix[row + 1][col] == ' ')
                {
                    int rowIndex = row + 1;
                    do
                    {
                        rowIndex++;
                    } while (rowIndex <= matrix.Count - 1 && matrix[rowIndex][col] == ' ');
                    rowIndex--;
                    matrix[rowIndex][col] = matrix[row][col];
                    matrix[row][col] = ' ';
                }
            }
        }

        return matrix;
    }

    static List<List<char>> GetMatrixFromInput(string inputText, int colummnLength)
    {
        List<List<char>> matrix = new List<List<char>>();

        int counter = 1;
        int index = 0;
        while (counter <= inputText.Length)
        {
            List<char> currentRow = new List<char>();
            for (int i = 0; i < colummnLength; i++)
            {
                if (counter > inputText.Length)
                {
                    currentRow.Add(' ');
                }
                else
                {
                    currentRow.Add(inputText[index]);
                }
                counter++;
                index++;
            }

            matrix.Add(currentRow);
        }

        return matrix;
    }

    static void Print(List<List<char>> matrix)
    {
        Console.Write("<table>");
        foreach (var row in matrix)
        {
            Console.Write("<tr>");  
            foreach (var col in row)
            {
                Console.Write("<td>{0}</td>", SecurityElement.Escape(col.ToString()));
            }
            Console.Write("</tr>");
        }
        Console.Write("</table>");
    }
}