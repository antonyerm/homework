namespace Homework_M7_5
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Holds the whole logic of the project.
    /// </summary>
    public class ManipulationsWithNumbers
    {
        /// <summary>
        /// Finds the next bigger number.
        /// </summary>
        /// <param name="sourceNumber">Input number.</param>
        /// <returns>Number which is built form the digits of the input number.</returns>
        public int NextBiggerNumber(int sourceNumber)
        {
            int[] arrayOfDigits;
            int numberOfDigits;
            int previousDigit;
            int turningPoint;

            // find number of digits in the source number
            numberOfDigits = (int)Math.Log10(sourceNumber) + 1;

            arrayOfDigits = new int[numberOfDigits];

            // find digits of the source number and put them in the array
            int currentNumber = sourceNumber;
            for (int i = numberOfDigits; i > 0; i--)
            {
                arrayOfDigits[i - 1] = (int) (currentNumber / Math.Pow(10, (i - 1)));
                currentNumber = currentNumber % (int) Math.Pow(10, (i - 1));
            }

            // find position (turningPoint) where the digit is less than the previous one
            previousDigit = 0;
            turningPoint = 0;
            for (int i = 0; i < numberOfDigits; i++)
            {
                if (arrayOfDigits[i] >= previousDigit)
                    previousDigit = arrayOfDigits[i];
                else
                {
                    turningPoint = i;
                    // swap values at turning point
                    arrayOfDigits[i - 1] = arrayOfDigits[i];
                    arrayOfDigits[i] = previousDigit;
                    break;
                }
            }

            // failed to find result
            if (turningPoint == 0)
            {
                return -1;
            }

            // the part to the right of the turning point needs to be reverse-sorted
            Array.Sort(arrayOfDigits, 0, turningPoint);
            Array.Reverse(arrayOfDigits, 0, turningPoint);

            // convert array back to number
            currentNumber = 0;
            for (int i = numberOfDigits; i > 0; i--)
            {
                currentNumber += arrayOfDigits[i - 1] * (int) Math.Pow(10, (i - 1));
            }


            return currentNumber;
        }
    }
}
