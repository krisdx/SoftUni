using System;
using Shapes.Interfaces;
using Shapes.Figures;
using System.Collections.Generic;

public class ShapesMain
{
    public static void Main()
    {
        List<IShape> figures = new List<IShape>
        {
            new Circle(2),
            new Circle(5), 
            new Rectangle(10, 20),
            new Rectangle(30, 40), 
            new Rhombus(4, 4, 4),
            new Rhombus(5, 6, 6)
        };

        foreach (var figure in figures)
        {
            Console.WriteLine("[{0}]", figure.GetType().Name);
            Console.WriteLine("Perimeter: {0}", figure.CalculatePerimeter());
            Console.WriteLine("Area: {0}", figure.CalculateArea());
            Console.WriteLine();
        }
    }
}