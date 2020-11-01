namespace Homework_M7_6
{
    using System;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    class Homework_M7_6
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework Module 7. Basic coding. Task 6. Filter digit in an int array.\n");

            var arrayOperations = new ArrayOperations();
            arrayOperations.GenerateArray();

            Console.WriteLine("The input array is:");
            arrayOperations.ShowArray();

            Console.WriteLine("\nPlease enter the filter value (0..9): ");
            int filterValue;
            int.TryParse(Console.ReadLine(), out filterValue);
            arrayOperations.FilterDigit(filterValue);

            Console.WriteLine("The filtered array is:");
            arrayOperations.ShowArray();
        }
    }
}
