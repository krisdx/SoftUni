namespace AllPathsInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class PathsInLabyrinth
    {
        private static char[,] labyrinth =
        {
            {'.', '.', '.', 'X', '.', '.', '.'},
            {'X', 'X', '.', 'X', '.', 'X', '.'},
            {'.', '.', '.', '.', '.', '.', '.'},
            {'.', 'X', 'X', 'X', 'X', 'X', '.'},
            {'.', '.', '.', '.', '.', '.', 'e'}
        };

        private static List<char> pathDirections = new List<char>();
        private static List<Tuple<int, int>> pathCoordinates = new List<Tuple<int, int>>();

        public static void Main()
        {
            PrintLabyrinth();

            // Uncomment the code below to create larger labyrinth
            // Test with size = 10 and size = 100

            //int size = 10;
            //labyrinth = new char[size, size];
            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < size; col++)
            //    {
            //        labyrinth[row, col] = ' ';
            //    }
            //}
            //labyrinth[size - 1, size - 1] = 'e';

            FindPathToExit(0, 0, 'R');
        }

        static void FindPathToExit(int row, int col, char direction)
        {
            if (!IsInRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (labyrinth[row, col] == 'e')
            {
                PrintPath(row, col);
            }

            if (labyrinth[row, col] != '.')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            labyrinth[row, col] = 's';
            pathCoordinates.Add(new Tuple<int, int>(row, col));
            pathDirections.Add(direction);

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1, 'L'); // left
            FindPathToExit(row - 1, col, 'U'); // up
            FindPathToExit(row, col + 1, 'R'); // right
            FindPathToExit(row + 1, col, 'D'); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            labyrinth[row, col] = '.';
            pathCoordinates.RemoveAt(pathCoordinates.Count - 1);
            pathDirections.RemoveAt(pathDirections.Count - 1);
        }

        static bool IsInRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool colInRange = col >= 0 && col < labyrinth.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void PrintPath(int finalRow, int finalCol)
        {
            Console.Write("Found the exit: ");
            foreach (var cell in pathCoordinates)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }

            Console.WriteLine("({0},{1})", finalRow, finalCol);

            foreach (var direction in pathDirections)
            {
                Console.Write(direction);
            }

            Console.WriteLine("\n");
        }

        private static void PrintLabyrinth()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0} ", labyrinth[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}