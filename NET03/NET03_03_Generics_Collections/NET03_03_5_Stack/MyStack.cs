namespace NET03_03_5_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    internal class MyStack<T> : IMyStack<T>, IEnumerable<T>
    {
        private List<T> list = new List<T>();

        public int Count => list.Count;

        public T Pop()
        {
            if (list.Count > 0)
            {
                var deletedItem = this.list[this.list.Count - 1];
                this.list.RemoveAt(this.list.Count - 1);
                return deletedItem;
            }
            else
            {
                throw new ArgumentOutOfRangeException("No items left in the stack.");
            }

        }

        public void Push(T obj)
        {
            this.list.Add(obj);
        }

        public T Peek()
        {
            if (this.list.Count > 0)
            {
                return this.list[this.list.Count - 1];
            }
            else
            {
                throw new ArgumentOutOfRangeException("No items left in the stack.");
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

        MyStackEnumerator<T> GetEnumerator()
        {
            return new MyStackEnumerator<T>(list);
        }
    }
}