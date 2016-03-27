namespace BinaryTree
{
    using System;

    public class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> 
        where T : IComparable<T>
    {
        public BinaryTreeNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public void PrintIndentedPreOrder(int spacesCount = 0)
        {
            Console.WriteLine(new string(' ', spacesCount) + this.Value);
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintIndentedPreOrder(spacesCount + 1);
            }

            if (this.RightChild != null)
            {
                this.RightChild.PrintIndentedPreOrder(spacesCount + 1);
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = (BinaryTreeNode<T>)obj;
            return this.CompareTo(other) == 0;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public int CompareTo(BinaryTreeNode<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}