namespace LinkedStack
{
    public class LinkedStackNode<T>
    {
        public LinkedStackNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public LinkedStackNode<T> NextNode { get; set; }

        public LinkedStackNode<T> PreviousNode { get; set; }
    }
}