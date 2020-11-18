// Task 7
// Develop a generic class-collection BinarySearchTree that implements the basic operations for working with the structure data 
// binary search tree. Provide an opportunity of using a plug-in interface to implement the order relation. 
// Implement three ways of traversing the tree: direct(preorder), transverse(inorder), reverse(postorder)
// (use the block iterator yield).Develop unit - tests.Use for the testing the following types:
//
// -System.String(use default comparison and plug -in comparator);
// -the custom class Book, for objects of which the order relation is implemented(use the default comparison and plug -in comparator);
// -the custom structure Point, for instance of which the relation of order is not implemented (use a plug-in comparator).

namespace NET03_03_7_BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Class for binary search tree basic operations.
    /// </summary>
    /// <typeparam name="T">Type of value of a node.</typeparam>
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// Root of the tree.
        /// </summary>
        public BinaryTreeNode<T> Root;

        /// <summary>
        /// Order of traversal.
        /// </summary>
        public TraversalOrder TraversalOrder { get; set; }

        /// <summary>
        /// Number of items.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Collection of values in the tree.
        /// </summary>
        public IEnumerable<BinaryTreeNode<T>> Values
        {
            get
            {
                return Traverse(Root);
            }
        }

        public Comparer<T> myComparer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="order">Order of traversal.</param>
        public BinarySearchTree(TraversalOrder order = TraversalOrder.PreOrder, Comparison<T> customComparison = null)
        {
            this.TraversalOrder = order;

            Comparison<T> myComparison;
            if (customComparison is null)
            {
                myComparison = GetStandardComparison;
            }
            else
            {
                myComparison = customComparison;
            }
            
            this.myComparer = Comparer<T>.Create(myComparison);
        }

        public int GetStandardComparison(T x, T y)
        {
            var xAsComparable = x as IComparable<T>;
            if (xAsComparable is null)
            {
                // the type does not implement IComparable
                throw new Exception("The type of tree items should either implement IComparable or you should provide Comparison<T> delegate.");
            } else 
            {
                // use IComparable standard comparator 
                return Comparer<T>.Default.Compare(x, y);
            }
        }

        /// <summary>
        /// Implements traversal for foreach statement in 3 variants.
        /// </summary>
        /// <param name="startingNode">Root of subtree.</param>
        /// <returns>Collection (lazy evaluated).</returns>
        public IEnumerable<BinaryTreeNode<T>> Traverse(BinaryTreeNode<T> startingNode)
        {
            switch (this.TraversalOrder)
            {
                case TraversalOrder.PreOrder:
                    if (startingNode is null)
                        yield break;
                    yield return startingNode;
                    if (! (startingNode.Left is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Left))
                        {
                            yield return node;
                        }
                    }

                    if (! (startingNode.Right is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Right))
                        {
                            yield return node;
                        }
                    }

                    break;
                case TraversalOrder.InOrder:
                    if (startingNode is null)
                        yield break;
                    if (! (startingNode.Left is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Left))
                        {
                            yield return node;
                        }
                    }

                    yield return startingNode;

                    if (! (startingNode.Right is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Right))
                        {
                            yield return node;
                        }
                    }

                    break;
                case TraversalOrder.PostOrder:
                    if (startingNode is null)
                        yield break;
                    if (! (startingNode.Left is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Left))
                        {
                            yield return node;
                        }
                    }

                    if (! (startingNode.Right is null))
                    {
                        foreach (BinaryTreeNode<T> node in Traverse(startingNode.Right))
                        {
                            yield return node;
                        }
                    }

                    yield return startingNode;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Checks if item (node) is in the tree.
        /// </summary>
        /// <param name="key">Item (node) to be checked.</param>
        /// <returns>True if the tree contains the item. False otherwise.</returns>
        public bool Contains(BinaryTreeNode<T> key)
        {
            var currentNode = this.Root;
            while (! (currentNode is null))
            {
                var comparison = myComparer.Compare(currentNode.Data, key.Data);
                if (comparison == 0)
                {
                    return true;
                }

                if (comparison < 0)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode = currentNode.Left;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the value (as opposed to a node) is contained in the tree.
        /// </summary>
        /// <param name="keyData">Value of some node to be checked.</param>
        /// <returns>True if the tree contains the item with the specified value. False otherwise.</returns>
        public bool Contains(T keyData)
        {
            var node = new BinaryTreeNode<T>();
            node.Data = keyData;
            return Contains(node);
        }

        /// <summary>
        /// Adds node with specified value to the tree.
        /// </summary>
        /// <param name="keyData">The value to be added.</param>
        public void Add(T keyData)
        {
            var parent = GetParentForNewNode(keyData);
            var node = new BinaryTreeNode<T>
            {
                Data = keyData,
                Parent = parent,
            };
            if (parent is null)
            {
                this.Root = node;
            }
            else
            if (myComparer.Compare(keyData, parent.Data) > 0)
            {
                parent.Right = node;
            }
            else
            {
                parent.Left = node;
            }

            this.Count++;
        }

        /// <summary>
        /// Helper for <see cref="Add"/> method. Searched for a suitable parent for specified value.
        /// </summary>
        /// <param name="keyData">Value to be added as a node.</param>
        /// <returns>Node which is good as parent node for the value.</returns>
        public BinaryTreeNode<T> GetParentForNewNode(T keyData)
        {
            var current = this.Root;
            BinaryTreeNode<T> parent = null;
            while (! (current is null))
            {
                parent = current;
                int result = myComparer.Compare(keyData, parent.Data);
                if (result == 0)
                {
                    throw new Exception($"Node with value {keyData} already exists in the tree.");
                }

                if (result < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return parent;
        }

        /// <summary>
        /// Removes the node with specified value.
        /// </summary>
        /// <param name="keyData">Specified value.</param>
        public void Remove(T keyData)
        {
            Remove(this.Root, keyData);
        }

        /// <summary>
        /// Removes the node with specified value.
        /// </summary>
        /// <param name="node">Root of subtree.</param>
        /// <param name="keyData">Value to find and delete.</param>
        public void Remove(BinaryTreeNode<T> node, T keyData)
        {
            if (node is null)
            {
                throw new ArgumentException($"The node {keyData} does not exist.");
            }
            else
            if (myComparer.Compare(keyData, node.Data) < 0)
            {
                Remove(node.Left, keyData);
            }
            else
            if (myComparer.Compare(keyData, node.Data) > 0)
            {
                Remove(node.Right, keyData);
            }
            else
            // here we already found the node to delete
            // and try to delete node with either no children or one child
            {
                if (node.Left is null && node.Right is null)
                {
                    ReplaceInParent(node, null);
                    this.Count--;
                }
                else
                if (node.Left is null)
                {
                    ReplaceInParent(node, node.Right);
                    this.Count--;
                }
                else
                if (node.Right is null)
                {
                    ReplaceInParent(node, node.Left);
                    this.Count--;
                }
                else
                // we try to delete a node with both left and right children
                {
                    var successor = FindMinimumInSubtree(node.Right);
                    node.Data = successor.Data;
                    Remove(successor, successor.Data);
                }
            }
        }

        /// <summary>
        /// Substitutes reference of children in parent of the specified node for
        /// a new node. Thus old node becomes separated and dies (is removed).
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        private void ReplaceInParent(BinaryTreeNode<T> node, BinaryTreeNode<T> newNode)
        {
            if (! (node.Parent is null))
            {
                if (node.Parent.Left == node)
                {
                    node.Parent.Left = newNode;
                }
                else
                {
                    node.Parent.Right = newNode;
                }
            }
            else
            {
                this.Root = newNode;
            }

            // we are deleting not a leaf (the new node exists as a child)
            if (! (newNode is null))
            {
                newNode.Parent = node.Parent;
            }
        }

        /// <summary>
        /// Finds a node which will take place of deleted node, effectively is the minimal
        /// node from the right subtree (i.e. lowest among the bigger ones).
        /// </summary>
        /// <param name="node">Root of subtree.</param>
        /// <returns>The node which has minimal value among the right subtree nodes.</returns>
        private BinaryTreeNode<T> FindMinimumInSubtree(BinaryTreeNode<T> node)
        {
            while (! (node is null))
            {
                node = node.Left;
            }
            return node;
        }
    }
}