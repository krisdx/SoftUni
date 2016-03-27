namespace EscapeFromLabyrinth
{
    public class Point
    {
        public Point(int y, int x, string direction, Point previousPoint)
        {
            this.Y = y;
            this.X = x;
            this.Direction = direction;
            this.PreviousPoint = previousPoint;
        }

        public Point(int y, int x) 
            : this(y, x, null, null)
        {
        }
        
        public int X { get; private set; }

        public int Y { get; private set; }

        public string Direction { get; private set; }

        public Point PreviousPoint { get; private set; }
    }
}