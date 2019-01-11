using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7
{
    class Program
    {
        public static void Main(string[] args)
        {
            string spaz = Encrypt("x");
            Console.WriteLine(spaz);
            Console.ReadLine();
        }
        static string Encrypt(string s)
        {
            StringBuilder sb = new StringBuilder();
            var list = new List<char>();
            var dict = new Dictionary<string, string>();
            char[] alpha = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            //dict.Add(alpha);
            for (int i = 0; i < s.Length - 1; i++)
            {
                for (int j = 0;j < list.Count; j++)
                {
                    if(s[i] == list[24])
                        sb.Append(list[0]);
                     else if (list[j] == 'y')
                        sb.Append(list[1]);
                     else if (s[i] == 'z')
                        sb.Append(list[2]);
                    else if (s[i] == list[j])
                        sb.Append(list[j + 3]);

                }
            }
            return sb.ToString();
        }
    }
}
