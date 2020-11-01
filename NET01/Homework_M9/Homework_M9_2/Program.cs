namespace Homework_M9_2
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    
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
            Console.WriteLine("Homework NET-01 Module 9. task 2. Euclid algorithm for GCD for 3 and more numbers.\n");

            var stopWatch = new Stopwatch();
            var generatorObj = new Generator();


            for (int i = 0; i < 500; i++)
            {
                var numbers = generatorObj.GenerateNumbers(5);
                var calculationObj = new Calculation();
                stopWatch.Reset();
                stopWatch.Start();
                var gcd = calculationObj.Gcd(numbers);
                stopWatch.Stop();

                if (gcd > 1)
                {
                    Console.WriteLine("The numbers are:");
                    foreach (var number in numbers)
                    {
                        Console.Write("{0, -4}", number);
                    }

                    Console.WriteLine(" => Their GCD is: {0, 3}. Time elapsed: {1} ticks.", gcd, stopWatch.ElapsedTicks);
                }
                
            }
            
        }
    }
}