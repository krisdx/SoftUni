namespace _ShortestPathBetweenAllPairNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPathBetweenAllPairNodes
    {
        private static long[,] graph;

        public static void Main()
        {
            ReadInput();
            FloydWarshall();
            Print();
        }

        private static void ReadInput()
        {
            int nodesCount =
                int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);
            int edgesCount =
                 int.Parse(Console.ReadLine().Split(new char[] { ' ' })[1]);

            graph = new long[nodesCount, nodesCount];
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    if (row != col)
                    {
                        graph[row, col] = int.MaxValue;
                    }
                }
            }

            for (int i = 0; i < edgesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(new char[] { ' ' });
                int startNodeIndex = int.Parse(edge[0]);
                int endNodeIndex = int.Parse(edge[1]);
                int weight = int.Parse(edge[2]);

                graph[startNodeIndex, endNodeIndex] = weight;
                graph[endNodeIndex, startNodeIndex] = weight;
            }
        }

        private static void FloydWarshall()
        {
            for (int middleNode = 0; middleNode < graph.GetLength(0); middleNode++)
            {
                for (int startNode = 0; startNode < graph.GetLength(0); startNode++)
                {
                    for (int endNode = 0; endNode < graph.GetLength(0); endNode++)
                    {
                        if (graph[startNode, middleNode] + graph[middleNode, endNode] < graph[startNode, endNode])
                        {
                            graph[startNode, endNode] =
                                graph[startNode, middleNode] + graph[middleNode, endNode];
                        }
                    }
                }
            }
        }

        private static void Print()
        {
            for (int row = 0; row < graph.GetLength(0); row++)
            {
                for (int col = 0; col < graph.GetLength(1); col++)
                {
                    if (graph[row, col] == int.MaxValue)
                    {
                        Console.Write("{0,3}", 0);
                    }
                    else
                    {
                        Console.Write("{0,3}", graph[row, col]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}