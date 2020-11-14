using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_03_6_Set
{
    interface IMySet<T>
    {
        bool Add(T item);
        bool Remove(T item);

        int Count { get; }

        T this[int index]
        {
            get;
        }
    }
}
