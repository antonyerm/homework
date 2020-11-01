using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_6;
using System;

namespace Homework_M7_6.Tests
{
    [TestClass()]
    public class ArrayOperationsTests
    {
        [DataTestMethod]
        [DataRow(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, new int[] { 7, 7, 70, 17 })]
        public void FilterDigitTest(int[] inputArray, int filterKey, int[] expected)
        {
            // arrange
            int[] actual;
            var operationsObject = new ArrayOperations();

            // act
            actual = operationsObject.FilterDigit(inputArray, filterKey);

            // assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}