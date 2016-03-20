namespace CohesionAndCoupling.Shapes
{
    public class Shape2D : Shape
    {
        public Shape2D(double width, double height)
            : base(width, height)
        {
        }

        public double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            return CalculateDistance(x1, y1, x2, y2);
        }
    }
}