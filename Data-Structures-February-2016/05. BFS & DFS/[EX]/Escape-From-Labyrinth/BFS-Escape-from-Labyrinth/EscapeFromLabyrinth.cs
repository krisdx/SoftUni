namespace EscapeFromLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EscapeFromLabyrinth
    {
        private const char VisitedCell = 's';
        private const char EmptyCell = '-';

        private static char[,] labyrinth;

        // private static char[,] samlpeLabyrinth =
        // {
        //    { '*', '*', '*', '*', '*', '*', '*', '*', '*' },
        //    { '*', '-', '-', '-', '-', '*', '*', '-', '-' },
        //    { '*', '*', '-', '*', '-', '-', '-', '-', '*' },
        //    { '*', '-', '-', '*', '-', '*', '-', '*', '*' },
        //    { '*', 's', '*', '-', '-', '*', '-', '*', '*' },
        //    { '*', '*', '-', '-', '-', '-', '-', '-', '*' },
        //    { '*', '*', '*', '*', '*', '*', '*', '-', '*' }
        // };

        public static void Main()
        {
            ReadLabyrinth();

            string shortestPathToExit = FindShortestPathToExit();
            if (shortestPathToExit == null)
            {
                Console.WriteLine("No exit!");
            }
            else if (shortestPathToExit == string.Empty)
            {
                Console.WriteLine("Start is at the exit.");
            }
            else
            {
                Console.WriteLine("Shortest exit: " + shortestPathToExit);
            }
        }

        private static string FindShortestPathToExit()
        {
            var queue = new Queue<Point>();

            var startPosition = FindStartPosition();
            if (startPosition == null)
            {
                return null;
            }

            queue.Enqueue(startPosition);
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                if (IsExit(currentCell))
                {
                    return TracePathBack(currentCell);
                }
                
                TryDirection(queue, currentCell, "U", -1, 0);
                TryDirection(queue, currentCell, "L", 0, -1);
                TryDirection(queue, currentCell, "D", +1, 0);
                TryDirection(queue, currentCell, "R", 0, +1);
            }

            return null;
        }

        private static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int rowDirection, int colDirection)
        {
            int nextCellRow = currentCell.Y + rowDirection;
            int nextCellCol = currentCell.X + colDirection;

            if (nextCellRow >= 0 && nextCellRow < labyrinth.GetLength(0) &&
                nextCellCol >= 0 && nextCellCol < labyrinth.GetLength(1) &&
                labyrinth[nextCellRow, nextCellCol] == EmptyCell)
            {
                labyrinth[nextCellRow, nextCellCol] = VisitedCell;

                var nextCell = new Point(nextCellRow, nextCellCol, direction, currentCell);
                queue.Enqueue(nextCell);
            }
        }
        
        private static string TracePathBack(Point currentCell)
        {
            var reversedPath = new StringBuilder();

            while (currentCell.PreviousPoint != null)
            {
                reversedPath.Append(currentCell.Direction);
                currentCell = currentCell.PreviousPoint;
            }

            var path = new StringBuilder(reversedPath.Length);
            for (int i = reversedPath.Length - 1; i >= 0; i--)
            {
                path.Append(reversedPath[i]);
            }

            return path.ToString();
        }

        private static bool IsExit(Point currentCell)
        {
            if (currentCell.X == 0 || currentCell.X == labyrinth.GetLength(1) - 1 ||
                currentCell.Y == 0 || currentCell.Y == labyrinth.GetLength(0) - 1)
            {
                return true;
            }

            return false;
        }

        private static Point FindStartPosition()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == VisitedCell)
                    {
                        var startPoint = new Point(row, col);
                        return startPoint;
                    }
                }
            }

            return null;
        }

        private static void ReadLabyrinth()
        {
            int cols = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            labyrinth = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string inputLine = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = inputLine[col];
                }
            }
        }
    }
}