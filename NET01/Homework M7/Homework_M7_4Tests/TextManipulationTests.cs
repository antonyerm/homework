using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework_M7_4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_M7_4.Tests
{
    [TestClass()]
    public class TextManipulationTests
    {
        [DataTestMethod]
        [DataRow("abcdefg", "abcdefg", "abcdefgabcdefg")]
        [DataRow("aabcccdeeeefggggg", "abcdefg", "abcdefgabcdefg")]
        [DataRow("Тестhello", "aabbbbccccdПриветeеееfg", "heloabcdefg")]
        public void ConcatenationTest(string stringA, string stringB, string expected)
        {
            // arrange
            var textManipulationObject = new TextManipulation();
            string actual;

            // act
            actual = textManipulationObject.Concatenation(stringA, stringB);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}