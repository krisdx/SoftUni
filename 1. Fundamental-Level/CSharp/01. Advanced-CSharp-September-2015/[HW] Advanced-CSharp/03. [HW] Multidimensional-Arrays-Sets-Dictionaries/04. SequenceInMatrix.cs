using System;
using System.Collections.Generic;
using System.Linq;

// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix

class SequenceInMatrix
{
    static void Main()
    {
        string[,] matrix = 
        {
           { "ha", "fifi", "ho", "hi" }, 
           { "fo", "ha", "hi", "xx" },
           { "xxx", "ho", "ha", "xx" }
        };

        //string[,] secondMatrix = 
        //{
        //     { "s", "qq", "s" },
        //     { "pp", "s", "s" },
        //     { "pp", "qq", "s" }
        //};
        
        List<string> horizontalSequence = GetHorizontalSequence(matrix);
        List<string> verticalSequence = GetVerticalSequence(matrix);
        List<string> diagonalSequence = GetDiagonalSequence(matrix);

        List<string> longestSequence = new List<string>();
        if (horizontalSequence.Count > verticalSequence.Count &&
            horizontalSequence.Count > diagonalSequence.Count)
        {
            longestSequence = horizontalSequence.ToList();
        }
        else if (verticalSequence.Count > horizontalSequence.Count &&
                 verticalSequence.Count > diagonalSequence.Count)
        {
            longestSequence = verticalSequence.ToList();
        }
        else
        {
            longestSequence = diagonalSequence.ToList();
        }

        Console.WriteLine(string.Join(", ", longestSequence));
    }

    private static List<string> GetHorizontalSequence(string[,] matrix)
    {
        List<string> longestHorizontalSequence = new List<string>();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            List<string> currentHorizontalSequence = new List<string>();
            for (int col = 0; col < matrix.GetLength(0) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    currentHorizontalSequence.Add(matrix[row, col]);
                    currentHorizontalSequence.Add(matrix[row, col + 1]);
                }
            }
            currentHorizontalSequence.Distinct();

            if (currentHorizontalSequence.Count > longestHorizontalSequence.Count)
            {
                longestHorizontalSequence = currentHorizontalSequence;
            }
        }

        return longestHorizontalSequence;
    }

    private static List<string> GetVerticalSequence(string[,] matrix)
    {
        List<string> longestVerticalSequence = new List<string>();

        int equalCounter = 1;
        int equalElementRow = 0;
        int equalElementCol = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            equalCounter = 1;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    if (matrix[row + 1, col] == matrix[row, col])
                    {
                        equalCounter++;
                        equalElementRow = row;
                        equalElementCol = col;
                    }
                }
            }

            List<string> currentVerticalSequence = new List<string>();
            if (equalCounter > 1)
            {
                for (int i = 0; i < equalCounter; i++)
                {
                    currentVerticalSequence.Add(matrix[equalElementRow, equalElementCol]);
                }
            }
            
            if (currentVerticalSequence.Count > longestVerticalSequence.Count)
            {
                longestVerticalSequence = currentVerticalSequence.ToList();
            }

            currentVerticalSequence.Clear();
        }

        return longestVerticalSequence;
    }

    private static List<string> GetDiagonalSequence(string[,] matrix)
    {
        List<string> longestDiagonalSequence = new List<string>();

        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                List<string> currentDiagonalSequence = new List<string>();
                int startRow = row;
                int startCol = col;

                int equalCounter = 1;
                int equalElementRow = 0;
                int equalElementCol = 0;
                while (startRow < matrix.GetLength(0) - 1 && startCol < matrix.GetLength(1) - 1)
                {
                    if (matrix[startRow, startCol] == matrix[startRow + 1, startCol + 1])
                    {
                        equalCounter++;   
                        equalElementRow = startRow;
                        equalElementCol = startCol;
                    }

                    startRow++;
                    startCol++;
                }

                if (equalCounter > 1)
                {
                    for (int i = 0; i < equalCounter; i++)
                    {
                        currentDiagonalSequence.Add(matrix[equalElementRow, equalElementCol]);
                    }
                }

                if (currentDiagonalSequence.Count > longestDiagonalSequence.Count)
                {
                    longestDiagonalSequence = currentDiagonalSequence.ToList();
                }

                currentDiagonalSequence.Clear();
            }
        }

        return longestDiagonalSequence;
    }
}