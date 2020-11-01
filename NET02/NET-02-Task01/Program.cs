// Эта программа выполняет следующее задание:
// * Task 1
// * To refactor the algorithm [Task 2 Module 3](https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/tree/master/M3.%20Types) 
// * (don't use delegates and standard interfaces), allowing to sorting both in ascending and descending directions, 
// * depending on comparison criterion of the matrix rows. Develop unit-tests using varioгs comparison criterion of the matrix rows.
//
// Поскольку первый вариант программы (аналогичный [Task 2 Module 3]) уже выполнял сортировку во всех направлениях,
// я решил просто переписать эту программу немного по-другому:
// - сортировка выполняется станартным методом List<T>Sort(IComparer), а не пузырьковым;
// - для всех критериев сортировки заданы свои компараторы IComparer (в файле compares.cs);
// - при реализации компаратаров сделана попытка реализовать Design Pattern Visitor, а именно 
// числовое значение, ассоциируемое со строкой матрицы (которое и сравнивается) рассчитывается в зависимости от типа класса компаратора
// соответствующим перегруженным методом из класса ValueCalculator, т.е. имеется двойная диспетчеризация, характерная для Visitor.
//
// Наверное, это не настоящий Visitor, потому что он реализован не в общем виде, без использования интерфейсов...



namespace NET_02_Task01_01
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Homework NET-02 Task01 - 01. Matrix sorting with sorting criterions.\n");

            // Generate the source array
            var array = new int[3, 3];
            var rnd = new Random();
            var drawer = new Drawer();

            // fill the array
            for (int y = 0; y <= array.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= array.GetUpperBound(1); x++)
                {
                    array[y, x] = rnd.Next(0, 100);
                }
            }

            Console.WriteLine("The original matrix:");
            drawer.DrawMatrix(array);

            var sortObject = new SortUsingStandardSortMethod();

            // Perform all kinds of sorting
            foreach (var sortBy in Enum.GetValues(typeof(SortCriteria)))
            {
                var sortedArray = sortObject.Sort(array, (SortCriteria)sortBy);
                Console.WriteLine("Type of sorting: {0}. The sorted matrix:",
                    Enum.GetName(typeof(SortCriteria), sortBy));
                drawer.DrawMatrix(sortedArray);
            }
            
        }
    }
}
