// Task 1
// Implement a BinarySearch generic method (*do not use the type constraints*). Develop unit-tests.

namespace NET03_03_1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, 03 Task. Problem 1. Generic Binary Search method.\n");

            // var myCollection = new int[] { 6, 3, 15, 10 };
            var myCollection = new string[] { "bc", "abc", "klm", "fgh" };
            var target = "fgh";
            var collectionOperations = new CollectionOperations();
            var foundPosition = collectionOperations.BinarySearch<string>(myCollection, target);

            var message = "";
            if (foundPosition == -1)
            {
                message = "Not found";
            }
            else
            {
                message = $"It was found at {foundPosition} of sorted list.";
            }

            Console.Write("Given the input list of: ");
            foreach (var item in myCollection)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine($"I searched for {target}. The result is:");
            Console.WriteLine(message);
        }
    }
}
