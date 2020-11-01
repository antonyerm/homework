namespace Homework_M7_1
{
    using System;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    public class Homework_M7_1
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {
            int numberSource = 4096 + 1024 + 256 + 64 + 16 + 4 + 1;
            int numberIn = 128 + 64 + 1;
            int i = 8;
            int j = 15;

            int resultingNumber = Calculations.InsertNumber(numberSource, numberIn, i, j);
            Console.WriteLine("Homework Module 7. Basic coding. Task 1. Copying bits to the number.\n");
            Console.WriteLine("NumberSource: {0,8} ({1,32})", numberSource, Convert.ToString(numberSource, 2));
            Console.WriteLine("NumberIn:     {0,8} ({1,32})", numberIn, Convert.ToString(numberIn, 2));
            Console.WriteLine("Result:       {0,8} ({1,32})", resultingNumber, Convert.ToString(resultingNumber, 2));
            Console.WriteLine("i: {0}, j: {1}", i, j);
        }
    }
}
