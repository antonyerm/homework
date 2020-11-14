// Task 4
// Develop a generic class-collection Queue that implements the basic operations for working with the structure data queue. 
// Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.

namespace NET03_03_4_Queue
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 4. Generic Queue.\n");
            var myQueue = new MyQueue<string>();
            var inputValues = new string[] { "This", "is", "an", "example" };

            Console.WriteLine("Enqueue some values:");
            foreach (var inputObject in inputValues)
            {
                myQueue.Enqueue(inputObject);
                PrintMyQueueWithForeach(myQueue);
                Console.WriteLine();
            }

            Console.WriteLine("Collection traverse using indexer:");
            for (int i = 0; i < myQueue.Count; i++)
            {
                Console.Write(myQueue[i] + " ");
            }
            Console.WriteLine("\n");

            Console.WriteLine("Dequeue one by one:");
            while (myQueue.Count > 0)
            {
                PrintMyQueueWithForeach(myQueue);
                myQueue.Dequeue();
                Console.WriteLine();
            }
        }

        private static void PrintMyQueueWithForeach<T>(MyQueue<T> collection)
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
