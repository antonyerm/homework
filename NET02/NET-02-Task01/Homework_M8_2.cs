namespace Homework_M8_2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Homework_M8_2
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET-01 Module 8.2. Matrix sorting.\n");

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
