// Task 7
// Develop a generic class-collection BinarySearchTree that implements the basic operations for working with the structure data 
// binary search tree. Provide an opportunity of using a plug-in interface to implement the order relation. 
// Implement three ways of traversing the tree: direct(preorder), transverse(inorder), reverse(postorder)
// (use the block iterator yield).Develop unit - tests.Use for the testing the following types:
//
// -System.String(use default comparison and plug -in comparator);
// -the custom class Book, for objects of which the order relation is implemented(use the default comparison and plug -in comparator);
// -the custom structure Point, for instance of which the relation of order is not implemented (use a plug-in comparator).


using System.Collections.Generic;

namespace NET03_03_7_BinarySearchTree
{
    /// <summary>
    /// Contains definition of a node in the tree.
    /// </summary>
    /// <typeparam name="T">Type of value of a node.</typeparam>
    public class BinaryTreeNode<T>
    {
        /// <summary>
        /// Internal value of the node.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Node which is parent of the node.
        /// </summary>
        public BinaryTreeNode<T> Parent { get; set; }
        /// <summary>
        /// List of nodes which are children of the node.
        /// </summary>        
        public List<BinaryTreeNode<T>> Children { get; set; }
        /// <summary>
        /// The left child of the node. Has lower value than the node.
        /// </summary>
        public BinaryTreeNode<T> Left {
            get
            {
                if (this.Children is null)
                {
                    return null;
                }

                return this.Children[0];

            }
            set
            {
                this.Children[0] = value;
            } 
        }

        /// <summary>
        /// The right child of the node. Has bigger value than the node.
        /// </summary>
        public BinaryTreeNode<T> Right
        {
            get
            {
                if (this.Children is null)
                {
                    return null;
                }

                return this.Children[1];
            }
            set
            {
                this.Children[1] = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinaryTreeNode()
        {
            this.Children = new List<BinaryTreeNode<T>>()
            {
                null,
                null,
            };
        }
        
        /// <summary>
        /// Converts node's value to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Data.ToString();
        }
    }
}