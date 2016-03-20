namespace _01.LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public LinkedQueue()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new QueueNode<T>(element);

            if (this.head == null)
            {
                // The linked queue is empty -> create new head an tail.
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            this.Count--;

            return firstElement;
        }

        public bool Contains(T element)
        {
            return this.Any(e => e.Equals(element));
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public T Peek()
        {
            var lastElement = this.tail.Value;

            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode.NextNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}