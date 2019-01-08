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
          string spaz =  Compress("AAAAAAAABBBCD");
            Console.WriteLine(spaz);
            Console.ReadLine();
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
    }
}
