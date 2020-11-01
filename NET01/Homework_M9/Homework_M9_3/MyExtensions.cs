using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Homework_M9_3
{
    public static class MyExtensions
    {
        /// <summary>
        /// Extension method to check if caller object of Nullable type is null or not.
        /// </summary>
        /// <typeparam name="T">Used to limit caller objects to value types.</typeparam>
        /// <param name="o">Caller object which must be of Nullable type.</param>
        /// <returns>True if caller object is null, False if caller has value.</returns>
        //public static bool IsNull<T>(this Nullable<T> o) where T : struct
        //{
        //    if (o.HasValue == false)
        //    {
        //        return true;
        //    }

        //    return false;

        //    // variant of above: return o == null ? true : false;
        //}

        /// <summary>
        /// Extension method to check if caller object is null or not.
        /// </summary>
        /// <typeparam name="T">Used to limit caller objects to value types.</typeparam>
        /// <param name="o">Caller object which may be of any type.</param>
        /// <returns>True if caller object is null, False if caller has value.</returns>
        public static bool IsNull(this Object o)
        {
            return o == null ? true : false;
        }
    }
}
