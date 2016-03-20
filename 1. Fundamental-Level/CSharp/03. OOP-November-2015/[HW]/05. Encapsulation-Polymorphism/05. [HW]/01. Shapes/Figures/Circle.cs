namespace Shapes.Figures
{
    using System;
    using Interfaces;

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }

        public double CalculateArea()
        {
            return Math.PI * this.Radius * 2;
        }

        public double CalculatePerimeter()
        {
            return Math.PI * (this.Radius * this.Radius);
        }
    }
}