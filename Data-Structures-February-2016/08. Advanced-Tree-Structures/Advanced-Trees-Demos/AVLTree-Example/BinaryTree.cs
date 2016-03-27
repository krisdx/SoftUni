//====================================================
//| Downloaded From                                  |
//| Visual C# Kicks - http://www.vcskicks.com/       |
//| License - http://www.vcskicks.com/license.html   |
//====================================================
using System;
using System.Collections;
using System.Collections.Generic;

class BinaryTreeNode<T>
    where T : IComparable
{
    public BinaryTreeNode(T value)
    {
        this.Value = value;
    }

    public virtual T Value { get; set; }

    public virtual BinaryTreeNode<T> LeftChild { get; set; }

    public virtual BinaryTreeNode<T> RightChild { get; set; }

    public virtual BinaryTreeNode<T> Parent { get; set; }

    public virtual BinaryTree<T> Tree { get; set; }

    public virtual bool IsLeaf
    {
        get { return this.ChildCount == 0; }
    }

    /// <summary>
    /// Gets whether the node is internal (has children nodes)
    /// </summary>
    //public virtual bool IsInternal
    //{
    //    get { return this.ChildCount > 0; }
    //}

    public virtual bool IsLeftChild
    {
        get { return this.Parent != null && this.Parent.LeftChild == this; }
    }

    public virtual bool IsRightChild
    {
        get { return this.Parent != null && this.Parent.RightChild == this; }
    }

    public virtual int ChildCount
    {
        get
        {
            int count = 0;

            if (this.LeftChild != null)
                count++;

            if (this.RightChild != null)
                count++;

            return count;
        }
    }

    public virtual bool HasLeftChild
    {
        get { return (this.LeftChild != null); }
    }

    public virtual bool HasRightChild
    {
        get { return (this.RightChild != null); }
    }
}

class BinaryTree<T> : ICollection<T>
    where T : IComparable
{
    public enum TraversalMode
    {
        InOrder = 0,
        PostOrder,
        PreOrder
    }

    private BinaryTreeNode<T> head;
    private Comparison<IComparable> comparer = CompareElements;
    private int size;
    private TraversalMode _traversalMode = TraversalMode.InOrder;

    public virtual BinaryTreeNode<T> Root
    {
        get { return this.head; }
        set { this.head = value; }
    }

    public virtual bool IsReadOnly
    {
        get { return false; }
    }

    public virtual int Count
    {
        get { return this.size; }
    }

    public virtual TraversalMode TraversalOrder
    {
        get { return this._traversalMode; }
        set { this._traversalMode = value; }
    }

    public BinaryTree()
    {
        this.head = null;
        this.size = 0;
    }

    public virtual void Add(T value)
    {
        BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
        this.Add(node);
    }

    /// <summary>
    /// Adds a node to the tree
    /// </summary>
    public virtual void Add(BinaryTreeNode<T> node)
    {
        if (this.head == null) //first element being added
        {
            this.head = node; //set node as root of the tree
            node.Tree = this;
            this.size++;
        }
        else
        {
            if (node.Parent == null)
                node.Parent = this.head; //start at head

            //Node is inserted on the left side if it is smaller or equal to the parent
            bool insertLeftSide = this.comparer((IComparable)node.Value, (IComparable)node.Parent.Value) <= 0;

            if (insertLeftSide) //insert on the left
            {
                if (node.Parent.LeftChild == null)
                {
                    node.Parent.LeftChild = node; //insert in left
                    this.size++;
                    node.Tree = this; //assign node to this binary tree
                }
                else
                {
                    node.Parent = node.Parent.LeftChild; //scan down to left child
                    this.Add(node); //recursive call
                }
            }
            else //insert on the right
            {
                if (node.Parent.RightChild == null)
                {
                    node.Parent.RightChild = node; //insert in right
                    this.size++;
                    node.Tree = this; //assign node to this binary tree
                }
                else
                {
                    node.Parent = node.Parent.RightChild;
                    this.Add(node);
                }
            }
        }
    }

    public virtual BinaryTreeNode<T> Find(T value)
    {
        BinaryTreeNode<T> node = this.head; //start at head
        while (node != null)
        {
            if (node.Value.Equals(value)) //parameter value found
                return node;
            else
            {
                //Search left if the value is smaller than the current node
                bool searchLeft = this.comparer((IComparable)value, (IComparable)node.Value) < 0;

                if (searchLeft)
                    node = node.LeftChild; //search left
                else
                    node = node.RightChild; //search right
            }
        }

        return null; //not found
    }

    public virtual bool Contains(T value)
    {
        return (this.Find(value) != null);
    }

    public virtual bool Remove(T value)
    {
        BinaryTreeNode<T> removeNode = this.Find(value);

        return this.Remove(removeNode);
    }

    public virtual bool Remove(BinaryTreeNode<T> removeNode)
    {
        if (removeNode == null || removeNode.Tree != this)
            return false; //value doesn't exist or not of this tree

        //Note whether the node to be removed is the root of the tree
        bool wasHead = (removeNode == this.head);

        if (this.Count == 1)
        {
            this.head = null; //only element was the root
            removeNode.Tree = null;

            this.size--; //decrease total element count
        }
        else if (removeNode.IsLeaf) //Case 1: No Children
        {
            //Remove node from its parent
            if (removeNode.IsLeftChild)
                removeNode.Parent.LeftChild = null;
            else
                removeNode.Parent.RightChild = null;

            removeNode.Tree = null;
            removeNode.Parent = null;

            this.size--; //decrease total element count
        }
        else if (removeNode.ChildCount == 1) //Case 2: One Child
        {
            if (removeNode.HasLeftChild)
            {
                //Put left child node in place of the node to be removed
                removeNode.LeftChild.Parent = removeNode.Parent; //update parent

                if (wasHead)
                    this.Root = removeNode.LeftChild; //update root reference if needed

                if (removeNode.IsLeftChild) //update the parent's child reference
                    removeNode.Parent.LeftChild = removeNode.LeftChild;
                else
                    removeNode.Parent.RightChild = removeNode.LeftChild;
            }
            else //Has right child
            {
                //Put left node in place of the node to be removed
                removeNode.RightChild.Parent = removeNode.Parent; //update parent

                if (wasHead)
                    this.Root = removeNode.RightChild; //update root reference if needed

                if (removeNode.IsLeftChild) //update the parent's child reference
                    removeNode.Parent.LeftChild = removeNode.RightChild;
                else
                    removeNode.Parent.RightChild = removeNode.RightChild;
            }

            removeNode.Tree = null;
            removeNode.Parent = null;
            removeNode.LeftChild = null;
            removeNode.RightChild = null;

            this.size--; //decrease total element count
        }
        else //Case 3: Two Children
        {
            //Find inorder predecessor (right-most node in left subtree)
            BinaryTreeNode<T> successorNode = removeNode.LeftChild;
            while (successorNode.RightChild != null)
            {
                successorNode = successorNode.RightChild;
            }

            removeNode.Value = successorNode.Value; //replace value

            this.Remove(successorNode); //recursively remove the inorder predecessor
        }


        return true;
    }

    public virtual void Clear()
    {
        //Remove children first, then parent
        //(Post-order traversal)
        IEnumerator<T> enumerator = this.GetPostOrderEnumerator();
        while (enumerator.MoveNext())
        {
            this.Remove(enumerator.Current);
        }
        enumerator.Dispose();
    }

    public virtual int GetHeight()
    {
        return this.GetHeight(this.Root);
    }

    public virtual int GetHeight(T value)
    {
        //Find the value's node in tree
        BinaryTreeNode<T> valueNode = this.Find(value);
        if (value != null)
            return this.GetHeight(valueNode);
        else
            return 0;
    }

    public virtual int GetHeight(BinaryTreeNode<T> startNode)
    {
        if (startNode == null)
            return 0;
        else
            return 1 + Math.Max(
                this.GetHeight(startNode.LeftChild), 
                this.GetHeight(startNode.RightChild));
    }

    public virtual int GetDepth(T value)
    {
        BinaryTreeNode<T> node = this.Find(value);
        return this.GetDepth(node);
    }

    public virtual int GetDepth(BinaryTreeNode<T> startNode)
    {
        int depth = 0;

        if (startNode == null)
            return depth;

        BinaryTreeNode<T> parentNode = startNode.Parent; //start a node above
        while (parentNode != null)
        {
            depth++;
            parentNode = parentNode.Parent; //scan up towards the root
        }

        return depth;
    }

    public virtual IEnumerator<T> GetEnumerator()
    {
        switch (this.TraversalOrder)
        {
            case TraversalMode.InOrder:
                return this.GetInOrderEnumerator();
            case TraversalMode.PostOrder:
                return this.GetPostOrderEnumerator();
            case TraversalMode.PreOrder:
                return this.GetPreOrderEnumerator();
            default:
                return this.GetInOrderEnumerator();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public virtual IEnumerator<T> GetInOrderEnumerator()
    {
        return new BinaryTreeInOrderEnumerator(this);
    }

    public virtual IEnumerator<T> GetPostOrderEnumerator()
    {
        return new BinaryTreePostOrderEnumerator(this);
    }

    public virtual IEnumerator<T> GetPreOrderEnumerator()
    {
        return new BinaryTreePreOrderEnumerator(this);
    }

    public virtual void CopyTo(T[] array)
    {
        this.CopyTo(array, 0);
    }

    public virtual void CopyTo(T[] array, int startIndex)
    {
        IEnumerator<T> enumerator = this.GetEnumerator();

        for (int i = startIndex; i < array.Length; i++)
        {
            if (enumerator.MoveNext())
                array[i] = enumerator.Current;
            else
                break;
        }
    }

    public static int CompareElements(IComparable x, IComparable y)
    {
        return x.CompareTo(y);
    }

    internal class BinaryTreeInOrderEnumerator : IEnumerator<T>
    {
        private BinaryTreeNode<T> _current;
        private BinaryTree<T> _tree;
        internal Queue<BinaryTreeNode<T>> TraverseQueue;

        public BinaryTreeInOrderEnumerator(BinaryTree<T> tree)
        {
            this._tree = tree;

            //Build queue
            this.TraverseQueue = new Queue<BinaryTreeNode<T>>();
            this.VisitNode(this._tree.Root);
        }

        private void VisitNode(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            else
            {
                this.VisitNode(node.LeftChild);
                this.TraverseQueue.Enqueue(node);
                this.VisitNode(node.RightChild);
            }
        }

        public T Current
        {
            get { return this._current.Value; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
            this._current = null;
            this._tree = null;
        }

        public void Reset()
        {
            this._current = null;
        }

        public bool MoveNext()
        {
            if (this.TraverseQueue.Count > 0)
                this._current = this.TraverseQueue.Dequeue();
            else
                this._current = null;

            return (this._current != null);
        }
    }

    internal class BinaryTreePostOrderEnumerator : IEnumerator<T>
    {
        private BinaryTreeNode<T> _current;
        private BinaryTree<T> _tree;
        internal Queue<BinaryTreeNode<T>> TraverseQueue;

        public BinaryTreePostOrderEnumerator(BinaryTree<T> tree)
        {
            this._tree = tree;

            //Build queue
            this.TraverseQueue = new Queue<BinaryTreeNode<T>>();
            this.VisitNode(this._tree.Root);
        }

        private void VisitNode(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            else
            {
                this.VisitNode(node.LeftChild);
                this.VisitNode(node.RightChild);
                this.TraverseQueue.Enqueue(node);
            }
        }

        public T Current
        {
            get { return this._current.Value; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
            this._current = null;
            this._tree = null;
        }

        public void Reset()
        {
            this._current = null;
        }

        public bool MoveNext()
        {
            if (this.TraverseQueue.Count > 0)
                this._current = this.TraverseQueue.Dequeue();
            else
                this._current = null;

            return (this._current != null);
        }
    }

    internal class BinaryTreePreOrderEnumerator : IEnumerator<T>
    {
        private BinaryTreeNode<T> _current;
        private BinaryTree<T> _tree;
        internal Queue<BinaryTreeNode<T>> TraverseQueue;

        public BinaryTreePreOrderEnumerator(BinaryTree<T> tree)
        {
            this._tree = tree;

            //Build queue
            this.TraverseQueue = new Queue<BinaryTreeNode<T>>();
            this.VisitNode(this._tree.Root);
        }

        private void VisitNode(BinaryTreeNode<T> node)
        {
            if (node == null)
                return;
            else
            {
                this.TraverseQueue.Enqueue(node);
                this.VisitNode(node.LeftChild);
                this.VisitNode(node.RightChild);
            }
        }

        public T Current
        {
            get { return this._current.Value; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
            this._current = null;
            this._tree = null;
        }

        public void Reset()
        {
            this._current = null;
        }

        public bool MoveNext()
        {
            if (this.TraverseQueue.Count > 0)
                this._current = this.TraverseQueue.Dequeue();
            else
                this._current = null;

            return (this._current != null);
        }
    }
}