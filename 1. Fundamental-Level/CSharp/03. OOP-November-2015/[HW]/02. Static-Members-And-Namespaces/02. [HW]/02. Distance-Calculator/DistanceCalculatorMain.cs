using System;

public class DistanceCalculatorMain
{
    public static void Main()
    {
        Point3D point1 = new Point3D(0, 5, 1);
        Point3D point2 = new Point3D(-3, 20, 0);

        Console.WriteLine(DistanceCalculator.CalculateDistance(point1, point2));
    }
}