namespace NET03_04_IntroductionToLinq
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using NET03_03_7_BinarySearchTree;

    /// <summary>
    /// Class for persistance abstraction of stored values
    /// </summary>
    class Repository
    {
        /// <summary>
        /// Saves objects to a file.
        /// </summary>
        /// <param name="filename">Name of the file to store data.</param>
        /// <param name="students">List of data to store.</param>
        internal void SaveStudents(string filename, List<StudentTestMark> students)
        {
            using (var file = new FileStream(filename, FileMode.Create))
            using (var writer = new BinaryWriter(file))
            {
                foreach (var student in students)
                {
                    writer.Write(student.Name);
                    writer.Write(student.TestName);
                    writer.Write(student.TestDate.ToBinary());
                    writer.Write(student.Assessment);
                }

            }
        }

        /// <summary>
        /// Loads data from file to BinarySearchTree object.
        /// </summary>
        /// <param name="filename">Name of file from which to load data.</param>
        /// <param name="studentsAsBinaryTree">BinarySearchTree object in which to store data.</param>
        internal void LoadStudents(string filename, BinarySearchTree<StudentTestMark> studentsAsBinaryTree)
        {
            if (File.Exists(filename))
            {
                // load all bytes into MemoryStrem
                var memoryFile = new MemoryStream(File.ReadAllBytes(filename));
                // then read them through Binary Reader
                using (var reader = new BinaryReader(memoryFile))
                {
                    while (reader.BaseStream.Position < reader.BaseStream.Length - 1)
                    {
                        var studentAndHisMark = new StudentTestMark
                        {
                            Name = reader.ReadString(),
                            TestName = reader.ReadString(),
                            TestDate = DateTime.FromBinary(reader.ReadInt64()),
                            Assessment = reader.ReadInt32()
                        };

                        studentsAsBinaryTree.Add(studentAndHisMark);
                    }
                    
                }
            }
        }
    }
}
