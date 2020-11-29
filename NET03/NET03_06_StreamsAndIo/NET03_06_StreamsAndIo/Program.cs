//Task 1
//Разработать класс, предоставляющий следующие функциональные возможности : 
//   (1)+функцию побайтового копирования содержимого одного тествового файла в другой с использованием класса FileStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт;
//(3)+функцию побайтового копирования содержимого одного тествового файла в другой с использованием класса MemoryStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт; содержимое потока MemoryStream наполняется массивом байт, полученных на основе текстовой информации из файла-источника с помощью класса StreamReader;
//(2)+функцию копирования содержимого одного тествового файла в другой, используя возможности буферизации класса FileStream, функция должна возвращать количество записанных байт;
//(4)+функцию копирования содержимого одного тествового файла в другой, используя возможности класса-декоратора потоков BufferedStream, функция должна возвращать количество записанных байт;
//(3 повтор?)-функцию копирования содержимого одного тествового файла в другой с использованием класса MemoryStream в качестве потока с резервным хранилищем; функция должна возвращать количество записанных байт;
//(5)+функцию построчного копирования содержимого одного тествового файла в другой, функция должна возвращать количество записанных строк;
//(6)+функцию сравнения содержимого исходного и полученного файлов.
//Task 2
//2. Протестировать работу класса для данного текстового файла в консоли, обратить внимание на содержимое файлов, полученных при копировании с помощью различных методов класса. Результаты проанализировать.
//Task 3
//3. Для выполнения задания использовать следующий проект.

namespace NET03_06_StreamsAndIo
{
    using System;
    class Program
    {
        public const string filename = "test.dat";
        static void Main(string[] args)
        {
            Console.WriteLine("Homework NET03, Module 06. Streams and I/O.");
            var fileOperations = new FileOperations("source.dat", "destination.dat");
            

            fileOperations.CreateFile();

            // (1)
            Console.WriteLine("\nCopying Source.dat to Destination.dat byte by byte using Filestream class. \n{0} bytes copied.", fileOperations.CopyFileStream());
            // (2)
            Console.WriteLine("\nCopying Source.dat to Destination.dat byte by byte using Filestream class with explicit buffering. \n{0} bytes copied.", fileOperations.CopyFileStreamWithBuffering());
            // (3)
            Console.WriteLine("\nCopying Source.dat to MemoryStream with array using StreamReader, then to Destination.dat byte by byte using Filestream class. \n{0} bytes copied.", fileOperations.CopyStreamReaderToMemoryStreamToFile());
            // (4)
            Console.WriteLine("\nCopying Source.dat to BufferedStream by byte array using FileStream, then to Destination.dat by byte array using File class. \n{0} bytes copied.", fileOperations.CopyToBufferedStream());
            // (5)
            Console.WriteLine("\nCopying Source.dat to BufferedStream line by line. \n{0} lines copied.", fileOperations.CopyLines());

            // (6)
            Console.WriteLine("\nComparing Source.dat to Destination.dat. \nThese files are {0}.", 
                fileOperations.CompareFiles()? "identical" : "different");

            fileOperations.CropFile();
            
            // (6)
            Console.WriteLine("\nComparing Source.dat to Destination.dat (which was cropped). \nThese files are {0}.",
                fileOperations.CompareFiles() ? "identical" : "different");

            // (5)
            Console.WriteLine("\nCopying Source.dat to BufferedStream line by line. \n{0} lines copied.", fileOperations.CopyLines());
        }
    }
}
