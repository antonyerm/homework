using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_03_4_Queue
{
    interface IMyQueue<T>
    {
        void Enqueue(T obj);
        T Dequeue();

        T Peek();

        int Count { get; }

        T this[int index] { get; }
    }
}
