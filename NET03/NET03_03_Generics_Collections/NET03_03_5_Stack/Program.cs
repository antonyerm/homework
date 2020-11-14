// Task 5
// Develop a generic class-collection Stack that implements the basic operations for working with the structure data stack. 
// Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.

using System;
using System.Collections.Generic;

namespace NET03_03_5_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 4. Generic Stack.\n");
            var myStack = new MyStack<string>();
            var inputValues = new string[] { "This", "is", "an", "example" };

            Console.WriteLine("Push some values:");
            foreach (var inputObject in inputValues)
            {
                myStack.Push(inputObject);
                PrintMyQueueWithForeach(myStack);
                Console.WriteLine();
            }

            Console.WriteLine("Pop one by one:");
            while (myStack.Count > 0)
            {
                PrintMyQueueWithForeach(myStack);
                myStack.Pop();
                Console.WriteLine();
            }
        }

        private static void PrintMyQueueWithForeach<T>(MyStack<T> collection)
        {
            Console.Write("Current queue: ");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nPeek         : {collection.Peek()}");
        }


    }
}
