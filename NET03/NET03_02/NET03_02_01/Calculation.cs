namespace NET03_02_01
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// All calculations of the program.
    /// </summary>
    public class Calculation
    {
        private delegate int GcdDelegate(int u, int v);
        private GcdDelegate currentAlgorithm;

        /// <summary>
        /// Calculates greatest common devisor of the number in the list.
        /// </summary>
        /// <param name="numbers">List of numbers to process.</param>
        /// <returns>GCD of the input numbers.</returns>
        public int Gcd(List<int> numbers)
        {
            int result = -1;
            var currentNumbers = new List<int>();

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                currentNumbers.Add(currentAlgorithm(numbers[i], numbers[i + 1]));
            }

            result = currentNumbers[0];

            if (currentNumbers.Count > 1)
            {
                result = Gcd(currentNumbers);
            }

            return result;
        }

        /// <summary>
        /// Calculates GCD of just two numbers with classic algorithm.
        /// </summary>
        /// <param name="v">First number.</param>
        /// <param name="u">Second number.</param>
        /// <returns>GCD of the two numbers.</returns>
        private int gcdOfTwo(int v, int u)
        {
            int t;
            while (u != 0)
            {
                t = u;
                u = v % u;
                v = t;
            }
            return v;
        }

        /// <summary>
        /// Calculates GCD of just two numbers with Stein algorithm.
        /// </summary>
        /// <param name="v">First number.</param>
        /// <param name="u">Second number.</param>
        /// <returns>GCD of the two numbers.</returns>
        private int gcdByStein(int v, int u)
        {
            if (v == u)
                return v;
            if (v == 0)
                return u;
            if (u == 0)
                return v;
            if ((~v & 1) != 0) // v is even
            {
                if ((u & 1) != 0) // u is odd
                    return gcdByStein(v >> 1, u);
                else
                    return gcdByStein(v >> 1, u >> 1) << 1; // both even
            }
            if ((~u & 1) != 0) // u is even (and v is odd from above)
                return gcdByStein(v, u >> 1);
            if (v > u) // u and v are both odd
                return gcdByStein((v - u) >> 1, u);
            return gcdByStein((u - v) >> 1, v);
        }

        /// <summary>
        /// Sets the current algorithm for GCD calculations.
        /// </summary>
        /// <param name="algorithm">Type of algorithm.</param>
        internal void SetAlgorithm(TypeOfAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case TypeOfAlgorithm.classic:
                    currentAlgorithm = gcdOfTwo;
                    break;
                case TypeOfAlgorithm.Stein:
                    currentAlgorithm = gcdByStein;
                    break;
                default:
                    break;
            }
        }
    }
}