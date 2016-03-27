namespace LinkedList
{
    public class CustomLinkedListNode<T> 
    {
        public CustomLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public CustomLinkedListNode<T> NextNode { get; set; }
    }
}