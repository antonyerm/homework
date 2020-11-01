namespace Homework_M7_3
{
    using System;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    class Homework_M7_3
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            var searchObj = new Search(20);

            Console.WriteLine("Homework Module 7. Basic coding. Task 3. Search for middle value position.\n");

            int searchResult = searchObj.SearchForMiddlePosition();
            Console.WriteLine("The array is: \n");

            if (searchResult == -1)
                {
                    // print array without highlighting
                    searchObj.ShowArray();
                    Console.WriteLine("\n\nThe middle value is not found. Please run the program several times to get the value.");
                }
            else
                {
                    // print array with highlighting the result
                    searchObj.ShowArray(searchResult);
                    Console.WriteLine("\n\nThe position of middle value is: " + searchResult + "(zero based).");
                }
        }
    }
}
