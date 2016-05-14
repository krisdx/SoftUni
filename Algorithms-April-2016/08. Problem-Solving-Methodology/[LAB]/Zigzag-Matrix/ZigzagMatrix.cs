namespace Zigzag_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZigzagMatrix // 75% Done
    {
        private static ulong[,] matrix;
        private static ulong[,] sums;
        private static Tuple<int, int>[] prev;

        private static ulong maxSum;

        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new ulong[rows, cols];
            prev = new Tuple<int, int>[cols];
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine().Split(',');
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = ulong.Parse(row[j]);
                }
            }

            sums = new ulong[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                sums[i, 0] = matrix[i, 0];
            }

            var path = GetZigZagPath();
            Console.WriteLine("{0} = {1}", maxSum, string.Join(" + ", path));
        }

        private static List<ulong> GetZigZagPath()
        {
            Tuple<int, int> maxSumRowCol = null;

            bool lookingUp = true;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (lookingUp)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int i = row + 1; i < matrix.GetLength(0); i++)
                        {
                            ulong currentSum = matrix[row, col] + sums[i, col - 1];
                            if (currentSum > sums[row, col])
                            {
                                sums[row, col] = currentSum;
                                if (currentSum > maxSum)
                                {
                                    maxSum = currentSum;
                                    maxSumRowCol = new Tuple<int, int>(row, col);

                                    prev[col] = new Tuple<int, int>(i, col - 1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        for (int i = row - 1; i >= 0; i--)
                        {
                            ulong currentSum = matrix[row, col] + sums[i, col - 1];
                            if (currentSum > sums[row, col])
                            {
                                sums[row, col] = currentSum;
                                if (currentSum > maxSum)
                                {
                                    maxSum = currentSum;
                                    maxSumRowCol = new Tuple<int, int>(row, col);

                                    prev[col] = new Tuple<int, int>(i, col - 1);
                                }
                            }
                        }
                    }
                }

                lookingUp = !lookingUp;
            }

            var path = ReconstructPath(prev, maxSumRowCol);
            return path;
        }

        private static List<ulong> ReconstructPath(Tuple<int, int>[] prev, Tuple<int, int> maxSumRowCol)
        {
            var path = new List<ulong>();
            for (int i = prev.Length - 1; i > 0; i--)
            {
                int row = prev[i].Item1;
                int col = prev[i].Item2;
                path.Add(matrix[row, col]);
            }

            path.Reverse();
            path.Add(matrix[maxSumRowCol.Item1, maxSumRowCol.Item2]);
            return path;
        }
    }
}