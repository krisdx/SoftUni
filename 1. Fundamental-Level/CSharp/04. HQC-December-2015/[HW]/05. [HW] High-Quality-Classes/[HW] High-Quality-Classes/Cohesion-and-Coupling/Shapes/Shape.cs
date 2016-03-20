namespace CohesionAndCoupling.Shapes
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;

        protected Shape(double width, double height)
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
                    throw new ArgumentOutOfRangeException(string.Format("The width of the {0} cannot be empty.",
                        this.GetType().Name));
                }

                this.width = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The height of the {0} cannot be empty.",
                        this.GetType().Name));
                }

                this.height = value;
            }
        }

        protected static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(
                (x2 - x1) * (x2 - x1) +
                (y2 - y1) * (y2 - y1));

            return distance;
        }
    }
}