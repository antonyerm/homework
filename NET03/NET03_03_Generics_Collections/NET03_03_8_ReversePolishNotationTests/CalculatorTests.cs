using NUnit.Framework;
using NET03_03_8_ReversePolishNotation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET03_03_8_ReversePolishNotation.Tests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        public void CalculateTest(string expression, double expected)
        {
            // arrange
            var caclulator = new Calculator();


            // act
            var actual = caclulator.Calculate(expression);
            
            Assert.That(actual == expected);
        }
    }
}