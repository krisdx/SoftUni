namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private OrderedSetNode<T> root;

        public int Count { get; private set; }

        public bool Add(T value)
        {
            // TODO: Reduce this to log(N)
            if (!this.Contains(value))
            {
                this.root = this.Insert(value, this.root, null);
                this.Count++;

                return true;
            }

            return false;
        }

        public bool Contains(T valueToFind)
        {
            var foundNode = this.Find(valueToFind, this.root);
            if (foundNode == null)
            {
                return false;
            }

            return true;
        }

        public bool Remove(T value)
        {
            var nodeToRemove = this.Find(value, this.root);
            if (nodeToRemove == null)
            {
                return false;
            }

            this.Delete(nodeToRemove);
            this.Count--;
            return true;
        }

        private void Delete(OrderedSetNode<T> nodeToRemove)
        {
            if (nodeToRemove.LeftChild != null && nodeToRemove.RightChild != null)
            {
                // The node has 2 children.

                // We can choose to get the biggest element in the left subtree or the smallest element in the right tree. 
                // Both approaches are valid and the tree will remain sorted after the removal. 
                var replacementNode = this.GetBiggestNodeInLeftSubtree(nodeToRemove.LeftChild);

                var swapValue = nodeToRemove.Value;
                nodeToRemove.Value = replacementNode.Value;
                replacementNode.Value = swapValue;

                // After swapping values the node should have at most one child.
                if (replacementNode.LeftChild == null && replacementNode.RightChild == null)
                {
                    this.RemoveLeaf(replacementNode);
                }
                else
                {
                    this.RemoveNodeWithOneChild(replacementNode);
                }
            }
            else if (nodeToRemove.LeftChild == null && nodeToRemove.RightChild == null)
            {
                // The node is a leaf and has no children.
                if (nodeToRemove.Parent == null)
                {
                    // The node is the root
                    this.root = null;
                }
                else
                {
                    this.RemoveLeaf(nodeToRemove);
                }
            }
            else
            {
                // The node has only one child.
                this.RemoveNodeWithOneChild(nodeToRemove);
            }
        }

        private void RemoveNodeWithOneChild(OrderedSetNode<T> nodeToRemove)
        {
            OrderedSetNode<T> childOfNodeToRemove = nodeToRemove.LeftChild ?? nodeToRemove.RightChild;
            childOfNodeToRemove.Parent = nodeToRemove.Parent;

            if (childOfNodeToRemove.Parent == null)
            {
                this.root = childOfNodeToRemove;
            }
            else
            {
                if (nodeToRemove.Parent.RightChild != null &&
                    nodeToRemove.Parent.RightChild.Equals(nodeToRemove))
                {
                    nodeToRemove.Parent.RightChild = childOfNodeToRemove;
                }
                else
                {
                    nodeToRemove.Parent.LeftChild = childOfNodeToRemove;
                }
            }
        }

        private void RemoveLeaf(OrderedSetNode<T> nodeToRemove)
        {
            if (nodeToRemove.Parent.LeftChild != null &&
                nodeToRemove.Parent.LeftChild.Equals(nodeToRemove))
            {
                nodeToRemove.Parent.LeftChild = null;
            }
            else
            {
                nodeToRemove.Parent.RightChild = null;
            }
        }

        private OrderedSetNode<T> GetBiggestNodeInLeftSubtree(OrderedSetNode<T> currentNode)
        {
            OrderedSetNode<T> biggestNodeInLeftSubtree = null;
            if (currentNode.RightChild == null)
            {
                return currentNode;
            }

            biggestNodeInLeftSubtree = this.GetBiggestNodeInLeftSubtree(currentNode.RightChild);
            return biggestNodeInLeftSubtree;
        }

        private OrderedSetNode<T> Find(T valueToFind, OrderedSetNode<T> currentNode)
        {
            var searchNode = currentNode;
            if (currentNode == null)
            {
                return null;
            }

            int compareIndex = valueToFind.CompareTo(currentNode.Value);
            if (compareIndex < 0)
            {
                searchNode = this.Find(valueToFind, currentNode.LeftChild);
            }
            else if (compareIndex > 0)
            {
                searchNode = this.Find(valueToFind, currentNode.RightChild);
            }

            return searchNode;
        }

        private OrderedSetNode<T> Insert(T value, OrderedSetNode<T> currentNode, OrderedSetNode<T> parentNode)
        {
            if (currentNode == null)
            {
                currentNode = new OrderedSetNode<T>(value);
                currentNode.Parent = parentNode;
            }
            else
            {
                int compareIndex = value.CompareTo(currentNode.Value);
                if (compareIndex < 0)
                {
                    currentNode.LeftChild = this.Insert(value, currentNode.LeftChild, currentNode);
                }
                else if (compareIndex > 0)
                {
                    currentNode.RightChild = this.Insert(value, currentNode.RightChild, currentNode);
                }
            }

            return currentNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}