using System;
using System.Collections.Generic;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int[][] firstArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            firstArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        int[][] secondArray = new int[n][];
        for (int i = 0; i < n; i++)
        {
            secondArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Reverse(secondArray[i]);
        }

        List<List<int>> matrix = FillMatrix(n, firstArray, secondArray);

        bool fitPerfectly = true;
        List<int> rowsLength = new List<int>();
        foreach (var row in matrix)
        {
            rowsLength.Add(row.Count);
        }
        for (int i = 0; i < rowsLength.Count - 1; i++)
        {
            if (rowsLength[i] != rowsLength[i + 1])
            {
                fitPerfectly = false;
            }
        }

        if (fitPerfectly)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine("[{0}]", string.Join(", ", row));
            }
        }
        else
        {
            int totalNumberOfCells = 0;
            foreach (var row in matrix)
            {
                foreach (var col in row)
                {
                    totalNumberOfCells++;
                }
            }

            Console.WriteLine("The total number of cells is: {0}", totalNumberOfCells);
        }
    }

    private static List<List<int>> FillMatrix(int n, int[][] firstArray, int[][] secondArray)
    {
        List<List<int>> matrix = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            List<int> currentRow = new List<int>();

            for (int firstArrayRow = 0; firstArrayRow < firstArray[i].Length; firstArrayRow++)
            {
                currentRow.Add(firstArray[i][firstArrayRow]);
            }
            for (int secondArrayRow = 0; secondArrayRow < secondArray[i].Length; secondArrayRow++)
            {
                currentRow.Add(secondArray[i][secondArrayRow]);
            }

            matrix.Add(currentRow);
        }

        return matrix;
    }
}