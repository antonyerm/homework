// Task 3
// Implement a method for the counting of the Fibonacci's numbers of the Fibonacci using the iterator block yield. Develop unit-tests.



namespace NET03_03_3_Fibonacci_iterator
{
    using Microsoft.VisualBasic.CompilerServices;
    using System.Collections;
    using System.Collections.Generic;

    internal class Fibonacci : IEnumerable<int>
    {
       
        private FibonacciEnumerator GetEnumerator()
        {
            return new FibonacciEnumerator();
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class FibonacciEnumerator : IEnumerator<int>
    {
        //private int position = 0;
        private int previous = 0;
        private int beforePrevious = 1;
        private int current = 0;

        int IEnumerator<int>.Current => Current();

        object IEnumerator.Current => (this as IEnumerator<int>).Current;

        public int Current()
        {
            this.current = previous + beforePrevious;
            return current;
        }

        public bool MoveNext()
        {
            //this.position++;
            this.beforePrevious = this.previous;
            this.previous = this.current;
            return true;
        }

        public void Reset()
        {
            //this.position = 0;
            this.previous = 1;
            this.beforePrevious = 0;
        }

        public void Dispose()
        {
        }
    }
}