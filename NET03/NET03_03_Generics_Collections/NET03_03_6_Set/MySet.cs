namespace NET03_03_6_Set
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    internal class MySet<T> : IMySet<T>, IEnumerable<T> where T : class
    {
        private List<T> list = new List<T>();

        public int Count => this.list.Count;

        public T this[int index] => this.list[index];

        public bool Remove(T item) => this.list.Remove(item);

        public bool Add(T item)
        {
            if (!list.Contains(item))
            {
                this.list.Add(item);
                return true;
            }

            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        MySetEnumerator<T> GetEnumerator()
        {
            return new MySetEnumerator<T>(this.list);
        }
    }
}