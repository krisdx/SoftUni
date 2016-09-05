using System.Runtime.Remoting.Services;

namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class AStar
    {

        /// <summary>
        /// Manhattan distance means moving strictly horizontal and/or vertical. 
        /// </summary>
        private const int ManhattanDistance = 10;

        /// <summary>
        /// Euclidean distance means moving in a straight line (diagonal).
        /// </summary>
        private const int EuclideanDistance = 14;

        private readonly PriorityQueue<Node> priorityQueue;
        private readonly ISet<Node> visited;
        private readonly Node[,] graph;
        private readonly char[,] map;

        public AStar(char[,] map)
        {
            this.map = map;
            this.graph = new Node[map.GetLength(0), map.GetLength(1)];
            this.priorityQueue = new PriorityQueue<Node>();
            this.visited = new HashSet<Node>();
        }

        public List<int[]> FindShortestPath(int[] startCoords, int[] endCoords)
        {
            int startRow = startCoords[0];
            int startCol = startCoords[1];
            var startNode = this.GetNode(startRow, startCol);

            startNode.GCost = 0;
            this.priorityQueue.Enqueue(startNode);
            while (priorityQueue.Count > 0)
            {
                var currentNode = this.priorityQueue.ExtractMin();
                if (currentNode.Row == endCoords[0] &&
                    currentNode.Col == endCoords[1])
                {
                    // Found the shortest path to the destination node.
                    return this.ReconstructPath(currentNode);
                }

                this.visited.Add(currentNode);
                var neighbors = this.GetNeighbors(currentNode);
                foreach (var neighbor in neighbors)
                {
                    if (this.visited.Contains(neighbor))
                    {
                        // Skip the nod, because it's already visited.
                        continue;
                    }

                    var neighborNewGCost = currentNode.GCost + this.CaclulateGCost(neighbor, currentNode);
                    if (neighborNewGCost < neighbor.GCost)
                    {
                        neighbor.GCost = neighborNewGCost;
                        neighbor.Parent = currentNode;

                        if (!this.priorityQueue.Contains(neighbor))
                        {
                            neighbor.HCost = this.CalcualteHCost(neighbor, endCoords);
                            this.priorityQueue.Enqueue(neighbor);
                        }
                        else
                        {
                            this.priorityQueue.DecreaseKey(neighbor);
                        }
                    }
                }
            }

            // No path found.
            return new List<int[]>(0);
        }

        private List<int[]> ReconstructPath(Node endNode)
        {
            var path = new List<int[]>();

            var currentNode = endNode;
            while (currentNode != null)
            {
                path.Add(new[] { currentNode.Row, currentNode.Col });
                currentNode = currentNode.Parent;
            }

            return path;
        }

        private int CalcualteHCost(Node node, int[] endCoords)
        {
            return this.CalculateDistance(node.Row, node.Col, endCoords[0], endCoords[1]);
        }

        private int CaclulateGCost(Node node, Node previous)
        {
            return this.CalculateDistance(node.Row, node.Col, previous.Row, previous.Col);
        }
        
        private int CalculateDistance(int row1, int col1, int row2, int col2)
        {
            // deltaX and deltaY are the number of cells, difference between the two nodes.
            var deltaY = Math.Abs(row1 - row2);
            var deltaX = Math.Abs(col1 - col2);

            int euclideanDistance = 0; 
            int manhattanDistance = 0;
            int difference = 0;
            if (deltaX > deltaY)
            { 
                // First we move deltaY times horizontal or vertical.
                euclideanDistance = EuclideanDistance * deltaY;

                // Now we are on the same row. 
                // Then we move deltaX times to horizontal or vertical path
                // to get to the destination. But it's not exactly deltaX times, 
                // because we've already moved deltaY times to the horizontal or vertical, 
                // so we have to move (deltaX - deltaY) times.
                difference = deltaX - deltaY;
                manhattanDistance = ManhattanDistance * difference;
            }
            else
            {
                // First we move deltaX times to one of the diagonals.
                euclideanDistance = EuclideanDistance * deltaX;

                // Now we are on the same col. 
                // Then we move deltaY times to horizontal or vertical path
                // to get to the destination. But it's not exactly deltaY times, 
                // because we've already moved deltaX times to the diagonal, 
                // so we have to move (deltaY - deltaX) times.
                difference = deltaY - deltaX;
                manhattanDistance = ManhattanDistance * difference;
            }

            return euclideanDistance + manhattanDistance;
        }

        private List<Node> GetNeighbors(Node node)
        {
            var neighbors = new List<Node>();

            int maxRow = this.graph.GetLength(0);
            int maxCol = this.graph.GetLength(1);
            for (int row = node.Row - 1; row <= node.Row + 1 && row < maxRow; row++)
            {
                if (row < 0)
                    continue;

                for (int col = node.Col - 1; col <= node.Col + 1 && col < maxCol; col++)
                {
                    if (col < 0)
                        continue;

                    if (row == node.Row && col == node.Col)
                        continue;

                    if (this.map[row, col] == 'W')
                        continue;

                    var neighbor = this.GetNode(row, col);
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

        private Node GetNode(int row, int col)
        {
            return this.graph[row, col] ??
                (this.graph[row, col] = new Node(row, col));
        }
    }
}