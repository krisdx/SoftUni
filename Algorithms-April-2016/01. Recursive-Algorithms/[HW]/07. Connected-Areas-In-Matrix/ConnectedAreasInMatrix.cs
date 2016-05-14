namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class ConnectedAreasInMatrix
    {
        private const char EmptyCell = ' ';
        private const char NonEmptyCell = '*';

        private static char[][] matrix =
        {
           new char[] { EmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell },
           new char[] { EmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell },
           new char[] { EmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell },
           new char[] { EmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, NonEmptyCell, EmptyCell,  EmptyCell }
        };

        //private static char[][] matrix =
        //{
        //    new char[] { NonEmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell, EmptyCell },
        //   new char[] { NonEmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell, EmptyCell },
        //    new char[] { NonEmptyCell, EmptyCell, EmptyCell, NonEmptyCell, NonEmptyCell, NonEmptyCell, NonEmptyCell, NonEmptyCell,  EmptyCell, EmptyCell },
        //    new char[] { NonEmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell, EmptyCell },
        //    new char[] { NonEmptyCell, EmptyCell, EmptyCell, NonEmptyCell, EmptyCell, EmptyCell, EmptyCell, NonEmptyCell,  EmptyCell, EmptyCell }
        // };

        private static SortedSet<Area> areas = new SortedSet<Area>();

        private static bool[][] visited;
        private static int currentAreaSise;

        public static void Main()
        {
            Init();

            FindConnectedAreas();

            Print();
        }

        private static void Init()
        {
            visited = new bool[matrix.Length][];
            for (int row = 0; row < matrix.Length; row++)
            {
                visited[row] = new bool[matrix[row].Length];
            }
        }

        private static void FindConnectedAreas()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != NonEmptyCell &&
                        !visited[row][col])
                    {
                        MarkCells(row, col);
                        areas.Add(new Area(row, col, currentAreaSise));

                        currentAreaSise = 0;
                    }
                }
            }
        }

        private static void MarkCells(int currentRow, int currentCol)
        {
            if (IsOutOfRange(currentRow, currentCol) ||
                matrix[currentRow][currentCol] == NonEmptyCell ||
                visited[currentRow][currentCol])
            {
                return;
            }

            visited[currentRow][currentCol] = true;
            currentAreaSise++;

            // Try Down
            MarkCells(currentRow + 1, currentCol);

            // Try Up
            MarkCells(currentRow - 1, currentCol);

            // Try Right
            MarkCells(currentRow, currentCol + 1);

            // Try Left
            MarkCells(currentRow, currentCol - 1);
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
            Console.WriteLine("Total areas found: " + areas.Count);
            int count = 1;
            foreach (var area in areas)
            {
                Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", count, area.StartRow, area.StartCol, area.Size);
                count++;
            }
        }
    }
}