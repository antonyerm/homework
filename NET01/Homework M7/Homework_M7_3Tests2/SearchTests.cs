using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_3;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M7_3.Tests
{
    [TestClass()]
    public class SearchTests
    {
        [DataTestMethod]
        [DataRow(new double[] { 0.3, 0.9, 1.5, 0.6, 0.6 }, 2)]
        [DataRow(new double[] { 35.555, 0.9, 1.5, 0.6, 0.6, 2.349, 30.506 }, 1)]
        public void SearchForMiddlePositionTest(double[] array, int expected)
        {
            // arrange
            // the parameter is of no importance, as class's array is not used.
            var searchObject = new Search(5);

            // act
            double actual = searchObject.SearchForMiddlePosition(array);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}