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
    using System.IO;
    using NET03_03_7_BinarySearchTree;
    using System.Linq;

    /// <summary>
    /// Entry class for the program.
    /// </summary>
    class Program
    {
        const string fileName = @"students.dat";

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Homewok NET03. Module 04. Intriduction to LINQ. Task 01. Retrieve data from file.");

            // create random values
            var rand = new Random();
            var students = new List<StudentTestMark>();
            for (int i = 0; i < 10; i++)
            {
                students.Add(new StudentTestMark
                {
                    Name = new string[] { "Ivanov", "Petrov", "Sidorov" }[rand.Next(3)],
                    TestName = new string[] { "Math", "Physics", "Chemistry" }[rand.Next(3)],
                    TestDate = new DateTime(2019, 5, rand.Next(30) + 1),
                    Assessment = rand.Next(100),
                });
            }

            // save values
            var repository = new Repository();
            repository.SaveStudents(fileName, students);

            // load values to BinarySearchTree object
            // Note that InOrder traversal order already sorts the elements from lowto high using
            // comparison method specified in the call of BinarySearchTree constructor.
            var studentsAsBinaryTree = new BinarySearchTree<StudentTestMark>(order: TraversalOrder.InOrder,
                (x, y) => { return x.Assessment.CompareTo(y.Assessment); });
            repository.LoadStudents(fileName, studentsAsBinaryTree);

            var resultCollectionOrderByAssessment = from student in studentsAsBinaryTree
                                                    orderby student.Assessment descending
                                                    select student;
            var resultCollectionOrderByName = from student in studentsAsBinaryTree
                                              orderby student.Name, student.TestName
                                              select student;
            var resultCollectionOrderByDate = from student in studentsAsBinaryTree
                                              orderby student.TestDate
                                              select student;
            var resultCollectionOrderByTestName = from student in studentsAsBinaryTree
                                              orderby student.TestName, student.Assessment descending
                                              select student;


            var differentSyntaxWithoutOrder = studentsAsBinaryTree.Select(x => x);
            var differnetSyntexOrderByDate = studentsAsBinaryTree.OrderByDescending(x => x.TestDate);

            Console.WriteLine("\nList of students sorted by Name:");
            foreach (var student in resultCollectionOrderByName)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nList of students sorted by Assessment score:");
            foreach (var student in resultCollectionOrderByAssessment)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nList of students sorted by Date:");
            foreach (var student in resultCollectionOrderByDate)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nList of students sorted by test name:");
            foreach (var student in resultCollectionOrderByTestName)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nList of students not sorted programmed in different syntax:");
            foreach (var student in differentSyntaxWithoutOrder)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine("\nList of students reverse-sorted by test Date programmed in different syntax:");
            foreach (var student in differnetSyntexOrderByDate)
            {
                Console.WriteLine(student.ToString());
            }

        }
    }
}
