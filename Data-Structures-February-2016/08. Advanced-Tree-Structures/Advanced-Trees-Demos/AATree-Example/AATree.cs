using System;

public class AATree<TKey, TValue> where TKey : IComparable<TKey>
{
    public class AATreeNode
    {
        // Node internal data
        internal int level;
        internal AATreeNode left;
        internal AATreeNode right;

        // User data
        internal TKey key;
        internal TValue value;

        // Constuctor for the sentinel node
        internal AATreeNode()
        {
            this.level = 0;
            this.left = this;
            this.right = this;
        }

        // Constuctor for regular nodes (that all start life as leaf nodes)
        internal AATreeNode(TKey key, TValue value, AATreeNode sentinel)
        {
            this.level = 1;
            this.left = sentinel;
            this.right = sentinel;
            this.key = key;
            this.value = value;
        }
    }

    AATreeNode root;
    AATreeNode sentinel;
    AATreeNode deleted;

    public AATreeNode Root
    {
        get { return this.root; }
    }

    public AATree()
    {
        this.root = new AATreeNode();
        this.sentinel = new AATreeNode();
    }

    private void Skew(ref AATreeNode node)
    {
        if (node.level == node.left.level)
        {
            // Rotate right
            AATreeNode left = node.left;
            node.left = left.right;
            left.right = node;
            node = left;
        }
    }

    private void Split(ref AATreeNode node)
    {
        if (node.right.right.level == node.level)
        {
            // Rotate left
            AATreeNode right = node.right;
            node.right = right.left;
            right.left = node;
            node = right;
            node.level++;
        }
    }

    private bool Insert(ref AATreeNode aaTreeNode, TKey key, TValue value)
    {
        if (aaTreeNode == sentinel)
        {
            aaTreeNode = new AATreeNode(key, value, sentinel);
            return true;
        }

        int compare = key.CompareTo(aaTreeNode.key);
        if (compare < 0)
        {
            if (!Insert(ref aaTreeNode.left, key, value))
            {
                return false;
            }
        }
        else if (compare > 0)
        {
            if (!Insert(ref aaTreeNode.right, key, value))
            {
                return false;
            }
        }
        else
        {
            return false;
        }

        this.Skew(ref aaTreeNode);
        this.Split(ref aaTreeNode);

        return true;
    }

    private bool Delete(ref AATreeNode aaTreeNode, TKey key)
    {
        if (aaTreeNode == sentinel)
        {
            return (deleted != null);
        }

        int compare = key.CompareTo(aaTreeNode.key);
        if (compare < 0)
        {
            if (!Delete(ref aaTreeNode.left, key))
            {
                return false;
            }
        }
        else
        {
            if (compare == 0)
            {
                deleted = aaTreeNode;
            }
            if (!Delete(ref aaTreeNode.right, key))
            {
                return false;
            }
        }

        if (deleted != null)
        {
            deleted.key = aaTreeNode.key;
            deleted.value = aaTreeNode.value;
            deleted = null;
            aaTreeNode = aaTreeNode.right;
        }
        else if (aaTreeNode.left.level < aaTreeNode.level - 1
                || aaTreeNode.right.level < aaTreeNode.level - 1)
        {
            --aaTreeNode.level;
            if (aaTreeNode.right.level > aaTreeNode.level)
            {
                aaTreeNode.right.level = aaTreeNode.level;
            }
            Skew(ref aaTreeNode);
            Skew(ref aaTreeNode.right);
            Skew(ref aaTreeNode.right.right);
            Split(ref aaTreeNode);
            Split(ref aaTreeNode.right);
        }

        return true;
    }

    private AATreeNode Search(AATreeNode aaTreeNode, TKey key)
    {
        if (aaTreeNode == sentinel)
        {
            return null;
        }

        int compare = key.CompareTo(aaTreeNode.key);
        if (compare < 0)
        {
            return Search(aaTreeNode.left, key);
        }
        else if (compare > 0)
        {
            return Search(aaTreeNode.right, key);
        }
        else
        {
            return aaTreeNode;
        }
    }

    public bool Add(TKey key, TValue value)
    {
        return Insert(ref root, key, value);
    }

    public bool Remove(TKey key)
    {
        return Delete(ref root, key);
    }

    public TValue this[TKey key]
    {
        get
        {
            AATreeNode aaTreeNode = Search(root, key);
            return aaTreeNode == null ? default(TValue) : aaTreeNode.value;
        }

        set
        {
            AATreeNode aaTreeNode = Search(root, key);
            if (aaTreeNode == null)
            {
                Add(key, value);
            }
            else
            {
                aaTreeNode.value = value;
            }
        }
    }
}
