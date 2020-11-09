﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NET03_03_2_WordFrequency
{
    public class FileOperations
    {
        private String filename = String.Empty;
        private int nWords = 0;
        private String pattern = @"\b\w+\b";

        public WordCount(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("The file does not exist.");

            this.filename = filename;
            string txt = String.Empty;
            using (StreamReader sr = new StreamReader(filename))
            {
                txt = sr.ReadToEnd();
            }
            nWords = Regex.Matches(txt, pattern).Count;
        }

        public string FullName
        { get { return filename; } }

        public string Name
        { get { return Path.GetFileName(filename); } }

        public int Count
        { get { return nWords; } }
    }
}
