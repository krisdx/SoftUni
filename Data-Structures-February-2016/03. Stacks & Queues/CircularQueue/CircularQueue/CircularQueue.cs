namespace CircularQueue
{
    using System;

    public class CircularQueue<T>
    {
        private const int DefaultCapacity = 16;

        private T[] elements;
        private int startIndex;
        private int endIndex;

        public CircularQueue(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return this.elements.Length; }
        }

        public void Enqueue(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.endIndex] = element;
            this.endIndex = (this.endIndex + 1) % this.elements.Length;
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var dequeuedElement = this.elements[this.startIndex];
            this.elements[this.startIndex] = default(T);
            this.startIndex = (this.startIndex + 1) % this.elements.Length;
            this.Count--;

            return dequeuedElement;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            this.CopyAllElements(array);

            return array;
        }

        private void Resize()
        {
            var newElements = new T[this.elements.Length * 2];
            this.CopyAllElements(newElements);
            this.elements = newElements;
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private void CopyAllElements(T[] arrayToCopy)
        {
            int index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                arrayToCopy[i] = this.elements[index];
                index = (index + 1) % this.elements.Length;
            }
        }
    }
}