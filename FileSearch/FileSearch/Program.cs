using System;
using System.IO;
namespace FileSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Search("/Users/n/", "farm");
            Console.WriteLine("done");
            Console.ReadLine();
        }

        static void searchFile(string path, string word)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Contains(word))
                    {
                        Console.WriteLine(path);
                        return;
                    }
                }
            }
        }
        static void Search(string path, string word)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            if (dirs == null && files == null)
                return;

            if (files != null)
                foreach (var file in files)
                    searchFile(Path.GetFullPath(file), word);

            if (dirs != null)
                foreach (var dir in dirs)
                    Search(Path.GetFullPath(dir), word);
            
        } 
    }
}
