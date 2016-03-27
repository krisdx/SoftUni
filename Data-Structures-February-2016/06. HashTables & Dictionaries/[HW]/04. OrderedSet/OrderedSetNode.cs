namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSetNode<T> : IEnumerable<T> where T: IComparable<T>
    {
        public OrderedSetNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public OrderedSetNode<T> Parent { get; set; }

        public OrderedSetNode<T> LeftChild { get; set; }

        public OrderedSetNode<T> RightChild { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var value in this.LeftChild)
                {
                    yield return value;
                }
            }

            yield return this.Value;

            if (this.RightChild != null)
            {
                foreach (var value in this.RightChild)
                {
                    yield return value;
                }
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}