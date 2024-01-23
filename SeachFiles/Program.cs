using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace SeachFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var files = new List<string>();
            Console.WriteLine("Please enter the file extension or empty to search all files");
            var extenstion = Console.ReadLine();

            var searchPattern = !string.IsNullOrEmpty(extenstion) ? "*." + extenstion : "*.*";

            DirSearch(currentDir, files, searchPattern);

            var enumerable = files.ToArray();
            File.WriteAllLines("SavedLists.txt", enumerable);
        }

        private static void DirSearch(string sDir, ICollection<string> filesName, string searchPattern)
        {
            try
            {
                foreach (var f in Directory.GetFiles(sDir, searchPattern))
                {
                    var fileName = Path.GetFileName(f);
                    filesName.Add(fileName);
                }

                foreach (var d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d, filesName, searchPattern);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}