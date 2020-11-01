// Task 2
// Develop a geometric shapes class hierarchy -Circle, Triangle, Square, Rectangle.Classes should describe the properties of a shape and 
// have methods for calculating the area and perimeter of the shape. (*A task with an emphasis on building an inheritance hierarchy, 
// without unduly detailed implementation*).


namespace NET_02_Task01_02
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
            Console.WriteLine("Homework NET-02 Task01 - 02. Geometric shapes classes.\n");

            var rectangle = new Rectangle();
            var square = new Square();
            var triangle = new Triangle();
            var circle = new Circle();

            Console.WriteLine(rectangle);
            Console.WriteLine(square);
            Console.WriteLine(triangle);
            Console.WriteLine(circle);

        }
    }
}
