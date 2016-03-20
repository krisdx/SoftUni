using System;

// Write a program that reads the radius r of a circle and prints its perimeter and area formatted with 2 digits after the decimal point.

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter r: ");
        double r = double.Parse(Console.ReadLine());

        Console.WriteLine();

        double circleArea = (Math.Pow(r, 2) * Math.PI);
        double circlePerimeter = (2 * r * Math.PI);

        Console.WriteLine("Circle perimeter: {0:F2}\nCircle area: {1:F2}\n", circlePerimeter, circleArea);
    }
}