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
            string spaz = Encrypt("spaz");
            Console.WriteLine(spaz);
            Console.ReadLine();
        }

        static string Encrypt(string s)
        {
            StringBuilder sb = new StringBuilder();
            var list = new List<char>();
            string alpha  = "abcdefghijklmnopqrstuvwxyz";
            string enalpha = "defghijklmnopqrstuvwxyzabc";

            string alphaCaps = alpha.ToUpper();
            string enalphaCaps = enalpha.ToUpper();
            

            for (int i = 0; i < s.Length; i++)
            {

                for (int j = 0; j < alpha.Length; j++)
                {
                    if(s[i] == alpha[j])
                        sb.Append(enalpha[j]);
                    else if(s[i] == alphaCaps[j])
                        sb.Append(enalphaCaps[j]);
                }
            }
            return sb.ToString();
        }
    }
}
