using System;

// Write an expression that checks if given point (x,  y) is inside a circle K({0, 0}, 2).

class PointInACircle
{
    static void Main()
    {
        Console.WriteLine("Please enter x and y to see if they are int the circle K({0, 0}, 2).\n");

        Console.Write("Enter x: ");
        float x = float.Parse(Console.ReadLine());

        Console.Write("Enter y: ");
        float y = float.Parse(Console.ReadLine());

        float radius = 2;

        float inside = (float)Math.Sqrt(x * x + y * y);
        bool result = (radius > inside);

        Console.WriteLine("\n{0}\n", result);
    }
}