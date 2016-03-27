namespace LinkedQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedQueue<T> : IEnumerable<T>
    {
        public LinkedQueue()
        {
            this.HeadNode = null;
            this.TailNode = null;
            this.Count = 0;
        }

        public LinkedQueueNode<T> HeadNode { get; private set; }

        public LinkedQueueNode<T> TailNode { get; private set; }

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            var newNode = new LinkedQueueNode<T>(element);

            if (this.HeadNode == null)
            {
                this.HeadNode = newNode;
                this.TailNode = newNode;
            }
            else
            {
                newNode.PreviousNode = this.TailNode;
                this.TailNode.NextNode = newNode;
                this.TailNode = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            this.ValidateEmptyQueue();

            var elementToDequeue = this.HeadNode.Value;

            this.Count--;
            if (this.Count == 0)
            {
                this.HeadNode = null;
                this.TailNode = null;
            }
            else
            {
                this.HeadNode = this.HeadNode.NextNode;
                this.HeadNode.PreviousNode = null;
            }

            return elementToDequeue;
        }

        public T Peek()
        {
            this.ValidateEmptyQueue();

            return this.HeadNode.Value;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];

            var currentNode = this.HeadNode;
            for (int index = 0; index < this.Count; index++)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.HeadNode;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ValidateEmptyQueue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
        }
    }
}
