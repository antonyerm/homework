//Task 4
// Implement the function UniqueInOrder which takes as argument a sequence and returns a list of items without any elements
// with the same value next to each other and preserving the original order of elements. 
// For example (Note that you can return any data structure you want, as long it inherits the IEnumerable interface.)
//   -UniqueInOrder("AAAABBBCCDAABBB")                     => "ABCDAB"
//  - UniqueInOrder("ABBCcAD")                             => "ABCcAD"
//  - UniqueInOrder("12233")                               => "123"
//  - UniqueInOrder(new List<double> { 1.1, 2.2, 2.2, 3.3 }) => new List<double> { 1.1, 2.2, 3.3 }

namespace NET03_01_04
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Contains methods for modification of IEnumerable collections.
    /// </summary>
    internal class CollectionsOperations
    {
        ///// <summary>
        ///// Creates new list of non-repeating items from input collection.
        ///// </summary>
        ///// <typeparam name="T">Type of collection item.</typeparam>
        ///// <param name="original">Input collection.</param>
        ///// <returns>New List of filtered items.</returns>
        //internal IEnumerable UniqueInOrder<T>(IEnumerable<T> original) where T : new()
        //{
        //    T previous = new T(); 
        //    var result = new List<T>();

        //    foreach (var item in original)
        //    {
        //        if (!previous.Equals(item) || (result.Count == 0))
        //        {
        //            result.Add(item);
        //        }

        //        previous = item;
        //    }

        //    return result;
        //}

        /// <summary>
        /// Creates new list of non-repeating items from input collection.
        /// </summary>
        /// <param name="original">Input collection.</param>
        /// <returns>New List of filtered items.</returns>
        internal IEnumerable UniqueInOrder(IEnumerable original) 
        {
            object previous = null;
            var result = new List<object>();

            foreach (var item in original)
            {
                // if "previous" is null it is substituted by "item". item.Equals(item) = true, so condition says "skip this if".
                if (!((previous?? item).Equals(item)) || (result.Count == 0))
                {
                    result.Add(item);
                }

                previous = item;
            }

            return result;
        }
    }
}