using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M7_2.Tests
{
    [TestClass()]
    public class SearchTests
    {
        [DataTestMethod]
        [DataRow(new [] {1, 50, 1345, 4, -234}, 1345)]
        [DataRow(new[] { -40, -234, -500, -24, 0 }, 0)]
        [DataRow(new[] { -40, -234, -500, -24, -42 }, -24)]
        [DataRow(new[] { 40, 234, 0, 24, 502 }, 502)]
        public void SearchForMaxTests(int[] array, int expected)
        {
            // arrange
            // parameter here does not matter, private Search.array is not used
            var searchObj = new Search(15);

            // act
            var actual = searchObj.SearchForMax(array);

            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}