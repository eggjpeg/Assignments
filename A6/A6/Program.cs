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

        }
        static string Compress(string s)
        {
            string compressedS = "";
            int n = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == s[i+1])
                {
                    n = i;
                    compressedS = s[i] + n;
                }
            }
        }
    }
}
