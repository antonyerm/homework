using NUnit.Framework;
using Homework_M9_2;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;
using System.Linq;

namespace Homework_M9_2.Tests
{
    [TestFixture()]
    public class CalculationTests
    {
        [TestCaseSource("TestArrays")]
        public void GcdTest(List<int> testList, int expected)
        {
            var calculationObject = new Calculation();
            var actual = calculationObject.Gcd(testList);
            Assert.That(actual == expected);
        }

        static object[] TestArrays =
        {
            new object[]
            {
                new List<int> { 23, 54, 76},
                1
            },
            new object[]
            {
                new List<int> { 5, 20, 25},
                5
            },
            new object[]
            {
                new List<int> { 24, 48, 54},
                6
            },
            new object[]
            {
                new List<int> { 44, 121, 88},
                11
            },
            new object[]
            {
                new List<int> { 34, 136, 85, 51, 204},
                17
            },

        };

    }
}