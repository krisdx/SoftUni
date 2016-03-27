namespace LinkedQueue
{
    public class LinkedQueueNode<T>
    {
        public LinkedQueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public LinkedQueueNode<T> NextNode { get; set; }

        public LinkedQueueNode<T> PreviousNode { get; set; }

    }
}