namespace Homework_M7_3
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Holds the whole logic of the project.
    /// </summary>
    public class Search
    {
        double[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="arraySize">Size of the array.</param>
        /// <remarks>Initializes the array.</remarks>
        public Search(int arraySize)
        {
            var rand = new Random();
            array = new double[arraySize];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(rand.Next(0, 10) / 10F, 1);
            }
        }

        /// <summary>
        /// Prints out the array members.
        /// </summary>
        public void ShowArray()
        {
            for (var i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        /// <summary>
        /// Prints out the array members.
        /// </summary>
        /// <param name="highlighPosition">Position of the array member which will be highlighted.</param>
        public void ShowArray(int highlighPosition)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (i == highlighPosition)
                {
                    var previousBackgroundColor = Console.BackgroundColor;
                    var previousForegroundColor = Console.ForegroundColor;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(array[i] + " ");
                    Console.BackgroundColor = previousBackgroundColor;
                    Console.ForegroundColor = previousForegroundColor;
                }
                else
                {
                    Console.Write(array[i] + " ");
                }
            }
        }

        /// <summary>
        /// Searches for position in the array where sum to the left is equal to the sum to the right.
        /// </summary>
        /// <returns>Middle postition</returns>
        /// <remarks>This is a wrapper for <see cref="DoTheSearchForMiddlePosition(double[])"/></remarks>
        public int SearchForMiddlePosition()
        {
            return this.DoTheSearchForMiddlePosition(this.array);
        }

        /// <summary>
        /// Searches for position in the array where sum to the left is equal to the sum to the right.
        /// </summary>
        /// <param name="array">Input array which is in fact <c>this.array</c>.</param>
        /// <returns>Middle position number.</returns>
        /// /// <remarks>This is a wrapper for <see cref="DoTheSearchForMiddlePosition(double[])"/></remarks>
        public int SearchForMiddlePosition(double[] array)
        {
            return this.DoTheSearchForMiddlePosition(array);
        }

        /// <summary>
        /// Searches for the middle position of the array member.
        /// </summary>
        /// <param name="array">Input array which is in fact <c>this.array</c>.</param>
        /// <returns>Middle position number.</returns>
        /// <remarks>The member at the position is excluded from sums.</remarks>
        private int DoTheSearchForMiddlePosition(double[] array)
        {
            double totalSum = 0;
            double currentSum = 0;

            // Get the sum of all members of the array
            for (var i = 0; i < array.Length; i++)
            {
                totalSum += array[i];
            }

            // found nothing if the array is filled with 0s
            if (totalSum == 0)
            {
                return -1;
            }

            // Check through all members until we find
            // if the sum on the left equals half of [the TotalSum minus current element]
            // (since value at middle position is not included in total count)
            for (var i = 0; i < array.Length; i++)
            {
                // precision is 0.0001 (4th digit after decimal point)
                if (currentSum == Math.Round((totalSum - array[i]) / 2, 4))
                {
                    return i;
                }

                currentSum += array[i];
            }

            // found nothing after search
            return -1;
        }
    }
}