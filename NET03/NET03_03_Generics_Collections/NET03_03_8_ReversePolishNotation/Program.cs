// Task 8
// Create a calculator which evaluates expressions in Reverse Polish notation. For example, expression 5 1 2 + 4 * + 3 - 
// (which is equivalent to 5 + ((1 + 2) *4) -3 in normal notation) should evaluate to 14. Note, that for simplicity you may assume 
// that there are always spaces between numbers and operations, e.g. 1 3 + expression is valid, but 1 3+ isn't. Empty expression 
// should evaluate to 0. Valid operations are +, -, *, /.

namespace NET03_03_8_ReversePolishNotation
{
    using System;

    /// <summary>
    /// Entry class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 8. Reverse Polish Notation Calculator.\n");
            Console.WriteLine("Please enter expression in Reverse Polish Notation:\n");
            var expression = Console.ReadLine();

            var calculator = new Calculator();
            Console.WriteLine(calculator.Calculate(expression));
        }
    }
}
