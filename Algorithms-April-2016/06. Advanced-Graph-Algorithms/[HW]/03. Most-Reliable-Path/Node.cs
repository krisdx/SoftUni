//namespace MostReliablePath
//{
using System;
using System.Collections.Generic;

public class Node : IComparable<Node>
{
    public Node(int index, double distance = double.NegativeInfinity)
    {
        this.Index = index;
        this.Reliability = distance;
    }

    public int Index { get; set; }

    public double Reliability { get; set; }

    public override int GetHashCode()
    {
        return this.Index.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        var other = obj as Node;
        return this.Index == other.Index;
    }

    public int CompareTo(Node other)
    {
        return this.Reliability.CompareTo(other.Reliability);
    }

    public override string ToString()
    {
        return this.Index.ToString();
    }
}
//}