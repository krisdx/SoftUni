namespace RideTheHorse
{
    public class MatrixCell
    {
        public MatrixCell(int value, int row, int col)
        {
            this.Value = value;
            this.Row = row;
            this.Col = col;
        }

        public int Value { get; private set; }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
