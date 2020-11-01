namespace Homework_M9_1
{
    using System;
    using MyExtensionMethods;

    /// <summary>
    /// Entry class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET-01 Module 9. Task 1. System.Double.IEEE754().\n");
            Console.WriteLine("Please enter real number: ");
            double.TryParse(Console.ReadLine(), out double inputNumber);

            Console.WriteLine("String representation of double {0} is \n", inputNumber);
            var tempForegroundColour = Console.ForegroundColor;
            var tempBackgroundColour = Console.BackgroundColor;
            for (var i = 63; i >= 0; i--)
            {
                if (i == 63)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    if (i > 52)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                }
                Console.Write("{0, 3}", i);
            }
            Console.BackgroundColor = tempBackgroundColour;
            Console.ForegroundColor = tempForegroundColour;

            var result = inputNumber.IEEE754();
            Console.WriteLine();
            for (var i = 0; i < 64; i++)
            {
                Console.Write("{0,3}", (i >= result.Length) ? "" : result[i].ToString());
            }
        }
    }
}

//Sign bit: 1 bit
//Exponent: 11 bits
//Significand precision: 53 bits(52 explicitly stored)
