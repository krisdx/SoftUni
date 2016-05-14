namespace ShortestPathsWithNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Edge
    {
        public Edge(int start, int end, double distance)
        {
            this.Start = start;
            this.End = end;
            this.Distance = distance;
        }

        public int Start { get; set; }

        public int End { get; set; }

        public double Distance { get; set; }

        public override string ToString()
        {
            return string.Format("({0},{1}) -> {2}", this.Start, this.End, this.Distance);
        }
    }
}