namespace CohesionAndCoupling.Shapes
{
    using System;

    public class Shape3D : Shape
    {
        private double depth;

        public Shape3D(double width, double height, double depth)
            : base(width, height)
        {
            this.Depth = depth;
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("The depth of the {0} cannot be empty.",
                        this.GetType().Name));
                }

                this.depth = value;
            }
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }

        public double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(
                (x2 - x1) * (x2 - x1) +
                (y2 - y1) * (y2 - y1) +
                (z2 - z1) * (z2 - z1));

            return distance;
        }

        public double CalculateDiagonalXYZ()
        {
            double distance = this.CalculateDistance3D(0, 0, 0, this.Width, this.Height, this.Depth);
            return distance;
        }

        public double CalculateDiagonalXZ()
        {
            return CalculateDistance(0, 0, this.Width, this.Depth);
        }

        public double CalculateDiagonalYZ()
        {
            return CalculateDistance(0, 0, this.Width, this.Depth);
        }

        public double CalculateDiagonalXY()
        {
            return CalculateDistance(0, 0, this.Width, this.Depth);
        }
    }
}