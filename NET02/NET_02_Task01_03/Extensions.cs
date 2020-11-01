namespace NET_02_Task01_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Extensions
    {
        public static Polynomial Clone(this Polynomial source)
        {
            var copy = new double[source.GetDegree() + 1];
            for (var index = 0; index < copy.Length; index++)
            {
                copy[index] = source[index];
            }

            Array.Reverse(copy);
            return new Polynomial(copy);
        }
    }
}
