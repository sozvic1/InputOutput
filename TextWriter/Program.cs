using System;
using System.IO;

namespace TextWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteText();
            ReadText();           
        }

        private static void ReadText()
        {
            StreamReader reader = File.OpenText(@"D:\ITEA\Writer.txt");
            Console.WriteLine(reader.ReadToEnd());
            string input;
            while ((input = reader.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
            reader.Close();
            Console.ReadKey();
        }

        private static void WriteText()
        {
            FileInfo file = new FileInfo(@"D:\ITEA\Writer.txt");
            FileStream fileStream = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter stream = new StreamWriter(fileStream);
            stream.WriteLine("Hello ITEA");
            stream.Close();
        }
    }
}
