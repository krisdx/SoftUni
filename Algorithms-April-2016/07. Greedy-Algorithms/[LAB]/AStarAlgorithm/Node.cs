namespace AStarAlgorithm
{
    using System;
    using System.Collections.Generic;

    internal class Node : IComparable<Node>
    {
        public Node(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.GCost = int.MaxValue;
            this.HCost = int.MaxValue;
        }

        public Node(int col, int row, Node parent)
            : this(col, row)
        {
            this.Parent = parent;
        }

        public int Col { get; set; }

        public int Row { get; set; }

        public Node Parent { get; set; }

        /// <summary>
        /// The estimated distance to the destination node.
        /// </summary>
        public int HCost { get; set; }

        /// <summary>
        /// The distance to the start node.
        /// </summary>
        public int GCost { get; set; }

        public int FCost
        {
            get
            {
                return this.HCost + this.GCost;
            }
        }

        public List<Node> Neighbours { get; set; }

        public override bool Equals(object obj)
        {
            var other = (Node)obj;
            return this.Col == other.Col && this.Row == other.Row;
        }

        public int CompareTo(Node other)
        {
            if (this.FCost == other.FCost)
            {
                return this.HCost.CompareTo(other.HCost);
            }

            return this.FCost.CompareTo(other.FCost);
        }

        public override string ToString()
        {
            return string.Format("({0},{1}), G:{2}, H:{3}, F:{4}",
                this.Row, this.Col, this.GCost, this.HCost, this.FCost);
        }
    }
}