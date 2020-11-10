// Task 2
// The test file contains some information. Implement an algorithm that allows to determine the frequency of occurrences of words in the text. 
// Develop unit-tests.

namespace NET03_03_2_WordFrequency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Entry class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Task 03. Problem 2. Word frequency analysis of a file.\n");

            var fileOperation = new FileOperations("Joyce - Dubliners.txt");
            var originalText = fileOperation.Text;
            var wordOperation = new WordOperations();
            var frequency = wordOperation.GetWordFrequency(originalText);

            // Print frequency table sorted by alphabet
            //foreach (var word in frequency)
            //{
            //    Console.WriteLine($"The word \"{word.Key}\" is found {word.Value} times.");
            //}

            // Print frequency table sorted by Frequency
            var frequencySortByFrequency = from wordRecord in frequency
                                           orderby wordRecord.Value descending
                                           select wordRecord;
            foreach (var word in frequencySortByFrequency)
            {
                Console.WriteLine($"The word \"{word.Key}\" is found {word.Value} times.");
            }

        }
    }
}
