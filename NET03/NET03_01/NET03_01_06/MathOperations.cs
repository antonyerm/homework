// Task 6
// Write a function that returns the sum of two big numbers. The input numbers are strings and the function must return a string.

namespace NET03_01_06
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// Contains methods impementing Math operations.
    /// </summary>
    internal class MathOperations
    {
        /// <summary>
        /// Sums two numbers represented as strings.
        /// </summary>
        /// <param name="number1">First number as string.</param>
        /// <param name="number2">Second number as string.</param>
        /// <returns>Resulting sum as string.</returns>
        internal string Sum(string number1, string number2)
        {
            var result = new StringBuilder();
            var n1 = number1.ToCharArray();
            var n2 = number2.ToCharArray();

            Array.Reverse(n1);
            Array.Reverse(n2);

            var maxLength = Math.Max(n1.Length, n2.Length);
            int digitFromN1;
            int digitFromN2;
            int carryover = 0;
            for (var i = 0; i < maxLength; i++)
            {
                digitFromN1 = (i >= n1.Length) ? 0 : int.Parse(n1[i].ToString(), NumberStyles.None);
                digitFromN2 = (i >= n2.Length) ? 0 : int.Parse(n2[i].ToString(), NumberStyles.None);
                var digit = digitFromN1 + digitFromN2 + carryover;
                if (digit > 9)
                {
                    carryover = 1;
                    digit = digit - 10;
                } else
                {
                    carryover = 0;
                }

                result.Append(digit.ToString());
            }
            
            if (carryover > 0)
            {
                result.Append(carryover.ToString());
            }

            var resultArray = result.ToString().ToCharArray();
            Array.Reverse(resultArray);
            return new string(resultArray);
        }
    }
}