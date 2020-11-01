// Task 3
// You need to write a function AddOrChangeUrlParameter(url, keyValueParameter) that can manipulate URL parameters. 
// It should be able to add a parameter to an existing URL, but also to change a parameter if it already exists. 
//   Example:
//   -AddOrChangeUrlParameter("www.example.com", "key=value") => 'www.example.com?key=value'(adds a parameter).
//  - AddOrChangeUrlParameter("www.example.com?key=value", "key2=value2") => 'www.example.com?key=value&key2=value2'(adds another parameter).
// - AddOrChangeUrlParameter("www.example.com?key=oldValue", "key=newValue") => 'www.example.com?key=newValue'(changes the parameter).
//
// FOR INFO:
// https://help.alchemer.com/help/url-variables
// Operators
// The question mark, ampersand, and equals sign are operators used in the syntax of query strings/URL variables.

// ?  - The question mark identifies the beginning of the query string and must be placed at the end of the link,
// before the contents of the query string.
// & - The ampersand is used before each subsequent variable/value pair in the query string.
// = - The equals sign separates the variable from the value assigned to that variable


namespace NET03_01_03
{
    using System;

    /// <summary>
    /// Entry class of the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry method of the program.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03. Task 01-03. URL modifications.");
            var input = new string[,]
            {
                {"www.example.com","key=value" },
                {"www.example.com?key=value","key2=value2" },
                {"www.example.com?key=oldValue", "key=newValue" },
                {"www.example.com?key=oldValue&key=SuperOldValue", "key=newValue" },
                {"www.example.com?key=oldValue&key2=1234", "key=newValue&key2=1111" },
                {"www.example.com?key=oldValue&key2=", "key=newValue" },
                {"www.example.com?key=oldValue&key2=", "key2=HiThere!&key=newValue" },
            };

            var textFunction = new UrlOperations();

            for (int i = 0; i < input.GetLength(0); i++)
            {
                var resultString = textFunction.AddOrChangeUrlParameter(input[i, 0], input[i, 1]);
                Console.WriteLine($"{input[i, 0]}  +  {input[i, 1]}  =>  {resultString}");
            }
        }
    }
}
