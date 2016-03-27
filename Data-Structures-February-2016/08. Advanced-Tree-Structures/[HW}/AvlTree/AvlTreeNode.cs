namespace AvlTree
{
    using System;

    public class AvlTreeNode<T> where T : IComparable<T>
    {
        private AvlTreeNode<T> leftChild;
        private AvlTreeNode<T> rightChild;

        public AvlTreeNode(T value)
        {
            this.Value = value;
            this.Count = 1;
        }

        public T Value { get; set; }

        public AvlTreeNode<T> Parent { get; set; }

        public AvlTreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public AvlTreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public int BallanceFactor { get; set; }

        public int Count { get; set; }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent != null && this.Parent.leftChild != null)
                {
                    return this.Parent.leftChild == this;
                }

                return false;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent != null && this.Parent.rightChild != null)
                {
                    return this.Parent.RightChild == this;
                }

                return false;
            }
        }

        public int ChildrenCount
        {
            get
            {
                if (this.rightChild != null && this.leftChild != null)
                {
                    return 2;
                }

                if (this.rightChild == null && this.leftChild == null)
                {
                    return 0;
                }

                return 1;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}