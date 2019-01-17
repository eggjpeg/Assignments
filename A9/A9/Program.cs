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
            Evaluate(list);
            Console.ReadLine();
        }
        static List<object> Tokenize(string exp)
        {
            StringBuilder sb = new StringBuilder();
            var list = new List<object>();
            for (int i = 0; i < exp.Length; i++)
            {
                bool isInt = double.TryParse(exp[i].ToString(), out double spaz);
                if (isInt)
                    sb.Append(exp[i]);
                else
                {
                    if(sb.Length>0)
                        list.Add(int.Parse(sb.ToString()));
                    list.Add(exp[i]);
                    sb.Clear();
                }
            }
            if (sb.Length > 0)
                list.Add(int.Parse(sb.ToString()));
            return list;
        }
        static List<object> Evaluate(List<object> list)
        {
            int n1 = 0;
            int n2 = 0;
            char op = ' ';
            var lstNew = new List<object>();
            if (list.Count == 1)
                return list;
            n1 = (int)list[0];
                    op = (char)list[1];
                    n2 = (int)list[2];
                    if (op == '+')
                        lstNew.Add(n1+n2);
                    else
                        lstNew.Add(n1 - n2);
            List<object> lstRemainder = list.GetRange(3, list.Count - 3);
            lstNew.AddRange(lstRemainder);
            
             return Evaluate(lstNew);
        }
    }
}
