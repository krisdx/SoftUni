using System;
using System.Collections.Generic;

class StringMatrixRotation
{
    static void Main()
    {
        int degrees = GetDegrees(Console.ReadLine());

        List<string> inputLines = new List<string>();
        string inputLine = Console.ReadLine();
        while (inputLine != "END")
        {
            inputLines.Add(inputLine);

            inputLine = Console.ReadLine();
        }

        char[][] matrix = new char[inputLines.Count][];
        int maxColLength = 0;
        for (int i = 0; i < inputLines.Count; i++)
        {
            matrix[i] = inputLines[i].ToCharArray();
            if (matrix[i].Length > maxColLength)
            {
                maxColLength = matrix[i].Length;
            }
        }
        if (degrees == 0)
        {
            PrintInitialMatrix(matrix);
            return;
        }

        List<List<char>> rotatedMatrix = new List<List<char>>();
        int counter = 0;
        int counterForInitialMatrix = 0;
        for (int i = 0; i < degrees / 90; i++)
        {
            counterForInitialMatrix = 0;
            if (counter == 0)
            {
                rotatedMatrix = Rotate90Degrees(matrix, maxColLength);
                counter++;
            }
            else if (counter == 1)
            {
                rotatedMatrix = Rotate180Degrees(rotatedMatrix);
                counter++;
            }
            else if (counter == 2)
            {
                rotatedMatrix = Rotate270Degrees(rotatedMatrix);
                counter++;
            }
            else if (counter == 3)
            {
                counter = 0;
                counterForInitialMatrix = 1;
            }

        }

        if (counterForInitialMatrix == 1)
        {
            PrintInitialMatrix(matrix);
        }
        else
        {
            Print(rotatedMatrix);
        }
    }

    static void PrintInitialMatrix(char[][] matrix)
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

    static List<List<char>> Rotate270Degrees(List<List<char>> rotatedMatrix180)
    {
        List<List<char>> rotated270DegreesMatrix = new List<List<char>>();

        for (int col = 0; col < rotatedMatrix180[0].Count; col++)
        {
            List<char> currentRow = new List<char>();
            for (int row = 0; row < rotatedMatrix180.Count; row++)
            {
                currentRow.Add(rotatedMatrix180[row][col]);
            }

            currentRow.Reverse();
            rotated270DegreesMatrix.Add(currentRow);
        }

        return rotated270DegreesMatrix;
    }

    static void Print(List<List<char>> rotatedMatrix)
    {
        foreach (var row in rotatedMatrix)
        {
            foreach (var col in row)
            {
                Console.Write(col);
            }
            Console.WriteLine();
        }
    }

    static List<List<char>> Rotate180Degrees(List<List<char>> ninetyDegreesRotatedMatrix)
    {
        List<List<char>> rotated180DegreesMatrix = new List<List<char>>();

        for (int col = 0; col < ninetyDegreesRotatedMatrix[0].Count; col++)
        {
            List<char> currentRow = new List<char>();
            for (int row = 0; row < ninetyDegreesRotatedMatrix.Count; row++)
            {
                if (col > ninetyDegreesRotatedMatrix[row].Count - 1)
                {
                    break;
                }
                currentRow.Add(ninetyDegreesRotatedMatrix[row][col]);
            }
            currentRow.Reverse();
            rotated180DegreesMatrix.Add(currentRow);
        }

        return rotated180DegreesMatrix;
    }

    static List<List<char>> Rotate90Degrees(char[][] matrix, int maxColLength)
    {
        List<List<char>> rotatedMatrix = new List<List<char>>();

        for (int col = 0; col < maxColLength; col++)
        {
            List<char> currentRow = new List<char>();
            for (int row = 0; row < matrix.Length; row++)
            {
                if (col > matrix[row].Length - 1 && col < maxColLength)
                {
                    currentRow.Add(' ');
                    continue;
                }
                currentRow.Add(matrix[row][col]);
            }

            currentRow.Reverse();
            rotatedMatrix.Add(currentRow);
        }

        return rotatedMatrix;
    }

    static int GetDegrees(string input)
    {
        string num = string.Empty;
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                num += input[i];
            }
        }

        return int.Parse(num);
    }
}