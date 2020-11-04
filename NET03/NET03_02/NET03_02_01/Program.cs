// Task 1
// Refactor of class methods (Izh - 06.Methods in details) using delegates (the API 's of the class should not change). 
// 
// link (Izh - 06.Methods):
// Разработать класс, позволяющий выполнять вычисления НОД по алгоритму Евклида для двух, трех и т.д. целых чисел 
// (http://en.wikipedia.org/wiki/Euclidean_algorithm , https://habrahabr.ru/post/205106/, https://habrahabr.ru/post/205106/ ). 
// Методы класса помимо вычисления НОД должны предоставлять дополнительную возможность определения значение времени, 
// необходимое для выполнения расчета. Добавить к разработанному классу методы, реализующие алгоритм Стейна (бинарный алгоритм Евклида) 
// для расчета НОД двух, трех и т.д. целых чисел (http://en.wikipedia.org/wiki/Binary_GCD_algorithm, https://habrahabr.ru/post/205106/ ), 
// а также методы, предоставляющие дополнительную возможность определения значение времени, необходимое для выполнения расчета. 
// Рассмотреть различные возможности реализации методов, возвращающих время вычисления НОД. Разработать модульные тесты.

namespace NET03_02_01
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03 Task 2. Problem 1. Euclidean algorithm for GCD for 3 and more numbers " +
                "\nwith different implementations and delegates.\n");

            var stopWatch = new Stopwatch();
            var generatorObj = new Generator();

            foreach (int algorithm in Enum.GetValues(typeof(TypeOfAlgorithm)))
            {
                Console.WriteLine($"Results by algorithm: {(TypeOfAlgorithm)algorithm}");
                Console.WriteLine("===================================================");
                for (int i = 0; i < 500; i++)
                {
                    var numbers = generatorObj.GenerateNumbers(5);
                    var calculationObj = new Calculation();
                    stopWatch.Reset();
                    stopWatch.Start();
                    calculationObj.SetAlgorithm((TypeOfAlgorithm)algorithm);
                    var gcd = calculationObj.Gcd(numbers);
                    stopWatch.Stop();

                    if (gcd > 1) // we show only "interesting" cases
                    {
                        Console.WriteLine("The numbers are:");
                        foreach (var number in numbers)
                        {
                            Console.Write("{0, -4}", number);
                        }

                        Console.WriteLine(" => Their GCD is: {0, 3}. Time elapsed: {1} ticks.", gcd, stopWatch.ElapsedTicks);
                    }
                }
            }
        }
    }
}
