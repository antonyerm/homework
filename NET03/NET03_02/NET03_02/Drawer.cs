namespace NET03_02_01
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains methods to draw matrices.
    /// </summary>
    internal class Drawer
    {
        /// <summary>
        /// Draws the matrix.
        /// </summary>
        /// <param name="matrix">Array to be drawn.</param>
        public void DrawMatrix(int[,] matrix)
        {
            for (int y = 0; y <= matrix.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= matrix.GetUpperBound(1); x++)
                {
                    var element = matrix[y, x];
                    Console.Write("{0,4}", element);
                }

                Console.WriteLine();
            }
        }
    }
}