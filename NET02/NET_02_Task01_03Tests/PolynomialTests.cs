using NUnit.Framework;
using NET_02_Task01_03;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_02_Task01_03.Tests
{
    [TestFixture()]
    public class PolynomialTests
    {
        [TestCaseSource(nameof(PolynomialSumResults))]
        public void PolynomialsSumTests(double[] a, double[] b, double[] result)
        {
            // arrange
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            // act
            var resultPolynomial = new Polynomial(result);
            var actual = polynomialA + polynomialB;

            // assert
            Assert.That(resultPolynomial.Equals(actual));
        }

        [TestCaseSource(nameof(PolynomialSubtractionResults))]
        public void PolynomialSubtractionTests(double[] a, double[] b, double[] result)
        {
            // arrange
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            // act
            var resultPolynomial = new Polynomial(result);
            var actual = polynomialA - polynomialB;

            // assert
            Assert.That(resultPolynomial.Equals(actual));
        }

        [TestCaseSource(nameof(PolynomialMultResults))]
        public void PolynomialMultTests(double[] a, double[] b, double[] result)
        {
            // arrange
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            // act
            var resultPolynomial = new Polynomial(result);
            var actual = polynomialA * polynomialB;

            // assert
            Assert.That(resultPolynomial.Equals(actual));
        }

        [TestCaseSource(nameof(PolynomialDivisionResults))]
        public void PolynomialDivisionTests(double[] a, double[] b, double[] result)
        {
            // arrange
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            // act
            var resultPolynomial = new Polynomial(result);
            var actual = polynomialA / polynomialB;

            // assert
            Assert.That(resultPolynomial.Equals(actual));
        }

        [TestCaseSource(nameof(PolynomialDivWithRemainderResults))]
        public void PolynomialDivisionWithRemainiderTests(double[] a, double[] b, double[] result, double[] remainder)
        {
            // arrange
            var polynomialA = new Polynomial(a);
            var polynomialB = new Polynomial(b);

            // act
            var resultPolynomial = new Polynomial(result);
            var remainderPolynomial = new Polynomial(remainder);
            Polynomial actualRemainder;
            var actualResult = polynomialA.DivisionRemainder(polynomialB, out actualRemainder);

            // assert
            Assert.That(resultPolynomial.Equals(actualResult) && remainderPolynomial.Equals(actualRemainder));
        }

        // Test examples are taken from https://saylordotorg.github.io/text_intermediate-algebra/s04-06-polynomials-and-their-operatio.html

        static object[] PolynomialSumResults = new object[]
        {
            new object[]
            {
                new double[] { 1, 5, 6}, // polynomial A
                new double[] { 4, 3, 5}, // polynomial B
                new double[] { 5, 8, 11}, // A + B
            },

            new object[]
            {
                new double[] {    1, 4, 6}, // polynomial A
                new double[] { 4, 3, 5, 50}, // polynomial B
                new double[] { 4, 4, 9, 56}, // A + B
            },

        };

        static object[] PolynomialSubtractionResults = new object[]
        {
            new object[]
            {
                new double[] { 1, 5.3, 6}, // polynomial A
                new double[] { 4.7, 3, 5}, // polynomial B
                new double[] { -3.7, 2.3, 1}, // A - B
            },

            new object[]
            {
                new double[] {    1, 4, 6}, // polynomial A
                new double[] { 4, 3, 5, 50}, // polynomial B
                new double[] { -4, -2, -1, -44}, // A - B
            },

        };

        static object[] PolynomialMultResults = new object[]
        {
            new object[]
            {
                new double[] { 1, 7, -1}, // polynomial A (#71)
                new double[] { 2, -3, -1}, // polynomial B
                new double[] { 2, 11, -24, -4, 1}, // A * B
            },

            new object[]
            {
                new double[] {    1, -5}, // polynomial A (#69)
                new double[] { 1, -3, 8}, // polynomial B
                new double[] { 1, -8, 23, -40}, // A * B
            },

        };

        static object[] PolynomialDivisionResults = new object[]
        {
            new object[]
            {
                new double[] { 6, 13, -9, -1, 6}, // polynomial A (#111)
                new double[] { 3, 2}, // polynomial B
                new double[] { 2, 3, -5, 3}, // A / B
            },

            new object[]
            {
                new double[] { 6, -11, 7, -6}, // polynomial A (#107)
                new double[] { 2, -3}, // polynomial B
                new double[] { 3, -1, 2}, // A / B
            },

        };

        static object[] PolynomialDivWithRemainderResults = new object[]
        {
            new object[]
            {
                new double[] { 16, 8, -39, 17}, // polynomial A (#109)
                new double[] { 4, -3}, // polynomial B
                new double[] { 4, 5, -6}, // A / B
                new double[] { -1} // remainder
            },

            new object[]
            {
                new double[] { 20, 12, 9, 10, 5}, // polynomial A (#113)
                new double[] { 2, 1}, // polynomial B
                new double[] { 10, 1, 4, 3}, // A / B
                new double[] { 2} // remainder
            },

        };











    }
}