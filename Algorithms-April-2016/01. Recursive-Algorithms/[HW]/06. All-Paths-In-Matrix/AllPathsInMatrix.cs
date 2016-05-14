namespace AllPathsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AllPathsInMatrix
    {
        private const char EmptyCell = '.';
        private const char NonEmptyCell = '*';
        private const char ExitCell = 'e';

        private const char LeftDirection = 'L';
        private const char RightDirection = 'R';
        private const char UpDirection = 'U';
        private const char DownDirection = 'D';

        private static char[][] matrix =
        {
            new [] { 's', EmptyCell, EmptyCell, EmptyCell },
            new [] { EmptyCell, NonEmptyCell, NonEmptyCell, EmptyCell },
            new [] { EmptyCell, NonEmptyCell, NonEmptyCell, EmptyCell },
            new [] { EmptyCell, NonEmptyCell, ExitCell, EmptyCell },
            new [] { EmptyCell, EmptyCell, EmptyCell, EmptyCell },
        };

        //private static char[][] matrix =
        //{
        //    new [] { 's', EmptyCell, EmptyCell, EmptyCell , EmptyCell, EmptyCell },
        //    new [] { EmptyCell, NonEmptyCell, NonEmptyCell, EmptyCell , NonEmptyCell, EmptyCell },
        //    new [] { EmptyCell, NonEmptyCell, NonEmptyCell, EmptyCell, NonEmptyCell, EmptyCell},
        //    new [] { EmptyCell, NonEmptyCell, ExitCell, EmptyCell , EmptyCell, EmptyCell },
        //    new [] { EmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell },
        //};

        private static bool[][] visitedCells;
        private static List<List<char>> allPaths = new List<List<char>>();
        private static List<char> currentPath = new List<char>();

        public static void Main()
        {
            Init();

            int startRow = 0;
            int startCol = 0;
            FindStartPositions(ref startRow, ref startCol);

            FindAllPaths(startRow, startCol, 's');

            Print();
        }

        private static void Init()
        {
            visitedCells = new bool[matrix.Length][];
            for (int row = 0; row < matrix.Length; row++)
            {
                visitedCells[row] = new bool[matrix[row].Length];
            }
        }

        private static void FindAllPaths(int currentRow, int currentCol, char currentDirection)
        {
            if (IsOutOfRange(currentRow, currentCol) ||
                matrix[currentRow][currentCol] == NonEmptyCell ||
                visitedCells[currentRow][currentCol])
            {
                return;
            }

            currentPath.Add(currentDirection);
            visitedCells[currentRow][currentCol] = true;

            if (matrix[currentRow][currentCol] == ExitCell)
            {
                allPaths.Add(currentPath.ToList());
                currentPath.RemoveAt(currentPath.Count - 1);
                visitedCells[currentRow][currentCol] = false;
                return;
            }
            
            // Try Down
            FindAllPaths(currentRow + 1, currentCol, DownDirection);

            // Try Up
            FindAllPaths(currentRow - 1, currentCol, UpDirection);

            // Try Right
            FindAllPaths(currentRow, currentCol + 1, RightDirection);

            // Try Left
            FindAllPaths(currentRow, currentCol - 1, LeftDirection);

            visitedCells[currentRow][currentCol] = false;
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private static void FindStartPositions(ref int startRow, ref int startCol)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                        break;
                    }
                }
            }
        }

        private static bool IsOutOfRange(int currentRow, int currentCol)
        {
            bool isOutOfRange =
                currentRow < 0 || currentRow >= matrix.Length ||
                currentCol < 0 || currentCol >= matrix[currentRow].Length;
            return isOutOfRange;
        }

        private static void Print()
        {
            Console.WriteLine("Matrix: ");
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }

            foreach (var path in allPaths)
            {
                Console.WriteLine(string.Join("", path));
            }

            Console.WriteLine("Total paths found: " + allPaths.Count);
        }
    }
}