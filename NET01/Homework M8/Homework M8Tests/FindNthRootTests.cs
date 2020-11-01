using NUnit.Framework;
using Homework_M8;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M8.Tests
{
    [TestFixture]
    public class FindNthRootTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double DoCalculationTest(double number, int degree, double precision)
        {
            // arrange
            var findNthRootObj = new FindNthRoot();

            // act + assert
            return findNthRootObj.DoCalculation(number, degree, precision);
        }

        [TestCase(-0.01,  2, 0.0001)]
        [TestCase(0.001, -2, 0.0001)]
        [TestCase(0.01, 2, -1)]
        public void doCalculationTest_Number_Degree_Precision_ArgumentOutOfRangeException
            (double number, int degree, double precision)
        {
            // arrange
            var findNthRootObj = new FindNthRoot();

            // act + assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => findNthRootObj.DoCalculation(number, degree, precision));
        }
    }


}