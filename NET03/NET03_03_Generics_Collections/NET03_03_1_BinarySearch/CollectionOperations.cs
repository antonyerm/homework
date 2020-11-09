// Task 1
// Implement a BinarySearch generic method (*do not use the type constraints*). Develop unit-tests.

using System;
using System.Collections.Generic;
using System.Linq;

namespace NET03_03_1
{
    public class CollectionOperations
    {
        public int BinarySearch<T>(ICollection<T> collection, T target)
        {
            var targetAsComparable = target as IComparable<T>;
            if (targetAsComparable == null)
            {
                throw new Exception("The types in the collection do not support comparing (are not IComparable).");
            }

            var internalCollection = new List<T>(collection);
            internalCollection = internalCollection.OrderBy(x => x).ToList();
            int left = 0;
            int right = internalCollection.Count - 1;
            
            while (left <= right)
            {
                var middle = left + (right - left) / 2;
                var compareResult = targetAsComparable.CompareTo(internalCollection[middle]);
                if (compareResult < 0)
                {
                    right = middle - 1;
                }
                else
                    if (compareResult > 0)
                    {
                        left = middle + 1;
                    }
                    else
                        if (compareResult == 0)
                        {
                            return middle;
                        }
            }
            return -1;
        }
    }
}