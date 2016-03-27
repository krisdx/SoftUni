namespace Trees
{
    using System;

    public class BinaryTree<T>
    {
        public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public BinaryTree<T> RightChild { get; private set; }

        public BinaryTree<T> LeftChild { get; private set; }

        public void PrintIndentedPreOrder(int spacesCount = 0)
        {
            Console.WriteLine(new string(' ', 2 * spacesCount) + this.Value);
            if (this.LeftChild != null)
            {
                this.LeftChild.PrintIndentedPreOrder(spacesCount + 1);
            }

            if (this.RightChild != null)
            {
                this.RightChild.PrintIndentedPreOrder(spacesCount + 1);
            }
        }

        public void EachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.EachInOrder(action);
            }

            action(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.EachInOrder(action);
            }
        }

        public void EachPostOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.EachPostOrder(action);
            }

            if (this.RightChild != null)
            {
                this.RightChild.EachPostOrder(action);
            }

            action(this.Value);
        }
    }
}