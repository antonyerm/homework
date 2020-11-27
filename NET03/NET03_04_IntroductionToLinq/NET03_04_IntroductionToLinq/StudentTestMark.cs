// Task 1
// Develop an console application that uses LINQ queries to retrieve and display data. 
// Data is stored in binary file and represents information about the results of students tests. 
// Information about the student contains the name of the student, the name of the test, 
// the date of the test and the assessment of the test for this student. To work with data the information
// is read into a binary search tree. Provide the ability to define user criteria for viewing data. 
// Expand the ability to work with the application in such a way that users can specify the sort order 
// and limit the number of rows retrieved.
// Develop unit tests.

namespace NET03_04_IntroductionToLinq
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class containing specification of the stored data.
    /// </summary>
    class StudentTestMark
    {
        public string Name { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int Assessment { get; set; }

        /// <summary>
        /// Default IComparable method which may be needed for BinarySearchTree creation (in case
        /// a custom Comparison method is not specified in the call of BinarySearchTree constructor)
        /// </summary>
        /// <param name="other">The other object to compare this object to.</param>
        /// <returns>0 = equal, -1 = this is less than the other, 1 = this is higher than the other.</returns>
        public int CompareTo(StudentTestMark other)
        {
            return this.Assessment.CompareTo(other.Assessment);
        }

        /// <summary>
        /// Prepares a string representation the stored object.
        /// </summary>
        /// <returns>String representation of the stored object.</returns>
        public override string ToString()
        {
            return $"{this.Name}: {this.TestName}, {this.TestDate.ToString("d")} - {this.Assessment}";
        }
    }
}
