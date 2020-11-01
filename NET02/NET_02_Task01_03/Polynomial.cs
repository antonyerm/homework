namespace NET_02_Task01_03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    public class Polynomial// : IEquatable<Polynomial>
    {
        private double[] polynomial;
        private double[] resultPolynomial;

        /// <summary>
        /// Initializes an instance of <see cref="Polynomial"/>.
        /// </summary>
        /// <param name="coefficients"></param>
        public Polynomial(params double[] coefficients)
        {
            this.polynomial = (double[])coefficients.Clone();
            Array.Reverse(this.polynomial);
        }

        /// <summary>
        /// Indexer to browse coefficients of the polynomial.
        /// </summary>
        /// <param name="index">Index of the coefficient.</param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                return polynomial[index];
            }

            set
            {
                polynomial[index] = value;
            }
        }

        public int GetDegree()
        {
            return this.polynomial.Length - 1;
        }

        public Polynomial Sum(Polynomial other)
        {
            // create resulting polynomial with correct size which matches other polynomial
            ResizeResultPolynomialToBeAs(other);

            // go through other polynomial coefficients            
            for (var i = 0; i <= other.GetDegree(); i++)
            {
                this.resultPolynomial[i] += other[i];
            }

            TruncateZerosAtHighDegreeOfResult();

            Array.Reverse(resultPolynomial);
            return new Polynomial(resultPolynomial);
        }

        public Polynomial Subtract(Polynomial other)
        {
            // create resulting polynomial with correct size which matches other polynomial
            ResizeResultPolynomialToBeAs(other);

            // go through other polynomial coefficients            
            for (var i = 0; i <= other.GetDegree(); i++)
            {
                this.resultPolynomial[i] -= other[i];
            }

            TruncateZerosAtHighDegreeOfResult();

            Array.Reverse(resultPolynomial);
            return new Polynomial(resultPolynomial);
        }

        public Polynomial Multiply(Polynomial other)
        {
            // create empty resulting polynomial with correct size which matches the product of this and other polynomials
            ResizeResultPolynomialToHoldProductOf(other);

            for (var firstPoly = this.polynomial.Length - 1; firstPoly >= 0; firstPoly--)
            {
                for (var secondPoly = 0; secondPoly < other.GetDegree() + 1; secondPoly++)
                {
                    resultPolynomial[firstPoly + secondPoly] += this[firstPoly] * other[secondPoly];
                }
            }

            TruncateZerosAtHighDegreeOfResult();
            Array.Reverse(resultPolynomial);

            return new Polynomial(resultPolynomial);
        }

        public Polynomial Divide(Polynomial divisor)
        {
            Polynomial currentDividend;
            Polynomial currentQuotient;
            Polynomial multiplicativeValue;
            Polynomial resultPolynomial;
            var partialResults = new List<Polynomial>();

            currentDividend = this.Clone();
            var i = 0;
            do
            {
                currentQuotient = OnlyHighestCoeffDivision(currentDividend, divisor);
                partialResults.Add(currentQuotient);
                
                multiplicativeValue = currentQuotient.Multiply(divisor);
                currentDividend = currentDividend.Subtract(multiplicativeValue);
            }
            while (currentDividend.GetDegree() >= divisor.GetDegree());

            // Polynomial Remainder = currentDividend;

            // собрать полином из неполных частных
            var sizeOfResultPolynomial = partialResults[0].GetDegree() + 1;
            resultPolynomial = new Polynomial(new double[sizeOfResultPolynomial]);

            foreach (var part in partialResults)
            {
                resultPolynomial = resultPolynomial.Sum(part);
            }

            return resultPolynomial;
        }

        public Polynomial DivisionRemainder(Polynomial divisor)
        {
            Polynomial currentDividend;
            Polynomial currentQuotient;
            Polynomial multiplicativeValue;
            var partialResults = new List<Polynomial>();

            currentDividend = this.Clone();
            var i = 0;
            do
            {
                currentQuotient = OnlyHighestCoeffDivision(currentDividend, divisor);
                partialResults.Add(currentQuotient);

                multiplicativeValue = currentQuotient.Multiply(divisor);
                currentDividend = currentDividend.Subtract(multiplicativeValue);
            }
            while (currentDividend.GetDegree() >= divisor.GetDegree());

            // return remainder
            return currentDividend;
        }

        public Polynomial DivisionRemainder(Polynomial divisor, out Polynomial remainder)
        {
            Polynomial currentDividend;
            Polynomial currentQuotient;
            Polynomial multiplicativeValue;
            Polynomial resultPolynomial;
            var partialResults = new List<Polynomial>();

            currentDividend = this.Clone();
            var i = 0;
            do
            {
                currentQuotient = OnlyHighestCoeffDivision(currentDividend, divisor);
                partialResults.Add(currentQuotient);

                multiplicativeValue = currentQuotient.Multiply(divisor);
                currentDividend = currentDividend.Subtract(multiplicativeValue);
            }
            while (currentDividend.GetDegree() >= divisor.GetDegree());

            remainder = currentDividend;

            // собрать полином из неполных частных
            var sizeOfResultPolynomial = partialResults[0].GetDegree() + 1;
            resultPolynomial = new Polynomial(new double[sizeOfResultPolynomial]);

            foreach (var part in partialResults)
            {
                resultPolynomial = resultPolynomial.Sum(part);
            }

            return resultPolynomial;
        }


        private Polynomial OnlyHighestCoeffDivision(Polynomial a, Polynomial b)
        {
            // caclulate quotient of the highest coeffiecients 
            double quotientOfHighestCoeff = a[a.GetDegree()] / b[b.GetDegree()];
            var result = new Polynomial(new double[a.GetDegree() - b.GetDegree() + 1]);
            result[result.GetDegree()] = quotientOfHighestCoeff;
            return result;
        }



        private void ResizeResultPolynomialToBeAs(Polynomial other)
        {
            // find max degree of the two polynomials
            var sizeOfResultPolynomial = (other.GetDegree() > this.GetDegree()) ? other.GetDegree() : this.GetDegree();
            sizeOfResultPolynomial++;
            // create polynomial array with size that matches max degree
            this.resultPolynomial = new double[sizeOfResultPolynomial];
            this.polynomial.CopyTo(resultPolynomial, 0);
        }

        private void TruncateZerosAtHighDegreeOfResult()
        {
            var sizeOfResultPolynomial = this.resultPolynomial.Length;
            for (var i = sizeOfResultPolynomial - 1; i >=0 ; i--)
            {
                if (this.resultPolynomial[i] == 0)
                {
                    sizeOfResultPolynomial--;
                }
                else break;
            }
            
            if (sizeOfResultPolynomial != 0)
            {
                Array.Resize(ref this.resultPolynomial, sizeOfResultPolynomial);
            }
            else
            {
                this.resultPolynomial = new double[1] { 0f };
            }
            
        }

        private void ResizeResultPolynomialToHoldProductOf(Polynomial other)
        {
            // find sum of degrees of the two polynomials
            var sizeOfResultPolynomial = other.GetDegree() + this.GetDegree();
            // add 1 to accomodate to zero degree term of result polynomial
            sizeOfResultPolynomial += 1;
            // create empty polynomial array with size that matches max degree
            this.resultPolynomial = new double[sizeOfResultPolynomial];
        }

        private void ResizeResultPolynomialToHoldQuotientOf(Polynomial other)
        {
            // find differencr of degrees of the two polynomials
            var sizeOfResultPolynomial = this.GetDegree() - other.GetDegree();
            // add 1 to accomodate to zero degree term of this polynomial
            sizeOfResultPolynomial += 1;
            // create empty polynomial array with size that matches max degree
            if (sizeOfResultPolynomial >= 1)
            {
                this.resultPolynomial = new double[sizeOfResultPolynomial];
            }
            else

            // the result of division will be just reminder, no quotient
            {
                this.resultPolynomial = null;
            }
            
        }

        public override string ToString()
        {
            var str = new StringBuilder("Coefficients: ");
            foreach(var coefficient in this.polynomial)
            {
                str.Append($"{coefficient, 3}, ");
            }

            return str.ToString();
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            return a.Sum(b);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            return a.Subtract(b);
        }
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            return a.Multiply(b);
        }

        public static Polynomial operator /(Polynomial a, Polynomial b)
        {
            return a.Divide(b);
        }

        public static Polynomial operator %(Polynomial a, Polynomial b)
        {
            return a.DivisionRemainder(b);
        }

        public override bool Equals(object other)
        {
            if (!(other is Polynomial))
            {
                return false;
            }

            var otherPolynomialArray = (other as Polynomial).polynomial;

            // compare the arrays
            IStructuralEquatable thisPolynomialArray = this.polynomial;
            return thisPolynomialArray.Equals(otherPolynomialArray, StructuralComparisons.StructuralEqualityComparer);
        }
    }
    }
