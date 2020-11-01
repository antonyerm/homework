namespace Homework_M8_2
{
    using System;
    using System.Collections.Generic;
    using global::Homework_M8_2.Sorting;

    /// <summary>
    /// Entry class fo the program.
    /// </summary>
    public class Homework_M8_2
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {
            var drawer = new Drawer();
            var sort = new Sort();
            int[,] currentMatrix;

            Console.WriteLine("Homework NET-01 Module 8.2. Matrix sorting.\n");
            var originalMatrix = new MatrixGenerator().GenerateMatrix();
            Console.WriteLine("The original matrix:");
            drawer.DrawMatrix(originalMatrix);

            currentMatrix = //originalMatrix.GetDeepCopy();
            sort.SortMatrix(currentMatrix, SortCriteria.RowSum);

            //Console.WriteLine("The RowSum sorted matrix:");
            //drawer.DrawMatrix(currentMatrix);
        }
    }
}

План:
1. сделать сорвтировщик
    он делает пузырьковыую сортировку, но values считает по-разному, в зависимости от SortBy
