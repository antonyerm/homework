namespace NET_02_Task01_02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains common parameters of 2D-shapes.
    /// </summary>
    public abstract class Shapes
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Color Color { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Shapes"/> class.
        /// </summary>
        /// <param name="width">Width of the shape.</param>
        /// <param name="height">Height of the shape.</param>
        /// <param name="color">Color of the shape.</param>
        public Shapes(double width = 5, double height = 5, Color color = Color.white)
        {
            this.Width = width;
            this.Height = height;
            this.Color = color;
        }

        /// <summary>
        /// Calculates Area of the shape.
        /// </summary>
        /// <returns>Area value.</returns>
        public abstract double Area();

        /// <summary>
        /// Calculates Perimeter of the shape.
        /// </summary>
        /// <returns>Perimeter value.</returns>
        public abstract double Perimeter();

        /// <summary>
        /// Creates string of shape's parameters for easy shape info print-out.
        /// </summary>
        /// <returns>String of parameters.</returns>
        public override string ToString()
        {
            return $"Name: {this.GetType().Name}, Width: {this.Width:f2}, Height: {this.Height:f2}, " +
                $"Area: {this.Area():f2}, Perimeter: {this. Perimeter():f2}, Color: {this.Color}";
        }



    }
}
