//Objective:
//understand delegate usage scenarios;
//understand the relationship delegates versus interfaces;
//understand callback functions;
//study design pattern Observer;
//understand difference between events and delegates;
//understand DRY(Don’t Repeat Yourself), SoC(Separation of Concerns principles), Low Coupling principles;
//write agile extensible testable code;
//understand standard event delegate pattern.

// Task 1
// Refactor of class methods (Izh - 06.Methods in details) using delegates (the API 's of the class should not change). 

namespace NET03_02_01
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, 02 Task. Problem 1. Matrix sorting with delegates.\n");

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
