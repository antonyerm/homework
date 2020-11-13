// Task 4
// Develop a generic class-collection Queue that implements the basic operations for working with the structure data queue. 
// Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.

using System;
using System.Collections;
using System.Collections.Generic;

namespace NET03_03_4_Queue
{
    internal class MyQueue<T> : IMyQueue<T>, IEnumerable<T>
    {
        private List<T> list = new List<T>();

        public int Count => list.Count;

        public T Dequeue()
        {
            if (list.Count > 0)
            {
                var deletedItem = list[0];
                list.RemoveAt(0);
                return deletedItem;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No items left in the queue.");
            }

        }

        public void Enqueue(T obj)
        {
            list.Add(obj);
        }

        public T Peek()
        {
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException("No items left in the queue.");
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        MyQueueEnumerator<T> GetEnumerator()
        {
            return new MyQueueEnumerator<T>(list);
        }
    }
}