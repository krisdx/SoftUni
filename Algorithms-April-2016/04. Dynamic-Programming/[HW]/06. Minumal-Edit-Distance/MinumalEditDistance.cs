namespace MinumalEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MinumalEditDistance // Not Finished
    {
        private const int ReplaceCoef = 3;
        private const int InsertCoef = 2;
        private const int DeleteCoef = 1;

        private static int minimalEditDistance;

        public static void Main()
        {
            string firstStr = "abracadabra";
            string secondStr = "mabragabra";

            var matrix = new int[firstStr.Length + 1, secondStr.Length + 1];
            var result = GetMinumalEditDistance(matrix, firstStr, secondStr);

            Console.WriteLine("Minimal edit distance: " + minimalEditDistance);
            Console.WriteLine(string.Join("\n", result));
        }

        private static List<string> GetMinumalEditDistance(int[,] matrix, string firstStr, string secondStr)
        {
            // Fill the base cases
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = i;
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = i;
            }

            for (int first = 1; first < matrix.GetLength(0); first++)
            {
                for (int second = 1; second < matrix.GetLength(1); second++)
                {
                    if (firstStr[first - 1] != secondStr[second - 1])
                    {
                        matrix[first, second] = GetMin(
                            matrix[first - 1, second], // without the symbol of the first string
                            matrix[first, second - 1], // without the symbol of the second string
                            matrix[first - 1, second - 1]); // without both symbols
                        matrix[first, second]++;
                    }
                    else
                    {
                        // The symbols are equal. We copy the left diagonal value
                        matrix[first, second] = matrix[first - 1, second - 1];
                    }
                }
            }

            // Print(matrix);
            return ReconstructSolution(matrix, firstStr, secondStr);
        }

        private static List<string> ReconstructSolution(int[,] matrix, string firstStr, string secondStr)
        {
            var result = new List<string>();

            int row = matrix.GetLength(0) - 1;
            int col = matrix.GetLength(1) - 1;
            while (row > 0 && col > 0)
            {
                if (firstStr[row - 1] == secondStr[col - 1])
                {
                    row--;
                    col--;
                }
                else if (matrix[row - 1, col - 1] <= matrix[row - 1, col] &&
                    matrix[row - 1, col - 1] <= matrix[row, col - 1])
                {
                    result.Add(string.Format("REPLACE({0}, {1})", row-1 , secondStr[row]));
                    minimalEditDistance += ReplaceCoef;
                    row--;
                    col--;
                }
                else if (matrix[row - 1, col] <= matrix[row - 1, col - 1] &&
                         matrix[row - 1, col] <= matrix[row, col - 1])
                {
                    result.Add(string.Format("INSERT({0}, {1})", row - 1, secondStr[row ]));
                    minimalEditDistance += InsertCoef;
                    row--;
                }
                else if (matrix[row, col - 1] <= matrix[row - 1, col - 1] &&
                         matrix[row, col - 1] <= matrix[row - 1, col])
                {
                    result.Add(string.Format("DELETE({0}) ", row));
                    minimalEditDistance += DeleteCoef;
                    col--;
                }
            }

            result.Reverse();
            return result;
        }

        private static int GetMin(int firstNum, int secondNum, int thirdNum)
        {
            int minNum = Math.Min(firstNum, secondNum);
            return Math.Min(minNum, thirdNum);
        }

        private static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}