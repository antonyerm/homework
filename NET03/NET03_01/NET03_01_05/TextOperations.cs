// Task 5
// Complete the solution so that it reverses all of the words within the string passed in. Example: 
//      ReverseWords("The greatest victory is that which requires no battle") => "battle no requires which that is victory greatest The"
namespace NET03_01_05
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains methods for operations with text.
    /// </summary>
    internal class TextOperations
    {
        /// <summary>
        /// Reverses the order of words in the given string.
        /// </summary>
        /// <param name="original">Input string with original words' order.</param>
        /// <returns>Reversed string.</returns>
        internal string ReverseWords(string original)
        {
            var wordsArray = original.Split(' ');
            Array.Reverse(wordsArray);

            var sb = new StringBuilder();
            foreach (var word in wordsArray)
            {
                sb.Append(word);
                sb.Append(' ');
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }
    }
}