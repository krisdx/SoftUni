namespace DoubleLinkedList
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public DoublyLinkedListNode<T> NextNode { get; set; }

        public DoublyLinkedListNode<T> PreviousNode { get; set; }
    }
}