using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace NET03_01_04
{
    internal static class Output
    {
        //public static string AsString<T>(this IEnumerable<T> collection)
        //{
        //    var buffer = new StringBuilder();
        //    foreach (var item in collection)
        //    {
        //        buffer.Append(item.ToString());
        //        buffer.Append(", ");
        //    }

        //    return buffer.ToString();
        //}

        /// <summary>
        /// Creates a string representing content of any collection.
        /// </summary>
        /// <param name="collection">Collection whose content needs to be printed.</param>
        /// <returns>String representing content of colleciton.</returns>
        public static string AsString(this IEnumerable collection)
        {
            var buffer = new StringBuilder();
            foreach (var item in collection)
            {
                buffer.Append(item.ToString());
                buffer.Append(", ");
            }

            return buffer.ToString();
        }
    }
}
