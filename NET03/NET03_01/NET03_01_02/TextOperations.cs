// Task 2
// A string is considered to be in title case if each word in the string is either(a) capitalised (that is, 
// only the first letter of the word is in upper case) or(b) considered to be an exception and 
// put entirely into lower case unless it is the first word, which is always capitalised. 
// Write a function that will convert a string into title case, given an optional list of exceptions (minor words). 
// The list of minor words will be given as a string with each word separated by a space. 
// Your function should ignore the case of the minor words string -- it should behave in the same way 
// even if the case of the minor word string is changed.
//    - Arguments:
//      -First argument(required): the original string to be converted.
//      - Second argument (optional): space - delimited list of minor words that must always be lowercase 
//      except for the first word in the string.
//    - Example:
//      -TitleCase("a an the of", "a clash of KINGS")   => "A Clash of Kings"
//     - TitleCase("The In", "THE WIND IN THE WILLOWS") => "The Wind in the Willows"
//     - TitleCase("the quick brown fox")               => "The Quick Brown Fox"

namespace NET03_01_02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains the methods to perform text modifications.
    /// </summary>
    internal class TextOperations
    {
        /// <summary>
        /// Characters which divide the input string into words.
        /// </summary>
        char[] separatorForWords = new char[] { ',', '.', '!', '?', ';', ':', ' ', '(', ')' };

        /// <summary>
        /// Characters which divide the minor string into words (according to rules - "space" character).
        /// </summary>
        char[] separatorForMinors = new char[] { ' ' };

        /// <summary>
        /// Performs modification of the input string into capitalised one.
        /// </summary>
        /// <param name="original">Original input string.</param>
        /// <param name="minorString">String of words which are exceptions to capitalization.</param>
        /// <returns></returns>
        internal string TitleCase(string original, string minorString)
        {
            List<String> words;
            List<String> minors;
            string result;

            words = this.FindSeparatedWords(original, this.separatorForWords);
            minors = this.FindSeparatedWords(minorString, this.separatorForMinors);
            minors = this.NormaliseMinors(minors);
            result = this.ApplyUppercaseRules(words, minors);

            return result;
        }

        /// <summary>
        /// Divides the string into separate words.
        /// </summary>
        /// <param name="inputString">Input string.</param>
        /// <param name="separator">Characters which divide the string into words.</param>
        /// <returns>List of strings which are words taken out of the input string. The separator characters are also included.</returns>
        private List<String> FindSeparatedWords(string inputString, char[] separator)
        {
            var separatedWords = new List<String>();
            var position = 0;
            var nextPosition = 0;
            var start = 0;
            do
            {
                position = inputString.IndexOfAny(separator, start);
                if (position < 0)
                {
                    // take the rest of the string as it does not contain separators
                    position = inputString.Length - 1;
                }

                // skip adjacent separators by 1
                while (position < inputString.Length - 1)
                {
                    nextPosition = inputString.IndexOfAny(separator, position + 1);
                    if ((nextPosition < 0) || (nextPosition > position + 1))
                    {
                        break;
                    }
                    position = nextPosition;
                }

                separatedWords.Add(inputString.Substring(start, position - start + 1));
                start = position + 1;

            } while (position < inputString.Length - 1);

            return separatedWords;
        }

        /// <summary>
        /// Divides the string of minor words into separate words and makes them low case.
        /// </summary>
        /// <param name="minors">String of minors to process.</param>
        /// <returns>List of strings which are words taken out of the input string. The separator characters are not included.</returns>
        private List<string> NormaliseMinors(List<string> minors)
        {
            var normalisedMinors = new List<string>();
            for (int i = 0; i < minors.Count; i++)
            {
                var minorWord = minors[i];
                minorWord = NormaliseOneWord(minorWord, separatorForMinors);
                normalisedMinors.Add(minorWord);
            }

            return normalisedMinors;
        }

        /// <summary>
        /// Makes one wrod lower case and clears it from separator characters if any.
        /// </summary>
        /// <param name="oneWord">One word which can contain separator charactors and each character of it can be in different case.</param>
        /// <param name="separator">Characters which are tp be removed (they are separators in method <see cref="TitleCase(string, string)"/></param>
        /// <returns>String containing one word which is lower case and clear from separators.</returns>
        private string NormaliseOneWord(string oneWord, char[] separator)
        {
            // set the word to lower case
            oneWord = oneWord.ToLower();

            // get rid of separators
            var oneWordAsSBuilder = new StringBuilder(oneWord);
            for (int counter = 0; counter < oneWordAsSBuilder.Length; counter++)
            {
                if (Array.Exists<Char>(separator, (char separatorChar) => oneWordAsSBuilder[counter] == separatorChar))
                {
                    oneWordAsSBuilder.Remove(counter, 1);
                    counter--;
                }
            }

            return oneWordAsSBuilder.ToString();
        }

        /// <summary>
        /// Performs modification of case of the first character of each word except the forst word in the input string.
        /// </summary>
        /// <param name="words">List of input words with separators (not normalized).</param>
        /// <param name="minors">List of minor words in lower case and free form separators (normalised).</param>
        /// <returns>Concatenation of all input words into resulting string.</returns>
        private string ApplyUppercaseRules(List<String> words, List<String> minors)
        {
            var resultWords = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                words[i] = words[i].ToLower();
                var word = new StringBuilder(words[i]);
                var currentWord = this.NormaliseOneWord(words[i], separatorForWords);
                if ( (i == 0) || ! (String.IsNullOrEmpty(currentWord) || 
                    minors.Exists((string minorWord) => minorWord.Equals(currentWord))))
                {
                    word[0] = Char.ToUpper(word[0]);
                }

                resultWords.Append(word);
            }

            return resultWords.ToString();
        }
    }
}