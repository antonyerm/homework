namespace Homework_M7_2
{
    using System;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    public class Homework_M7_2
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            var searchObj = new Search(50);

            Console.WriteLine("Homework Module 7. Basic coding. Task 2. Recursive search for maximum.\n");
            Console.WriteLine("The input array is: \n");
            searchObj.ShowArray();
            Console.WriteLine("\nThe Max value is: " + searchObj.SearchForMax());
        }
    }
}
