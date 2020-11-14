using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_03_5_Stack
{
    interface IMyStack<T>
    {
        void Push(T obj);
        T Pop();

        T Peek();

        int Count { get; }
    }
}
