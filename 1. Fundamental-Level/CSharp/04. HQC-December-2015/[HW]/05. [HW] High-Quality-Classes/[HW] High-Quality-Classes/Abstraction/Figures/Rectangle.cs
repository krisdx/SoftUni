namespace Abstraction.Figures
{
    using System;
    using Interfaces;

    public class Rectangle : Figure, IRectangle
    {
        private const double DefaultWidth = 0;
        private const double DefaultHeight = 0;

        private double width;
        private double height;

        public Rectangle()
        {
            this.Width = DefaultWidth;
            this.Height = DefaultHeight;
        }

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The width of the rectangle cannot be negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The height of the rectangle cannot be negative.");
                }

                this.height = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = (this.Width + this.Height) * 2;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}