namespace NET03_06_StreamsAndIo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Linq;

    class FileOperations
    {
        private const string path = @"..\..\..\..\";
        private string sourceFile;
        private string destinationFile;

        public FileOperations(string source, string destination)
        {
            this.sourceFile = Path.Combine(path, source);
            this.destinationFile = Path.Combine(path, destination);
        }
        public void CreateFile()
        {
            var str = new string[] { @"That's a really fantasctic deal!", "Just a sample text here", "Why not write this line", "Hi guys! This is the last thing I'm gonna tell you." };
            File.WriteAllLines(this.sourceFile, str);
        }

        /// <summary>
        /// Copies source to destination byte by byte using FileStream.
        /// </summary>
        /// <returns>Number of written bytes.</returns>
        public int CopyFileStream()
        {
            if (File.Exists(this.sourceFile))
            {
                int counter = 0;
                using (var sourceFileStream = new FileStream(sourceFile, FileMode.Open))
                using (var destinationFileStream = new FileStream(destinationFile, FileMode.Create))
                {
                    int readByte;
                    do
                    {
                        readByte = sourceFileStream.ReadByte();
                        if (readByte > 0)
                        {
                            destinationFileStream.WriteByte((byte)readByte);
                            counter++;
                        }
                    }
                    while (readByte > 0);
                }

                return counter;
            }
            else
            {
                throw new Exception($"File {sourceFile} does not exist.");
            }
        }

        /// <summary>
        /// Copies source to destination byte by byte using FileStream and explicit buffering.
        /// </summary>
        /// <returns>Number of written bytes.</returns>
        public int CopyFileStreamWithBuffering()
        {
            if (File.Exists(this.sourceFile))
            {
                int counter = 0;
                using (var sourceFileStream = new FileStream(sourceFile, FileMode.Open))
                using (var destinationFileStream = new FileStream(destinationFile, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.None))
                {
                    int readByte;
                    do
                    {
                        readByte = sourceFileStream.ReadByte();
                        if (readByte > 0)
                        {
                            destinationFileStream.WriteByte((byte)readByte);
                            counter++;
                        }
                    }
                    while (readByte > 0);
                    // not necessary as using will Close the file. i.e. Flush and Dispose
                    destinationFileStream.Flush();
                }

                return counter;
            }
            else
            {
                throw new Exception($"File {sourceFile} does not exist.");
            }
        }

        /// <summary>
        /// Copies source to destination in the following stages:  byte array from StremReader to MemoryStream, then from Memory stream byte by byte to FileStream of destination.
        /// </summary>
        /// <returns>Number of written bytes.</returns>
        public int CopyStreamReaderToMemoryStreamToFile()
        {
            if (File.Exists(this.sourceFile))
            {
                int counter = 0;
                using (var sourceFileStream = new FileStream(sourceFile, FileMode.Open))
                using (var sourceStreamReader = new StreamReader(sourceFileStream))
                using (var destinationFileStream = new FileStream(destinationFile, FileMode.Create))
                {
                    var readBytes = sourceStreamReader.ReadToEnd().Select(x => (byte)x).ToArray();
                    var sourceMemoryStream = new MemoryStream(readBytes);
                    int readByte;
                    do
                    {
                        readByte = sourceMemoryStream.ReadByte();
                        if (readByte > 0)
                        {
                            destinationFileStream.WriteByte((byte)readByte);
                            counter++;
                        }
                    }
                    while (readByte > 0);
                }

                return counter;
            }
            else
            {
                throw new Exception($"File {sourceFile} does not exist.");
            }
        }

        /// <summary>
        /// Copies source to destination using BufferedStream and bytes array.
        /// </summary>
        /// <returns>Number of written bytes.</returns>
        public int CopyToBufferedStream()
        {
            if (File.Exists(this.sourceFile))
            {
                byte[] readBytes;
                using (var sourceFileStream = new FileStream(sourceFile, FileMode.Open))
                using (var sourceBufferedStream = new BufferedStream(sourceFileStream))
                {
                    readBytes = new byte[sourceBufferedStream.Length];
                    sourceBufferedStream.Read(readBytes, 0, (int)sourceBufferedStream.Length);
                    File.WriteAllBytes(destinationFile, readBytes);
                }

                return readBytes.Length;
            }
            else
            {
                throw new Exception($"File {sourceFile} does not exist.");
            }

        }

        /// <summary>
        /// Copies source to destination line by line using StreamReader and StreamWriter methods.
        /// </summary>
        /// <returns>Number of written lines.</returns>
        public int CopyLines()
        {
            if (File.Exists(this.sourceFile))
            {
                int counter = 0;
                using (var textReader = File.OpenText(this.sourceFile))
                using (var textWriter = File.CreateText(this.destinationFile))
                {
                    while (textReader.Peek() > -1)
                    {
                        var str = textReader.ReadLine();
                        textWriter.WriteLine(str);
                        counter++;
                    }
                }

                return counter;
            }
            else
            {
                throw new Exception($"File {sourceFile} does not exist.");
            }
        }

        /// <summary>
        /// Compares files Source and Destination.
        /// </summary>
        /// <returns>True if the files are identincal, False if the files are different.</returns>
        public bool CompareFiles()
        {
            if (File.Exists(this.sourceFile) && File.Exists(this.destinationFile))
            {
                using (var firstBinary = File.OpenRead(this.sourceFile))
                using (var secondBinary = File.OpenRead(this.destinationFile))
                {
                    if (firstBinary.Length != secondBinary.Length)
                    {
                        return false;
                    }

                    while (firstBinary.Position < firstBinary.Length - 1)
                    {
                        if (firstBinary.ReadByte() != secondBinary.ReadByte())
                        {
                            return false;
                        }
                    }

                }

                return true;
            }

            else
            {
                throw new Exception($"File {sourceFile} or {destinationFile} do not exist.");
            }
        }

        /// <summary>
        /// Remove 5 last bytes of destination file. Used for tests.
        /// </summary>
        public void CropFile()
        {
            using (var destination = File.OpenWrite(destinationFile))
            {
                destination.SetLength(destination.Length - 5);
            }

            //using (var source = new StreamWriter(sourceFile, true))
            //{
            //    source.BaseStream.Position = 0;
            //    source.Write("Boo-Boo-Boo");
            //}


        }
    }
}
