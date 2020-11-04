namespace Homework_M9_2
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Generates list of numbers.
    /// </summary>
    internal class Generator
    {
        /// <summary>
        /// Generates list of random numbers.
        /// </summary>
        /// <param name="howManyNumbers">Quantity of numbers in the list.</param>
        /// <returns>List of numbers.</returns>
        internal List<int> GenerateNumbers(int howManyNumbers)
        {
            var rnd = new Random();
            var numbers = new List<int>();

            for (var i = 0; i < howManyNumbers; i++)
            {
                numbers.Add(rnd.Next(1, 30));
            }

            return numbers;
        }
    }
}