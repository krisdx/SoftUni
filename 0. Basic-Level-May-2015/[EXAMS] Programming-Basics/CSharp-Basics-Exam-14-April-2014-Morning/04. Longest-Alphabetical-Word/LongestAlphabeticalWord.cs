using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class LongestAlphabeticalWord
{
    static void Main()
    {
        string inputWord = Console.ReadLine();
        int size = int.Parse(Console.ReadLine());

        char[,] matrix = FillMatrix(inputWord, size);

        SortedSet<string> words = new SortedSet<string>();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string currentWordRight = GetWordRight(matrix, row, col);
                words.Add(currentWordRight);

                string currentWordLeft = GetWordLeft(matrix, row, col);
                words.Add(currentWordLeft);

                string currentWordDonw = GetWordDown(matrix, row, col);
                words.Add(currentWordDonw);

                string currentWordUp = GetWordUp(matrix, row, col);
                words.Add(currentWordUp);
            }
        }

        var longestAlphabericalWord =
            words.OrderByDescending(x => x.Length)
            .ThenBy(x => x[0]);
        Console.WriteLine( longestAlphabericalWord.First());
    }

    public static string GetWordRight(char[,] matrix, int row, int col)
    {
        StringBuilder currentLongestWord = new StringBuilder();
        currentLongestWord.Append(matrix[row, col]);

        char currentChar = matrix[row, col];
        while (true)
        {
            if (col + 1 <= matrix.GetLength(1) - 1)
            {
                col++;
            }

            char nextChar = matrix[row, col];
            if (currentChar < nextChar)
            {
                currentLongestWord.Append(matrix[row, col]);
                currentChar = nextChar;
            }
            else
            {
                break;
            }
        }

        return currentLongestWord.ToString();
    }

    public static string GetWordLeft(char[,] matrix, int row, int col)
    {
        StringBuilder currentLongestWord = new StringBuilder();
        currentLongestWord.Append(matrix[row, col]);

        char currentChar = matrix[row, col];
        while (true)
        {
            if (col - 1 >= 0)
            {
                col--;
            }

            char nextChar = matrix[row, col];
            if (currentChar < nextChar)
            {
                currentLongestWord.Append(matrix[row, col]);
                currentChar = nextChar;
            }
            else
            {
                break;
            }
        }

        return currentLongestWord.ToString();
    }

    public static string GetWordDown(char[,] matrix, int row, int col)
    {
        StringBuilder currentLongestWord = new StringBuilder();
        currentLongestWord.Append(matrix[row, col]);

        char currentChar = matrix[row, col];
        while (true)
        {
            if (row + 1 <= matrix.GetLength(0) - 1)
            {
                row++;
            }

            char nextChar = matrix[row, col];
            if (currentChar < nextChar)
            {
                currentLongestWord.Append(matrix[row, col]);
                currentChar = nextChar;
            }
            else
            {
                break;
            }
        }

        return currentLongestWord.ToString();
    }

    public static string GetWordUp(char[,] matrix, int row, int col)
    {
        StringBuilder currentLongestWord = new StringBuilder();
        currentLongestWord.Append(matrix[row, col]);

        char currentChar = matrix[row, col];
        while (true)
        {
            if (row - 1 >= 0)
            {
                row--;
            }

            char nextChar = matrix[row, col];
            if (currentChar < nextChar)
            {
                currentLongestWord.Append(matrix[row, col]);
                currentChar = nextChar;
            }
            else
            {
                break;
            }
        }

        return currentLongestWord.ToString();
    }

    public static char[,] FillMatrix(string inputWord, int size)
    {
        char[,] matrix = new char[size, size];

        int index = 0;
        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = inputWord[index];
                index++;
                if (index == inputWord.Length)
                {
                    index = 0;
                }
            }
        }

        return matrix;
    }
}