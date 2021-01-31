using System;
using System.IO;

namespace InputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\ITEA");
            if (!directory.Exists)
            {
                directory.Create();               
            }
            for (int i = 0; i < 50; i++)
            {
                directory.CreateSubdirectory($"Folder_{i}");
            }

            //directory.GetDirectories().ToList().ForEach(x=>Console.WriteLine($"Name {x.Name} Attribute {x.Attributes} Time - {x.CreationTime} "));
            var info = directory.GetDirectories();
            foreach (var item in info)
            {
                Console.WriteLine($"Full Name {item.Name} ");
                Console.WriteLine($"Parent {item.CreationTime} ");
                Console.WriteLine($"Attributes {item.Attributes} ");
                Console.WriteLine();
                item.Delete();
            }
            Console.ReadKey();
        }
    }
}
