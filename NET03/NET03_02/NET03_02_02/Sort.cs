namespace NET03_02_01
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
        /// <remarks>Actual evaluation is done in <see cref="SortMatrix"/> method.</remarks>
        private int yMax { get; set; }

        /// <summary>
        /// Evaluated x-size () number of columns) of the array.
        /// </summary>
        /// <remarks>Actual evaluation is done in <see cref="SortMatrix"/> method.</remarks>
        private int xMax { get; set; }

        /// <summary>
        /// Gets value of the specified row in array.
        /// </summary>
        /// <param name="input">Input array 2d.</param>
        /// <param name="row">Row number.</param>
        /// <returns>Value for the row.</returns>
        private delegate int GetValueOfRow(int[,] input, int row);

        /// <summary>
        /// Sorts array by bubble sorting algorithm.
        /// </summary>
        /// <param name="currentArray">Input array.</param>
        /// <param name="GetRowValue">Method for computation of the row value.</param>
        private delegate void BubbleSortDelegate(int[,] currentArray, GetValueOfRow GetRowValue);

        /// <summary>
        /// Performs sorting of the array.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="sortBy">Sorting type, see <see cref="SortCriteria"/> enum.</param>
        /// <returns>New sorted array.</returns>
        public int[,] SortMatrix(int[,] array, SortCriteria sortBy)
        {
            int[,] currentArray = (int[,])array.Clone();
            this.xMax = currentArray.GetUpperBound(1);
            this.yMax = currentArray.GetUpperBound(0);
            GetValueOfRow GetRowValue = null;
            BubbleSortDelegate BubbleSort = null;

            switch (sortBy)
            {
                // normal sorting order
                case SortCriteria.RowSum:
                    GetRowValue = GetRowValueRowSum;
                    BubbleSort = BubbleSortNormal;
                    break;
                case SortCriteria.RowMax:
                    GetRowValue = GetRowValueRowMax;
                    BubbleSort = BubbleSortNormal;
                    break;
                case SortCriteria.RowMin:
                    GetRowValue = GetRowValueRowMin;
                    BubbleSort = BubbleSortNormal;
                    break;
                // reverse sorting order
                case SortCriteria.RowSumReverse:
                    GetRowValue = GetRowValueRowSumReverse;
                    BubbleSort = BubbleSortReverse;
                    break;
                case SortCriteria.RowMaxReverse:
                    GetRowValue = GetRowValueRowMaxReverse;
                    BubbleSort = BubbleSortReverse;
                    break;
                case SortCriteria.RowMinReverse:
                    GetRowValue = GetRowValueRowMinReverse;
                    BubbleSort = BubbleSortReverse;
                    break;
            }

            BubbleSort(currentArray, GetRowValue);

            return currentArray;
        }

        /// <summary>
        /// Sorts array by bubble sorting algorithm in normal order.
        /// </summary>
        /// <param name="currentArray">Input array.</param>
        /// <param name="GetRowValue">Method for computation of the row value.</param>
        private void BubbleSortNormal(int[,] currentArray, GetValueOfRow GetRowValue)
        {
            for (var i = 0; i <= this.yMax; i++)
            {
                for (int j = 0; j <= this.yMax - 1; j++)
                {
                    if (GetRowValue(currentArray, j + 1) < GetRowValue(currentArray, j))
                    {
                        this.SwapRows(currentArray, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts array by bubble sorting algorithm in reverse order.
        /// </summary>
        /// <param name="currentArray">Input array.</param>
        /// <param name="GetRowValue">Method for computation of the row value.</param>
        private void BubbleSortReverse(int[,] currentArray, GetValueOfRow GetRowValue)
        {
            // This is not a consistent version of the sorting algorith 
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

            // this is a consistent version
            BubbleSortNormal(currentArray, GetRowValue);
            this.ReverseArray(currentArray);
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
        /// Reverses the row order of the array.
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
                    tempArray[this.yMax - y, x] = currentArray[y, x];
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

        /// <summary>
        /// Computes sum of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowSum(int[,] input, int rowNumber)
        {
            int value = 0;
            for (int x = 0; x <= this.xMax; x++)
            {
                value += input[rowNumber, x];
            }
            return value;
        }

        /// <summary>
        /// Computes max of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowMax(int[,] input, int rowNumber)
        {
            int value = int.MinValue;
            for (int x = 0; x <= this.xMax; x++)
            {
                if (input[rowNumber, x] > value)
                {
                    value = input[rowNumber, x];
                }
            }
            return value;
        }

        /// <summary>
        /// Computes min of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowMin(int[,] input, int rowNumber)
        {
            int value = int.MaxValue;
            for (int x = 0; x <= this.xMax; x++)
            {
                if (input[rowNumber, x] < value)
                {
                    value = input[rowNumber, x];
                }
            }
            return value;
        }

        /// <summary>
        /// Computes sum of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowSumReverse(int[,] input, int rowNumber)
        {
            return GetRowValueRowSum(input, rowNumber);
        }

        /// <summary>
        /// Computes max of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowMaxReverse(int[,] input, int rowNumber)
        {
            return GetRowValueRowMax(input, rowNumber);
        }

        /// <summary>
        /// Computes min of the row elements.
        /// </summary>
        /// <param name="input">Input array.</param>
        /// <param name="rowNumber">Number of the row.</param>
        /// <returns></returns>
        private int GetRowValueRowMinReverse(int[,] input, int rowNumber)
        {
            return GetRowValueRowMin(input, rowNumber);
        }
    
    }
}