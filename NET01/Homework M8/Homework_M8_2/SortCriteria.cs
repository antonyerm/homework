namespace Homework_M8_2.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Matrix elements sort criteria.
    /// </summary>
    public enum SortCriteria
    {
        /// <summary>
        /// Increasing order of sums of row elements.
        /// </summary>
        RowSum,

        /// <summary>
        /// Decreasing order of sums of row elements.
        /// </summary>
        RowSumReverse,

        /// <summary>
        /// Increasing order of sums of row's max elements.
        /// </summary>
        RowMax,

        /// <summary>
        /// Decreasing order of sums of row's max elements.
        /// </summary>
        RowMaxReverse,

        /// <summary>
        /// Increasing order of sums of row's min elements.
        /// </summary>
        RowMin,

        /// <summary>
        /// Decreasing order of sums of row's min elements.
        /// </summary>
        RowMinReverse,
    }
}
