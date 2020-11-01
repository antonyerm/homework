using System;
using System.Collections.Generic;
using System.Text;

namespace NET_02_Task01_02
{
    /// <summary>
    /// Circle shape class.
    /// </summary>
    class Circle : Shapes
    {
        public double Radius { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="radius">Radius of the circle.</param>
        /// <param name="color">Color of the circle.</param>
        public Circle(double radius = 5, Color color = Color.white)
            : base(radius, radius, color)
        {
            this.Radius = radius;

            // height and width are calculated
            this.Height = Radius * 2;
            this.Width = this.Height;
        }

        public override double Area()
        {
            return 2 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Name: {this.GetType().Name}, Width: {this.Width:f2}, Height: {this.Height:f2}, " +
                $"Radius: {this.Radius:f2}, Area: {this.Area():f2}, Perimeter: {this.Perimeter():f2}, Color: {this.Color}";
        }

    }
}
