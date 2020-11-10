using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NET03_03_2_WordFrequency
{
    /// <summary>
    /// Manages file operations.
    /// </summary>
    public class FileOperations
    {
        private String filename = String.Empty;
        private String txt = String.Empty;

        /// <summary>
        /// Creates a new instance of <see cref="FileOperations"/>. Opens the specified
        /// file and loads its content to <see cref="txt"/> field.
        /// </summary>
        /// <param name="filename">Name of the file to open.</param>
        public FileOperations(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("The file does not exist.");

            this.filename = filename;
            using (StreamReader sr = new StreamReader(filename))
            {
                this.txt = sr.ReadToEnd();
            }
        }

        public string Text
        { get { return this.txt; } }
    }
}
