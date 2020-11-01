namespace NET_02_Task01_01
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains different overloaded Comparers for List<T>.Sort method.
    /// </summary>
    static class ValueCalculator
    {
        /// <summary>
        /// Finds sum of elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        public static int CalculateValue(ComparerRowSum _, int[] row)
        {
            var value = 0;
            for (var i = 0; i < row.Length; i++)
            {
                value += row[i];
            }
            return value;
        }

        /// <summary>
        /// Finds sum of elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        /// <remarks>Actually calls the other method as the function is the same.</remarks>
        public static int CalculateValue(ComparerRowSumReverse _, int[] row)
        {
            ComparerRowSum dummy = null;
            return CalculateValue(dummy, row);
        }

        /// <summary>
        /// Finds max value among the elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        public static int CalculateValue(ComparerRowMax _, int[] row)
        {
            var value = int.MinValue;
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] > value)
                {
                    value = row[i];
                }
            }
            return value;
        }

        /// <summary>
        /// Finds max value among the elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        /// <remarks>Actually calls the other method as the function is the same.</remarks>
        public static int CalculateValue(ComparerRowMaxReverse _, int[] row)
        {
            ComparerRowMax dummy = null;
            return CalculateValue(dummy, row);
        }

        /// <summary>
        /// Finds min value among the elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        public static int CalculateValue(ComparerRowMin _, int[] row)
        {
            var value = int.MaxValue;
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] < value)
                {
                    value = row[i];
                }
            }
            return value;
        }

        /// <summary>
        /// Finds min value among the elements of the row.
        /// </summary>
        /// <param name="_">Only type of this discard is important for choosing the method.</param>
        /// <param name="row">Row of matrix.</param>
        /// <returns></returns>
        /// <remarks>Actually calls the other method as the function is the same.</remarks>
        public static int CalculateValue(ComparerRowMinReverse _, int[] row)
        {
            ComparerRowMin dummy = null;
            return CalculateValue(dummy, row);
        }
    }
}
