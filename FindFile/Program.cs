using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindFile
{
    class Program
    {
        static void Main(string[] args)
        {            
            string nameFile = "Writer.txt";
            FindNameFile(nameFile);

           
        }

        private static void FindNameFile(string fileName)
        {
            FileStream source = null;
            FileStream destin = File.Create(@"D:\FindFolder.zip");           
            string name = null;
            FileInfo file;
            foreach (var value in Directory.EnumerateFiles(@"D:\ITEA", fileName, SearchOption.AllDirectories))
            {
                try
                {
                    file = new FileInfo(value);
                    name = new FileInfo(value).FullName;
                    Console.WriteLine(file.FullName + " " + file.Attributes + file.CreationTime);

                }
                catch
                {
                    continue;
                }
            }

            source = File.OpenRead(name);
            GZipStream compres = new GZipStream(destin, CompressionMode.Compress);
            int theByte = source.ReadByte();
            while (theByte != -1)
            {
                compres.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            }
            compres.Close();

        }
    }
}
