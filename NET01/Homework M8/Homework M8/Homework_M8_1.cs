// This program uses Strategy design pattern. It is suited to execute different math operations
// which have to be implemented as classes of IStrategy. "Calculations" class is used as an
// interface for operations.
//
// A good article about strategy pattern: https://www.tutorialspoint.com/design_pattern/strategy_pattern.htm

namespace Homework_M8
{
    using System;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    public class Homework_M8_1
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Homework NET-01 Module 8. FindNthRoot of a number.\n");
            Console.WriteLine("Please enter real number: ");
            double.TryParse(Console.ReadLine(), out double inputNumber);
            Console.WriteLine("Please enter root number: ");
            int.TryParse(Console.ReadLine(), out int rootNumber);
            Console.WriteLine("Please enter precision value: ");
            double.TryParse(Console.ReadLine(), out double precision);

            var calculationObject = new Calculations(new FindNthRoot());
            var result = calculationObject.ExecuteStrategy(inputNumber, (double)rootNumber, precision);

            Console.WriteLine("{0}-th root of number {1} is {2}", rootNumber, inputNumber, result);
        }
    }
}
