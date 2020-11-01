namespace NET_02_Task01_02
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    internal class Triangle : Shapes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="side1">Side 1 of the triangle.</param>
        /// <param name="side2">Side 2 of the triangle.</param>
        /// <param name="side3">Side 3 of the triangle.</param>
        /// <param name="color">Colorof the triangle.</param>
        public Triangle(double side1 = 5, double side2 = 5, double side3 = 5, Color color = Color.white)
            : base(side1, side1, color)
        {
            this.Side1 = side1;
            this.Side2 = side2;
            this.Side3 = side3;

            // Width and Height are calculated
            this.Height = 2 * Area() / Side1;

            // this formula is uncertain as I deduced it myself
            // base side is Side1
            this.Width = Math.Sqrt(Math.Pow(this.Side2, 2) - (4 * Math.Pow(this.Area(), 2) / Math.Pow(this.Side1, 2)));
            if (this.Width < this.Side1)
            {
                this.Width = this.Side1;
            }

        }

        public double Side1 { get; set; }

        public double Side2 { get; set; }

        public double Side3 { get; set; }

        public override double Area()
        {
            // Heron's formula
            var s = (this.Side1 + this.Side2 + this.Side3) / 2;
            return Math.Sqrt(s * (s - this.Side1) * (s - this.Side2) * (s - this.Side3));
        }

        public override double Perimeter()
        {
            return this.Side1 + this.Side2 + this.Side3;
        }

        public override string ToString()
        {
            return $"Name: {this.GetType().Name}, Width: {this.Width:f2}, Height: {this.Height:f2}, " +
                $"Side1: {this.Side1:f2}, Side2: {this.Side2:f2}, Side3: {this.Side3:f2}, " +
                $"Area: {this.Area():f2}, Perimeter: {this.Perimeter():f2}, Color: {this.Color}";
        }
    }
}
