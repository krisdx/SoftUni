namespace ConnectedAreasInMatrix
{
    using System;

    public class Area : IComparable<Area>
    {
        public Area(int row, int col, int size)
        {
            this.StartRow = row;
            this.StartCol = col;
            this.Size = size;
        }

        public int StartRow { get; set; }

        public int StartCol { get; set; }

        public int Size { get; set; }

        public int CompareTo(Area other)
        {
            int compareIndex =  other.Size.CompareTo(this.Size);
            if (compareIndex == 0)
            {
                compareIndex = this.StartRow.CompareTo(other.StartRow);
                if (compareIndex == 0)
                {
                    compareIndex = this.StartCol.CompareTo(other.StartCol);
                }
            }

            return compareIndex;
        }
    }
}