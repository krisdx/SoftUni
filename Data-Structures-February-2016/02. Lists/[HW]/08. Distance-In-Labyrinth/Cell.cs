namespace DistanceInLabyrinth
{
    public class Cell
    {
        public Cell(string value, int row, int col)
        {
            this.Value = value;
            this.Row = row;
            this.Col = col;
        }

        public string Value { get; private set; }

        public int Row { get;private set; }

        public int Col { get; private set; }

        public override string ToString()
        {
            return this.Value;
        }
    }
}