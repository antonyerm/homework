namespace NET_02_Task01_02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Rectangle shape class.
    /// </summary>
    class Rectangle : Shapes
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        /// <param name="color">Color of the rectangle.</param>
        public Rectangle(double width = 5, double height = 5, Color color = Color.white)
            : base(width, height, color)
        {
            // Nothing new to initialize
        }

        public override double Area()
        {
            return this.Width * this.Height;
        }

        public override double Perimeter()
        {
            return 2 * (this.Width + this.Height);
        }

    }
}
