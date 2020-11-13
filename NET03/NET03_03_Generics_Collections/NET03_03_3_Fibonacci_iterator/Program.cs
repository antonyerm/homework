// Task 3
// Implement a method for the counting of the Fibonacci's numbers of the Fibonacci using the iterator block yield. Develop unit-tests.

namespace NET03_03_3_Fibonacci_iterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 3. Fibonacci using the iterator.\n");

            var fibonacciNumbers = new Fibonacci();
            var fibonacciEnumerator = (fibonacciNumbers as IEnumerable<int>).GetEnumerator();
            for (int i = 1; i <= 15; i++)
            {
                Console.Write($"{fibonacciEnumerator.Current}, ");
                fibonacciEnumerator.MoveNext();
            }

            Console.WriteLine();
            var fibonacciNumbersWithYield = new FibonacciWithYield(7);
            foreach (var item in fibonacciNumbersWithYield)
            {
                Console.Write($"\"{item}\", ");
            }



        }
    }
}
