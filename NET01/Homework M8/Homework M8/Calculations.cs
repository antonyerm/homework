namespace Homework_M8
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Context (interface) class for executing various math operations.
    /// </summary>
    /// <remarks>All of them must be implementations of <see cref="IStrategy"/>.</remarks>
    public class Calculations
    {
        /// <summary>
        /// This variable holds the object that is actually doing the calculation.
        /// </summary>
        private IStrategy strategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculations"/> class.
        /// </summary>
        /// <param name="strategy">Instance of the class which holds the operation method.</param>
        public Calculations(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Executes some math operation which is in <see cref="strategy"/> object.
        /// </summary>
        /// <param name="number1">First argument of math operation.</param>
        /// <param name="number2">Second argument of math operation.</param>
        /// <param name="number3">Third argument of math operation.</param>
        /// <returns>Resulting value of math operation.</returns>
        public double ExecuteStrategy(double number1, double number2, double number3)
        {
            return this.strategy.DoCalculation(number1, number2, number3);
        }
    }
}
