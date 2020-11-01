namespace NET_02_Task01_02
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Square shape class.
    /// </summary>
    class Square : Rectangle
    {
        public double Side { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        /// <param name="sideLength">Length of the side of the square.</param>
        /// <param name="color">Color of the square.</param>
        public Square(double sideLength = 5, Color color = Color.white)
            : base(sideLength, sideLength, color)
        {
            this.Side = sideLength;
        }

        public override double Area()
        {
            return Math.Pow(Side, 2);
        }

        public override double Perimeter()
        {
            return Side * 4;
        }
    }
}
