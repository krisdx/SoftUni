namespace BinaryTree
{
    using System;

    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Root { get; private set; }

        /// <summary>
        /// Inserts a value in the binary search tree
        /// </summary>
        /// <param name="value">The value to be inserted</param>
        public void Insert(T value)
        {
            this.Root = this.Insert(value, this.Root, null);
        }

        /// <summary>
        /// Finds a value in the binary search tree.
        /// </summary>
        /// <param name="value">The value to search for</param>
        /// <returns>Returns a binary tree node if the element is found. Returns null if the element does not exists</returns>
        public BinaryTreeNode<T> Find(T value)
        {
            var searchNode = this.Find(value, this.Root);
            return searchNode;
        }

        /// <summary>
        /// Removes an element from the binary search tree. The tree stays sorted after the removal.
        /// </summary>
        /// <param name="value">The value to be removed</param>
        /// <returns>Returns true if the element was removed successful. Returns false if the element does not exists</returns>
        public bool Remove(T value)
        {
            var nodeToRemove = this.Find(value);
            if (nodeToRemove == null)
            {
                // The node to remove does not exists.
                return false;
            }

            this.Remove(nodeToRemove);
            return true;
        }

        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> currentNode, BinaryTreeNode<T> parentNode)
        {
            if (currentNode == null)
            {
                currentNode = new BinaryTreeNode<T>(value);
                currentNode.Parent = parentNode;
            }
            else
            {
                int compareIndex = value.CompareTo(currentNode.Value);
                if (compareIndex < 0)
                {
                    currentNode.LeftChild = this.Insert(value, currentNode.LeftChild, currentNode);
                }
                else if (compareIndex >= 0)
                {
                    currentNode.RightChild = this.Insert(value, currentNode.RightChild, currentNode);
                }
            }

            return currentNode;
        }

        private BinaryTreeNode<T> Find(T value, BinaryTreeNode<T> currentNode)
        {
            BinaryTreeNode<T> searchNode = currentNode;
            if (currentNode == null)
            {
                // The element we're searching for does not exist.
                return null;
            }

            int compareIndex = value.CompareTo(currentNode.Value);
            if (compareIndex < 0)
            {
                // The element we're searching for has to be in the left subtree.
                searchNode = this.Find(value, currentNode.LeftChild);
            }
            else if (compareIndex > 0)
            {
                // The element we're searching for has to be in the right subtree.
                searchNode = this.Find(value, currentNode.RightChild);
            }

            return searchNode;
        }

        private void Remove(BinaryTreeNode<T> nodeToRemove)
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
                    this.Root = null;
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

        private BinaryTreeNode<T> GetBiggestNodeInLeftSubtree(BinaryTreeNode<T> currentNode)
        {
            BinaryTreeNode<T> biggestNodeInLeftSubtree = null;
            if (currentNode.RightChild == null)
            {
                return currentNode;
            }

            biggestNodeInLeftSubtree = this.GetBiggestNodeInLeftSubtree(currentNode.RightChild);
            return biggestNodeInLeftSubtree;
        }

        private void RemoveNodeWithOneChild(BinaryTreeNode<T> nodeToRemove)
        {
            BinaryTreeNode<T> childOfNodeToRemove = nodeToRemove.LeftChild ?? nodeToRemove.RightChild;
            childOfNodeToRemove.Parent = nodeToRemove.Parent;

            if (childOfNodeToRemove.Parent == null)
            {
                this.Root = childOfNodeToRemove;
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

        private void RemoveLeaf(BinaryTreeNode<T> nodeToRemove)
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
    }
}