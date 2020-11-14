// Task 6
// 6.Develop a generic class-collection Set that implements the basic operations for working with the structure data set 
// with the reference types elements. Implement the capability to iterate by collection by block iterator yield. Develop unit-tests.

using System;

namespace NET03_03_6_Set
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 6. Generic Set.\n");
            var mySet = new MySet<string>();
            var inputValues = new string[] { "This", "is", "an", "example", "This", "example" };

            Console.WriteLine("Add some values:");
            foreach (var inputObject in inputValues)
            {
                Console.WriteLine($"Adding {inputObject}....");
                mySet.Add(inputObject);
                PrintMySetWithForeach(mySet);
                Console.WriteLine();
            }

            Console.WriteLine("Remove one by one:");
            foreach (var inputObject in inputValues)
            {
                Console.WriteLine($"Removing {inputObject}....");
                mySet.Remove(inputObject);
                PrintMySetWithForeach(mySet);
                Console.WriteLine();
            }
        }

        private static void PrintMySetWithForeach<T>(MySet<T> collection) where T: class
        {
            Console.Write("Current set: ");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
        }


    }
}
