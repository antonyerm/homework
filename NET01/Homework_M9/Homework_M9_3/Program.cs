namespace Homework_M9_3
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
            Console.WriteLine("Homework NET-01 Module 9. Task 3. Nullable types' check for null value.\n");

            string x = "6";
            int? y = 6;

            Console.WriteLine("Examples:");
            Console.WriteLine(nameof(y) + " is null. This is " + y.IsNull());
            Console.WriteLine(nameof(x) + " is null. This is " + x.IsNull());
            
        }
    }
}
