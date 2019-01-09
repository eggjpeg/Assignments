using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace A6
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = LoadString("txt.txt");
            string spaz = Compress(s);

            Console.WriteLine(spaz);
            Console.ReadLine();
        }


        static string DeCompress(string s)
        {
            StringBuilder sb = new StringBuilder();
            char c = ' ';
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetter(s[i]))
                {
                    c = s[i];
                    sb.Append(s[i]);
                }
                else if (char.IsNumber(s[i]))
                {
                    string sc = Char.ConvertFromUtf32(s[i]);
                    int loop = int.Parse(sc);

                    for (int j = 1; j <= loop - 1; j++)
                        sb.Append(c);
                }
                else
                    continue;
            }
            return sb.ToString();
        }

        static string Compress(string s)
        {
            StringBuilder sb = new StringBuilder();

            int acc = 1;

            s = s.PadRight(' ');
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                    acc++;
                else
                {
                    if (acc != 1)
                    {
                        sb.Append(s[i] + Convert.ToString(acc) + "~");
                        acc = 1;
                    }
                    else
                        sb.Append(s[i]);

                }
            }

            return sb.ToString();
        }
        //static string CompressFile(string file)
        //{
        //    using (StreamReader sr = new StreamReader(file))
        //    {
        //        var list = new List<string>();
        //        while (!sr.EndOfStream)
        //        {
        //            int acc = 1;

        //            s = s.PadRight(' ');
        //            for (int i = 0; i < s.Length - 1; i++)
        //            {
        //                if (s[i] == s[i + 1])
        //                    acc++;
        //                else
        //                {
        //                    if (acc != 1)
        //                    {
        //                        list.Add(s[i] + Convert.ToString(acc) + "~");
        //                        acc = 1;
        //                    }
        //                    else
        //                        sb.Append(s[i]);

        //                }
        //            }
        //        }
        //    }
        //}
        static string LoadString(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                StringBuilder sb = new StringBuilder();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().Trim().ToLower();
                    if (line == "")
                        continue;
                    sb.Append(line);
                }
                return sb.ToString();
            }
        }
    }
}
