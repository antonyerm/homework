namespace Homework_M7_5
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    class Homework_M7_5
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            int sourceNumber;
            var manipulations = new ManipulationsWithNumbers();
            int nextBiggerNumber;

            Console.WriteLine("Homework Module 7. Basic coding. Task 5. Find next bigger number.\n");
            Console.WriteLine("Please enter the source number: ");
            int.TryParse(Console.ReadLine(), out sourceNumber);
            sourceNumber = Math.Abs(sourceNumber);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            nextBiggerNumber = manipulations.NextBiggerNumber(sourceNumber);
            stopWatch.Stop();

            if (nextBiggerNumber == -1)
                Console.WriteLine("There is now next big number for your entry. Sorry.");
            else
                Console.WriteLine("The next bigger number built with the digits of the source number is \n{0}", nextBiggerNumber);
            Console.WriteLine("Elapsed time: {0}", stopWatch.Elapsed);
        }
    }
}
