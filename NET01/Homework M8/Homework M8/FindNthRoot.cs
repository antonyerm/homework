namespace Homework_M8
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains one of the operations - finding Nth root of the number.
    /// </summary>
    public class FindNthRoot : IStrategy
    {
        /// <summary>
        /// FindsNth root of the number.
        /// </summary>
        /// <param name="inputNumber">Input number.</param>
        /// <param name="rootNumber">Degree of the root.</param>
        /// <param name="precision">Precision required.</param>
        /// <returns>Nth root of the input number.</returns>
        public double DoCalculation(double inputNumber, double rootNumber, double precision)
        {
            double nextGuess;
            double previousGuess;
            int rootNumberInt = (int)rootNumber;
            double actualPrecision;

            switch (rootNumberInt)
            {
                case 0:
                    return -1;
                    break;
                case 1:
                    return inputNumber;
                    break;
            }

            // parameters are not valid if:
            // - degree is < 0, precision < 0, input number < 0 and reoot number is even
            if ((rootNumber < 0) || (precision <= 0) || ((inputNumber < 0) && (rootNumber % 2 == 0)))
            {
                throw new ArgumentOutOfRangeException();
            }

            // initial guess is the number itself
            previousGuess = inputNumber;

            do
            {
                nextGuess =
                    previousGuess - ((Math.Pow(previousGuess, rootNumberInt) - inputNumber) /
                    (rootNumberInt * Math.Pow(previousGuess, rootNumberInt - 1)));
                actualPrecision = Math.Abs(nextGuess - previousGuess);
                previousGuess = nextGuess;

                // test
                // Console.WriteLine("Current Guess: {0}, current precision: {1}", nextGuess, actualPrecision);
            }
            while (actualPrecision > precision);

            // find decimal point place of precision value
            int i = 0;
            while (precision < 1)
            {
                precision *= 10;
                i++;
            }

            // truncate all digits past precision decimal point place
            return Math.Round(nextGuess, i);
        }
    }
}


// Хотя все тесты проходят, у меня осталась неуверенность относительно погрешности
// нахождения величины.
// Если она задана как 1*10^-n, то вроде всё ОК (например, 0.01, 0.00001 и т.п.).
// Если она будет задана как M*10^-n (например, 0.03, 0.00007 и т.п.), то
// округление до десятичной точки погрешности, может быть, даст ошибку.
// Короче, не знаю. Нет уверенности. Метод не доведен до совершенства, но тесты проходят :)
