//====================================================
//| Downloaded From                                  |
//| Visual C# Kicks - http://www.vcskicks.com/       |
//| License - http://www.vcskicks.com/license.html   |
//====================================================

using System;

class AvlTreeNode<T> : BinaryTreeNode<T>
    where T : IComparable
{
    public AvlTreeNode(T value)
        : base(value)
    {
    }

    public new AvlTreeNode<T> LeftChild
    {
        get
        {
            return (AvlTreeNode<T>)base.LeftChild;
        }
        set
        {
            base.LeftChild = value;
        }
    }

    public new AvlTreeNode<T> RightChild
    {
        get
        {
            return (AvlTreeNode<T>)base.RightChild;
        }
        set
        {
            base.RightChild = value;
        }
    }

    public new AvlTreeNode<T> Parent
    {
        get
        {
            return (AvlTreeNode<T>)base.Parent;
        }
        set
        {
            base.Parent = value;
        }
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}

class AvlTree<T> : BinaryTree<T>
    where T : IComparable
{
    public new AvlTreeNode<T> Root
    {
        get { return (AvlTreeNode<T>)base.Root; }
        set { base.Root = value; }
    }

    public new AvlTreeNode<T> Find(T value)
    {
        return (AvlTreeNode<T>)base.Find(value);
    }

    public override void Add(T value)
    {
        AvlTreeNode<T> node = new AvlTreeNode<T>(value);

        base.Add(node); //add normally

        //Balance every node going up, starting with the parent
        AvlTreeNode<T> parentNode = node.Parent;

        while (parentNode != null)
        {
            int balance = this.GetBalance(parentNode);
            if (Math.Abs(balance) == 2) //-2 or 2 is unbalanced
            {
                //Rebalance tree
                this.BalanceAt(parentNode, balance);
            }

            parentNode = parentNode.Parent; //keep going up
        }
    }
    
    public override bool Remove(T value)
    {
        AvlTreeNode<T> valueNode = this.Find(value);
        return this.Remove(valueNode);
    }
    
    protected new bool Remove(BinaryTreeNode<T> removeNode)
    {
        return this.Remove((AvlTreeNode<T>)removeNode);
    }

    public bool Remove(AvlTreeNode<T> valueNode)
    {
        //Save reference to the parent node to be removed
        AvlTreeNode<T> parentNode = valueNode.Parent;

        //Remove the node as usual
        bool removed = base.Remove(valueNode);

        if (!removed)
            return false; //removing failed, no need to rebalance
        else
        {
            //Balance going up the tree
            while (parentNode != null)
            {
                int balance = this.GetBalance(parentNode);

                if (Math.Abs(balance) == 1) //1, -1
                    break; //height hasn't changed, can stop
                else if (Math.Abs(balance) == 2) //2, -2
                {
                    //Rebalance tree
                    this.BalanceAt(parentNode, balance);
                }

                parentNode = parentNode.Parent;
            }

            return true;
        }
    }

    protected virtual void BalanceAt(AvlTreeNode<T> node, int balance)
    {
        if (balance == 2) //right outweighs
        {
            int rightBalance = this.GetBalance(node.RightChild);
            if (rightBalance == 1 || rightBalance == 0)
            {
                // RIGHT-RIGHT case
                //Left rotation needed
                this.RotateLeft(node);
            }
            else if (rightBalance == -1)
            {
                // RIGHT-LEFT case
                //Right rotation needed
                this.RotateRight(node.RightChild);

                //Left rotation needed
                this.RotateLeft(node);
            }
        }
        else if (balance == -2) //left outweighs
        {
            int leftBalance = this.GetBalance(node.LeftChild);
            if (leftBalance == 1)
            {
                // LEFT-RIGHT case

                //Left rotation needed
                this.RotateLeft(node.LeftChild);

                //Right rotation needed
                this.RotateRight(node);
            }
            else if (leftBalance == -1 || leftBalance == 0)
            {
                // LEFTH-LEFT CASE

                //Right rotation needed
                this.RotateRight(node);
            }
        }
    }

    /// <summary>
    /// Determines the balance of a given node
    /// </summary>
    protected virtual int GetBalance(AvlTreeNode<T> root)
    {
        //Balance = right child's height - left child's height
        return 
            this.GetHeight(root.RightChild) - 
            this.GetHeight(root.LeftChild);
    }

    /// <summary>
    /// Rotates a node to the left within an AVL Tree
    /// </summary>
    protected virtual void RotateLeft(AvlTreeNode<T> root)
    {
        if (root == null)
            return;

        AvlTreeNode<T> pivot = root.RightChild;

        if (pivot == null)
            return;
        else
        {
            AvlTreeNode<T> rootParent = root.Parent; //original parent of root node
            bool isLeftChild = (rootParent != null) && rootParent.LeftChild == root; //whether the root was the parent's left node
            bool makeTreeRoot = root.Tree.Root == root; //whether the root was the root of the entire tree

            //Rotate
            root.RightChild = pivot.LeftChild;
            pivot.LeftChild = root;

            //Update parents
            root.Parent = pivot;
            pivot.Parent = rootParent;

            if (root.RightChild != null)
                root.RightChild.Parent = root;

            //Update the entire tree's Root if necessary
            if (makeTreeRoot)
                pivot.Tree.Root = pivot;

            //Update the original parent's child node
            if (isLeftChild)
                rootParent.LeftChild = pivot;
            else
                if (rootParent != null)
                    rootParent.RightChild = pivot;
        }
    }

    /// <summary>
    /// Rotates a node to the right within an AVL Tree
    /// </summary>
    protected virtual void RotateRight(AvlTreeNode<T> root)
    {
        if (root == null)
            return;

        AvlTreeNode<T> pivot = root.LeftChild;

        if (pivot == null)
            return;
        else
        {
            AvlTreeNode<T> rootParent = root.Parent; //original parent of root node
            bool isLeftChild = (rootParent != null) && rootParent.LeftChild == root; //whether the root was the parent's left node
            bool makeTreeRoot = root.Tree.Root == root; //whether the root was the root of the entire tree

            //Rotate
            root.LeftChild = pivot.RightChild;
            pivot.RightChild = root;

            //Update parents
            root.Parent = pivot;
            pivot.Parent = rootParent;

            if (root.LeftChild != null)
                root.LeftChild.Parent = root;

            //Update the entire tree's Root if necessary
            if (makeTreeRoot)
                pivot.Tree.Root = pivot;

            //Update the original parent's child node
            if (isLeftChild)
                rootParent.LeftChild = pivot;
            else
                if (rootParent != null)
                    rootParent.RightChild = pivot;
        }
    }
}