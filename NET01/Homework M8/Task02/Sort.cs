namespace Homework_M8_2
{
    using System;

    /// <summary>
    /// Sorting algorithms.
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Evaluated y-size () number of rows) of the array.
        /// </summary>
        /// <remarks>Actual evaluation is done in <see cref="Sort"/> method.</remarks>
        private int yMax { get; set; }

        /// <summary>
        /// Evaluated x-size () number of columns) of the array.
        /// </summary>
        /// <remarks>Actual evaluation is done in <see cref="Sort"/> method.</remarks>
        private int xMax { get; set; }

        /// <summary>
        /// Performs sorting.
        /// </summary>
        /// <param name="array">Source array.</param>
        /// <param name="sortBy">Sorting type, see <see cref="SortCriteria"/> enum.</param>
        /// <returns>New sorted array.</returns>
        public int [,] SortMatrix(int[,] array, SortCriteria sortBy)
        {
            int [,] currentArray = (int[,])array.Clone();
            this.xMax = currentArray.GetUpperBound(1);
            this.yMax = currentArray.GetUpperBound(0);

            switch (sortBy)
            {
                // normal sorting order
                case SortCriteria.RowSum:
                case SortCriteria.RowMax:
                case SortCriteria.RowMin:
                    this.BubbleSort(currentArray, sortBy);
                    break;
                // reverse sorting order
                case SortCriteria.RowSumReverse:
                case SortCriteria.RowMaxReverse:
                case SortCriteria.RowMinReverse:
                    this.BubbleSortReverse(currentArray, sortBy);
                    break;
            }

            return currentArray;
        }

        /// <summary>
        /// Performs bubble sorting in normal order.
        /// </summary>
        /// <param name="currentArray">Array to sort.</param>
        /// <param name="sortBy"Sorting type, see <see cref="SortCriteria"/> enum.</param>
        private void BubbleSort(int[,] currentArray, SortCriteria sortBy)
        {
            for (var i = 0; i <= this.yMax; i++)
            {
                for (int j = 0; j <= this.yMax -1; j++)
                {
                    if (GetValue(currentArray, j+1, sortBy) < GetValue(currentArray, j, sortBy))
                    {
                        this.SwapRows(currentArray, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Performs bubble sorting in reverse order.
        /// </summary>
        /// <param name="currentArray">Array to sort.</param>
        /// <param name="sortBy"Sorting type, see <see cref="SortCriteria"/> enum.</param>
        private void BubbleSortReverse(int[,] currentArray, SortCriteria sortBy)
        {
            // This is not a steady version of the sorting algorith 
            // i.e. the order is not known if the values are equal
            //for (var i = 0; i <= this.yMax; i++)
            //{
            //    for (int j = this.yMax; j >= 1; j--)
            //    {
            //        if (GetValue(currentArray, j - 1, sortBy) < GetValue(currentArray, j, sortBy))
            //        {
            //            this.SwapRows(currentArray, j, j - 1);
            //        }
            //    }
            //}

            // this is a steady version
            this.BubbleSort(currentArray, sortBy);
            this.ReverseArray(currentArray);
        }

        /// <summary>
        /// Evaluates the value which is used in comparison.
        /// </summary>
        /// <param name="currentArray">Array to sort.</param>
        /// <param name="rowNumber">Number of the row (y-coordinate).</param>
        /// <param name="sortBy">Type of value to evaluate, depends on <see cref="SortCriteria"/></param>
        /// <returns></returns>
        private int GetValue(int[,] currentArray, int rowNumber, SortCriteria sortBy)
        {
            int value = 0;

            switch (sortBy)
            {
                case SortCriteria.RowSum:
                case SortCriteria.RowSumReverse:
                    value = 0;
                    for (int x = 0; x <= this.xMax; x++)
                    {
                        value += currentArray[rowNumber, x];
                    }
                    break;
                case SortCriteria.RowMax:
                case SortCriteria.RowMaxReverse:
                    value = int.MinValue;
                    for (int x = 0; x <= this.xMax; x++)
                    {
                        if (currentArray[rowNumber, x] > value)
                        {
                            value = currentArray[rowNumber, x];
                        }
                    }
                    break;
                case SortCriteria.RowMin:
                case SortCriteria.RowMinReverse:
                    value = int.MaxValue;
                    for (int x = 0; x <= this.xMax; x++)
                    {
                        if (currentArray[rowNumber, x] < value)
                        {
                            value = currentArray[rowNumber, x];
                        }
                    }
                    break;
            }

            return value;
        }

        /// <summary>
        /// Swaps two raws.
        /// </summary>
        /// <param name="currentArray">Array to sort.</param>
        /// <param name="row1">First row.</param>
        /// <param name="row2">Second row.</param>
        private void SwapRows(int[,] currentArray, int row1, int row2)
        {
            if (this.xMax == 0)
            {
                throw new Exception("Method is called before initialization of class private properties.");
            }

            int[] tempArray = new int[this.xMax + 1];

            for (int x = 0; x <= this.xMax; x++)
            {
                tempArray[x] = currentArray[row2, x];
                currentArray[row2, x] = currentArray[row1, x];
                currentArray[row1, x] = tempArray[x];
            }
        }

        /// <summary>
        /// Reversed the row order of the array.
        /// </summary>
        /// <param name="currentArray">Array to reverse.</param>
        /// <remarks>This is not reversing just the elements of array, but rows.</remarks>
        private void ReverseArray(int[,] currentArray)
        {
            if (this.xMax == 0 || this.yMax == 0)
            {
                throw new Exception("Method is called before initialization of class private properties.");
            }

            int[,] tempArray = new int[this.yMax + 1, this.xMax + 1];

            // fill the buffer in reverse order
            for (int y = 0; y <= this.yMax; y++)
            {
                for (int x = 0; x <= this.xMax; x++)
                {
                    tempArray[this.yMax - y,x] = currentArray[y, x];
                }
            }

            // restore from buffer
            for (int y = 0; y <= this.yMax; y++)
            {
                for (int x = 0; x <= this.xMax; x++)
                {
                    currentArray[y, x] = tempArray[y, x];
                }
            }
        }

    }
}