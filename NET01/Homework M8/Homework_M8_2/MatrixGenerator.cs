namespace Homework_M8_2
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    /// <summary>
    /// Generator of matrices.
    /// </summary>
    internal class MatrixGenerator
    {
        /// <summary>
        /// Generates matrix and fills it with random values.
        /// </summary>
        /// <returns>Matrix as <see cref="Matrix"/> object.</returns>
        internal Matrix GenerateMatrix(int rowsMax = 3, int columnsMax = 3)
        {
            var rnd = new Random();
            var newMatrix = new Matrix(rowsMax, columnsMax);

            // fill the matrix with random values
            for (int y = 0; y < rowsMax; y++)
            {
                for (int x = 0; x < columnsMax; x++)
                {
                    newMatrix[y, x] = rnd.Next(0, 100);
                }
            }

            return newMatrix;
        }
    }
}