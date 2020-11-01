// Task 5
// Complete the solution so that it reverses all of the words within the string passed in. Example: 
//      ReverseWords("The greatest victory is that which requires no battle") => "battle no requires which that is victory greatest The"
namespace NET03_01_05
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03. Task 01-05. Remove order of words in string.\n");
            var input = new string[]
            {
                "The greatest victory is that which requires no battle",
                "It is not dying",
                "Turn off your mind relax, and float down stream",
                "Lay down all thoughts, surrender to the void",
                "It is shining",
            };

            var processing = new TextOperations();

            foreach (var original in input)
            {
                var result = processing.ReverseWords(original);
                Console.WriteLine($"{original}\n=>\n{result}\n");
            }
        }
    }
}
