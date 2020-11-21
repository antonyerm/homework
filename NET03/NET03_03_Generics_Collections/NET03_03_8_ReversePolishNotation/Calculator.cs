// Task 8
// Create a calculator which evaluates expressions in Reverse Polish notation. For example, expression 5 1 2 + 4 * + 3 - 
// (which is equivalent to 5 + ((1 + 2) *4) -3 in normal notation) should evaluate to 14. Note, that for simplicity you may assume 
// that there are always spaces between numbers and operations, e.g. 1 3 + expression is valid, but 1 3+ isn't. Empty expression 
// should evaluate to 0. Valid operations are +, -, *, /.

using System;
using System.Collections.Generic;

namespace NET03_03_8_ReversePolishNotation
{
    /// <summary>
    /// Implements simple calculator which processes Reverse Polinsh Notation expressions.
    /// </summary>
    public class Calculator
    {
        Stack<double> expressionOperands = new Stack<double>();

        /// <summary>
        /// Calculates the result of expression in Reverse Polish Notation.
        /// </summary>
        /// <param name="expression">The explression in Reverse Polish Notation.</param>
        /// <returns>The result of calculation.</returns>
        public double Calculate(string expression)
        {
            double operand;
            double operand1;
            double operand2;
            double result = default;
            expressionOperands.Clear();
            Func<double, double, double> operation = null;

            var expressionElements = expression.Split();
            foreach (var element in expressionElements)
            {
                if (Double.TryParse(element, out operand))
                {
                    expressionOperands.Push(operand);
                    continue;
                } 
                else
                if (element.Equals("+"))
                {
                    operation = (double x, double y) => (x + y);
                }
                else
                if (element.Equals("-"))
                {
                    operation = (double x, double y) => (x - y);
                }
                else
                if (element.Equals("*"))
                {
                    operation = (double x, double y) => (x * y);
                }
                else
                if (element.Equals("/"))
                {
                    operation = (double x, double y) => (x / y);
                }
                else
                {
                    throw new FormatException($"Unrecognized operation \"{element}\".");
                }

                if (expressionOperands.TryPop(out operand2) &&
                    expressionOperands.TryPop(out operand1))
                {
                    result = operation(operand1, operand2);
                }

                expressionOperands.Push(result);
            }

            if (expressionOperands.TryPop(out result))
            {
                return result;
            }
            else
            {
                return Double.NaN;
            }
        }
    }
}