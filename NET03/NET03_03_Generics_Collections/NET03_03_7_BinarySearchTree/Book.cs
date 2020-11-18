using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NET03_03_7_BinarySearchTree
{
    public class Book : IComparable<Book>
    {
        public int Pages { get; set; }

        public string Name { get; set; }

        public int CompareTo([AllowNull] Book other)
        {
            if (other is null)
            {
                // value is always greater than null
                return 1;
            }

            if (this.Pages == other.Pages)
            {
                return 0;
            }
            else
                if (this.Pages > other.Pages)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return $"{Name} - {Pages}p.";
        }
    }
}
