using System;

public class Point3D
{
    private static readonly string startingPoints = "{0, 0, 0}";

    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public double Z { get; set; }

    public static string StartingPoint { get { return startingPoints; } }

    public override string ToString()
    {
        return string.Format("[3DPoint]\nCoordinates:\nX: {0}\nY: {1}\nZ: {2}", this.X, this.Y, this.Z);
    }
}