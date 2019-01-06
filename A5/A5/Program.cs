using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = LoadList("txt1.txt");
            var list2 = LoadList("txt2.txt");
            var list3 = LoadList("txt3.txt");
            var insult = GenerateInsult(list1, list2, list3);
            Console.WriteLine(insult);
            Console.ReadLine();
        }
        static List<string> LoadList(string file1)
        {
            using (StreamReader sr = new StreamReader(file1))
            {
                var list = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim().ToLower();
                    if (line == "")
                        continue;
                    list.Add(line);
                }
                return list;
            }
        }
        static string GenerateInsult(List<string> list1, List<string> list2, List<string> list3)
        {
            Random r = new Random();
            int insult1 = r.Next(0, list1.Count);
            int insult2 = r.Next(0, list2.Count);
            int insult3 = r.Next(0, list3.Count);
            string MasterInsult = list1[insult1] + " " + list2[insult2] + " " + list3[insult3];
            return MasterInsult;
        }
    }
}
