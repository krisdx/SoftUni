namespace CalculateSequence
{
    public class Item
    {
        public Item(int value, Item previousItem)
        {
            this.Value = value;
            this.PreviousItem = previousItem;
        }

        public int Value { get; private set; }

        public Item PreviousItem { get; private set; }
    }
}
