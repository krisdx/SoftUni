using System;

public class Point3DMain
{
    public static void Main()
    {
        Point3D point = new Point3D(2, 3, 4);
        Console.WriteLine(point);

        Console.WriteLine();
        Console.WriteLine("Default starting points: " + Point3D.StartingPoint);
    }
}