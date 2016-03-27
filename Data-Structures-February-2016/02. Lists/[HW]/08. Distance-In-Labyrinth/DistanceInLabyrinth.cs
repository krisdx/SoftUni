namespace DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class DistanceInLabyrinth
    {
        private static readonly string[,] labyrinth = new string[,]
        {
            {"0", "0", "0", "x", "0", "x"},
            {"0", "x", "0", "x", "0", "x"},
            {"0", "*", "x", "0", "x", "0"},
            {"0", "x", "0", "0", "0", "0"},
            {"0", "0", "0", "x", "x", "0"},
            {"0", "0", "0", "x", "0", "x"}
        };

        public static void Main()
        {
            int startRow = 0;
            int startCol = 0;
            GetStartCell(ref startRow, ref startCol);

            FillLabyrinth(startRow, startCol);

            PrintLabyrinth();
        }

        private static void FillLabyrinth(int startRow, int startCol)
        {
            var queue = new Queue<Cell>();

            queue.Enqueue(new Cell("0", startRow, startCol));

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                TryRightCell(queue, currentCell);
                TryLeftCell(queue, currentCell);
                TryUpCell(queue, currentCell);
                TryDownCell(queue, currentCell);
            }

            FillUnreacheableCells();
        }

        private static void TryDownCell(Queue<Cell> queue, Cell currentCell)
        {
            int row = currentCell.Row + 1;
            int col = currentCell.Col;
            if (row < labyrinth.GetLength(0) && labyrinth[row, col] == "0")
            {
                int cellValue = int.Parse(currentCell.Value) + 1;
                var newCell = new Cell(cellValue.ToString(), row, col);

                labyrinth[row, col] = cellValue.ToString();

                queue.Enqueue(newCell);
            }
        }

        private static void TryUpCell(Queue<Cell> queue, Cell currentCell)
        {
            int row = currentCell.Row - 1;
            int col = currentCell.Col;
            if (row >= 0 && labyrinth[row, col] == "0")
            {
                int cellValue = int.Parse(currentCell.Value) + 1;
                var newCell = new Cell(cellValue.ToString(), row, col);

                labyrinth[row, col] = cellValue.ToString();

                queue.Enqueue(newCell);
            }
        }

        private static void TryLeftCell(Queue<Cell> queue, Cell currentCell)
        {
            int row = currentCell.Row;
            int col = currentCell.Col - 1;
            if (col >= 0 && labyrinth[row, col] == "0")
            {
                int cellValue = int.Parse(currentCell.Value) + 1;
                var newCell = new Cell(cellValue.ToString(), row, col);

                labyrinth[row, col] = cellValue.ToString();

                queue.Enqueue(newCell);
            }
        }

        private static void TryRightCell(Queue<Cell> queue, Cell currentCell)
        {
            int row = currentCell.Row;
            int col = currentCell.Col + 1;
            if (col < labyrinth.GetLength(1) && labyrinth[row, col] == "0")
            {
                int cellValue = int.Parse(currentCell.Value) + 1;
                var newCell = new Cell(cellValue.ToString(), row, col);

                labyrinth[row, col] = cellValue.ToString();

                queue.Enqueue(newCell);
            }
        }

        private static void FillUnreacheableCells()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        private static void GetStartCell(ref int startRow, ref int startCol)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }

        private static void PrintLabyrinth()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}