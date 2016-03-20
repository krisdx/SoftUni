namespace Shapes.Figures
{
    public class Rhombus : BasicShape
    {
        public Rhombus(double side, double firstDiagonal, double secondDiagonal)
        {
            this.Side = side;
            this.FirstDiagonal = firstDiagonal;
            this.SecondDiagonal = secondDiagonal;
        }

        public double Side { get; private set; }

        public double FirstDiagonal { get; private set; }

        public double SecondDiagonal { get; private set; }
        
        public override double CalculatePerimeter()
        {
            return 4 * this.Side;
        }

        public override double CalculateArea()
        {
            return (this.FirstDiagonal * this.SecondDiagonal) / 2;
        }
    }
}