using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M7_1.Tests
{
    [TestClass()]
    public class CalculationsTests
    {
        [DataTestMethod]
        [DataRow(15,15,0,0,15)]
        [DataRow(8,15,0,0,9)]
        [DataRow(8,15,3,8,120)]
        public void InsertNumberTest(int numberSource, int numberIn, int i, int j, int expected)
        {
            // arrange

            // act
            var actual = Calculations.InsertNumber(numberSource, numberIn, i, j);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}