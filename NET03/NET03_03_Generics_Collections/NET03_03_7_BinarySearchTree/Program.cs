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

    /// <summary>
    /// Entry class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 7. Binary Search Tree.\n");
            

            // test with integers
            var myBinarySearchTree = new BinarySearchTree<int>(TraversalOrder.PostOrder);
            var values = new int[] { 100, 34, 50, 49, 80, 40, 150, 81 };
            foreach (var value in values)
            {
                myBinarySearchTree.Add(value);
            }

            var printout = new Visualization();
            printout.VisualizeTree<int>(myBinarySearchTree);
            Console.WriteLine("Count: " + myBinarySearchTree.Count);


            // test with Books
            var booksBinarySearchTree = new BinarySearchTree<Book>();
            var bookWarAndPeace = new Book
            {
                Name = "War and Peace",
                Pages = 1350,
            };
            booksBinarySearchTree.Add(bookWarAndPeace);
            printout.VisualizeTree<Book>(booksBinarySearchTree);

            var book2 = new Book
            {
                Name = "War and Peace",
                Pages = 1350,
            };
            booksBinarySearchTree.Remove(book2);
            printout.VisualizeTree<Book>(booksBinarySearchTree);


            // test with strings (default comparator)
            var myStringBinarySearchTree = new BinarySearchTree<string>(TraversalOrder.InOrder, StringComparer.Ordinal.Compare);
            var stringValues = "We are the champions my friend".Split();
            foreach (var str in stringValues)
            {
                myStringBinarySearchTree.Add(str);
            }

            printout.VisualizeTree<string>(myStringBinarySearchTree);
            Console.WriteLine("Count: " + myBinarySearchTree.Count);


            // test with strings (plug-in string comparator)
            myStringBinarySearchTree = new BinarySearchTree<string>(TraversalOrder.PostOrder, StringComparer.OrdinalIgnoreCase.Compare);
            stringValues = "We are the champions my friend".Split();
            foreach (var str in stringValues)
            {
                myStringBinarySearchTree.Add(str);
            }

            printout.VisualizeTree<string>(myStringBinarySearchTree);
            Console.WriteLine("Count: " + myBinarySearchTree.Count);

        }

    }
} 
