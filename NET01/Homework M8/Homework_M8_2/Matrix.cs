using System;
using System.Security.Cryptography;

namespace Homework_M8_2
{
    public class Matrix
    {
        private int[,] matrix;

        public int[,] fullMatrix
        {
            get => this.matrix;

            set => this.matrix = value;
        }

        public int this[int y, int x]
        {
            get => this.matrix[y, x];
            set => this.matrix[y, x] = value;
        }

        public Matrix(int ySize, int xSize)
        {
            this.matrix = new int[ySize, xSize];
        }

        public int[,] GetDeepCopy()
        {
            var newArray = new int[this.matrix.GetUpperBound(1) + 1, this.matrix.GetUpperBound(0) + 1];
            for (int y = 0; y < this.matrix.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < this.matrix.GetUpperBound(1) + 1; x++)
                {
                    newArray[y, x] = matrix[y, x];
                }
            }
        }
    }
}