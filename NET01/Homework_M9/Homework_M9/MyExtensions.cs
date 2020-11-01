namespace MyExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Makes bitwise representation of Double input number to string according to IEEE754.
    /// </summary>
    public static class MyExtensions
    {
        public static string IEEE754(this double number)
        {
            double precision = double.Epsilon;
            int exponent;
            double mantissa;
            char sign = '0';
            char[] exponentCharArray = new char[11];
            char[] mantissaCharArray = new char[52];

            if (number - double.Epsilon == 0)
            {
                return "0000000000000000000000000000000000000000000000000000000000000001";
            }

            if (double.IsNaN(number))
            {
                return "1111111111111000000000000000000000000000000000000000000000000000";
            }

            if (number == double.NegativeInfinity)
            {
                return "1111111111110000000000000000000000000000000000000000000000000000";
            }

            if (number == double.PositiveInfinity)
            {
                return "0111111111110000000000000000000000000000000000000000000000000000";
            }


            if (double.IsNegative(number))
            {
                sign = '1';
            }
            number = Math.Abs(number);

            // search for exponent, mantissa = 2
            exponent = (int)Math.Floor(Math.Log2(number));
            if (exponent < -1023)
            {
                exponent = -1023;
            }

            if (exponent > 1023)
            {
                exponent = 1023;
            }

            // search for mantissa
            mantissa = number / Math.Pow(2, exponent);
            if (mantissa >= 1)
            {
                mantissa -= 1;
            }

            double currentMantissa = 0d;
            for (int bit = 1; bit <= 52; bit++)
            {
                double currentBitValue = Math.Pow(2, -bit);
                currentMantissa += currentBitValue;
                if ((currentMantissa - mantissa) > precision) // currentMantissa > mantissa
                {
                    currentMantissa -= currentBitValue;
                    mantissaCharArray[bit - 1] = '0';
                }
                else
                {
                    mantissaCharArray[bit - 1] = '1';
                }
            }

            int currentExponent = (exponent + 1023);

            for (int bit = 11; bit >= 1; bit--)
            {
                if (currentExponent % 2 == 1)
                {
                    exponentCharArray[bit - 1] = '1';
                }
                else
                {
                    exponentCharArray[bit - 1] = '0';
                }
                currentExponent = (int)currentExponent / 2;
            }

            return string.Concat(sign.ToString(), new string(exponentCharArray), new string(mantissaCharArray));
        }
    }
}
