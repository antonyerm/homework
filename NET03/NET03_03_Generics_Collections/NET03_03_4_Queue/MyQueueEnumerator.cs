// Task 4
// Develop a generic class-collection Queue that implements the basic operations for working with the structure data queue. 
// Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.

using System.Collections;
using System.Collections.Generic;

namespace NET03_03_4_Queue
{
    internal class MyQueueEnumerator<T> : IEnumerator<T>
    {
        private List<T> list;
        private int position;

        public MyQueueEnumerator(List<T> list)
        {
            this.list = list;
            this.position = -1;
        }

        public T Current => this.list[position];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            position++;
            return (position > this.list.Count - 1) ? false : true;
        }

        public void Reset()
        {
            //position = -1;
        }

        public void Dispose()
        {
        }
    }
}