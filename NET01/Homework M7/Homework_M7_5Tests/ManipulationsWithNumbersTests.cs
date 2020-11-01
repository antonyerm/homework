using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_5;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M7_5.Tests
{
    [TestClass()]
    public class ManipulationsWithNumbersTests
    {

        [DataTestMethod]
        [DataRow(12, 21)]
        [DataRow(513, 531)]
        [DataRow(2017, 2071)]
        [DataRow(414, 441)]
        [DataRow(144, 414)]
        [DataRow(1234321, 1241233)]
        [DataRow(1234126, 1234162)]
        [DataRow(3456432, 3462345)]
        [DataRow(10, -1)]
        [DataRow(20, -1)]
        public void NextBiggerNumberTest(int sourceNumber, int expected)
        {
            // arrange
            int actual;
            var manipulationsObject = new ManipulationsWithNumbers();

            // act
            actual = manipulationsObject.NextBiggerNumber(sourceNumber);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}