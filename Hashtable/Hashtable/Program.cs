using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class Program
    {


        static void Main(string[] args)
        {
            
            var list = LoadList("20k.txt");
            HT ht = new HT(20000);
            //Dictionary<string, string> d = new Dictionary<string, string>();



            Stopwatch sw = new Stopwatch();

            sw.Start();
            //foreach (var item in list)
            //    d.Add(item, item);
            sw.Stop();

            Console.WriteLine(sw.Elapsed + " theirs load ");

            sw.Reset();

            sw.Start();
            foreach (var item in list)
                ht.Add(item, item);
            sw.Stop();
            
            Console.WriteLine(sw.Elapsed + " ours load ");

            sw.Reset();
            list.Sort();
            sw.Start();
            for (int i = 0; i < 100; i++)
                foreach (var item in list)
                    list.BinarySearch(item);
            sw.Stop();
            Console.WriteLine(sw.Elapsed + " bs fetch");

            sw.Reset();
            sw.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    foreach (var item in list)
            //    {
            //        string a = d[item];
            //    }
            //}
            sw.Stop();
            Console.WriteLine(sw.Elapsed + " theirs fetch");

            sw.Reset();
            sw.Start();

            for (int i = 0; i < 1000; i++)
            {
                foreach (var item in list)
                {
                    string a = ht.Get(item);
                }
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed + " ours fetch");


            
            //   ht.Print();
            Console.WriteLine("done");
            Console.ReadLine();

        }

        static public List<string> LoadList(string file)
        {
            var list = new List<string>();
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    list.Add(line);
                }
                return list;
            }
        }


    }
}
