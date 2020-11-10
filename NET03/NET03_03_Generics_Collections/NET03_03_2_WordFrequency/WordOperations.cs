using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NET03_03_2_WordFrequency
{
    /// <summary>
    /// Manages operations with words in a string.
    /// </summary>
    class WordOperations
    {
        /// <summary>
        /// Word and their frequencies as items of SortedDictionary.
        /// </summary>
        private SortedDictionary<string, int> frequencyTable;
        
        /// <summary>
        /// Calculates words and number of their appearances in a string.
        /// </summary>
        /// <param name="txt">Source string.</param>
        /// <returns>Collection of words and their frequencies.</returns>
        public SortedDictionary<string, int> GetWordFrequency(string txt)
        {
            frequencyTable = new SortedDictionary<string, int>();
            Regex rx = new Regex(@"\b\w+\b",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var words = rx.Matches(txt);
            foreach (Match word in words)
            {
                var wordCaseInsensitive = word.Value.ToUpper();
                if (!frequencyTable.ContainsKey(wordCaseInsensitive))
                {
                    var numberOfOccurrences = Regex.Matches(txt, word.Value, RegexOptions.IgnoreCase).Count;
                    frequencyTable.Add(wordCaseInsensitive, numberOfOccurrences);
                }
            }

            return frequencyTable;

        }
    }
}
