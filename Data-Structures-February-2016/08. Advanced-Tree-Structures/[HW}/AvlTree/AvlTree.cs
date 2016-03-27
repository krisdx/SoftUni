namespace AvlTree
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T> where T : IComparable<T>
    {
        public int Count { get; private set; }

        public AvlTreeNode<T> Root { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                var node = this.Root;
                while (true)
                {
                    var leftSubTreeCount = 0;
                    if (node.LeftChild != null)
                    {
                        leftSubTreeCount = node.LeftChild.Count;
                    }

                    if (index == leftSubTreeCount)
                    {
                        return node.Value;
                    }

                    if (index <= leftSubTreeCount)
                    {
                        node = node.LeftChild;
                        continue;
                    }

                    if (index > leftSubTreeCount)
                    {
                        index -= leftSubTreeCount + 1;
                        node = node.RightChild;
                    }
                }
            }
        }

        public void Add(T item)
        {
            var inserted = true;
            if (this.Root == null)
            {
                this.Root = new AvlTreeNode<T>(item);
            }
            else
            {
                inserted = this.InternalInsert(this.Root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        public bool Contains(T item)
        {
            var node = this.Root;
            while (node != null)
            {
                if (node.Value.CompareTo(item) < 0)
                {
                    node = node.RightChild;
                }
                else if (node.Value.CompareTo(item) > 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<T> Range(T from, T to)
        {
            var itemsInRange = this.GetItemsInRange(from, to, this.Root);
            return itemsInRange;
        }

        private List<T> GetItemsInRange(T from, T to, AvlTreeNode<T> currentNode)
        {
            var items = new List<T>();
            if (currentNode.LeftChild != null &&
                currentNode.Value.CompareTo(from) > 0 &&
                currentNode.Value.CompareTo(to) < 0)
            {
                items.AddRange(this.GetItemsInRange(from, to, currentNode.LeftChild));
            }

            if (currentNode.Value.CompareTo(from) > 0 && 
                currentNode.Value.CompareTo(to) < 0)
            {
                items.Add(currentNode.Value);
            }

            if (currentNode.RightChild != null &&
                currentNode.Value.CompareTo(from) > 0 &&
                currentNode.Value.CompareTo(to) < 0)
            {
                items.AddRange(this.GetItemsInRange(from, to, currentNode.RightChild));
            }

            return items;
        }

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.Root, 1, action);
        }

        private bool InternalInsert(AvlTreeNode<T> node, T item)
        {
            var currentNode = node;
            var newNode = new AvlTreeNode<T>(item);

            while (true)
            {
                if (currentNode.Value.CompareTo(item) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BallanceFactor--;

                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else if (currentNode.Value.CompareTo(item) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BallanceFactor++;

                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    return false;
                }
            }

            this.RetraceInsert(currentNode);
            return true;
        }

        private void RetraceInsert(AvlTreeNode<T> node)
        {
            node.Count++;
            var parent = node.Parent;
            while (parent != null)
            {
                parent.Count++;
                parent = parent.Parent;
            }

            parent = node.Parent;

            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    if (parent.BallanceFactor == 1)
                    {
                        parent.BallanceFactor++;
                        if (node.BallanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;
                    }

                    if (parent.BallanceFactor == -1)
                    {
                        parent.BallanceFactor = 0;
                        break;
                    }

                    parent.BallanceFactor = 1;
                }
                else
                {
                    if (parent.BallanceFactor == -1)
                    {
                        parent.BallanceFactor--;
                        if (node.BallanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;
                    }

                    if (parent.BallanceFactor == 1)
                    {
                        parent.BallanceFactor = 0;
                        break;
                    }

                    parent.BallanceFactor = -1;
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void ModifyRotatedNodesCount(AvlTreeNode<T> node)
        {
            var newCount = 1;
            if (node.LeftChild != null)
            {
                newCount += node.LeftChild.Count;
            }

            if (node.RightChild != null)
            {
                newCount += node.RightChild.Count;
            }

            node.Count = newCount;
        }

        private void RotateLeft(AvlTreeNode<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.Root = child;
                this.Root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BallanceFactor += 1 - Math.Min(child.BallanceFactor, 0);
            child.BallanceFactor += 1 + Math.Max(node.BallanceFactor, 0);

            this.ModifyRotatedNodesCount(node);
            this.ModifyRotatedNodesCount(child);
        }

        private void RotateRight(AvlTreeNode<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;

            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.Root = child;
                this.Root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BallanceFactor -= 1 + Math.Max(child.BallanceFactor, 0);
            child.BallanceFactor -= 1 - Math.Min(node.BallanceFactor, 0);

            this.ModifyRotatedNodesCount(node);
            this.ModifyRotatedNodesCount(child);
        }

        private void InOrderDfs(AvlTreeNode<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid Index");
            }
        }
    }
}