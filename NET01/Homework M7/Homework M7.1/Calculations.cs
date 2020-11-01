namespace Homework_M7_1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Performs all logic of the project.
    /// </summary>
    public class Calculations
    {
        /// <summary>
        /// Inserts first bits from numberIn into numberSource at specified positions.
        /// </summary>
        /// <param name="numberSource">Number which receives bits.</param>
        /// <param name="numberIn">Number which gives its bits.</param>
        /// <param name="i">Start position of insertion bit range of numberSource.</param>
        /// <param name="j">End position of insertion bit range of numberSource.</param>
        /// <returns>numberSource after insertion.</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            // Convert input numbers to their binary representations - arrays of digits {0,1}
            int[] sourceArray = new int[32];
            GetArrayFromNumber(numberSource, sourceArray);
            int[] inArray = new int[32];
            GetArrayFromNumber(numberIn, inArray);

            // System.Array does not have any method for copying from start pos to finish pos. Thus, we make it by hand.
            // Checks bits from j to i of sourceArray and copies them to outputArray
            for (int x = j; x >= i; x--)
            {
                sourceArray[x] = inArray[x - i];
            }

            return GetNumberFromArray(sourceArray);
        }

        /// <summary>
        /// Converts int number to array of binary digits.
        /// </summary>
        /// <param name="source">Source to be converted to binary form.</param>
        /// <param name="arrayOfDigits">Array which will be modified (output).</param>
        public static void GetArrayFromNumber(int source, int[] arrayOfDigits)
        {
            for (int x = 31; x >= 0; x--)
            {
                if (((int)Math.Pow(2, x) & source) > 0)
                {
                    arrayOfDigits[x] = 1;
                }
                else
                {
                    arrayOfDigits[x] = 0;
                }
            }
        }

        /// <summary>
        /// Converts array of binary digits to int number.
        /// </summary>
        /// <param name="source">Array of binary values.</param>
        /// <returns>Number obtained from conversion.</returns>
        public static int GetNumberFromArray(int[] source)
        {
            int output = 0;
            for (int x = 31; x >= 0; x--)
            {
                output += source[x] * (int)Math.Pow(2, x);
            }

            return output;
        }
    }
}
