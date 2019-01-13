using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = Tokenize("22+11-3-9-10");
            Console.ReadLine();
        }
        static List<object> Tokenize(string exp)
        {
           // double spaz = 0;
            var list = new List<object>();
            for (int i = 0; i < exp.Length; i++)
            {

                bool isInt = double.TryParse(exp[i].ToString(), out double spaz);
                bool isInt2 = double.TryParse(exp[i].ToString(), out double spaz2);

                //  string[] n = exp.Split('+', '-');
                if (isInt == true)
                {
                    double n = (double)char.GetNumericValue(num);
                    list.Add(n);
                }
                if (isInt == false)
                    list.Add(exp[i]);
            }
               
            return list;
        }
    }
}
