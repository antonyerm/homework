namespace Homework_M7_4
{
    using System;

    /// <summary>
    /// Entry point of the project.
    /// </summary>
    class Homework_M7_4
    {
        /// <summary>
        /// Entry point of the project.
        /// </summary>
        /// <param name="args">Not used.</param>
        static void Main(string[] args)
        {
            var textManipulationObj = new TextManipulation();

            Console.WriteLine("Homework Module 7. Basic coding. Task 4. Concatenation of 2 strings with additional filtering.\n");

            string concatenationResult = textManipulationObj.Concatenation();
            Console.WriteLine("The string A is: {0}\n", textManipulationObj.stringA_property);
            Console.WriteLine("The string B is: {0}\n", textManipulationObj.stringB_property);
            Console.WriteLine("The result string is: {0}\n", concatenationResult);
        }
    }
}
