namespace Homework_M8_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains methods to draw matrices.
    /// </summary>
    internal class Drawer
    {
        /// <summary>
        /// Draws the matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be drawn as a List of <see cref="MatrixElement"/></param>
        public void DrawMatrix(Matrix matrix)
        {
            var matrixArray = matrix.fullMatrix;
            for (int y = 0; y < matrixArray.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < matrixArray.GetUpperBound(1) + 1; x++)
                {
                    var element = matrixArray[y, x];
                    Console.Write("{0,4}", element);
                }

                Console.WriteLine();
            }
        }
    }
}