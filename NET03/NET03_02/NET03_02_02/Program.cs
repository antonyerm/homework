//Objective:
//understand delegate usage scenarios;
//understand the relationship delegates versus interfaces;
//understand callback functions;
//study design pattern Observer;
//understand difference between events and delegates;
//understand DRY(Don’t Repeat Yourself), SoC(Separation of Concerns principles), Low Coupling principles;
//write agile extensible testable code;
//understand standard event delegate pattern.
// Add to the class (Izh - 05.Creating types in C#) new methods with custom delegate, allowing to sorting both in 
// ascending and descending, depending on comparison criterion of the matrix rows. Develop unit-tests using various 
// comparison criterion of the matrix rows. 

namespace NET03_02_01
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
            Console.WriteLine("Homework NET03, 02 Task. Problem 2. Matrix sorting with delegates.\n");

            // Generate the source array
            var array = new int[3, 3];
            var rnd = new Random();
            var drawer = new Drawer();

            // fill the array
            for (int y = 0; y <= array.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= array.GetUpperBound(1); x++)
                {
                    array[y, x] = rnd.Next(0, 100);
                }
            }

            Console.WriteLine("The original matrix:");
            drawer.DrawMatrix(array);

            var sortObject = new Sort();

            // Perform all kinds of sorting
            foreach (var sortBy in Enum.GetValues(typeof(SortCriteria)))
            {
                var sortedArray = sortObject.SortMatrix(array, (SortCriteria)sortBy);
                Console.WriteLine("Type of sorting: {0}. The sorted matrix:",
                    Enum.GetName(typeof(SortCriteria), sortBy));
                drawer.DrawMatrix(sortedArray);
            }
        }
    }
}
