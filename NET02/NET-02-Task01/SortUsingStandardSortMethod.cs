using NET_02_Task01_01;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_02_Task01_01
{
    /// <summary>
    /// Contains methods for sorting the rows of the matrix.
    /// </summary>
    public class SortUsingStandardSortMethod
    {
        private List<int []> matrixAsList;

        /// <summary>
        /// Sorts the rows of the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to sort.</param>
        /// <param name="sortBy">Sorting criterion./></param>
        /// <returns></returns>
        public int[,] Sort(int[,] matrix, SortCriteria sortBy)
        {
            // convert matrix to List of rows.
            this.matrixAsList = generateMatrixAsList(matrix);
            
            // choose comparer method            
            IComparer<int[]> comparer = null;
            switch (sortBy)
            {
                case SortCriteria.RowSum:
                    comparer = new ComparerRowSum();
                    break;
                case SortCriteria.RowSumReverse:
                    comparer = new ComparerRowSumReverse();
                    break;
                case SortCriteria.RowMax:
                    comparer = new ComparerRowMax();
                    break;
                case SortCriteria.RowMaxReverse:
                    comparer = new ComparerRowMaxReverse();
                    break;
                case SortCriteria.RowMin:
                    comparer = new ComparerRowMin();
                    break;
                case SortCriteria.RowMinReverse:
                    comparer = new ComparerRowMinReverse();
                    break;
                default:
                    break;
            }

            // apply List<T>.Sort method.
            this.matrixAsList.Sort(comparer);

            // convert List of rows back to matrix.
            return generateMatrixAsArray(matrixAsList);
        }

        /// <summary>
        /// Converts List of rows back to matrix.
        /// </summary>
        /// <param name="matrixAsList">List of rows.</param>
        /// <returns>Matrix as 2d-array.</returns>
        private int[,] generateMatrixAsArray(List<int[]> matrixAsList)
        {
            var matrix = new int[matrixAsList.Count, matrixAsList[0].Length];
            for (var y = 0; y <= matrix.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= matrix.GetUpperBound(1); x++)
                {
                    matrix[y, x] = matrixAsList[y][x];
                }
            }

            return matrix;
        }

        /// <summary>
        /// Converts the matrix to List of rows.
        /// </summary>
        /// <param name="matrix">Source matrix.</param>
        /// <returns>List of rows.</returns>
        private List<int []> generateMatrixAsList(int[,] matrix)
        {
            var matrixRows = new List<int []>();
            for (var y = 0; y <= matrix.GetUpperBound(0); y++)
            {
                var oneRow = new int[matrix.GetUpperBound(1) + 1];
                for (int x = 0; x <= matrix.GetUpperBound(1); x++)
                {
                    oneRow[x] = matrix[y, x];
                }
                matrixRows.Add(oneRow);
            }

            return matrixRows;
        }
    }
}
