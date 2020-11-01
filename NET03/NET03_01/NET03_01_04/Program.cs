//Task 4
// Implement the function UniqueInOrder which takes as argument a sequence and returns a list of items without any elements
// with the same value next to each other and preserving the original order of elements. 
// For example (Note that you can return any data structure you want, as long it inherits the IEnumerable interface.)
//   -UniqueInOrder("AAAABBBCCDAABBB")                     => "ABCDAB"
//  - UniqueInOrder("ABBCcAD")                             => "ABCcAD"
//  - UniqueInOrder("12233")                               => "123"
//  - UniqueInOrder(new List<double> { 1.1, 2.2, 2.2, 3.3 }) => new List<double> { 1.1, 2.2, 3.3 }

namespace NET03_01_04
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03. Task 01-04. Remove repeating adjacent elements from collection.");
            var input = new IEnumerable[]
            {
                "AAAABBBCCDAABBB",
                "ABBCcAD",
                "12233",
                new List<double> { 1.1, 2.2, 2.2, 3.3 },
            };

            var processing = new CollectionsOperations();

            //var result = processing.UniqueInOrder("AAAABBBCCDAABBB");
            //Console.WriteLine($"{"AAAABBBCCDAABBB"}   =>  {result.AsString()}");
            //result = processing.UniqueInOrder("ABBCcAD");
            //Console.WriteLine($"{"ABBCcAD"}   =>  {result.AsString()}");
            //result = processing.UniqueInOrder("12233");
            //Console.WriteLine($"{"12233"}   =>  {result.AsString()}");
            //result = processing.UniqueInOrder(new List<double> { 1.1, 2.2, 2.2, 3.3 });
            //Console.WriteLine($"{new List<double> { 1.1, 2.2, 2.2, 3.3 }.AsString()}   =>  {result.AsString()}");

            foreach (var collection in input)
            {
                var result = processing.UniqueInOrder(collection);
                Console.WriteLine($"{collection.AsString()}   =>  {result.AsString()}");
            }
            
        }
    }
}

// need to find way of working with Generics