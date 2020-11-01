namespace Homework_M8
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Used for every math operation implementation.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// Some math operation method.
        /// </summary>
        /// <param name="number1">First parameter of math operaton.</param>
        /// <param name="number2">Second parameter of math operaton.</param>
        /// <param name="precision">Third parameter of math operaton.</param>
        /// <returns>Resulting value.</returns>
        public double DoCalculation(double number1, double number2, double precision);
    }
}
