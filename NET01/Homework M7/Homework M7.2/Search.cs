namespace Homework_M7_2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Holds the whole logic of the project.
    /// </summary>
    public class Search
    {
        private int[] array;

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        /// <param name="arraySize">Size of the array.</param>
        /// <remarks>Initializes the array.</remarks>
        public Search(int arraySize)
        {
            var rand = new Random();
            array = new int[arraySize];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 1000);
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
        /// Just a wrapper for the recursive search method.
        /// </summary>
        /// <returns>Max value in array.</returns>
        /// <remarks>This one is needed because the recursive method requires parameters
        /// which are not known from outside. Also <c>int[] array</c> is private and
        /// this wrapper helps testing this method using <c>array</c> as a parameter.</remarks>
        public int SearchForMax()
        {
            return this.RecursiveSearch(this.array, 0, int.MinValue);
        }

        /// <summary>
        /// An overloaded version of <c>SearchForMax</c> with explicit external array passing as a parameter.
        /// </summary>
        /// <param name="arrayToTest">Array which will be analyzed. Can be passed in testing.</param>
        /// <returns>Max value in array.</returns>
        public int SearchForMax(int[] arrayToTest)
        {
            return this.RecursiveSearch(arrayToTest, 0, int.MinValue);
        }

        /// <summary>
        /// Does the recursive search for max.
        /// </summary>
        /// <param name="array">Array which will be analyzed (it is the same every cycle).
        /// Not needed really, but <c>int[] array</c> is private and this parameter helps 
        /// testing this method using <c>array</c> as a parameter.</param>
        /// <param name="pos">Current search position in array.</param>
        /// <param name="currentMax">Current max value.</param>
        /// <returns>Max value.</returns>
        private int RecursiveSearch(int[] array, int pos, int currentMax)
        {
            if (array[pos] > currentMax)
            {
                currentMax = array[pos];
            }

            if (pos == array.Length - 1)
            {
                return currentMax;
            }
            else
            {
                return RecursiveSearch(array, pos + 1, currentMax);
            }
        }
    }
}
