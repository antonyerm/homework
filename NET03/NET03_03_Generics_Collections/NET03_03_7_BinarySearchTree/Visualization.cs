namespace NET03_03_7_BinarySearchTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains methods for printing the tree on the screen.
    /// </summary>
    class Visualization
    {
        /// <summary>
        /// Prints the tree as a collection of nodes' values and their children.
        /// </summary>
        /// <typeparam name="T">Type of value stored in nodes of a tree.</typeparam>
        /// <param name="tree">Tree to visualize.</param>
        public void VisualizeTree<T>(BinarySearchTree<T> tree)
        {
            VisualizeSubtree<T>(tree.Root);
        }

        private void VisualizeSubtree<T>(BinaryTreeNode<T> root)
        {
            if (! (root is null))
            {
                Console.WriteLine($"{root} -> ({root.Left},{root.Right})");
                VisualizeSubtree(root.Left);
                VisualizeSubtree(root.Right);
            }
            else
            {
                return;
            }
            
        }
    }
}
