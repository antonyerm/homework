namespace Homework_M7_4
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    /// Holds the whole logic of the project.
    /// </summary>
    public class TextManipulation
    {
        string stringA;
        string stringB;

        public string stringA_property => stringA;
        public string stringB_property => stringB;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextManipulation"/> class.
        /// </summary>
        /// <remarks>Initializes the strings to be concatenated.</remarks>
        public TextManipulation()
        {
            stringA = "ППП ррр иии ввв еее ттт. Hhh eeeeee lllllllll oooooo!!!!!";
            stringB = "Hhhhooooooowww are yoooouuuu? 1233 Как делллла?";
        }

        /// <summary>
        /// Concatenates the strings.
        /// </summary>
        /// <returns>Resulting string.</returns>
        /// <remarks>This is a wrapper for <see cref="DoConcatenation(string, string)"/></remarks>
        public string Concatenation()
        {
            return DoConcatenation(this.stringA_property, this.stringB_property);
        }

        /// <summary>
        /// Concatenates the strings.
        /// </summary>
        /// <param name="stringA">The first string to concatenate.</param>
        /// <param name="stringB">The secondstring to concatenate.</param>
        /// <returns>Resulting string.</returns>
        /// /// <remarks>This is a wrapper for <see cref="DoConcatenation(string, string)"/></remarks>
        public string Concatenation(string stringA, string stringB)
        {
            // parameters are not related to properties and fields of class
            return DoConcatenation(stringA, stringB);
        }

        /// <summary>
        /// Concatenates the strings.
        /// </summary>
        /// <remarks>Operates in 2 parts: 1) removes symbols out of accepted range
        /// 2) removes repeating symbols (that is which follow one after another). </remarks>
        /// <returns>Resulting string.</returns>
        private string DoConcatenation(string stringA, string stringB)
        {
            var result = string.Empty;
            var sanitizedStringA = SanitizeRange(stringA);
            sanitizedStringA = SanitizeRepeats(sanitizedStringA);
            var sanitizedStringB = SanitizeRange(stringB);
            sanitizedStringB = SanitizeRepeats(sanitizedStringB);

            return string.Concat(sanitizedStringA, sanitizedStringB);
        }

        /// <summary>
        /// Removes repeating symbols from the string.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>New mdoified string.</returns>
        private string SanitizeRepeats(string inputString)
        {
            string outputString = inputString;
            int symbolRepeats;
            char currentChar;

            // check all Chars of the string 
            // (note that the string length is changing with every Remove method)
            for (var currentPosition = 0; currentPosition < inputString.Length; currentPosition++)
            {
                // count repeats of symbols
                symbolRepeats = 1;
                currentChar = inputString[currentPosition];

                // check further from currentPosition for repeats and count them,
                // also check if we go outside of the string
                while ((currentPosition + symbolRepeats < inputString.Length) && 
                    (inputString[currentPosition + symbolRepeats] == currentChar))
                    symbolRepeats++;
                symbolRepeats--;

                // remove part of the string
                if (symbolRepeats > 0)
                    outputString = inputString.Remove(currentPosition, symbolRepeats);

                if ((currentChar < 'A' ) || (currentChar > 'z'))
                    outputString = outputString.Remove(currentPosition, 1);

                inputString = outputString;
            }
            return outputString;
        }

        /// <summary>
        /// Removes symbols which are out of specified range.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <returns>New modified string.</returns>
        private string SanitizeRange(string inputString)
        {
            string outputString = inputString;
            char currentChar;

            // check all Chars of the string 
            // (note that the string length is changing with every Remove method)
            for (var currentPosition = 0; currentPosition < inputString.Length; currentPosition++)
            {
                currentChar = Char.ToLower(inputString[currentPosition]);
                if ((currentChar < 'a') || (currentChar > 'z'))
                {
                    outputString = outputString.Remove(currentPosition, 1);
                    currentPosition--;
                }
                inputString = outputString;
            }
            return outputString;
        }
    }
}
