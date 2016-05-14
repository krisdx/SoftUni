namespace AreaInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AreaInMatrix
    {
        private static char[][] matrix;
        private static bool[,] visited;

        public static void Main()
        {
            ReadInput();

            var resultAreas = GetAreas();
            PrintResult(resultAreas);
        }

        private static void ReadInput()
        {
            int rows = int.Parse(Console.ReadLine().Split(':')[1].Trim());
            matrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            visited = new bool[matrix.Length, matrix[0].Length];
        }

        private static Dictionary<char, int> GetAreas()
        {
            var resultAreas = new Dictionary<char, int>();
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (!visited[row, col])
                    {
                        visited[row, col] = true;
                        MarkNeighborAreas(row, col);

                        if (!resultAreas.ContainsKey(matrix[row][col]))
                        {
                            resultAreas[matrix[row][col]] = 0;
                        }

                        resultAreas[matrix[row][col]]++;
                    }
                }
            }

            return resultAreas;
        }

        private static void MarkNeighborAreas(int row, int col)
        {
            var queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(new Tuple<int, int>(row, col));
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                int currentRow = currentCell.Item1;
                int currentCol = currentCell.Item2;
                char currentLetter = matrix[currentCell.Item1][currentCell.Item2];

                // Try right cell
                if (currentCol + 1 < matrix[0].Length &&
                    matrix[currentRow][currentCol + 1] == currentLetter &&
                    !visited[currentRow, currentCol + 1])
                {
                    visited[currentRow, currentCol + 1] = true;
                    queue.Enqueue(new Tuple<int, int>(currentRow, currentCol + 1));
                }

                // Try left cell
                if (currentCol - 1 >= 0 &&
                    matrix[currentRow][currentCol - 1] == currentLetter &&
                    !visited[currentRow, currentCol - 1])
                {
                    visited[currentRow, currentCol - 1] = true;
                    queue.Enqueue(new Tuple<int, int>(currentRow, currentCol - 1));
                }

                // Try upper cell
                if (currentRow - 1 >= 0 &&
                    matrix[currentRow - 1][currentCol] == currentLetter &&
                    !visited[currentRow - 1, currentCol])
                {
                    visited[currentRow - 1, currentCol] = true;
                    queue.Enqueue(new Tuple<int, int>(currentRow - 1, currentCol));
                }

                // Try down cell
                if (currentRow + 1 < matrix.Length &&
                    matrix[currentRow + 1][currentCol] == currentLetter &&
                    !visited[currentRow + 1, currentCol])
                {
                    visited[currentRow + 1, currentCol] = true;
                    queue.Enqueue(new Tuple<int, int>(currentRow + 1, currentCol));
                }
            }
        }

        private static void PrintResult(Dictionary<char, int> resultAreas)
        {
            var output = new StringBuilder();

            int totalAres = 0;
            foreach (var letter in resultAreas)
            {
                output.AppendFormat("Letter '{0}' -> {1}\n", letter.Key, letter.Value);
                totalAres += letter.Value;
            }

            Console.WriteLine("Areas: " + totalAres);
            Console.WriteLine(output.ToString().Trim());
        }
    }
}