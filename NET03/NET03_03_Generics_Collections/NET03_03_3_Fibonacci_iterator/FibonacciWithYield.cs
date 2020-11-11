namespace NET03_03_3_Fibonacci_iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO.IsolatedStorage;
    using System.Text;

    public class FibonacciWithYield : IEnumerable<int>
    {
        private int current = 0;
        private int previous = 0;
        private int beforePrevious = 1;
        private int howManyNumbers;

        public FibonacciWithYield(int howManyNumbers)
        {
            this.howManyNumbers= howManyNumbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int counter = 0; counter < howManyNumbers; counter++)
            {
                current = previous + beforePrevious;
                beforePrevious = previous;
                previous = current;
                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
