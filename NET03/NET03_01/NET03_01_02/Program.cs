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

    /// <summary>
    /// Entry class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03. Task 01-02. Capitalise a string according to rules.");
            var input = new string[,]
            {
                {"a clash of KINGS","a an the of" },
                {"THE WIND IN THE WILLOWS","The In" },
                {"the quick brown fox", "" },
                {"...hello...,,,", "Rose    .dAisy,,.  HAHA" },
                {"lucy iN     The .SKY.... ,,,wiTH      diamondS", "in the with" }
            };

            var textFunction = new TextOperations();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                var resultString = textFunction.TitleCase(input[i, 0], input[i, 1]);
                Console.WriteLine(resultString);
            }
        }
    }
}