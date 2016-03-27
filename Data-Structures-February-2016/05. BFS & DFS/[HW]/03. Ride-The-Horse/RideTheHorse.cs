namespace RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class RideTheHorse
    {
        private const int StartValue = 1;

        private static int[,] matrix;

        public static void Main()
        {
            int matrixRows = int.Parse(Console.ReadLine());
            int matrixCols = int.Parse(Console.ReadLine());

            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            matrix = new int[matrixRows, matrixCols];
            matrix[startRow, startCol] = StartValue;

            FillMatrix(startRow, startCol);

            PrintColumn();

            // PrintMatrix();
        }

        private static void FillMatrix(int startRow, int startCol)
        {
            var queue = new Queue<MatrixCell>();

            var startCell = new MatrixCell(matrix[startRow, startCol], startRow, startCol);

            queue.Enqueue(startCell);
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                GetUpperNeighbors(queue, currentCell);

                GetLowerNeighbors(queue, currentCell);
            }
        }

        private static void GetLowerNeighbors(Queue<MatrixCell> queue, MatrixCell currentCell)
        {
            if (currentCell.Row + 1 < matrix.GetLength(0) &&
                currentCell.Col - 2 >= 0 &&
                matrix[currentCell.Row + 1, currentCell.Col - 2] == 0)
            {
                matrix[currentCell.Row + 1, currentCell.Col - 2] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row + 1, currentCell.Col - 2], currentCell.Row + 1, currentCell.Col - 2);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row + 1 < matrix.GetLength(0) &&
                 currentCell.Col + 2 < matrix.GetLength(1) &&
                 matrix[currentCell.Row + 1, currentCell.Col + 2] == 0)
            {
                matrix[currentCell.Row + 1, currentCell.Col + 2] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row + 1, currentCell.Col + 2], currentCell.Row + 1, currentCell.Col + 2);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row + 2 < matrix.GetLength(0) &&
                 currentCell.Col - 1 >= 0 &&
                 matrix[currentCell.Row + 2, currentCell.Col - 1] == 0)
            {
                matrix[currentCell.Row + 2, currentCell.Col - 1] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row + 2, currentCell.Col - 1], currentCell.Row + 2, currentCell.Col - 1);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row + 2 < matrix.GetLength(0) &&
                currentCell.Col + 1 < matrix.GetLength(1) &&
                matrix[currentCell.Row + 2, currentCell.Col + 1] == 0)
            {
                matrix[currentCell.Row + 2, currentCell.Col + 1] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row + 2, currentCell.Col + 1], currentCell.Row + 2, currentCell.Col + 1);
                queue.Enqueue(nextMatirxCell);
            }
        }

        private static void GetUpperNeighbors(Queue<MatrixCell> queue, MatrixCell currentCell)
        {
            if (currentCell.Row - 2 >= 0 &&
                            currentCell.Col - 1 >= 0 &&
                            matrix[currentCell.Row - 2, currentCell.Col - 1] == 0)
            {
                matrix[currentCell.Row - 2, currentCell.Col - 1] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row - 2, currentCell.Col - 1], currentCell.Row - 2, currentCell.Col - 1);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row - 2 >= 0 &&
                currentCell.Col + 1 < matrix.GetLength(1) &&
                matrix[currentCell.Row - 2, currentCell.Col + 1] == 0)
            {
                matrix[currentCell.Row - 2, currentCell.Col + 1] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row - 2, currentCell.Col + 1], currentCell.Row - 2, currentCell.Col + 1);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row - 1 >= 0 &&
                currentCell.Col - 2 >= 0 &&
                matrix[currentCell.Row - 1, currentCell.Col - 2] == 0)
            {
                matrix[currentCell.Row - 1, currentCell.Col - 2] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row - 1, currentCell.Col - 2], currentCell.Row - 1, currentCell.Col - 2);
                queue.Enqueue(nextMatirxCell);
            }

            if (currentCell.Row - 1 >= 0 &&
                currentCell.Col + 2 < matrix.GetLength(1) &&
                matrix[currentCell.Row - 1, currentCell.Col + 2] == 0)
            {
                matrix[currentCell.Row - 1, currentCell.Col + 2] = currentCell.Value + 1;

                var nextMatirxCell = new MatrixCell(matrix[currentCell.Row - 1, currentCell.Col + 2], currentCell.Row - 1, currentCell.Col + 2);
                queue.Enqueue(nextMatirxCell);
            }
        }

        private static void PrintColumn()
        {
            int middleCol = matrix.GetLength(1) / 2;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(matrix[row, middleCol]);
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}