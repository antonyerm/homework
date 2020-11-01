// Task 6
// Write a function that returns the sum of two big numbers. The input numbers are strings and the function must return a string.

namespace NET03_01_06
{
    using System;

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
            Console.WriteLine("Homework NET03. Task 01-06. Sum of two big numbers as strings.\n");

            var input = new string[,]
            {
                { "123", "456" },
                { "2394934", "34545567" },
                { "10000", "56" },
                { "974658395", "24495940697" }
            };

            var processing = new MathOperations();

            for (int i = 0; i <= input.GetUpperBound(0); i++)
            {
                var result = processing.Sum(input[i,0], input[i,1]);
                Console.WriteLine($"{input[i,0],30} +\n{input[i,1],30}\n{new String('-', 30)}\n{result,30}\n");
            }
        }
    }
}
