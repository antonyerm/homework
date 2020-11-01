using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NET_02_Task01_01
{
    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowSum"/>
    /// </summary>
    class ComparerRowSum : IComparer<int []>
    {
        public int Compare(int [] x, int [] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return firstValue.CompareTo(secondValue);
        }

    }

    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowMaxSumReverse"/>
    /// </summary>
    class ComparerRowSumReverse : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return secondValue.CompareTo(firstValue);
        }

    }

    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowMax"/>
    /// </summary>
    class ComparerRowMax : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return firstValue.CompareTo(secondValue);
        }

    }

    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowMaxReverse"/>
    /// </summary>
    class ComparerRowMaxReverse : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return secondValue.CompareTo(firstValue);
        }

    }

    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowMin"/>
    /// </summary>
    class ComparerRowMin : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return firstValue.CompareTo(secondValue);
        }

    }

    /// <summary>
    /// Comparer for criterion <see cref="SortCriteria.RowMinReverse"/>
    /// </summary>
    class ComparerRowMinReverse : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            var firstValue = ValueCalculator.CalculateValue(this, x);
            var secondValue = ValueCalculator.CalculateValue(this, y);

            return secondValue.CompareTo(firstValue);
        }

    }
}
